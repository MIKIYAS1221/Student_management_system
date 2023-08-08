using System.Text.Json;
namespace Student_management_system;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class StudentList<T> where T : Student
{
    private List<T> _students = new();

    public void AddStudent(T student)
    {
        _students.Add(student);
    }
    
    public List<T> GetAll()
    {
        return _students;
    }


    public T? GetStudentByName(string name)
    {
        var student = _students.FirstOrDefault(s => s.Name == name);
        return student;
    }

    public T? GetStudentById(int rollNumber)
    {
        return _students.FirstOrDefault(s => s.RollNumber == rollNumber);
    }

    public void DisplayAllStudents()
    {
        foreach (var student in _students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
        }
    }

    public void SerializeToJson(string filePath)
    {
        string json = JsonConvert.SerializeObject(_students, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        });
        File.WriteAllText(filePath, json);
    }

    public void DeserializeFromJson(string filePath)
    {
        string json = File.ReadAllText(filePath);
        _students = JsonConvert.DeserializeObject<List<T>>(json);
    }
}
