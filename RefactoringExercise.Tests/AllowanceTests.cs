using System;
using NUnit.Framework;
using RefactoringExercise.Core.Models;

namespace RefactoringExercise.Tests
{
    [TestFixture]
    public class AllowanceTests
    {
        private const string TestEmail = "test@email.com";
    
        [Test]
        public void StandardStudent()
        {
            LimitedStudent student = new StandardStudent(TestEmail, Guid.NewGuid());
            Assert.AreEqual(10, student.MonthlyEbookAllowance);
        }

        [Test]
        public void StandardStudentWithBonus()
        {
            LimitedStudent student = new StandardStudent(TestEmail, Guid.NewGuid());
            student.AddBonusAllowance();
            Assert.AreEqual(15, student.MonthlyEbookAllowance);
        }

        [Test]
        public void PremiumStudent()
        {
            LimitedStudent student = new PremiumStudent(TestEmail, Guid.NewGuid());
            Assert.AreEqual(20, student.MonthlyEbookAllowance);
        }

        [Test]
        public void PremiumStudentWithBonus()
        {
            LimitedStudent student = new PremiumStudent(TestEmail, Guid.NewGuid());
            student.AddBonusAllowance();
            Assert.AreEqual(30, student.MonthlyEbookAllowance);
        }

        [Test]
        public void UnlimitedStudent()
        {
            Student student = new UnlimitedStudent(TestEmail, Guid.NewGuid());
            Assert.AreEqual(0, student.MonthlyEbookAllowance);
        }
    }
}
