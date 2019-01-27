﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace ITEC_491_GroupProject.Utils
{
    public class Teacher : Person
    {
        static int nextId;
        private int id;
        private DateTime appointmentDate = new DateTime();
        private List<Course> teachingCourse = new List<Course>();
        private string role;

        public List<Course> Course
        {
            get { return teachingCourse; }
            set { teachingCourse = value; }
        }
        public new int Id
        {
            get { return id; }
        }

        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }

        }
        public Teacher()
        {
            id = Interlocked.Increment(ref nextId);
            FirstName = "";
            LastName = "";
        }
        public Teacher(string fName, string lName, DateTime aDate)
        {
            id = Interlocked.Increment(ref nextId);
            FirstName = fName;
            LastName = lName;
            AppointmentDate = aDate;
        }
    }
}