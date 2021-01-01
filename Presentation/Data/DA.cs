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
        public Student ExistingCourseID(int courseID)
        {
            var checkCourseID = from Course in db.Students
                                where Course.GroupID == courseID
                                select Course;

            return checkCourseID.FirstOrDefault();
        }
        public Teacher Login(string username)
        {
            var checkCourseID = from teacher in db.Teachers
                                where teacher.Username == username
                                select teacher;

            return checkCourseID.FirstOrDefault();
        }
        public Teacher Password(string username,string password)
        {
            var checkCourseID = from teacher in db.Teachers
                                where teacher.Username == username
                                where teacher.Password == password
                                select teacher;

            return checkCourseID.FirstOrDefault();
        }
    }

}
