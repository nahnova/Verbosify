namespace FeedBuf
{
    public partial class RegisterForm : Form
    {
        public Student student = new Student(0,"","","","","",0,0,0,"");

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterStudent(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty || comboBox1.Text != string.Empty || textBox5.Text != string.Empty)
            {
                string firstName = textBox1.Text;
                string lastName = textBox2.Text;
                string email = textBox3.Text;
                string gender = comboBox1.Text;
                string password = textBox5.Text;

                student.AddStudent(firstName, lastName, email, gender, password);
                this.Close();
            }
            else
            {
                MessageBox.Show("Vul alle velden in!");
            }
        }
    }
}
