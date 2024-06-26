﻿using InternationalStudents.Database;
using InternationalStudents.Interfaces;
using InternationalStudents.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace InternationalStudents.Service
{
    // CRUD actions
    public class StudentRepository : IStudentRepository
    {
        // class variable
        private readonly StudentContext _context;

        // constructor - inject context
        public StudentRepository(StudentContext context) { _context = context; }

        public List<Students> RetrieveAllStudentsAsync()
        {
            return _context.Students.ToList();
        }

        public async Task<Students?> RetrieveStudentByIdAsync(int studentId)
        {
            return await _context.Students.FirstOrDefaultAsync(stu => stu.Id == studentId);
        }
        public async Task<Students> InsertStudentAsync(Students student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Students> EditStudentAsync(Students updatedStudent)
        {
            try
            {
                var student = await _context.Students.FindAsync(updatedStudent.Id);
                student.FirstName = updatedStudent.FirstName;
                student.Surname = updatedStudent.Surname;
                student.Telephone = updatedStudent.Telephone;
                student.Email = updatedStudent.Email;
                student.CountryOfOrigin = updatedStudent.CountryOfOrigin;
                student.Age = updatedStudent.Age;


                // ToDo - other fields

                _context.Update(student);
                await _context.SaveChangesAsync();

                return student;
            }
            catch (Exception)
            {
                if (!IsStudentsExist(updatedStudent.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public bool EditStudent(Students updatedStudent)
        {
            try
            {
                var student = _context.Students.Find(updatedStudent.Id);

                student.FirstName = updatedStudent.FirstName;
                student.Surname = updatedStudent.Surname;
                student.Telephone = updatedStudent.Telephone;
                student.Email = updatedStudent.Email;
                student.CountryOfOrigin = updatedStudent.CountryOfOrigin;
                student.Age = updatedStudent.Age;

                _context.Update(student);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertStudent(Students student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteStudent(int id)
        {
            if (IsStudentsExist(id))
            {
                var student = _context.Students.Find(id);
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Students> RetrieveAllStudents()
        {
            var students = _context.Students.ToList();
            return students;
        }

        public Students? RetrieveStudentById(int studentId)
        {
            return _context.Students.FirstOrDefault(stu => stu.Id == studentId);
        }


        #region Helper methods

        private bool IsStudentsExist(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        #endregion



    }
}
