using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Data
{
    public class DA
    {
        // conect db
        OPPAssignmentEntities db = new OPPAssignmentEntities();
        public List<Student> StudentsInCourse(int StudentID)
        {

            List<Student> studentList = new List<Student>(from student in db.Students
                                                          where student.GroupID == StudentID
                                                          select student);
            return studentList;
        }
        public Student ExistingCourseID(int StudentID)
        {
            var checkStudentID = from Students in db.Students
                                 where Students.GroupID == StudentID
                                 select Students;

            return checkStudentID.FirstOrDefault();
        }
        public Teacher ExistingTeacherID(int TeacherID)
        {
            var checkTeacherID = from Teachers in db.Teachers
                                 where Teachers.TeacherID == TeacherID
                                 select Teachers;

            return checkTeacherID.FirstOrDefault();
        }
        public Group ExistingGroupID(int GroupID)
        {
            var checkGroupID = from Group in db.Groups
                               where Group.GroupID == GroupID
                               select Group;

            return checkGroupID.FirstOrDefault();
        }
        public Teacher Login(string username)
        {
            var checkLogin = from teacher in db.Teachers
                             where teacher.Username == username
                             select teacher;

            return checkLogin.FirstOrDefault();
        }

        public List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>
                                      (from Group in db.Groups
                                       select Group);
            return groups;
        }
        public Teacher Password(string username, string password)
        {
            var checkPassUsername = from teacher in db.Teachers
                                    where teacher.Username == username
                                    where teacher.Password == password
                                    select teacher;

            return checkPassUsername.FirstOrDefault();
        }

        public void AddAttendance(int StudentID, int LessonID, bool Attendance)
        {
            StudentAttendance sa = new StudentAttendance(LessonID, Attendance, StudentID);
            db.StudentAttendances.Add(sa);
            db.SaveChanges();
        }
        public void AddLesson(int GroupID, DateTime da, int TeacherID)
        {
            Lesson lesson = new Lesson(GroupID, da, TeacherID);
            db.Lessons.Add(lesson);
            db.SaveChanges();
        }
        public Lesson GetIDLesson(int TeacherID)
        {
            var GetLessonID = from teacher in db.Lessons
                              where teacher.TeacherID == TeacherID
                              orderby teacher.LessonID descending
                              select teacher;
            return GetLessonID.FirstOrDefault();
        }
        public void addGroup(string Name, string CourseName)
        {
            Group gp = new Group(Name,CourseName);
            db.Groups.Add(gp);
            db.SaveChanges();
        }
        public void addStudent(string Name, string Surname, string Email, int GroupID)
        {
            Student st = new Student(Name,Surname,Email,GroupID);
            db.Students.Add(st);
            db.SaveChanges();
        }
        public void addTeacher(string Username, string Password, string Name, string Surname, string Email)
        {
            Teacher te = new Teacher(Username,Password,Name,Surname,Email);
            db.Teachers.Add(te);
            db.SaveChanges();
        }
        public void EditStudent(int id, string Name, string Surname, string Email)
        {
            Student st = db.Students.SingleOrDefault(s => s.StudentID == id);

            st.Name = Name;
            st.Surname = Surname;
            st.Email = Email;

            db.SaveChanges();
        }
        public int SubmittedAttendances(int year, int month, int day, int TeacherID)
        {
            var GetLessonID = from lesson in db.Lessons
                              join attandance in db.StudentAttendances
                              on lesson.LessonID equals attandance.LessonID
                              where lesson.DateTime.Value.Year == year && lesson.DateTime.Value.Month == month && lesson.DateTime.Value.Day == day && lesson.TeacherID == TeacherID
                              select attandance;
            return GetLessonID.Count();
        }
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>
                                      (from S in db.Students
                                       select S);
            return students;
        }
        public Student ExistingStudentID(int StudentID)
        {
            var checkStudentID = from S in db.Students
                               where S.StudentID == StudentID
                               select S;

            return checkStudentID.FirstOrDefault();
        }
        public double GetTotalAttandance(int StudentID)
        {
            var TotalAttandance = from S in db.StudentAttendances
                                 where S.StudentID == StudentID
                                 select S;
            return TotalAttandance.Count()+.0;
        }
        public double GetTotalAttandancePres(int StudentID)
        {
            var TotalAttandancePresent = from S in db.StudentAttendances
                                         where S.StudentID == StudentID && S.Presence == true
                                         select S;

            return TotalAttandancePresent.Count()+.0;
        }
        public List<StudentAttendance> GetStudentPersantage(int id)
        {
            List<StudentAttendance> s = new List<StudentAttendance>
                                      (from S in db.StudentAttendances
                                       where S.StudentID == id
                                       select S);
            return s;
        }
        public List<Student> GetStudentGroup(int id)
        {
            List<Student> s = new List<Student>
                                      (from S in db.Students
                                       where S.GroupID == id
                                       select S);
            return s;
        }
        public int ExistingUName(string username)
        {
            List<Teacher> s = new List<Teacher>
                                      (from S in db.Teachers
                                       where S.Username == username
                                       select S);
            return s.Count();
        }

    }
}
