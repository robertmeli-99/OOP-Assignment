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
            mainmenu();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                login();
            }
            else if(choice == 2){
                exit();
            }
            Console.ReadKey();
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

            Console.WriteLine("Login");
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
            Console.WriteLine("The entered username does not exist");
        }
        public static void TeacherMenu()
        {
            Console.WriteLine("Teacher Menu");
            Console.WriteLine("=========");
            Console.WriteLine("1. Add Attendance");
            Console.WriteLine("2. Add a New Group");
            Console.WriteLine("3. Add a New Student");
            Console.WriteLine("4. Add a New Teacher");
            Console.WriteLine("5. Check a student's attendance percentage");
            Console.WriteLine("6. Get all attendances submitted on a particular day");
            Console.WriteLine("7. Edit Student");
            try
            {

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
                            string gId = Console.ReadLine();
                            int Igid = Convert.ToInt32(gId);
                            if (bl.CheckGroupID(Igid) == false)
                            {
                                Console.WriteLine("Id dose not exist enter new ID ");
                                TeacherMenu();
                            }
                            else {
                                DateTime now = DateTime.Now.Date;
                                bl.EnterLesson(Igid,now);
                                showStudents(Igid);
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
                            break;
                        case 3:
                            Console.WriteLine("New Student");
                            Console.WriteLine("===========\n");
                            Console.WriteLine(bl.Getgroups());
                            Console.Write("Group ID: ");
                            string ggId = Console.ReadLine();
                            int Iggid = Convert.ToInt32(ggId);
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
                            Console.Write("\nEmail");
                            string Semail = Console.ReadLine();
                            bl.AddStudent(Sname,Ssurname,Semail,Iggid);
                            break;
                        case 4:
                            Console.WriteLine("New Teacher");
                            Console.WriteLine("===========\n");
                            break;
                        case 5:
                            Console.WriteLine("Check Attendance Percentage");
                            Console.WriteLine("===========================\n");
                            break;
                        case 6:
                            Console.WriteLine("Submitted Attendances");
                            Console.WriteLine("=====================\n");
                            break;
                        case 7:
                            Console.WriteLine("Edit Student");
                            Console.WriteLine("===========\n");
                            Console.WriteLine(bl.GetStudents());
                            Console.Write("Student ID: ");
                            string id = Console.ReadLine();
                            int Iid = Convert.ToInt32(id);
                            do
                            {
                                Console.WriteLine("ID not valid; Please enter a vaild ID");
                                Console.Write("Student ID: ");
                                id = Console.ReadLine();
                                Iid = Convert.ToInt32(id);
                            }
                            while (bl.CheckStudentID(Iid) == false);
                            Console.WriteLine("New Details: \n");
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("\nSurname: ");
                            string surname = Console.ReadLine();
                            Console.Write("\nEmail");
                            string email = Console.ReadLine();
                            bl.EditStudent(Iid,name,surname,email);
                            break;
                        default:
                            TeacherMenu();
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Dont enter char pls :)",e);

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
        public static void EditStudent() 
        {

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
