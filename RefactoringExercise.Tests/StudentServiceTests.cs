using System;
using NSubstitute;
using NUnit.Framework;
using RefactoringExercise.Core.Exceptions;

namespace RefactoringExercise.Tests
{
    [TestFixture]
    public class StudentServiceTests
    {
        private const string TestEmail = "test@email.com";

        private ILogger _logger;
        private IStudentFactory _studentFactory;
        private IStudentRepository _studentRepository;
        private IUniversityRepository _universityRepository;
        private StudentWriterService _studentService;

        [SetUp]
        public void SetUp()
        {
            _logger = Substitute.For<ILogger>();
            _studentFactory = Substitute.For<IStudentFactory>();
            _studentRepository = Substitute.For<IStudentRepository>();
            _universityRepository = Substitute.For<IUniversityRepository>();

            _universityRepository.GetById(Arg.Any<Guid>()).Returns(callInfo => 
                new University(callInfo.Arg<Guid>(), "Test university", Package.Standard));

            _studentService = new StudentWriterService(_studentRepository, _universityRepository, _logger, _studentFactory);
        }

        [Test]
        public void DuplicateEmail()
        {
            _studentRepository.Exists("test@email.com").Returns(true);
            Assert.Throws<DomainException>(() => _studentService.Add("test@email.com", Guid.NewGuid()));
        }

        [Test]
        public void Logging()
        {
            _studentService.Add(TestEmail, Guid.NewGuid());
            _logger.Received().Log("Log: Start add student with email 'test@email.com'");
            _logger.Received().Log("Log: End add student with email 'test@email.com'");
        }

        [Test]
        public void StudentCreation_Bak()
        {
            Guid universityId = Guid.NewGuid();
            Student expectedStudent = new StandardStudent(TestEmail, universityId);

            _studentFactory.Create(TestEmail, universityId, Package.Standard).Returns(expectedStudent);
            _studentService.Add(TestEmail, universityId);

            _studentRepository.Received().Add(expectedStudent);
        }
    }
}
