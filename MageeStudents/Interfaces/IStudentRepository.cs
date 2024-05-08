using MageeStudents.Models;
using Microsoft.AspNetCore.Mvc;

namespace MageeStudents.Interfaces
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
