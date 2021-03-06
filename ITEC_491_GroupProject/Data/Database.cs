﻿using System.Collections.Generic;
using System.Linq;

namespace ITEC_491_GroupProject.Utils
{
    /// <summary>
    ///In a Database class we have a Model filled in a way that Json string from text file is loaded (deserialized to Database). 
    ///If the data.txt file does not exist it will be autogenerated when application starts, in case it exists we'll read it and deserialize it to Database model.
    /// </summary>

    public class Database
    {
        private List<Student> student;
        private List<Teacher> teacher;
        private List<Staff> staff;
        private List<Course> course;

        public Database() {

            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Staff = new List<Staff>();
            Course = new List<Course>();
        }

        public List<Student> Students
            {
                get { return student; }
                set { student = value; }
            }
            public List<Teacher> Teachers
            {
                get { return teacher; }
                set { teacher = value; }
            }
            public List<Staff> Staff
            {
                get { return staff; }
                set { staff = value; }
            }
        public List<Course> Course
        {
            get { return course; }
            set { course = value; }
        }
        public void AddStudent(Student student)
        {
        WorkContext.database.Students.Add(student); 
        }
        public void AddTeacher(Teacher teacher)
        {
            WorkContext.database.Teachers.Add(teacher);
        }
        public void AddStaff(Staff staff)
        {
            WorkContext.database.Staff.Add(staff);
        }
        public void AddCourse(Course course)
        {
            WorkContext.database.Course.Add(course);
        }
        public void PersistStudentChanges(Student s)
        {
            WorkContext.database.Students[WorkContext.database.Students.FindIndex(x => x.Id == s.Id)] = s;
        }
        public void PersistTeacherChanges(Teacher t)
        {
            WorkContext.database.Teachers[WorkContext.database.Teachers.FindIndex(x => x.Id == t.Id)] = t;
        }
        public void PersistStaffChanges(Staff st)
        {
            WorkContext.database.Staff[WorkContext.database.Staff.FindIndex(x => x.Id == st.Id)] = st;
        }
        public void PersistCourseChanges(Course c)
        {
            WorkContext.database.Course[WorkContext.database.Course.FindIndex(x => x.Id == c.Id)] = c;
        }
        public Student GetStudent(int id)
        {
            Student getStudent = new Student();
            getStudent = WorkContext.database.Students.First(x => x.Id == id);
            return getStudent;
        }
        public Teacher GetTeacher(int id)
        {
            Teacher getTeacher = new Teacher();
            getTeacher = WorkContext.database.Teachers.First(x => x.Id == id);
            return getTeacher;
        }
        public Staff GetStaff(int id)
        {
            Staff getStaff = new Staff();
            getStaff = WorkContext.database.Staff.First(x => x.Id == id);
            return getStaff;
        }
        public Course GetCourse(int id)
        {
            Course getCourse = new Course();
            getCourse = WorkContext.database.Course.First(x => x.Id == id);
            return getCourse;
        }
        public void RemoveStudent(int id)
        {
            int index = id - 1;
            WorkContext.database.Students.RemoveAt(index);
        }
        public void RemoveTeacher(int id)
        {
            int index = id - 1;
            WorkContext.database.Teachers.RemoveAt(index);
        }
        public void RemoveStaff(int id)
        {
            int index = id - 1;
            WorkContext.database.Staff.RemoveAt(index);
        }
        public void RemoveCourse(int id)
        {
            int index = id - 1;
            WorkContext.database.Course.RemoveAt(index);
        }
    }
}
