namespace FeedBuf
{
    public partial class TeacherFeedbackOverview : Form
    {

        public int TeacherID { get; set; }
        public int SelectedFeedbackID { get; set; }

        public Feedback feedback = new Feedback(0,0,0, new DateTime(2023, 1, 1), "","","",0);

        public TeacherFeedbackOverview(int id)
        {
            InitializeComponent();
            LoadFeedbackListView();
            TeacherID = id;
        }

        private void LoadFeedbackListView()
        {
            // Clear the list view items
            listView1.Items.Clear();

            // Get feedback from the database
            List<Feedback> feedbackList = feedback.GetFeedback();

            // Loop through the feedback and add to list view
            foreach (Feedback feedback in feedbackList)
            {
                ListViewItem item = new ListViewItem(feedback.ID.ToString());
                item.SubItems.Add(feedback.TeacherID.ToString());
                item.SubItems.Add(feedback.StudentID.ToString());
                item.SubItems.Add(feedback.Date.ToShortDateString());
                item.SubItems.Add(feedback.Course);
                item.SubItems.Add(feedback.GivenFeedback);
                item.SubItems.Add(feedback.Type);
                item.SubItems.Add(feedback.GoalID.ToString());
                listView1.Items.Add(item);
            }
        }

        private void AddFeedback(object sender, EventArgs e)
        {
            TeacherAddFeedback teacherAddFeedback = new TeacherAddFeedback(TeacherID, comboBox1.Text);
            teacherAddFeedback.ShowDialog();
            LoadFeedbackListView();
        }

        private void DeleteFeedback(object sender, EventArgs e)
        {
            feedback.DeleteFeedback(SelectedFeedbackID);
            LoadFeedbackListView();
        }

        private void SelectListviewId(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                SelectedFeedbackID = Int32.Parse(listView1.SelectedItems[0].Text);
            }
        }
    }
}
