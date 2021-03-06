﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _33AdoNet.Data;

namespace _33bAdoNet.Data.tests
{
    [TestClass]
    public class CRUDtests
    {
        [TestMethod]
        public void TeacherList()
        {
            //Arrange
            var db = new DbAccess();

            //Act
            var teachers = db.GetTeachers();
            //Assert
            Assert.AreEqual(2, teachers.Count);
        }
        [TestMethod]
        public void TeacherCreate()
        {
            //Arrange
            var db = new DbAccess();

            var teacher = new Teachers()
            {
                FirstName="Teszt"
                ,LastName="Elek"
                ,ClassCode="191"
                ,Subject_Id=1
            };
            var id = db.CreateTeacher(teacher);

            Assert.AreNotEqual(0, id);
            var teacherSaved = db.ReadTeacher(id);
            Assert.IsNotNull(teacherSaved);

            var deletedLines = db.DeleteTeacher(id);
            Assert.AreEqual(1, deletedLines);

        }
        [TestMethod]
        public void TeacherRead()
        {
        }
        [TestMethod]
        public void TeacherUpdate()
        {
            //Arrange
            var db = new DbAccess();

            //Act
            var teacher = db.ReadTeacher(1);

            teacher.FirstName = "Teszt1";
            teacher.LastName = "Teszt1_last";
            teacher.ClassCode = "191";
            teacher.Subject_Id = 2;

            int updatedTeacher=db.UpdateTeacher(teacher);
            //Assert
            Assert.AreEqual(1, updatedTeacher);
        }
        [TestMethod]
        public void TeacherDelete()
        {
        }
    }
}
