using System;

namespace RefactoringExercise
{
	public class University
	{
	    public University(Guid id, string name, Package package)
	    {
	        Id = id;
	        Name = name;
	        Package = package;
	    }

	    public Guid Id { get; }
		public string Name { get; }
		public Package Package { get; }
	}
}