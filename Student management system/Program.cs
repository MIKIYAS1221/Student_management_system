// See https://aka.ms/new-console-template for more information

using System;

namespace Student_management_system
{
    class Program
    {
        private static void Main(string[] args)
        {
            var studentList = new StudentList<Student>();

            // Add new students
            studentList.AddStudent(new Student("John", 18, 1, "A+"));
            studentList.AddStudent(new Student("Jane", 19, 2, "A"));
            

            // Search for students
            Student? john = studentList.GetStudentByName("John");
            if (john != null)
            {
                Console.WriteLine("The student is found.");
                Console.WriteLine($"Name: {john.Name}, Age: {john.Age}, Roll Number: {john.RollNumber}, Grade: {john.Grade}");
            }
            Student? jane = studentList.GetStudentById(2);
            if (jane != null)
            {
                Console.WriteLine("The student is found.");
                Console.WriteLine($"Name: {jane.Name}, Age: {jane.Age}, Roll Number: {jane.RollNumber}, Grade: {jane.Grade}");
            }

            // Display all students
            Console.WriteLine("All students:");
            studentList.DisplayAllStudents();

            // Serialize and deserialize student data to/from a JSON file
            studentList.SerializeToJson("students.json");
            studentList.DeserializeFromJson("students.json");
        }
    }
}