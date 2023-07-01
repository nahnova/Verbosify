namespace FeedBuf
{
    public partial class StudentSubGoalOverview : Form
    {
        public int ID { get; set; }
        public int DeleteId { get; set; }

        public SubGoal subGoal = new SubGoal(0,0,"","");

        public StudentSubGoalOverview(int Id)
        {
            InitializeComponent();
            ID = Id;
            Refresh_Listview();
        }

        public void Refresh_Listview()
        {
            try
            {
                listView1.Items.Clear();
    
                List<SubGoal> subgoalList = subGoal.GetSubgoals(ID);

                foreach (SubGoal subGoal in subgoalList)
                {
                    ListViewItem goalItem = new ListViewItem(subGoal.ID.ToString());
                    goalItem.SubItems.Add(subGoal.GoalID.ToString());
                    goalItem.SubItems.Add(subGoal.Subgoal.ToString());
                    goalItem.SubItems.Add(subGoal.Status.ToString());
                    listView1.Items.Add(goalItem);
                }
            }
            catch
            {
                MessageBox.Show("Kan subdoelen niet laden!");
            }
        }

        private void CreateSubGoal(object sender, EventArgs e)
        {
            try
            {
                int goalId = ID;
                string subgoal = textBox1.Text;

                subGoal.AddSubGoal(goalId, subgoal, "te doen");
                textBox1.Clear();
                Refresh_Listview();
            }
            catch
            {
                MessageBox.Show("Kan subdoel niet maken!");
            }
        }

        private void DeleteSubGoal(object sender, EventArgs e)
        {
            try
            {
                subGoal.DeleteSubGoal(DeleteId);
                MessageBox.Show("Subdoel " + DeleteId + " verwijderd");
                Refresh_Listview();
            }
            catch
            {
                MessageBox.Show("Kan subdoel niet verwijderen!");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DeleteId = Int32.Parse(listView1.SelectedItems[0].Text);
            }
        }
    }
}
