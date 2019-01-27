﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace ITEC_491_GroupProject.Utils
{
    public class Student : Person
    {
        private static int nextId;
        private int id;
        private List<Course> course = new List<Course>();
        private DateTime enrollmentDate = new DateTime();
        public List<Course> Course
        {
            get { return course; }
            set { course = value; }
        }
        public new int Id
        {
            get { return id; }
        }

        public DateTime EnrollmentDate
        {
            get { return enrollmentDate; }
            set { enrollmentDate = value; }
        }

        public Student()
        {
            id = Interlocked.Increment(ref nextId);
            FirstName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            EnrollmentDate = new DateTime();
            CreatedDate = DateTime.Now;
        }
        public Student(int id, string fName, string lName, DateTime dob)
        {
            id = Interlocked.Increment(ref nextId);
            FirstName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            CreatedDate = DateTime.Now;
        }
    }
}