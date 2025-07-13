namespace MyFirstWebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Salary { get; set; }
        public bool Permanent { get; set; }
        public Department Department { get; set; } = new Department();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public DateTime DateOfBirth { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}
}