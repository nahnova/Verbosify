using System.Data.SqlClient;
using DataAccess;

namespace FeedBuf
{
    public partial class LoginForm : Form
    {
        SqlCommand cmd;
        SqlDataReader dr;

        public int UserID { get; set; }
        public int TeacherID { get; set; }

        private FeedbackCollectionDBDataAccess iDB { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            this.iDB = new FeedbackCollectionDBDataAccess();
            textBox2.PasswordChar = '*';
            textBox4.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void StudentLogin(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {
                cmd = new SqlCommand("SELECT * FROM Student WHERE email= '" + textBox1.Text + "' AND password= '" + textBox2.Text + "' ", iDB.Sqlcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    UserID = Convert.ToInt32(dr["id"]);
                    dr.Close();
                    this.Hide();
                    StudentHome home = new StudentHome(UserID);
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Vul een correcte gebruiker in!");
                }
            }
            else
            {
                MessageBox.Show("Vul de velden in!");
            }
        }

        private void TeacherLogin(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty || textBox4.Text != string.Empty)
            {
                cmd = new SqlCommand("SELECT * FROM Teacher WHERE email= '" + textBox3.Text + "' AND password= '" + textBox4.Text + "' ", iDB.Sqlcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TeacherID = Convert.ToInt32(dr["id"]);
                    dr.Close();
                    this.Hide();
                    TeacherHome teacherHome = new TeacherHome(TeacherID);
                    teacherHome.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Vul een correcte docent in!");
                }
            }
            else
            {
                MessageBox.Show("Vul de velden in!");
            }
        }
    }
}
