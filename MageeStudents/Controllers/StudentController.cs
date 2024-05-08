using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MageeStudents.Data;
using MageeStudents.Interfaces;
using MageeStudents.Models;
using MageeStudents.Service;
using MageeStudents.ViewModel;

namespace MageeStudents.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Students> students = _studentRepository.RetrieveAllStudents();
            return View(students);
        }

        // button click from page (New Student)
        public IActionResult Create()
        {
            Students students = new Students();
            return View(students);
        }

        [HttpPost]
        public IActionResult Create(Students newStudent)
        {

            if (ModelState.IsValid)
            {
                _studentRepository.InsertStudent(newStudent);
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(Students student)
        {
            try
            {
                _studentRepository.EditStudent(student);
                //return View(student);
                TempData["SuccessMsg"] = "Student (" + student.FirstName + " " + student.Surname + ") updated successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["SuccessMsg"] = "Student (" + student.FirstName + " " + student.Surname + ") was not updated successfully. Error " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int Id)
        {
            Students? student = _studentRepository.RetrieveStudentById(Id);
            return View(student);
        }
        
        public IActionResult Delete(int Id)
        {
            Students student = _studentRepository.RetrieveStudentById(Id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int Id)
        {
            var isDeleted = _studentRepository.DeleteStudent(Id);
            if (isDeleted) TempData["SuccessMsg"] = "Student (" + Id + ") deleted successfully.";

            return RedirectToAction("Index");
        }
    }
}
