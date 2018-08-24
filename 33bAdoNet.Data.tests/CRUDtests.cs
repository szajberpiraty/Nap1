using System;
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
        }
        [TestMethod]
        public void TeacherRead()
        {
        }
        [TestMethod]
        public void TeacherUpdate()
        {
        }
        [TestMethod]
        public void TeacherDelete()
        {
        }
    }
}
