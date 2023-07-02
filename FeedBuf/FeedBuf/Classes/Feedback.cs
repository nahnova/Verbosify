﻿using Repository;
using System;

// This class represents feedback given by a student to a teacher about a course.
public class Feedback
{
    // The ID of the feedback.
    public int ID { get; set; }

    // The teacher who received the feedback.
    public int TeacherID { get; set; }

    // The student who provided the feedback.
    public int StudentID { get; set; }

    // The date the feedback was given.
    public DateTime Date { get; set; }

    // The name of the course for which the feedback was given.
    public string Course { get; set; }

    // The feedback text provided by the student.
    public string GivenFeedback { get; set; }

    // The type of feedback, e.g. "positive", "negative", "suggestion", etc.
    public string Type { get; set; }

    public int GoalID { get; set; }

    public FeedbackRepo feedbackRepo = new FeedbackRepo();

    // Creates a new instance of Feedback with the given properties.
    public Feedback(int iD, int teacherID, int studentID, DateTime date, string course, string feedback, string type, int goalID)
    {
        ID = iD;
        TeacherID = teacherID;
        StudentID = studentID;
        Date = date;
        Course = course;
        GivenFeedback = feedback;
        Type = type;
        GoalID = goalID;
    }

    public List<Feedback> GetFeedback() 
    {
        List<Feedback> feedbackList = feedbackRepo.GetFeedbackFromDatabase();
        return feedbackList;
    }

    public void AddFeedback(int teacherId, int studentId, DateTime date, string course, string feedback, string type,int goalId)
    {
        feedbackRepo.AddFeedback(teacherId,studentId,date,course,feedback,type,goalId);
    }

    public void DeleteFeedback(int id)
    {
        feedbackRepo.DeleteFeedback(id);
    }
}
