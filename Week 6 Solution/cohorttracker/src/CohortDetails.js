import React from 'react';
import styles from './CohortDetails.module.css';

const CohortDetails = ({ cohorts }) => {
  return (
    <div>
      <h1>Cohort Details</h1>
      {cohorts.map(cohort => (
        <div key={cohort.id} className={styles.box}>
          <h3 style={{ 
            color: cohort.status === 'ongoing' ? 'Green' : 'blue' 
          }}>
            {cohort.name}
          </h3>
          <dl>
            <dt>Current Status:</dt>
            <dd>{cohort.status}</dd>
            <dt>Start Date:</dt>
            <dd>{cohort.startDate}</dd>
            <dt>Duration:</dt>
            <dd>{cohort.duration}</dd>
            <dt>Coach:</dt>
            <dd>{cohort.coach}</dd>
            <dt>Trainer:</dt>
            <dd>{cohort.trainer}</dd>
            <dt>Participants:</dt>
            <dd>{cohort.participants}</dd>
          </dl>
        </div>
      ))}
    </div>
  );
};

export default CohortDetails;