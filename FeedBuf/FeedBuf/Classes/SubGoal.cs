using Repository;

// This class represents a subgoal associated with a larger goal.
public class SubGoal
{
    // The ID of the subgoal.
    public int ID { get; set; }

    // The ID of the goal to which the subgoal belongs.
    public int GoalID { get; set; }

    // The text of the subgoal.
    public string Subgoal { get; set; }

    // The status of the subgoal, e.g. "in progress", "completed", "failed".
    public string Status { get; set; }

    SubGoalRepo SubGoalRepo = new SubGoalRepo();

    // Creates a new instance of SubGoal with the given properties.
    public SubGoal(int iD, int goalId, string subgoal, string status)
    {
        ID = iD;
        GoalID = goalId;
        Subgoal = subgoal;
        Status = status;
    }

    public List<SubGoal> GetSubgoals(int id)
    {
        SubGoalRepo.subGoals.Clear();
        List<SubGoal> subgoalList = SubGoalRepo.GetSubGoalsFromDatabase(id);
        return subgoalList;
    }

    public void AddSubGoal(int id, string subgoal,string status)
    {
        SubGoalRepo.AddSubGoal(id, subgoal, status);
    }

    public void DeleteSubGoal(int id)
    {
        SubGoalRepo.DeleteSubGoal(id);
    }

}
