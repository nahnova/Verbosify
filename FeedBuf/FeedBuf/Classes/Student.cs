using Repository;
using System;
using System.Collections.Generic;

// This class represents a student.
public class Student
{
    // The ID of the student.
    public int ID { get; set; }

    // The first name of the student.
    public string FirstName { get; set; }

    // The last name of the student.
    public string LastName { get; set; }

    // The email address of the student.
    public string Email { get; set; }

    // The gender of the student.
    public string Gender { get; set; }

    // The password of the student.
    public string Password { get; set; }

    // The level of the student.
    public int StudentLevel { get; set; }

    // The xpAmount of the student.
    public int XpAmount { get; set; }

    // The xpProgression of the student.
    public int XpProgression { get; set; }

    // The rank of the student.
    public string Rank { get; set; }

    // A list of feedback given by the student.
    public List<Feedback> Feedback { get; set; }

    // A list of goals set by the student.
    public List<Goal> Goal { get; set; }

    // A list of groups the student belongs to.
    public List<Group> Group { get; set; }

    public StudentsRepo StudentRepo = new StudentsRepo();

    // Creates a new instance of Student with the given minimal properties.
    public Student(int iD, string firstName, string lastName, string email, string gender, string password, int studentLevel, int xpAmount, int xpProgression, string rank)
    {
        ID = iD;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Gender = gender;
        Password = password;
        StudentLevel = studentLevel;
        XpAmount = xpAmount;
        XpProgression = xpProgression;
        Rank = rank;
    }

    public void AddStudent(string firstName, string lastName, string email, string gender, string password)
    {
        StudentRepo.AddStudent(firstName, lastName, email, gender, password);
    }

    public Student GetSinglestudent(int id)
    {
        Student student = StudentRepo.GetSinglestudentByID(id);
        return student;
    }

    public void UpdateStudent(int id, string firstName, string lastName, string email, string gender)
    {
        StudentRepo.UpdateStudent(id, firstName, lastName, email, gender);
    }

    public void UpdateXpAmount(int id, int xpAmount, int xpProgression)
    {
        StudentRepo.UpdateXpAmount(id, xpAmount, xpProgression);
    }

}

