namespace FeedBuf
{
    public partial class StudentFeedbackOverview : Form
    {

        Feedback feedback = new Feedback(0, 0, 0, new DateTime(2023, 1, 1), "", "", "", 0);

        public StudentFeedbackOverview()
        {
            InitializeComponent();

            // Load feedback list view
            LoadFeedbackListView();
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
    }
}