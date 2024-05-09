using InternationalStudents.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternationalStudents.Interfaces
{
    public interface IStudentRepository
    {
        List<Students> RetrieveAllStudents();
        Students? RetrieveStudentById(int studentId);
        bool DeleteStudent(int id);
        bool EditStudent(Students student);
        bool InsertStudent(Students student);
    }
}
