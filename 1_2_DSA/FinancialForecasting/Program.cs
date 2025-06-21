using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialForecastingTool
{
    public class FinancialForecaster
    {
        private Dictionary<string, double> memoCache = new Dictionary<string, double>();
        private List<double> historicalData = new List<double>();

        public void SetHistoricalData(double[] data)
        {
            historicalData = data.ToList();
            memoCache.Clear();
        }

        // Simple recursive calculation for compound growth
        public double CalculateFutureValueRecursive(double presentValue, double growthRate, int periods)
        {
            if (periods == 0)
                return presentValue;
            return CalculateFutureValueRecursive(presentValue * (1 + growthRate), growthRate, periods - 1);
        }

        // Memoized version for efficiency
        public double CalculateFutureValueMemoized(double presentValue, double growthRate, int periods)
        {
            string key = $"{presentValue}_{growthRate}_{periods}";
            if (memoCache.ContainsKey(key))
                return memoCache[key];

            double result;
            if (periods == 0)
                result = presentValue;
            else
                result = CalculateFutureValueMemoized(presentValue * (1 + growthRate), growthRate, periods - 1);

            memoCache[key] = result;
            return result;
        }

        // Recursive average growth rate calculation
        public double CalculateAverageGrowthRateRecursive(double[] data, int index = 1, double sum = 0, int count = 0)
        {
            if (index >= data.Length)
                return count > 0 ? sum / count : 0;

            double growthRate = (data[index] - data[index - 1]) / data[index - 1];
            return CalculateAverageGrowthRateRecursive(data, index + 1, sum + growthRate, count + 1);
        }

        // Predict future values given historical data
        public double[] PredictFutureValues(int periodsToForecast)
        {
            if (historicalData.Count < 2)
                throw new InvalidOperationException("At least 2 historical data points are required");

            double avgGrowthRate = CalculateAverageGrowthRateRecursive(historicalData.ToArray());
            double lastValue = historicalData.Last();
            double[] predictions = new double[periodsToForecast];

            for (int i = 0; i < periodsToForecast; i++)
            {
                predictions[i] = CalculateFutureValueMemoized(lastValue, avgGrowthRate, i + 1);
            }
            return predictions;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var forecaster = new FinancialForecaster();

            // Example: Set historical data
            double[] historicalRevenue = { 50000, 55000, 58000, 62000, 68000, 72000, 78000 };
            forecaster.SetHistoricalData(historicalRevenue);

            // Calculate average growth rate
            double avgGrowth = forecaster.CalculateAverageGrowthRateRecursive(historicalRevenue);
            Console.WriteLine($"Average Growth Rate: {avgGrowth:P2}");

            // Predict next 5 years' revenue
            double[] predictions = forecaster.PredictFutureValues(5);
            Console.WriteLine("Future Revenue Predictions:");
            for (int i = 0; i < predictions.Length; i++)
            {
                Console.WriteLine($"Year {historicalRevenue.Length + i + 1}: Rs.{predictions[i]:F2}");
            }

            // Simple compound growth calculation
            double futureValue = forecaster.CalculateFutureValueRecursive(10000, 0.08, 10);
            Console.WriteLine($"\nFuture Value (Recursive, 10 years at 8%): Rs.{futureValue:F2}");
        }
    }
}
