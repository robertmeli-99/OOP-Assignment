using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Domain;

namespace OOPAssignment
{

    class PL
    {
        
        static BL bl = new BL();
        static void Main(string[] args)
        {
            startmain();
        }
        public static void startmain()
        {
                mainmenu();
                Console.Write("\nChoise: ");
                string choice = Console.ReadLine();
                int n1;
                bool c1 = int.TryParse(choice, out n1);
                if (c1 == true) {
                    if (n1 == 1)
                    {
                        login();
                    }
                    else if (n1 == 2)
                    {
                        exit();
                    }
                    else
                    {
                        Console.WriteLine("Please enter numbers (1 or 2) only!");
                        startmain();
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Please enter numbers (1 or 2) only!");
                    startmain();
                }
        }
        public static void mainmenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("=========");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
        }
        public static void exit()
        {
            Environment.Exit(0);
        }
        public static void login()
        {

            Console.WriteLine("\nLogin");
            Console.WriteLine("=====\n");
            Console.Write("Username: ");
            string username =  Console.ReadLine();
            Console.WriteLine(bl.Login(username));
            if (bl.Login(username) != "Username does not exist")
            {
                Console.Write("Password: ");
                string password = Console.ReadLine();
                Console.WriteLine(bl.Password(username, password));
                if (bl.Password(username, password) != "Re enter cridentials please!")
                {
                    TeacherMenu();
                }
                else
                {
                    login();
                }
            }
            else
            {
                login();
            }
        }
        public static void wrongLogin()
        {
            Console.WriteLine("The entered username does not exist.");
        }
        public static void TeacherMenu()
        {
            Console.WriteLine("\nTeacher Menu");
            Console.WriteLine("=========");
            Console.WriteLine("1. Add Attendance");
            Console.WriteLine("2. Add a New Group");
            Console.WriteLine("3. Add a New Student");
            Console.WriteLine("4. Add a New Teacher");
            Console.WriteLine("5. Check a student's attendance percentage");
            Console.WriteLine("6. Get all attendances submitted on a particular day");
            Console.WriteLine("7. Edit Student");
            Console.WriteLine("8. Logout back to main menu");
            try
            {
                Console.Write("\nChoise: ");
                string choice = Console.ReadLine();
                int choise1;
                bool num = int.TryParse(choice, out choise1);
                if (num == true)
                {
                    switch (choise1)
                    {
                        case 1:
                            Console.WriteLine("New Attandance");
                            Console.WriteLine("==============\n");
                            Console.WriteLine(bl.Getgroups());
                            Console.Write("Group ID: ");
                            try
                            {
                                string gId = Console.ReadLine();
                                int Igid = Convert.ToInt32(gId);
                                if (bl.CheckGroupID(Igid) == false)
                                {
                                    throw (new Exception());
                                }
                                else if (bl.GetNumOfStudents(Igid) == 0)
                                {
                                    Console.WriteLine("There are no students in this group enter new group please. \n");
                                    TeacherMenu();
                                }
                                else
                                {
                                    DateTime now = DateTime.Now.Date;
                                    bl.EnterLesson(Igid, now);
                                    showStudents(Igid);
                                    Console.WriteLine("\nAttandance Submitted");
                                    Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                                    Console.ReadKey();
                                    TeacherMenu();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Id dose not exist enter new ID \n");
                                TeacherMenu();
                            }
                            break;
                        case 2:
                            Console.WriteLine("New Group");
                            Console.WriteLine("=========\n");
                            Console.WriteLine(bl.Getgroups());
                            Console.WriteLine("Enter Details: \n");
                            Console.Write("Group Name: ");
                            string GroupName = Console.ReadLine();
                            Console.Write("\nCourse name: ");
                            string CourseName = Console.ReadLine();
                            bl.AddGroup(GroupName, CourseName);
                            Console.WriteLine("Data Submitted");
                            Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                            Console.ReadKey();
                            TeacherMenu();
                            break;
                        case 3:
                            Console.WriteLine("New Student");
                            Console.WriteLine("===========\n");
                            Console.WriteLine(bl.Getgroups());
                            Console.Write("Group ID: ");
                            try
                            {
                                string ggId = Console.ReadLine();
                                int Iggid = Convert.ToInt32(ggId);
                                if (bl.CheckGroupID(Iggid) == false)
                                {
                                    throw (new Exception());
                                }                                
                                else
                                {
                                    Console.WriteLine("Details: \n");
                                    Console.Write("Name: ");
                                    string Sname = Console.ReadLine();
                                    Console.Write("\nSurname: ");
                                    string Ssurname = Console.ReadLine();
                                    Console.Write("\nEmail: ");
                                    string Semail = Console.ReadLine();
                                    bl.AddStudent(Sname, Ssurname, Semail, Iggid);
                                    Console.WriteLine("Data Submitted");
                                    Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                                    Console.ReadKey();
                                    TeacherMenu();
                                }
                            }
                            catch(Exception e)
                            { 
                                string ggId;
                                int Iggid;
                                do
                                {
                                    Console.WriteLine("Group Id dose not exist enter new ID ");
                                    Console.Write("Group ID: ");
                                    ggId = Console.ReadLine();
                                    Iggid = Convert.ToInt32(ggId);
                                }
                                while (bl.CheckGroupID(Iggid) == false);

                                Console.WriteLine("Details: \n");
                                Console.Write("Name: ");
                                string Sname = Console.ReadLine();
                                Console.Write("\nSurname: ");
                                string Ssurname = Console.ReadLine();
                                Console.Write("\nEmail: ");
                                string Semail = Console.ReadLine();
                                bl.AddStudent(Sname, Ssurname, Semail, Iggid);
                                Console.WriteLine("\nData Submitted");
                                Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                                Console.ReadKey();
                                TeacherMenu();
                            }

                            break;
                        case 4:
                            Console.WriteLine("New Teacher");
                            Console.WriteLine("===========\n");
                            Console.WriteLine("Details: \n");
                            Console.Write("Username: ");
                            string pUsername = Console.ReadLine();
                            do
                            {
                                Console.WriteLine($"Username{pUsername} already existis or is empty.");
                                Console.Write("Username: ");
                                pUsername = Console.ReadLine();

                            }
                            while (bl.EsitingUName(pUsername) != 0 || pUsername == "");
                            Console.Write("Password: ");
                            string pPassword = Console.ReadLine();
                            Console.Write("Name: ");
                            string pName = Console.ReadLine();
                            Console.Write("\nSurname: ");
                            string pSurname = Console.ReadLine();
                            Console.Write("\nEmail: ");
                            string pEmail = Console.ReadLine();
                         
                            bl.AddTeacher(pUsername,pPassword,pName,pSurname,pEmail);
                            Console.WriteLine("Data Submitted");
                            Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                            Console.ReadKey();
                            TeacherMenu();
                            break;
                        case 5:
                            Console.WriteLine("Check Attendance Percentage");
                            Console.WriteLine("===========================\n");
                            Console.WriteLine(bl.GetStudents());
                            Console.Write("Student ID: ");
                            try
                            {
                                string Sid = Console.ReadLine();
                                int ISid = Convert.ToInt32(Sid);

                                if (bl.CheckStudentID(ISid) == false || ISid == 0)
                                {
                                    throw (new Exception());
                                }
                                else
                                {
                                    Console.WriteLine("\nStudent ID\tPrescence\tLesson ID");
                                    Console.WriteLine("\n==========\t=========\t=========");
                                    Console.WriteLine(bl.GetAttandance(ISid));
                                    Console.WriteLine("\n" + bl.AttandancePersentage(ISid));
                                    Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                                    Console.ReadKey();
                                    TeacherMenu();
                                }
                            }
                            catch(Exception e)
                            {
                                string Sid;
                                int ISid;

                                do
                                {
                                    Console.WriteLine("Student Id does not exist enter new ID ");

                                    Console.Write("Student ID: ");

                                    Sid = Console.ReadLine();
                                    ISid = Convert.ToInt32(Sid);
                                }
                                while (bl.CheckStudentID(ISid) == false || ISid == 0);
                                Console.WriteLine("\nStudent ID\tPrescence\tLesson ID");
                                Console.WriteLine("\n==========\t=========\t=========");
                                Console.WriteLine(bl.GetAttandance(ISid));
                                Console.WriteLine("\n" + bl.AttandancePersentage(ISid));
                                Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                                Console.ReadKey();
                                TeacherMenu();
                            }

                            break;
                        case 6:
                            Console.WriteLine("Submitted Attendances");
                            Console.WriteLine("=====================\n");
                            Console.Write("Day: ");
                            int day = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nMonth: ");
                            int month = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nYear: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n"+bl.SubmittedAttendances(year,month,day));
                            Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                            Console.ReadKey();
                            TeacherMenu();
                            break;
                        case 7:
                            Console.WriteLine("\nEdit Student");
                            Console.WriteLine("===========\n");
                            Console.WriteLine(bl.GetStudents());
                            Console.Write("\nStudent ID: ");
                            try
                            {
                                string id = Console.ReadLine();
                                int Iid = Convert.ToInt32(id);

                                if (bl.CheckStudentID(Iid) == false)
                                {
                                    throw (new Exception());
                                }
                                else
                                {
                                    EditStudent(Iid);

                                    TeacherMenu();
                                }
                            }
                            catch (Exception e)
                            {
                                string id;
                                int Iid;
                                do
                                {
                                    Console.WriteLine("\nID not valid; Please enter a vaild ID");
                                    Console.Write("\nStudent ID: ");
                                    id = Console.ReadLine();
                                    Iid = Convert.ToInt32(id);
                                }
                                while (bl.CheckStudentID(Iid) == false);
                                EditStudent(Iid);
                                TeacherMenu();

                            }
                            break;
                        case 8:
                            Console.Clear();
                            startmain();
                            break;
                        default:
                            Console.WriteLine("\nNumber out of range please enter a number between 1-8.");
                            TeacherMenu();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease Input Numbers Only.");
                    Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                    Console.ReadKey();
                    TeacherMenu();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nPlease enter numbers only",e);
                Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
                Console.ReadKey();
                TeacherMenu();

            }

        }
        public static void showStudents(int groupID)
        {
            List<Student> allStudents = bl.getStudentsInGroup(groupID);
            Console.WriteLine("\nStudent ID    Student Name      Student Surname        Prescence(P/A)");
            Console.WriteLine("\n==========    ============      ===============        ==============");

            foreach (Student s in allStudents)
            {
                int studentid = s.StudentID;
                Console.Write(studentid + "\t\t" + s.Name + "\t\t" + s.Surname + "\t\t  ");
                string attendance = Console.ReadLine();
                while (attendance != "a" && attendance != "p") {
                    if (attendance != "a" && attendance != "p")
                    {
                        Console.SetCursorPosition(0, Console.CursorTop-1);
                        ClearCurrentConsoleLine();
                        Console.Write(studentid + "\t\t" + s.Name + "\t\t" + s.Surname + "\t\t  ");
                        attendance = Console.ReadLine();
                    }
            }
            int id = bl.GetLessonID();
            bl.addAttendance(studentid, id, attendance);
            }
        }
        public static void EditStudent(int Iid) 
        {

            string name,surname,email;
            
            do
            {
                Console.WriteLine("Please dont leave any empty fields as you will need to fill them again.");
                Console.WriteLine("New Details: \n");
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("\nSurname: ");
                surname = Console.ReadLine();
                Console.Write("\nEmail: ");
                email = Console.ReadLine();

            }
            while (name == "" || surname == "" || email == "");
            bl.EditStudent(Iid, name, surname, email);
            Console.WriteLine("\nData Altered");
            Console.WriteLine("\nPress [ENTER] to go back to Teacher Menu.");
            Console.ReadKey();
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void addTeacher()
        {

        }
    }
}
