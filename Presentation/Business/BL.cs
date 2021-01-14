using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;

namespace Business
{
    class GetID
    {
        public int ID { get; set; }
        public GetID()
        {
            ID = 0;
        }
    }
    public class BL
    {
        static DA dl = new DA();
        static GetID id = new GetID();

        public string Login(string username)
        {
            if (dl.Login(username) != null)
            {
                return "Username: " + username + " Exists";

            }
            return "Username does not exist";
        }
        public string Password(string username, string password)
        {

            if (dl.Password(username, password) != null)
            {
                id.ID = dl.Password(username, password).TeacherID;
                return "Logged in";
            }

            return "Re enter cridentials please!";
        }

        public List<Student> getStudentsInGroup(int id)
        {
            return dl.StudentsInCourse(id);
        }

        public void addAttendance(int StudentID, int LessonID, string Attendance)
        {
            if (Attendance.ToLower() == "p")
            {
                dl.AddAttendance(StudentID, LessonID, true);
            }
            else if (Attendance.ToLower() == "a")
            {
                dl.AddAttendance(StudentID, LessonID, false);
            }
        }
        public string Getgroups()
        {
            string result = "";
            foreach (Group g in dl.GetGroups())
            { 
                result += "\n" + g.GroupID + "    " + g.Name + "              " + g.Course;
            }
            return result;
        }
        public void EnterLesson(int GroupID,DateTime date)
        {
            dl.AddLesson(GroupID,date,id.ID);
        }

        public int GetLessonID()
        {
            int lId = dl.GetIDLesson(id.ID).LessonID;
            return lId;
        }
        public bool CheckGroupID(int id)
        {
            if (dl.ExistingGroupID(id) != null)
                return true;
            else
                return false;
        }
        public void AddGroup(string Name, string CourseName)
        {
            dl.addGroup(Name,CourseName);
        }
        public void AddStudent(string Name,string Surname, string Email, int GroupID)
        {
            dl.addStudent(Name, Surname, Email, GroupID);
        }
        public void EditStudent(int id, string Name, string Surname, string Email)
        {
            dl.EditStudent(id, Name, Surname, Email);
        }
        public string SubmittedAttendances(int year, int month, int day)
        {
            int count = dl.SubmittedAttendances(year,month,day,id.ID);
            return $"Number of attendances submitted: {count}";
        }
        public bool CheckStudentID(int id)
        {
            if (dl.ExistingStudentID(id) != null)
                return true;
            else
                return false;
        }
        public string GetStudents()
        {
            string result = "";
            foreach (Student s in dl.GetStudents())
            {
                result += "\n" + s.StudentID + "    " + s.Name + "              " + s.Surname + "              " + s.Email;
            }
            return result;
        }
    }
}
