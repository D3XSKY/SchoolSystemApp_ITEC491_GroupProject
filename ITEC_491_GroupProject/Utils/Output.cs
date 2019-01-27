using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_491_GroupProject.Utils
{
    public class Output
    {
        public static void StartApp()
        {
            Console.WriteLine("School system console application is starting.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }
        public static void MasterOptions()
        {
            Console.WriteLine("---> School System <---");
            Console.WriteLine("Available options(Enter number): ");
            Console.WriteLine("1. Display All Data(Students[{0}], Teachers[{1}], Staff[{2}], Courses[{3}])", WorkContext.database.Students.Count, WorkContext.database.Teachers.Count, WorkContext.database.Staff.Count, WorkContext.database.Course.Count);
            Console.WriteLine("2. Display Data About Specific Group");
            Console.WriteLine("3. Add Record");
            Console.WriteLine("4. Edit Record");
            Console.WriteLine("5. Remove Record");
            Console.WriteLine("Enter -1 to Exit application!!\n");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    switch (input)
                    {
                        case 1:
                            DisplayAllData();
                            break;
                        case 2:
                            DisplayDataAboutSpecificGroup();
                            break;
                        case 3:
                            AddRecord();
                            break;
                        case 4:
                            EditRecord();
                            break;
                        case 5:
                            RemoveRecord();
                            break;
                        default:
                            Console.WriteLine("Input number out of range! Please choose again!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            MasterOptions();
                            break;
                    }
                    break;
                }
                Exit();
            }
            else
            {
                Console.Clear();
                MasterOptions();
            }
        }
        private static void RemoveRecord()
        {
            Console.Clear();
            Console.WriteLine("---> Remove Record <---");
            Console.WriteLine("Available options(Enter number): ");
            Console.WriteLine("1. Remove Student");
            Console.WriteLine("2. Remove Teacher");
            Console.WriteLine("3. Remove Staff");
            Console.WriteLine("4. Remove Course");
            Console.WriteLine("\n");
            Console.WriteLine("Enter -1 to go back.");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    switch (input)
                    {
                        case 1:
                            RemoveStudent();
                            break;
                        case 2:
                            RemoveTeacher();
                            break;
                        case 3:
                            RemoveStaff();
                            break;
                        case 4:
                            RemoveCourse();
                            break;
                        default:
                            Console.WriteLine("Input number out of range! Please choose again!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            RemoveRecord();
                            break;
                    }
                    break;
                }
                Console.Clear();
                MasterOptions();
            }
            else
            {
                Console.Clear();
                RemoveRecord();
            }
        }
        private static void RemoveStudent()
        {
            StudentShortList(true);
            Console.WriteLine("Enter Id of student you want to remove: ");
            Console.WriteLine("Enter -1 to exit delete mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Students.Any(x => x.Id == input))
                    {
                        Student s = new Student();
                        s = WorkContext.database.GetStudent(input);
                        DisplayLastRemoved(s, null, null, null);
                        WorkContext.database.RemoveStudent(input);
                        Console.WriteLine("\n");
                        Console.WriteLine("Student removed successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        AutoReturn(3);
                        RemoveRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStudent with Id " + input + " does not exist therefore nothing was removed.\n");
                        break;
                    }

                }
                Console.Clear();
                RemoveRecord();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                RemoveRecord();
            }
        }
        private static void RemoveTeacher()
        {
            TeacherShortList(true);
            Console.WriteLine("Enter Id of teacher you want to remove: ");
            Console.WriteLine("Enter -1 to exit delete mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Teachers.Any(x => x.Id == input))
                    {
                        Teacher t = new Teacher();
                        t = WorkContext.database.GetTeacher(input);
                        DisplayLastRemoved(null, t, null, null);
                        WorkContext.database.RemoveTeacher(input);
                        Console.WriteLine("\n");
                        Console.WriteLine("Teacher removed successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        AutoReturn(3);
                        RemoveRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nTeacher with Id " + input + " does not exist therefore nothing was removed.\n");
                        break;
                    }

                }
                Console.Clear();
                RemoveRecord();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                RemoveRecord();
            }
        }
        private static void RemoveStaff()
        {
            StaffShortList(true);
            Console.WriteLine("Enter Id of staff you want to remove: ");
            Console.WriteLine("Enter -1 to exit delete mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Staff.Any(x => x.Id == input))
                    {
                        Staff st = new Staff();
                        st = WorkContext.database.GetStaff(input);
                        DisplayLastRemoved(null, null, st, null);
                        WorkContext.database.RemoveStaff(input);
                        Console.WriteLine("\n");
                        Console.WriteLine("Staff removed successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        AutoReturn(3);
                        RemoveRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStaff with Id " + input + " does not exist therefore nothing was removed.\n");
                        break;
                    }

                }
                Console.Clear();
                RemoveRecord();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                RemoveRecord();
            }
        }
        private static void RemoveCourse()
        {
            CourseShortList(true);
            Console.WriteLine("Enter Id of course you want to remove: ");
            Console.WriteLine("Enter -1 to exit delete mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Course.Any(x => x.Id == input))
                    {
                        Course c = new Course();
                        c = WorkContext.database.GetCourse(input);
                        DisplayLastRemoved(null, null, null, c);
                        WorkContext.database.RemoveCourse(input);
                        Console.WriteLine("\n");
                        Console.WriteLine("Course removed successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        AutoReturn(3);
                        RemoveRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nCourse with Id " + input + " does not exist therefore nothing was removed.\n");
                        break;
                    }

                }
                Console.Clear();
                RemoveRecord();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                RemoveRecord();
            }
        }
        private static void EditRecord()
        {
            Console.Clear();
            Console.WriteLine("---> Edit Record <---");
            Console.WriteLine("Available options(Enter number): ");
            Console.WriteLine("1. Edit Student");
            Console.WriteLine("2. Edit Teacher");
            Console.WriteLine("3. Edit Staff");
            Console.WriteLine("4. Edit Course");
            Console.WriteLine("\n");
            Console.WriteLine("Enter -1 to go back.");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    switch (input)
                    {
                        case 1:
                            EditStudent();
                            break;
                        case 2:
                            EditTeacher();
                            break;
                        case 3:
                            EditStaff();
                            break;
                        case 4:
                            EditCourse();
                            break;
                        default:
                            Console.WriteLine("Input number out of range! Please choose again!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            EditRecord();
                            break;
                    }
                    break;
                }
                Console.Clear();
                MasterOptions();
            }
            else
            {
                Console.Clear();
                EditRecord();
            }
        }
        private static void EditCourse()
        {
            Console.Clear();
            Console.WriteLine("---> Edit Course <---");
            Console.WriteLine("Available options(Enter number): ");
            Console.WriteLine("1. Edit All Information About Course");
            Console.WriteLine("2. Edit Course Title");
            Console.WriteLine("3. Edit Course ECTS points");
            Console.WriteLine("4. Edit Course Description");

            Console.WriteLine("\n");
            Console.WriteLine("Enter -1 to go back.");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    switch (input)
                    {
                        case 1:
                            EditCourseAll();
                            break;
                        case 2:
                            EditCourseTitle();
                            break;
                        case 3:
                            EditCourseEctsPoints();
                            break;
                        case 4:
                            EditCourseDescription();
                            break;
                        default:
                            Console.WriteLine("Input number out of range! Please choose again!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            EditCourse();
                            break;
                    }
                    break;
                }
                Console.Clear();
                EditRecord();
            }
            else
            {
                Console.Clear();
                EditCourse();
            }
        }
        private static void EditCourseAll()
        {
            CourseShortList();
            Console.WriteLine("Enter Id of course you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Course.Any(x => x.Id == input))
                    {
                        Course c = new Course();
                        c = WorkContext.database.GetCourse(input);
                        Console.WriteLine("Current course title:\t" + c.CourseTitle);
                        Console.WriteLine("New course title:\t");
                        c.CourseTitle = Console.ReadLine();
                        Console.WriteLine("Current Ects Points:\t" + c.EctsPoints);
                        Console.WriteLine("New Ects Points:\t");
                        c.EctsPoints = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Current description:\t" + c.Description);
                        Console.WriteLine("New course description:\t");
                        c.Description = Console.ReadLine();
                        c.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistCourseChanges(c);
                        Console.WriteLine("Course edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null,null,null,c);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nCourse with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditCourse();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditCourse();
            }
        }
        private static void EditCourseTitle()
        {
            CourseShortList();
            Console.WriteLine("Enter Id of course you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Course.Any(x => x.Id == input))
                    {
                        Course c = new Course();
                        c = WorkContext.database.GetCourse(input);
                        Console.WriteLine("Current course title:\t" + c.CourseTitle);
                        Console.WriteLine("New course title:\t");
                        c.CourseTitle = Console.ReadLine();
                        c.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistCourseChanges(c);
                        Console.WriteLine("Course edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, null, null, c);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nCourse with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditCourse();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditCourse();
            }
        }
        private static void EditCourseEctsPoints()
        {
            CourseShortList();
            Console.WriteLine("Enter Id of course you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Course.Any(x => x.Id == input))
                    {
                        Course c = new Course();
                        c = WorkContext.database.GetCourse(input);
                        Console.WriteLine("Current Ects Points:\t" + c.EctsPoints);
                        Console.WriteLine("New Ects Points:\t");
                        c.EctsPoints = Convert.ToInt32(Console.ReadLine());
                        c.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistCourseChanges(c);
                        Console.WriteLine("Course edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, null, null, c);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nCourse with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditCourse();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditCourse();
            }
        }
        private static void EditCourseDescription()
        {
            CourseShortList();
            Console.WriteLine("Enter Id of course you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Course.Any(x => x.Id == input))
                    {
                        Course c = new Course();
                        c = WorkContext.database.GetCourse(input);
                        Console.WriteLine("Current description:\t" + c.Description);
                        Console.WriteLine("New course description:\t");
                        c.Description = Console.ReadLine();
                        c.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistCourseChanges(c);
                        Console.WriteLine("Course edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, null, null, c);
                        AutoReturn(3);
                        EditRecord();
                    }
                    else
                    {
                        Console.WriteLine("\nCourse with Id " + input + " does not exist.\n");
                        break;
                    }
                }
                AutoReturn(3);
                Console.Clear();
                EditCourse();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditCourse();
            }
        }
        private static void EditStaff()
        {
            Console.Clear();
            Console.WriteLine("---> Edit Staff <---");
            Console.WriteLine("Available options(Enter number): ");
            Console.WriteLine("1. Edit All Information About Staff");
            Console.WriteLine("2. Edit Staff First Name");
            Console.WriteLine("3. Edit Staff Last Name");
            Console.WriteLine("4. Edit Staff Date Of Birth");
            Console.WriteLine("5. Edit Staff Appointment Date");
            Console.WriteLine("6. Edit Staff Role");
            Console.WriteLine("\n");
            Console.WriteLine("Enter -1 to go back.");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    switch (input)
                    {
                        case 1:
                            EditStaffAll();
                            break;
                        case 2:
                            EditStaffFirstName();
                            break;
                        case 3:
                            EditStaffLastName();
                            break;
                        case 4:
                            EditStaffDateOfBirth();
                            break;
                        case 5:
                            EditStaffAppointmentDate();
                            break;
                        case 6:
                            EditStaffRole();
                            break;
                        default:
                            Console.WriteLine("Input number out of range! Please choose again!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            EditStaff();
                            break;
                    }
                    break;
                }
                Console.Clear();
                EditRecord();
            }
            else
            {
                Console.Clear();
                EditStaff();
            }
        }
        private static void EditStaffAll()
        {
            StaffShortList();
            Console.WriteLine("Enter Id of staff you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Staff.Any(x => x.Id == input))
                    {
                        Staff st = new Staff();
                        st = WorkContext.database.GetStaff(input);
                        Console.WriteLine("Current first name:\t" + st.FirstName);
                        Console.WriteLine("New first name:\t");
                        st.FirstName = Console.ReadLine();
                        Console.WriteLine("Current last name:\t" + st.LastName);
                        Console.WriteLine("New last name:\t");
                        st.LastName = Console.ReadLine();
                        Console.WriteLine("Current Date of Birth:\t" + st.DateOfBirth.ToString());
                        Console.WriteLine("New Date of Birth:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        st.DateOfBirth = date;
                        Console.WriteLine("Current Appointment date:\t" + st.AppointmentDate.ToString());
                        Console.WriteLine("New Appointment date:\t");
                        dt = Console.ReadLine();
                        date = Input.GetDate(dt);
                        st.AppointmentDate = date;
                        Console.WriteLine("Current role:\t" + st.Role);
                        Console.WriteLine("New role:\t");
                        st.Role = Console.ReadLine();
                        st.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStaffChanges(st);
                        Console.WriteLine("Staff edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null,null, st, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStaff with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStaff();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStaff();
            }
        }
        private static void EditStaffFirstName()
        {
            StaffShortList();
            Console.WriteLine("Enter Id of staff you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Staff.Any(x => x.Id == input))
                    {
                        Staff st = new Staff();
                        st = WorkContext.database.GetStaff(input);
                        Console.WriteLine("Current first name:\t" + st.FirstName);
                        Console.WriteLine("New first name:\t");
                        st.FirstName = Console.ReadLine();
                        st.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStaffChanges(st);
                        Console.WriteLine("Staff edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, null, st, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStaff with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStaff();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStaff();
            }
        }
        private static void EditStaffLastName()
        {
            StaffShortList();
            Console.WriteLine("Enter Id of staff you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Staff.Any(x => x.Id == input))
                    {
                        Staff st = new Staff();
                        st = WorkContext.database.GetStaff(input);
                        Console.WriteLine("Current last name:\t" + st.LastName);
                        Console.WriteLine("New last name:\t");
                        st.LastName = Console.ReadLine();
                        st.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStaffChanges(st);
                        Console.WriteLine("Staff edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, null, st, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStaff with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStaff();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStaff();
            }
        }
        private static void EditStaffDateOfBirth()
        {
            StaffShortList();
            Console.WriteLine("Enter Id of staff you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Staff.Any(x => x.Id == input))
                    {
                        Staff st = new Staff();
                        st = WorkContext.database.GetStaff(input);
                        Console.WriteLine("Current Date of Birth:\t" + st.DateOfBirth.ToString());
                        Console.WriteLine("New Date of Birth:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        st.DateOfBirth = date;
                        st.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStaffChanges(st);
                        Console.WriteLine("Staff edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, null, st, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStaff with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStaff();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStaff();
            }
        }
        private static void EditStaffAppointmentDate()
        {
            StaffShortList();
            Console.WriteLine("Enter Id of staff you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Staff.Any(x => x.Id == input))
                    {
                        Staff st = new Staff();
                        st = WorkContext.database.GetStaff(input);
                        Console.WriteLine("Current Appointment date:\t" + st.AppointmentDate.ToString());
                        Console.WriteLine("New Appointment date:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        st.AppointmentDate = date;
                        st.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStaffChanges(st);
                        Console.WriteLine("Staff edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, null, st, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStaff with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStaff();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStaff();
            }
        }
        private static void EditStaffRole()
        {
            StaffShortList();
            Console.WriteLine("Enter Id of staff you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Staff.Any(x => x.Id == input))
                    {
                        Staff st = new Staff();
                        st = WorkContext.database.GetStaff(input);
                        Console.WriteLine("Current role:\t" + st.Role);
                        Console.WriteLine("New role:\t");
                        st.Role = Console.ReadLine();
                        st.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStaffChanges(st);
                        Console.WriteLine("Staff edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, null, st, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStaff with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStaff();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStaff();
            }
        }
        private static void EditTeacher()
        {
            Console.Clear();
            Console.WriteLine("---> Edit Teacher <---");
            Console.WriteLine("Available options(Enter number): ");
            Console.WriteLine("1. Edit All Information About Teacher");
            Console.WriteLine("2. Edit Teacher's First Name");
            Console.WriteLine("3. Edit Teacher's Last Name");
            Console.WriteLine("4. Edit Teacher's Date Of Birth");
            Console.WriteLine("5. Edit Teacher's Appointment Date");
            Console.WriteLine("\n");
            Console.WriteLine("Enter -1 to go back.");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    switch (input)
                    {
                        case 1:
                            EditTeacherAll();
                            break;
                        case 2:
                            EditTeacherFirstName();
                            break;
                        case 3:
                            EditTeacherLastName();
                            break;
                        case 4:
                            EditTeacherDateOfBirth();
                            break;
                        case 5:
                            EditTeacherAppointmentDate();
                            break;
                        default:
                            Console.WriteLine("Input number out of range! Please choose again!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            EditTeacher();
                            break;
                    }
                    break;
                }
                Console.Clear();
                EditRecord();
            }
            else
            {
                Console.Clear();
                EditTeacher();
            }
        }
        private static void EditTeacherAll()
        {
            TeacherShortList();
            Console.WriteLine("Enter Id of teacher you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Teachers.Any(x => x.Id == input))
                    {
                        Teacher t = new Teacher();
                        t = WorkContext.database.GetTeacher(input);
                        Console.WriteLine("Current first name:\t" + t.FirstName);
                        Console.WriteLine("New first name:\t");
                        t.FirstName = Console.ReadLine();
                        Console.WriteLine("Current last name:\t" + t.LastName);
                        Console.WriteLine("New last name:\t");
                        t.LastName = Console.ReadLine();
                        Console.WriteLine("Current Date of Birth:\t" + t.DateOfBirth.ToString());
                        Console.WriteLine("New Date of Birth:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        t.DateOfBirth = date;
                        t.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistTeacherChanges(t);
                        Console.WriteLine("Teacher edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, t, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nTeacher with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditTeacher();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditTeacher();
            }
        }
        private static void EditTeacherFirstName()
        {
            TeacherShortList();
            Console.WriteLine("Enter Id of teacher you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Teachers.Any(x => x.Id == input))
                    {
                        Teacher t = new Teacher();
                        t = WorkContext.database.GetTeacher(input);
                        Console.WriteLine("Current first name:\t" + t.FirstName);
                        Console.WriteLine("New first name:\t");
                        t.FirstName = Console.ReadLine();
                        t.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistTeacherChanges(t);
                        Console.WriteLine("Teacher edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, t, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nTeacher with Id " + input + " does not exist.\n");
                        break;
                    }
                }
                AutoReturn(3);
                Console.Clear();
                EditTeacher();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditTeacher();
            }
        }
        private static void EditTeacherLastName()
        {
            TeacherShortList();
            Console.WriteLine("Enter Id of teacher you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Teachers.Any(x => x.Id == input))
                    {
                        Teacher t = new Teacher();
                        t = WorkContext.database.GetTeacher(input);
                        Console.WriteLine("Current last name: " + t.LastName);
                        Console.WriteLine("New last name: ");
                        t.LastName = Console.ReadLine();
                        t.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistTeacherChanges(t);
                        Console.WriteLine("Teacher edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, t, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nTeacher with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditTeacher();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditTeacher();
            }
        }
        private static void EditTeacherDateOfBirth()
        {
            TeacherShortList();
            Console.WriteLine("Enter Id of teacher you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Teachers.Any(x => x.Id == input))
                    {
                        Teacher t = new Teacher();
                        t = WorkContext.database.GetTeacher(input);
                        Console.WriteLine("Current Date of Birth:\t" + t.DateOfBirth.ToString());
                        Console.WriteLine("New Date of Birth:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        t.DateOfBirth = date;
                        t.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistTeacherChanges(t);
                        Console.WriteLine("Teacher edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, t, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nTeacher with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditTeacher();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditTeacher();
            }
        }
        private static void EditTeacherAppointmentDate()
        {
            TeacherShortList();
            Console.WriteLine("Enter Id of teacher you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Teachers.Any(x => x.Id == input))
                    {
                        Teacher t = new Teacher();
                        t = WorkContext.database.GetTeacher(input);
                        Console.WriteLine("Current Appointment date:\t" + t.AppointmentDate.ToString());
                        Console.WriteLine("New Appointment date:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        t.AppointmentDate = date;
                        t.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistTeacherChanges(t);
                        Console.WriteLine("Teacher edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(null, t, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nTeacher with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditTeacher();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditTeacher();
            }
        }
        private static void EditStudent()
        {
            Console.Clear();
            Console.WriteLine("---> Edit Student <---");
            Console.WriteLine("Available options(Enter number): ");
            Console.WriteLine("1. Edit All Information About Student");
            Console.WriteLine("2. Edit Student's First Name");
            Console.WriteLine("3. Edit Student's Last Name");
            Console.WriteLine("4. Edit Student's Date Of Birth");
            Console.WriteLine("5. Edit Student's Enrollment Date");
            Console.WriteLine("\n");
            Console.WriteLine("Enter -1 to go back.");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    switch (input)
                    {
                        case 1:
                            EditStudentAll();
                            break;
                        case 2:
                            EditStudentFirstName();
                            break;
                        case 3:
                            EditStudentLastName();
                            break;
                        case 4:
                            EditStudentDateOfBirth();
                            break;
                        case 5:
                            EditStudentEnrollmentDate();
                            break;
                        default:
                            Console.WriteLine("Input number out of range! Please choose again!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            EditStudent();
                            break;
                    }
                    break;
                }
                Console.Clear();
                EditRecord();
            }
            else
            {
                Console.Clear();
                EditStudent();
            }
        }
        private static void EditStudentAll()
        {
            StudentShortList();
            Console.WriteLine("Enter Id of student you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Students.Any(x => x.Id == input))
                    {
                        Student s = new Student();
                        s = WorkContext.database.GetStudent(input);
                        Console.WriteLine("Current first name:\t" + s.FirstName);
                        Console.WriteLine("New first name:\t");
                        s.FirstName = Console.ReadLine();
                        Console.WriteLine("Current last name:\t" + s.LastName);
                        Console.WriteLine("New last name:\t");
                        s.LastName = Console.ReadLine();
                        Console.WriteLine("Current Date of Birth:\t" + s.DateOfBirth.ToString());
                        Console.WriteLine("New Date of Birth:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        s.DateOfBirth = date;
                        s.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStudentChanges(s);
                        Console.WriteLine("Student edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(s, null, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStudent with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStudent();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStudent();
            }
        }
        private static void EditStudentFirstName()
        {
            StudentShortList();
            Console.WriteLine("Enter Id of student you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Students.Any(x => x.Id == input))
                    {
                        Student s = new Student();
                        s = WorkContext.database.GetStudent(input);
                        Console.WriteLine("Current first name:\t" + s.FirstName);
                        Console.WriteLine("New first name:\t");
                        s.FirstName = Console.ReadLine();
                        s.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStudentChanges(s);
                        Console.WriteLine("Student edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(s, null, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStudent with Id " + input + " does not exist.\n");
                        break;
                    }
                }
                AutoReturn(3);
                Console.Clear();
                EditStudent();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStudent();
            }
        }
        private static void EditStudentLastName()
        {
            StudentShortList();
            Console.WriteLine("Enter Id of student you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Students.Any(x => x.Id == input))
                    {
                        Student s = new Student();
                        s = WorkContext.database.GetStudent(input);
                        Console.WriteLine("Current last name: " + s.LastName);
                        Console.WriteLine("New last name: ");
                        s.LastName = Console.ReadLine();
                        s.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStudentChanges(s);
                        Console.WriteLine("Student edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(s, null, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStudent with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStudent();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStudent();
            }
        }
        private static void EditStudentDateOfBirth()
        {
            StudentShortList();
            Console.WriteLine("Enter Id of student you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Students.Any(x => x.Id == input))
                    {
                        Student s = new Student();
                        s = WorkContext.database.GetStudent(input);
                        Console.WriteLine("Current Date of Birth:\t" + s.DateOfBirth.ToString());
                        Console.WriteLine("New Date of Birth:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        s.DateOfBirth = date;
                        s.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStudentChanges(s);
                        Console.WriteLine("Student edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(s, null, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStudent with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStudent();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStudent();
            }
        }
        private static void EditStudentEnrollmentDate()
        {
            StudentShortList();
            Console.WriteLine("Enter Id of student you want to edit: ");
            Console.WriteLine("Enter -1 to exit edit mode and go back to selection");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    if (WorkContext.database.Students.Any(x => x.Id == input))
                    {
                        Student s = new Student();
                        s = WorkContext.database.GetStudent(input);
                        Console.WriteLine("Current Enrollment date:\t" + s.EnrollmentDate.ToString());
                        Console.WriteLine("New Enrollment date:\t");
                        string dt = Console.ReadLine();
                        DateTime date = Input.GetDate(dt);
                        s.DateOfBirth = date;
                        s.LastEdited = DateTime.Now;
                        Console.WriteLine("\n");
                        WorkContext.database.PersistStudentChanges(s);
                        Console.WriteLine("Student edited successfully.\n");
                        DatabaseUtilities.Save(WorkContext.database);
                        System.Threading.Thread.Sleep(1000);
                        DisplayLastEdited(s, null, null, null);
                        AutoReturn(3);
                        EditRecord();

                    }
                    else
                    {
                        Console.WriteLine("\nStudent with Id " + input + " does not exist.\n");
                        break;
                    }

                }
                AutoReturn(3);
                Console.Clear();
                EditStudent();
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
                AutoReturn(2);
                EditStudent();
            }
        }
        private static void DisplayDataAboutSpecificGroup()
        {
            {
                Console.WriteLine("---> Display Information About Specific Group <---");
                Console.WriteLine("Available options(Enter number): ");
                Console.WriteLine("1. Display All Students[{0}]", WorkContext.database.Students.Count);
                Console.WriteLine("2. Display All Teachers[{0}]", WorkContext.database.Teachers.Count);
                Console.WriteLine("3. Display All Staff[{0}]", WorkContext.database.Staff.Count);
                Console.WriteLine("4. Display All Courses[{0}]", WorkContext.database.Course.Count);
                Console.WriteLine("\n");
                Console.WriteLine("Enter -1 to go back.");
                int input;
                string consoleRead;
                consoleRead = Console.ReadLine();
                bool conversionSuccess = int.TryParse(consoleRead, out input);
                if (conversionSuccess == true)
                {
                    while (input != -1)
                    {
                        switch (input)
                        {
                            case 1:
                                DisplayAllStudents();
                                break;
                            case 2:
                                DisplayAllTeachers();
                                break;
                            case 3:
                                DisplayAllStaff();
                                break;
                            case 4:
                                DisplayAllCourses();
                                break;
                            default:
                                Console.WriteLine("Input number out of range! Please choose again!");
                                System.Threading.Thread.Sleep(1000);
                                Console.Clear();
                                DisplayDataAboutSpecificGroup();
                                break;
                        }
                        break;
                    }
                    Console.Clear();
                    MasterOptions();
                }
                else
                {
                    Console.Clear();
                    DisplayDataAboutSpecificGroup();
                }
            }
        }
        private static void DisplayLastEdited(Student student, Teacher teacher, Staff staff, Course course)
        {
            if (student != null)
            {
                Student s = new Student();
                s = student;
                Console.WriteLine("Last edited record\t: Student");
                Console.WriteLine("Id\t:" + s.Id);
                Console.WriteLine("Full Name\t:" + s.FirstName + " " + s.LastName);
                Console.WriteLine("Date Of Birth\t:" + s.DateOfBirth.ToString());
                Console.WriteLine("Created\t:" + s.CreatedDate.ToString());
                Console.WriteLine("Last Edite\t:" + s.LastEdited.ToString());
                Console.Write("\n");
                AutoReturn(10);
                Console.Clear();
            }
            else if (teacher != null)
            {
                Teacher t = new Teacher();
                t = teacher;
                Console.WriteLine("Last edited record\t: Teacher");
                Console.WriteLine("Id\t:" + t.Id);
                Console.WriteLine("Full Name\t:" + t.FirstName + " " + t.LastName);
                Console.WriteLine("Date Of Birth\t:" + t.DateOfBirth.ToString());
                Console.WriteLine("Appointment Date\t:" + t.AppointmentDate.ToString());
                Console.WriteLine("Created\t:" + t.CreatedDate.ToString());
                Console.WriteLine("Last Edited\t:" + t.LastEdited.ToString());
                Console.Write("\n");
                AutoReturn(10);
                Console.Clear();
            }
            else if (staff != null)
            {
                Staff st = new Staff();
                st = staff;
                Console.WriteLine("Last edited record\t: Staff");
                Console.WriteLine("Id\t:" + st.Id);
                Console.WriteLine("Full Name\t:" + st.FirstName + " " + st.LastName);
                Console.WriteLine("Date Of Birth\t:" + st.DateOfBirth.ToString());
                Console.WriteLine("Appointment Date\t:" + st.AppointmentDate.ToString());
                Console.WriteLine("Role\t:" + st.Role);
                Console.WriteLine("Created\t:" + st.CreatedDate.ToString());
                Console.WriteLine("Last Edited\t:" + st.LastEdited.ToString());
                Console.Write("\n");
                AutoReturn(10);
                Console.Clear();
            }
            else if (course != null)
            {
                Course c = new Course();
                c = course;
                Console.WriteLine("Last edited record\t: Course");
                Console.WriteLine("Id:\t" + c.Id);
                Console.WriteLine("Course Title:\t" + c.CourseTitle);
                Console.WriteLine("Ects Points:\t" + c.EctsPoints);
                Console.WriteLine("Description:\t" + c.Description);
                Console.WriteLine("Created:\t" + c.CreatedDate.ToString());
                Console.WriteLine("Last Edited:\t" + c.LastEdited.ToString());
                Console.Write("\n");
                AutoReturn(10);
                Console.Clear();
            }
        }
        private static void DisplayLastRemoved(Student student, Teacher teacher, Staff staff, Course course)
        {
            if (student != null)
            {
                Student s = new Student();
                s = student;
                Console.WriteLine("Last removed record\t: Student");
                Console.WriteLine("Id\t:" + s.Id);
                Console.WriteLine("Full Name\t:" + s.FirstName + " " + s.LastName);
                Console.WriteLine("Date Of Birth\t:" + s.DateOfBirth.ToString());
                Console.WriteLine("Created\t:" + s.CreatedDate.ToString());
                Console.WriteLine("Last Edited\t:" + s.LastEdited.ToString());
                Console.Write("\n");
                System.Threading.Thread.Sleep(2000);
            }
            else if (teacher != null)
            {
                Teacher t = new Teacher();
                t = teacher;
                Console.WriteLine("Last removed record\t: Teacher");
                Console.WriteLine("Id\t:" + t.Id);
                Console.WriteLine("Full Name\t:" + t.FirstName + " " + t.LastName);
                Console.WriteLine("Date Of Birth\t:" + t.DateOfBirth.ToString());
                Console.WriteLine("Appointment Date\t:" + t.AppointmentDate.ToString());
                Console.WriteLine("Created\t:" + t.CreatedDate.ToString());
                Console.WriteLine("Last Edited\t:" + t.LastEdited.ToString());
                Console.Write("\n");
                System.Threading.Thread.Sleep(2000);
            }
            else if (staff != null)
            {
                Staff st = new Staff();
                st = staff;
                Console.WriteLine("Last removed record\t: Staff");
                Console.WriteLine("Id\t:" + st.Id);
                Console.WriteLine("Full Name\t:" + st.FirstName + " " + st.LastName);
                Console.WriteLine("Date Of Birth\t:" + st.DateOfBirth.ToString());
                Console.WriteLine("Appointment Date\t:" + st.AppointmentDate.ToString());
                Console.WriteLine("Role\t:" + st.Role);
                Console.WriteLine("Created\t:" + st.CreatedDate.ToString());
                Console.WriteLine("Last Edited\t:" + st.LastEdited.ToString());
                Console.Write("\n");
                System.Threading.Thread.Sleep(2000);
            }
            else if (course != null)
            {
                Course c = new Course();
                c = course;
                Console.WriteLine("Last removed record\t: Course");
                Console.WriteLine("Id:\t" + c.Id);
                Console.WriteLine("Course Title:\t" + c.CourseTitle);
                Console.WriteLine("Ects Points:\t" + c.EctsPoints);
                Console.WriteLine("Description:\t" + c.Description);
                Console.WriteLine("Created:\t" + c.CreatedDate.ToString());
                Console.WriteLine("Last Edited:\t" + c.LastEdited.ToString());
                Console.Write("\n");
                System.Threading.Thread.Sleep(2000);
            }
        }
        private static void StudentShortList(bool remove =false)
        {
            if (WorkContext.database.Students.Count != 0)
            {
                Console.WriteLine("---> Student Shortlist <---\n");
                foreach (var student in WorkContext.database.Students)
                {
                    Console.WriteLine("ID --> " + student.Id + " Full Name:\t" + student.FirstName + " " + student.LastName);
                    Console.Write("\n");
                }
            }
            else
            {
                if (remove)
                {
                    Console.WriteLine("\nNo information about students.\nThere need to be at least one student added for deletion to be possible.");
                    AutoReturn(3);
                    Console.Clear();
                    RemoveRecord();
                }
                else
                {
                    Console.WriteLine("\nNo information about students.\nPlease add students first in order to edit them.");
                    AutoReturn(3);
                    Console.Clear();
                    EditStudent();
                }
            }
        }
        private static void TeacherShortList(bool remove =false)
        {
            if (WorkContext.database.Teachers.Count != 0)
            {
                Console.WriteLine("---> Teacher Shortlist <---\n");
                foreach (var teacher in WorkContext.database.Teachers)
                {
                    Console.WriteLine("ID --> " + teacher.Id + " Full Name:\t" + teacher.FirstName + " " + teacher.LastName);
                    Console.Write("\n");
                }
            }
            else
            {
                if (remove)
                {
                    Console.WriteLine("\nNo information about teachers.\nThere need to be at least one teachers added for deletion to be possible.");
                    AutoReturn(3);
                    Console.Clear();
                    RemoveRecord();
                }
                else
                {
                    Console.WriteLine("\nNo information about teachers.\nPlease add teachers first in order to edit them.");
                    AutoReturn(3);
                    Console.Clear();
                    EditTeacher();
                }
            }
        }
        private static void StaffShortList(bool remove=false)
        {
            if (WorkContext.database.Staff.Count != 0)
            {
                Console.WriteLine("---> Staff Shortlist <---\n");
                foreach (var staff in WorkContext.database.Staff)
                {
                    Console.WriteLine("ID --> " + staff.Id + " Full Name:\t" + staff.FirstName + " " + staff.LastName);
                    Console.Write("\n");
                }
            }
            else
            {
                if (remove)
                {
                    Console.WriteLine("\nNo information about staff.\nThere need to be at least one staff added for deletion to be possible.");
                    AutoReturn(3);
                    Console.Clear();
                    RemoveRecord();
                }
                else
                {
                    Console.WriteLine("\nNo information about staff.\nPlease add staff first in order to edit them.");
                    AutoReturn(3);
                    Console.Clear();
                    EditStaff();
                }
            }
        }
        private static void CourseShortList(bool remove=false)
        {
            if (WorkContext.database.Course.Count != 0)
            {
                Console.WriteLine("---> Course Shortlist <---\n");
                foreach (var course in WorkContext.database.Course)
                {
                    Console.WriteLine("ID --> " + course.Id + " Course Title:\t" +course.CourseTitle);
                    Console.Write("\n");
                }
            }
            else
            {
                if (remove)
                {
                    Console.WriteLine("\nNo information about courses.\nThere need to be at least one course added for deletion to be possible.");
                    AutoReturn(3);
                    Console.Clear();
                    RemoveRecord();
                }
                else
                {
                    Console.WriteLine("\nNo information about courses.\nPlease add courses first in order to edit them.");
                    AutoReturn(3);
                    Console.Clear();
                    EditCourse();
                }
            }
        }
        private static void DisplayAllCourses()
        {
            string consoleRead;
            int input;
            if (WorkContext.database.Course.Count != 0)
            {
                Console.WriteLine("---> Course Information <---\n");
                foreach (var course in WorkContext.database.Course)
                {
                    Console.WriteLine("Course Title:\t" + course.CourseTitle);
                    Console.WriteLine("Ects Points:\t" + course.EctsPoints.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nNo information about courses.\nPlease add courses first.");
            }
            Console.WriteLine("\nEnter -1 to go back \n");
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                Console.Clear();
                DisplayDataAboutSpecificGroup();
            }
            else
            {
                AutoReturn(5);
                Console.Clear();
                DisplayDataAboutSpecificGroup();

            }
        }
        private static void DisplayAllStaff()
        {
            {
                string consoleRead;
                int input;
                if (WorkContext.database.Staff.Count != 0)
                {
                    Console.WriteLine("---> Staff Information <---\n");
                    foreach (var staff in WorkContext.database.Staff)
                    {
                        Console.WriteLine("Full Name:\t" + staff.FirstName + " " + staff.LastName);
                        Console.WriteLine("Date Of Birth:\t" + staff.DateOfBirth.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("\nNo information about staff.\nPlease add staff first.");
                }
                Console.WriteLine("\nEnter -1 to go back \n");
                consoleRead = Console.ReadLine();
                bool conversionSuccess = int.TryParse(consoleRead, out input);
                if (conversionSuccess == true)
                {
                    Console.Clear();
                    DisplayDataAboutSpecificGroup();
                }
                else
                {
                    AutoReturn(5);
                    Console.Clear();
                    DisplayDataAboutSpecificGroup();

                }
            }
        }
        private static void DisplayAllTeachers()
        {
            string consoleRead;
            int input;
            if (WorkContext.database.Teachers.Count != 0)
            {
                Console.WriteLine("---> Teacher Information <---\n");
                foreach (var teacher in WorkContext.database.Teachers)
                {
                    Console.WriteLine("Full Name:\t" + teacher.FirstName + " " + teacher.LastName);
                    Console.WriteLine("Date Of Birth:\t" + teacher.DateOfBirth.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nNo information about teacher.\nPlease add teachers first.");
            }
            Console.WriteLine("\nEnter -1 to go back \n");
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                Console.Clear();
                DisplayDataAboutSpecificGroup();
            }
            else
            {
                AutoReturn(5);
                Console.Clear();
                DisplayDataAboutSpecificGroup();

            }
        }
        private static void DisplayAllStudents()
        {
            string consoleRead;
            int input;
            if (WorkContext.database.Students.Count != 0)
            {
                Console.WriteLine("---> Student Information <---\n");
                foreach (var student in WorkContext.database.Students)
                {
                    Console.WriteLine("Full Name:\t" + student.FirstName + " " + student.LastName);
                    Console.WriteLine("Date Of Birth:\t" + student.DateOfBirth.ToString());
                    Console.Write("\n");
                }
            }
            else
            {
                Console.WriteLine("\nNo information about students.\nPlease add students first.");
            }
            Console.WriteLine("\nEnter -1 to go back \n");
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                Console.Clear();
                DisplayDataAboutSpecificGroup();
            }
            else
            {
                AutoReturn(5);
                Console.Clear();
                DisplayDataAboutSpecificGroup();

            }
        }
        private static void DisplayAllData()
        {
            string consoleRead;
            int input;
            if (WorkContext.database.Students.Count != 0 || WorkContext.database.Teachers.Count != 0 || WorkContext.database.Staff.Count != 0 || WorkContext.database.Course.Count != 0)
            {
                if (WorkContext.database.Students.Count != 0)
                {
                    Console.WriteLine("---> Student Information <---\n");
                    foreach (var student in WorkContext.database.Students)
                    {
                        Console.WriteLine("Full Name:\t" + student.FirstName + " " + student.LastName);
                        Console.WriteLine("Date Of Birth:\t" + student.DateOfBirth.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("\nNo information about students.\nPlease add students first.");
                }
                Console.WriteLine("\n-------------------------");
                if (WorkContext.database.Teachers.Count != 0)
                {
                    Console.WriteLine("\n---> Teacher Information <---\n");
                    foreach (var teacher in WorkContext.database.Teachers)
                    {
                        Console.WriteLine("Full Name:\t" + teacher.FirstName + " " + teacher.LastName);
                        Console.WriteLine("Date Of Birth:\t" + teacher.DateOfBirth.ToString());
                        Console.Write("\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo information about teachers.\nPlease add teachers first.");
                }
                Console.WriteLine("\n-------------------------");
                if (WorkContext.database.Staff.Count != 0)
                {
                    Console.WriteLine("\n---> Staff Information <---\n");
                    foreach (var staff in WorkContext.database.Staff)
                    {
                        Console.WriteLine("Full Name:\t" + staff.FirstName + " " + staff.LastName);
                        Console.WriteLine("Date Of Birth:\t" + staff.DateOfBirth.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("\nNo information about staff.\nPlease add staff first.");
                }
                Console.WriteLine("\n-------------------------");
                if (WorkContext.database.Course.Count != 0)
                {
                    Console.WriteLine("\n---> Course Information <---\n");
                    foreach (var course in WorkContext.database.Course)
                    {
                        Console.WriteLine("Course Title:\t" + course.CourseTitle);
                        Console.WriteLine("Ects Points:\t" + course.EctsPoints.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("\nNo information about courses.\nPlease add courses first.");
                }
            }
            else
            {
                Console.WriteLine("\nThere is no any data entered yet. Please add new records first.");
                AutoReturn(5);
                Console.Clear();
                MasterOptions();
            }

            Console.WriteLine("\nEnter -1 to go back \n");
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                Console.Clear();
                MasterOptions();
            }
            else
            {
                AutoReturn(5);
                Console.Clear();
                MasterOptions();

            }
        }
        public static void AddRecord()
        {
            Console.Clear();
            Console.WriteLine("---> Add Record <---");
            Console.WriteLine("Available options(Enter number): ");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Teacher");
            Console.WriteLine("3. Add Staff");
            Console.WriteLine("4. Add Course");
            Console.WriteLine("\n");
            Console.WriteLine("Enter -1 to go back.");
            int input;
            string consoleRead;
            consoleRead = Console.ReadLine();
            bool conversionSuccess = int.TryParse(consoleRead, out input);
            if (conversionSuccess == true)
            {
                while (input != -1)
                {
                    switch (input)
                    {
                        case 1:
                            AddStudent();
                            break;
                        case 2:
                            AddTeacher();
                            break;
                        case 3:
                            AddStaff();
                            break;
                        case 4:
                            AddCourse();
                            break;
                        default:
                            Console.WriteLine("Input number out of range! Please choose again!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            AddRecord();
                            break;
                    }
                    break;
                }
                Console.Clear();
                MasterOptions();
            }
            else
            {
                Console.Clear();
                AddRecord();
            }
        }
        private static void AddCourse()
        {
            Console.Clear();
            Console.WriteLine("---> Add Course <---");
            Console.WriteLine("Enter information about course: ");
            Course c = new Course();
            Console.WriteLine("Enter course Title: ");
            c.CourseTitle = Console.ReadLine();
            Console.WriteLine("Enter Ects point value for course: ");
            c.EctsPoints = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter course description: ");
            c.Description = Console.ReadLine();
            Console.WriteLine("\n");
            WorkContext.database.AddCourse(c);
            DatabaseUtilities.Save(WorkContext.database);
            Console.WriteLine("New course added successfully.\n");
            AutoReturn(3);
            AddRecord();
        }
        private static void AddStaff()
        {
            Console.Clear();
            Console.WriteLine("---> Add Staff <---");
            Console.WriteLine("Enter information about staff: ");
            Staff st = new Staff();
            Console.WriteLine("Enter first name: ");
            st.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            st.LastName = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth: ");
            string dt = Console.ReadLine();
            DateTime date = Input.GetDate(dt);
            st.DateOfBirth = date;
            Console.WriteLine("\n");
            WorkContext.database.AddStaff(st);
            DatabaseUtilities.Save(WorkContext.database);
            Console.WriteLine("New staff added successfully.\n");
            AutoReturn(3);
            AddRecord();
        }
        private static void AddTeacher()
        {
            Console.Clear();
            Console.WriteLine("---> Add Teacher <---");
            Console.WriteLine("Enter information about teacher: ");
            Teacher t = new Teacher();
            Console.WriteLine("Enter first name: ");
            t.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            t.LastName = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth: ");
            string dt = Console.ReadLine();
            DateTime date = Input.GetDate(dt);
            t.DateOfBirth = date;
            Console.WriteLine("\n");
            WorkContext.database.AddTeacher(t);
            DatabaseUtilities.Save(WorkContext.database);
            Console.WriteLine("New teacher added successfully.\n");
            AutoReturn(3);
            AddRecord();
        }
        private static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("---> Add Student <---");
            Console.WriteLine("Enter information about student: ");
            Student s = new Student();
            Console.WriteLine("Enter first name: ");
            s.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            s.LastName = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth: ");
            string dt = Console.ReadLine();
            DateTime date = Input.GetDate(dt);
            s.DateOfBirth = date;
            Console.WriteLine("\n");
            WorkContext.database.AddStudent(s);
            Console.WriteLine("New Student added successfully.\n");
            DatabaseUtilities.Save(WorkContext.database);
            AutoReturn(3);
            AddRecord();
        }
        public static void Exit()
        {
            Console.WriteLine("School system will close now.");
            System.Threading.Thread.Sleep(2000);
            DatabaseUtilities.Save(WorkContext.database);
            Environment.Exit(1);
        }
        public static void AutoReturn(int time)
        {
            for (int i = time; i > 0; --i)
            {
                Console.Write("\rYou'll be taken back automatically in {0}s.", i);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
