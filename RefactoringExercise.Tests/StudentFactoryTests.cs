using System;
using NUnit.Framework;

namespace RefactoringExercise.Tests
{
    [TestFixture]
    public class StudentFactoryTests
    {
        private const string TestEmail = "test@email.com";
        
        [Test]
        public void BasicFields()
        {
            StudentFactory studentFactory = new StudentFactory();
            Guid guid = Guid.NewGuid();
            Student student = studentFactory.Create(TestEmail, guid, Package.Standard);
            Assert.AreEqual(TestEmail, student.EmailAddress);
            Assert.AreEqual(guid, student.UniversityId);
        }

        [Test]
        public void StandardStudent()
        {
            StudentFactory studentFactory = new StudentFactory();
            Guid guid = Guid.NewGuid();
            Student student = studentFactory.Create(TestEmail, guid, Package.Standard);
            Assert.IsTrue(student is StandardStudent);
        }

        [Test]
        public void PremiumStudent()
        {
            StudentFactory studentFactory = new StudentFactory();
            Guid guid = Guid.NewGuid();
            Student student = studentFactory.Create("test@email.com", guid, Package.Premium);
            Assert.IsTrue(student is PremiumStudent);
        }
    }
}
