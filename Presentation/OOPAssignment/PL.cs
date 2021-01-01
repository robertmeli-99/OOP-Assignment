using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

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
            else if (choice == 3)
            {
                Test();

            }
            Console.ReadKey();
        }
        public static void mainmenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("=========");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.WriteLine("3. Test");
        }
        public static void exit()
        {
            Environment.Exit(0);
        }
        public static void Test()
        {
            Console.WriteLine(bl.StudentsIncourse(2));
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
                    mainmenu();
                }

            }
            else
            {
                mainmenu();
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
            Console.WriteLine("4. Check a student's attendance percentage:");
            Console.WriteLine("5. Get all attendances submitted on a particular day");
            Console.WriteLine("6. Edit Student");

        }
        public static void correctLogin()
        {

        }
        public static void EditStudent() 
        {

        }

        public static void addTeacher()
        {

        }
    }
}
