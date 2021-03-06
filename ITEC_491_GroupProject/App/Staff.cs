﻿using System;
using System.Threading;

namespace ITEC_491_GroupProject.Utils
{
     /// <summary>
    /// We use class Staff to handle data about the staff.
    /// </summary>
    /// <remarks>
    /// Parameters of this class are: nextId, id, appointmentDate, role.
    /// We used Set and Get methods to set/get those parameters for staff object.
    /// </remarks>
    public class Staff : Person
    {
        static int nextId;
        private int id;
        private DateTime appointmentDate = new DateTime();
        private string role;
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
        public new int Id
        {
            get { return id; }
        }
        public Staff()
        {
            id = Interlocked.Increment(ref nextId);
            FirstName = "";
            LastName = "";
            appointmentDate = DateTime.Now;
            Role = "";

        }
        public Staff(string fName, string lName, DateTime aDate, string rStaff)
        {
            id = Interlocked.Increment(ref nextId);
            FirstName = fName;
            LastName = lName;
            appointmentDate = aDate;
            role = rStaff;
        }
    }
}
