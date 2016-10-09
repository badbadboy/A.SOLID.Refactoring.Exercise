using System;

namespace RefactoringExercise
{
	public class StudentFactory : IStudentFactory
	{
		public Student Create(string emailAddress, Guid universityId, Package package)
		{
			switch(package)
			{
				case Package.Standard: return new StandardStudent(emailAddress, universityId);
				case Package.Premium: return new PremiumStudent(emailAddress, universityId);
				default: throw new NotImplementedException("There is no associated student for this package");
			}
		}
	}
}
