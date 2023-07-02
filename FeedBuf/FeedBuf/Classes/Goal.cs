using Repository;
using System.Windows.Forms;

// This class represents a goal set by a student.
public class Goal
{
    // The ID of the goal.
    public int ID { get; set; }

    // The ID of the student who set the goal.
    public int StudentID { get; set; }

    // The priority level of the goal, e.g. "high", "medium", "low".
    public string Priority { get; set; }

    // The text of the goal.
    public string CreatedGoal { get; set; }

    // The time period for which the goal is set, e.g. "this week", "this month", "this semester".
    public string Time { get; set; }

    // The status of the goal, e.g. "in progress", "completed", "failed".
    public string Status { get; set; }

    // A list of subgoals associated with this goal.
    public List<SubGoal> ListOfSubGoal = new List<SubGoal>();

    GoalRepo goalrepo = new GoalRepo();

    // Creates a new instance of Goal with the given properties and no subgoals.
    public Goal(int iD, int studentID, string priority, string goal, string time, string status)
    {
        ID = iD;
        StudentID = studentID;
        Priority = priority;
        CreatedGoal = goal;
        Time = time;
        Status = status;
    }

    public void AddGoal(int id, string priority, string createdgoal, string time, string status)
    {
        goalrepo.AddGoal(id, priority, createdgoal, time, status);
    }

    public List<Goal> GetGoals(int id)
    {
        goalrepo.goals.Clear();
        List<Goal> goals = goalrepo.GetGoalsFromDatabase(id);
        return goals;
    }

    public void GetSingleGoalByID(int id)
    {
        goalrepo.GetSingleGoalByID(id);
    }

    public void DeleteGoal(int id)
    {
        goalrepo.DeleteGoal(id);
    }

    public void UpdateGoalStatus(int id, string status)
    {
        goalrepo.UpdateGoalStatus(id, status);
    }
}

