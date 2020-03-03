using System;
using System.Collections;
using System.Text;
using System.Linq;
using System.Collections.Generic;
namespace Jason.CodeLou.ExcerciseProject
{
    public class Student
    {
        public string studentRecord => $"Student Id | Name |  Class " +
                                        $"{StudentId} | {FirstName} {LastName} | {ClassName} "; 
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string LastClassCompleted { get; set; }
        public DateTimeOffset LastClassCompletedOn { get; set; }

        
    }
}