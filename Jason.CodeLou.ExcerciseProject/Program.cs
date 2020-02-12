using System;
using System.Collections.Generic;
using System.Linq;

namespace Jason.CodeLou.ExcerciseProject
{
    class Program
    {
        static List<Student> studentsList = new List<Student>();

        static void Main(string[] args)
        {
            var inputtingStudent = true;

            while (inputtingStudent)
            {
                DisplayMenu();
                var option = Console.ReadLine();

                switch (int.Parse(option))
                {
                    case 1:
                        InputStudent();
                        break;
                    case 2:
                        DisplayStudents();

                        break;
                    case 3:
                        SearchStudents();
                        break;
                    case 4:
                        inputtingStudent = false;
                        break;
                }
                Console.ReadLine();
            }
        }

        private static void DisplayStudents(IEnumerable<Student> students)
        {
            if (students.Any()) 
            {
                Console.WriteLine($"Student Id | Name |  Class ");
                studentsList.ForEach(x =>
                {
                    Console.WriteLine(x.StudentDisplay);
                });
            }
            else 
            {
                System.Console.WriteLine("No students found.");
            }
        }
        
        private static void DisplayStudents() => DisplayStudents(studentsList);       

        private static void SearchStudents()
        {
            Console.WriteLine("Search string:");
            var searchString = Console.ReadLine();
            var students = studentsList.Where(x => x.FullName.Contains(searchString));
            DisplayStudents(students);
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Select from the following operations:");
            Console.WriteLine("1: Enter new student");
            Console.WriteLine("2: List all students");
            Console.WriteLine("3: Search for student by name");
            Console.WriteLine("4: Exit");
        }

        static void InputStudent()
        {
            var student = new Student();
            while (true) 
            {
                Console.WriteLine("Enter Student Id");
                var studentIdSuccessful = int.TryParse(Console.ReadLine(), out var studentId);
                if (studentIdSuccessful) 
                {
                    student.StudentId = studentId;    
                    break;
                }
                Console.WriteLine("Enter Last Class Completed in Format MM/DD/YYYY");
                var lastClassCompletedOnSuccessful = DateTimeOffset.TryParse(Console.ReadLine(), out var lastClassCompletedOn);
                if (lastClassCompletedOnSuccessful) 
                {
                    student.LastClassCompletedOn = lastClassCompletedOn;    
                    break;
                }
                Console.WriteLine("Enter Start Date in Format MM/DD/YY");
                var startDateSuccessful = DateTime.TryParse(Console.ReadLine(), out var startDate);
                if (startDateSuccessful) 
                {
                    student.StartDate = startDate;    
                    break;
                }
            }
            Console.WriteLine("Enter First Name");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Enter Class Name");
            student.ClassName = Console.ReadLine();
            
            studentsList.Add(student);
        }
        //static List<Student> studentsList = new List<Student>();
    }
}
