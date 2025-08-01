import React from 'react';

const CourseDetails = () => {
  const courses = [
    { id: 1, name: 'React Fundamentals', duration: '4 weeks', level: 'Beginner', price: '$99' },
    { id: 2, name: 'Advanced React Patterns', duration: '6 weeks', level: 'Advanced', price: '$199' },
    { id: 3, name: 'React with TypeScript', duration: '5 weeks', level: 'Intermediate', price: '$149' }
  ];

  return (
    <div style={{ padding: '20px', border: '2px solid #dc3545', margin: '10px' }}>
      <h2 style={{ color: '#dc3545' }}>🎓 Course Details</h2>
      {courses.map(course => (
        <div key={course.id} style={{ 
          backgroundColor: '#fff8f8', 
          padding: '15px', 
          margin: '10px 0',
          borderRadius: '5px'
        }}>
          <h3>{course.name}</h3>
          <p><strong>Duration:</strong> {course.duration}</p>
          <p><strong>Level:</strong> {course.level}</p>
          <p><strong>Price:</strong> {course.price}</p>
        </div>
      ))}
    </div>
  );
};

export default CourseDetails;