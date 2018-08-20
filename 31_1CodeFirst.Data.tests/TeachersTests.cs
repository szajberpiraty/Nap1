using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _31CodeFirst.Data.models;
using System.Linq;

namespace _31_1CodeFirst.Data.tests
{
    [TestClass]
    public class TeachersTests
    {
        [TestMethod]
        public void TeachersTableShouldBeEmpty()
        {
            //Arrange
            var db = new SchoolContext();
            //Act
            var count = db.Teachers.Count();
            //Assert
            Assert.AreEqual(0,count);
        }

        [TestMethod]
        public void AddTeachersToTeachersTable_ShouldBeAppear()
        {
            //Arrange
            var db = new SchoolContext();
  
            var teacher = new Teacher()
            {
                ClassCode="1/9/1",
                LastName="Béla",
                FirstName="Zulu"
            };

            db.Teachers.Add(teacher);//Itt az Id értéke az int default értéke==0
            db.SaveChanges();//Itt visszajön az adatbázisból, és megkapjuk a lementett rekord azonodítóját
            //Act
            //Egy lehetséges megoldás, megkeresi az elsőt, ha nincs, akkor exceptiont dob
            //var teachersaved = db.Teachers.First(
            //    x=>x.FirstName==teacher.FirstName
            //     &&
            //    x.LastName==teacher.LastName
            //    );
            
            //Egy lehetséges megoldás, megkeresi az elsőt, ha nincs, akkor nullt ad vissza
            //var teachersaved = db.Teachers.FirstOrDefault(
            //   x => x.FirstName == teacher.FirstName
            //    &&
            //   x.LastName == teacher.LastName
            //   );

            var teachersaved = db.Teachers.FirstOrDefault(
            
                x => x.Id == teacher.Id
             );

            //Assert
            Assert.IsNotNull(teachersaved);
            Assert.AreEqual(teacher.Id, teachersaved.Id);
            Assert.AreEqual(teacher.ClassCode, teachersaved.ClassCode);
            Assert.AreEqual(teacher.FirstName, teachersaved.FirstName);
            Assert.AreEqual(teacher.LastName, teachersaved.LastName);

            //TearDown, takarítunk a teszt után
            db.Teachers.Remove(teachersaved);
            db.SaveChanges();
        }
    }
}
