using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI1
{
    public partial class PersonalPage : Form
    {
        public User user { get; set; }
        public List<User> users { get; set; }
        public PersonalPage(User user, List<User> users)
        {
            InitializeComponent();
            this.user = user;
            this.users = users;
        }

        private void PersonalPage_Load(object sender, EventArgs e)
        {
            label2.Text = "Login: " + user.Login;
            label6.Text = "Limitation: " + user.Limitation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntranceForm page = new EntranceForm(users);
            this.Hide();
            page.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reading reading = new Reading();
            
                if (user.Password == textBox1.Text)
                {
                if (user.Limitation == true)
                {
                    if (Regex.IsMatch(textBox2.Text, "[a-zA-Z]{1,}")
                       && Regex.IsMatch(textBox2.Text, "[0-9]{1,}")
                       && Regex.IsMatch(textBox2.Text, "[-+/*]{1,}")
                       && !Regex.IsMatch(textBox2.Text, "[;]{1,}"))
                    {
                        if (textBox2.Text == textBox3.Text)
                        {
                            string up = $"{user.Login};{user.Password};{user.Role};{user.Status};{user.Limitation}";
                            string u = $"{user.Login};{textBox2.Text};{user.Role};{user.Status};{user.Limitation}";
                            ChangeAgree agree = new ChangeAgree(users, user, reading, u, up);
                            this.Hide();
                            agree.Show();
                            textBox1.Text = String.Empty;
                            textBox2.Text = String.Empty;
                            textBox3.Text = String.Empty;
                            label5.Text = String.Empty;
                        }
                        else
                        {
                            label5.Text = "Confirmation password is not the same as new password!";
                        }

                    }
                    else
                    {
                        label5.Text = "New password must contain almost 1 latin and ariphmetical operation symbol";
                    }
                }
                else if (textBox2.Text != String.Empty && !Regex.IsMatch(textBox2.Text, "[;]{1,}"))
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        string up = $"{user.Login};{user.Password};{user.Role};{user.Status};{user.Limitation}";
                        string u = $"{user.Login};{textBox2.Text};{user.Role};{user.Status};{user.Limitation}";
                        ChangeAgree agree = new ChangeAgree(users, user, reading, u, up);
                        this.Hide();
                        agree.Show();
                        textBox1.Text = String.Empty;
                        textBox2.Text = String.Empty;
                        textBox3.Text = String.Empty;
                        label5.Text = String.Empty;
                    }
                    else
                    {
                        label5.Text = "Confirmation password is not the same as new password!";
                    }
                }
                else if (textBox2.Text == String.Empty)
                {
                    label5.Text = "Password can not be null!";
                }
                else if (Regex.IsMatch(textBox2.Text, "[;]{1,}"))
                {
                    label5.Text = "Password can not contain ; symbol";
                }
                    
                }
                else
                {
                    label5.Text = "Current password is uncorrect!";
                }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.Show();
        }
    }
}
