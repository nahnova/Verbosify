namespace FeedBuf
{
    public partial class StudentGoalOverview : Form
    {
        public int StudentId { get; set; }
        public int CurrentXp { get; set; }
        public int SelectedGoalId { get; set; }
        public int CurrentLevel { get; set; }

        public Goal goal = new Goal(0,0,"","","","");

        public StudentGoalOverview(int id, int currentXp, int currentLevel)
        {
            InitializeComponent();
            StudentId = id;
            CurrentXp = currentXp;
            CurrentLevel = currentLevel;
            Refresh_Listview();

            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);

        }
        public void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StudentHome studentHome = new StudentHome(StudentId);
            studentHome.Show();
            this.Hide();
        }

        public void Refresh_Listview()
        {
            try
            {
                listView1.Items.Clear();

                List<Goal> goalList = goal.GetGoals(StudentId);

                foreach (Goal goal in goalList)
                {
                    ListViewItem goalItem = new ListViewItem(goal.ID.ToString());
                    goalItem.SubItems.Add(goal.StudentID.ToString());
                    goalItem.SubItems.Add(goal.CreatedGoal.ToString());
                    goalItem.SubItems.Add(goal.Priority.ToString());
                    goalItem.SubItems.Add(goal.Time.ToString());
                    goalItem.SubItems.Add(goal.Status.ToString());
                    listView1.Items.Add(goalItem);
                }
            }
            catch 
            {
                MessageBox.Show("Kan doelen niet laden!");
            }
        }

        private void CreateGoal(object sender, EventArgs e)
        {
            StudentAddGoalForm addGoalForm = new StudentAddGoalForm(StudentId);
            addGoalForm.ShowDialog();
            Refresh_Listview();
        }

        private void DeleteGoal(object sender, EventArgs e)
        {
            try
            {
                goal.DeleteGoal(SelectedGoalId);
                MessageBox.Show("Doel " + SelectedGoalId + " verwijderd");
                Refresh_Listview();
            }
            catch
            {
                MessageBox.Show("Kan doel niet verwijderen!");
            }
        }

        private void OpenSubGoals(object sender, EventArgs e)
        {
            StudentSubGoalOverview subGoalsForm = new StudentSubGoalOverview(SelectedGoalId);
            subGoalsForm.ShowDialog();
            Refresh_Listview();
        }

        private void UpdateStatus(object sender, EventArgs e)
        {
            try
            {
                goal.UpdateGoalStatus(SelectedGoalId, comboBox1.Text);
                MessageBox.Show("status van doel " + SelectedGoalId + " geupdate");
                Refresh_Listview();
            }
            catch
            {
                MessageBox.Show("kan status niet updaten!");
            }

            if (comboBox1.Text == "afgerond")
            {
                int xp = CurrentXp += 20;
                int level = CurrentLevel;

                /*if (CurrentXp => \100)
                {
                    StudentsRepo.UpdateXpAmount(StudentId, xp, level);
                }*/
            }
        }

        private void SelectListviewId(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                SelectedGoalId = Int32.Parse(listView1.SelectedItems[0].Text);
            }
        }
    }
}