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
        public Group(int groupID, string Name, string Course)
        {
            GroupID = groupID;
            this.Name = Name;
            this.Course = Course;
        }
    }
    public partial class StudentAttendance
    {
        public StudentAttendance(int pAttendanceID, int pLessonID, bool pPresence, int pStudentID)
        {
            AttendanceID = pAttendanceID;
            LessonID = pLessonID;
            Presence = pPresence;
            StudentID = pStudentID;
        }
    }
    public partial class Lesson
        {
        public Lesson(int pLessonID, int pGroupID, DateTime pLessonDate,int pTeacherID )
        {
            LessonID = pLessonID;
            GroupID = pGroupID;
            DateTime = pLessonDate;
            TeacherID = pTeacherID;
        }
    }
    public partial class Student
        {
        public Student(int pStudentID, string pName, string pSurname, string pEmail, int pGroupID)
        {
            StudentID = pStudentID;
            Name = pName;
            Surname = pSurname;
            Email = pEmail;
            GroupID = pGroupID;
        }
    }
    public partial class Teacher
    {
        public Teacher(int pTeacherID, string pUsername, string pPassword, string pName, string pSurname, string pEmail)
        {
            TeacherID = pTeacherID;
            Username = pUsername;
            Password = pPassword;
            Name = pName;
            Surname = pSurname;
            Email = pEmail;
        }

    }

}

