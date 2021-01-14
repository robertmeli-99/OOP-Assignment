using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class TypeLayer
    {
    }
    public partial class Group
    {
        public Group(string Name, string Course)
        {
            this.Name = Name;
            this.Course = Course;
        }
    }
    public partial class StudentAttendance
    {
        public StudentAttendance(int pLessonID, bool pPresence, int pStudentID)
        {
            LessonID = pLessonID;
            Presence = pPresence;
            StudentID = pStudentID;
        }
    }
    public partial class Lesson
        {
        public Lesson(int pGroupID, DateTime pLessonDate,int pTeacherID )
        {
            GroupID = pGroupID;
            DateTime = pLessonDate;
            TeacherID = pTeacherID;
        }
    }
    public partial class Student
        {
        public Student(string pName, string pSurname, string pEmail, int pGroupID)
        {
            Name = pName;
            Surname = pSurname;
            Email = pEmail;
            GroupID = pGroupID;
        }
    }
    public partial class Teacher
    {
        public Teacher(string pUsername, string pPassword, string pName, string pSurname, string pEmail)
        {
            Username = pUsername;
            Password = pPassword;
            Name = pName;
            Surname = pSurname;
            Email = pEmail;
        }
    }
}

