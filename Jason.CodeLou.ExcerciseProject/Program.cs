using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;


namespace Jason.CodeLou.ExcerciseProject
{
    class Program
    {
        static string _studentRepositoryPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\students.json";
        static List<Student> studentList = File.Exists(_studentRepositoryPath) ? Read() : new List<Student>();
        static void Save(){
            using (var file = File.CreateText(_studentRepositoryPath)){
                file.WriteAsync(JsonSerializer.Serialize(studentList));
            }
        }
        static List<Student> Read(){
            var studentString = File.ReadAllText(_studentRepositoryPath);
            return JsonSerializer.Deserialize<List<Student>>(studentString);
        }
        static void Main(string[] args){
            bool AppRunning = true;
            
            while (AppRunning){ 
                DisplayMenu();
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1){
                    GetStudentInput(); 
                }

                else if (input == 2){
                    DisplayStudents(studentList); 
                }
                
                else if (input == 3){ 
                    SearchStudents(studentList); 
                }
                else{
                    AppRunning = false;
                }   
            }
        }
        public static void GetStudentInput(){
            var studentRecord = new Student();
            while (true){
                Console.WriteLine("Enter Student Id");
                var studentIdSuccess = Int32.TryParse(Console.ReadLine(), out var studentId);
                if (studentIdSuccess){
                    studentRecord.StudentId = studentId;
                    break;
                }
            }
            Console.WriteLine("Enter First Name");
            var studentFirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            var studentLastName = Console.ReadLine();
            var studentName = studentFirstName + studentLastName;
            Console.WriteLine("Enter Class Name");
            var className = Console.ReadLine();
            Console.WriteLine("Enter Last Class Completed");
            var lastClass = Console.ReadLine();
            while (true){
                Console.WriteLine("Enter Last Class Completed Date in format MM/dd/YYYY");
                var lastCompletedDateSuccess = DateTimeOffset.TryParse(Console.ReadLine(),out var lastCompletedOn);
                if (lastCompletedDateSuccess){
                    studentRecord.LastClassCompletedOn = lastCompletedOn;
                    break;
                }
            }
            while (true){
                Console.WriteLine("Enter Start Date in format MM/dd/YYYY");
                var startDateSuccess = DateTimeOffset.TryParse(Console.ReadLine(),out var startDate);
                if (startDateSuccess){
                    studentRecord.StartDate = startDate;
                    break;
                }
            }
            
            studentRecord.FirstName = studentFirstName;
            studentRecord.LastName = studentLastName;
            studentRecord.StudentName = studentName;
            studentRecord.ClassName = className;
            studentRecord.LastClassCompleted = lastClass;
            
            Console.WriteLine($"Student Id | Name |  Class "); ;
            Console.WriteLine($"{studentRecord.StudentId} | {studentRecord.FirstName} {studentRecord.LastName} | {studentRecord.ClassName} "); ;
            Console.ReadKey();

            studentList.Add(studentRecord);
            Save();
        }
        static void DisplayStudents(List<Student> studentList){
            studentList.ForEach(s =>{
                Console.WriteLine(s.studentRecord);
            });
        }
        
        static void SearchStudents(List<Student> studentList) {
                Console.WriteLine("Search String:");
                var searchString = Console.ReadLine();
                var students = studentList.Where(s => s.StudentName.Contains(searchString)).ToList();
                if (students.Any()) {
                    students.ForEach(s =>{
                        Console.WriteLine(s.studentRecord);
                    });
                }
            }

        static void DisplayMenu(){
            Console.WriteLine("Menu");
            Console.WriteLine("1. New Student");
            Console.WriteLine("2. List Students");
            Console.WriteLine("3. Find Student by name");
            Console.WriteLine("4. Exit");
         }
    }
}