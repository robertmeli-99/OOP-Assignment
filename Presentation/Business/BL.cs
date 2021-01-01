using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;

namespace Business
{
    public class BL
    {
        static DA dl = new DA();

        public string StudentsIncourse(int courseID)
        {
            if (dl.ExistingCourseID(courseID) != null)
            {
                string result = "Students in Course " + courseID;
                foreach (Student s in dl.StudentsInCourse(courseID))
                {
                    result += "\nName: " + s.Name + " " + " Surname: " + s.Surname;
                }
                return result;
            }

            return "Course does not exist!";
        }

        public string Login(string username)
        {
            if (dl.Login(username) != null)
            {
                return "Username: "+ username+" Exists";
            }
            return "Username does not exist";
        }
        public string Password(string username, string password)
        {
            if (dl.Password(username,password) != null)
            {
                return "Logged in";
            }
            return "Re enter cridentials please!";
        }
    }
}
