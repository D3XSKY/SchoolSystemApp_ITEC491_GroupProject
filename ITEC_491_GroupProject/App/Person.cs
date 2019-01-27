﻿using ITEC_491_GroupProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITEC_491_GroupProject
{
    public class Person : IDisposable
    {
        static int nextId;
        private int id;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth = new DateTime();
        private DateTime createdDate = new DateTime();
        private DateTime lastEdited = new DateTime();


        public Person() {
            id = Interlocked.Increment(ref nextId);
            firstName = "";
            lastName = "";
            createdDate = DateTime.Now;
        }
        public Person(int id, string fName, string lName, DateTime dob)
        {
            id = Interlocked.Increment(ref nextId);
            firstName = fName;
            lastName = lName;
            dateOfBirth = dob;
            createdDate = DateTime.Now;
        }
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }

        }
        public DateTime LastEdited
        {
            get { return lastEdited; }
            set { lastEdited = value; }

        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int Id
        {
            get { return id; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime DateOfBirth {
            get { return dateOfBirth;}
            set { dateOfBirth = value; }

        }

        public void Dispose()
        {

        }
    }
}
