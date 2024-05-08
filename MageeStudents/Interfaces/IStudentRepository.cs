using MVC6Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC6Crud.Interfaces
{
    public interface IStudentRepository
    {
        List<Students> RetrieveAllStudents();
        Students? RetrieveStudentById(int studentId);
        bool DeleteStudentConfirmed(int id);
        void EditStudent(Students student);
        Students InsertStudent(Students student);
    }
}
