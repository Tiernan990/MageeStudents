﻿using MVC6Crud.Database;
using MVC6Crud.Interfaces;
using MVC6Crud.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace MVC6Crud.Service
{
    // CRUD actions
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;

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


        public async Task<bool> DeleteStudentConfirmed(int id)
        {
            if (IsStudentsExist(id))
            {
                var student = await _context.Students.FindAsync(id);

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        #region Helper methods

        private bool IsStudentsExist(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        List<Students> IStudentRepository.RetrieveAllStudents()
        {
            var students = _context.Students.ToList();
            return students;
        }

        Students? IStudentRepository.RetrieveStudentById(int studentId)
        {
            return _context.Students.FirstOrDefault(stu => stu.Id == studentId);
        }

        bool IStudentRepository.DeleteStudentConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        void  IStudentRepository.EditStudent(Students updatedStudent)
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


                    // ToDo - other fields

                    _context.Update(student);
                    _context.SaveChanges();

                    //return student;
                }
                catch (Exception)
                {
                    if (!IsStudentsExist(updatedStudent.Id))
                    {
                       // return null;
                    }
                    else
                    {
                        throw;
                    }
            }
        }

        Students IStudentRepository.InsertStudent(Students student)
        {
            throw new NotImplementedException();
        }

        #endregion



    }
}