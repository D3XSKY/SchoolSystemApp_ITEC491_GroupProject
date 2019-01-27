using System;
using System.Threading;

namespace ITEC_491_GroupProject.Utils
{
    /// <summary>
    /// We use class Course to handle courses.
    /// </summary>
    /// <remarks>
    /// Parameters of this class are: nextId, id, courseTitle, ectsPoints, description, createDate, lastEdited
    /// We used Set and Get methods to set/get those parameters for course object.
    /// </remarks>
    public class Course : IDisposable
    {
        static int nextId;
        private int id;
        private string courseTitle;
        private int ectsPoints;
        private string description;
        private DateTime createdDate = new DateTime();
        private DateTime lastEdited = new DateTime();
        public Course()
        {
            id = Interlocked.Increment(ref nextId);
            courseTitle = "";
            ectsPoints =0;
            description = "";
            createdDate = DateTime.Now;
        }
        public Course(int id, string cTitle, int cPoints, string cDescription)
        {
            id = Interlocked.Increment(ref nextId);
            courseTitle = cTitle;
            ectsPoints = cPoints;
            description = cDescription;
            createdDate = DateTime.Now;
        }

        public string CourseTitle
        {
            get { return courseTitle; }
            set { courseTitle = value; }
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
        public int Id
        {
            get { return id; }
        }

        public int EctsPoints
        {
            get { return ectsPoints; }
            set { ectsPoints = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }

        }
        public void Dispose()
        {

        }
    }
}