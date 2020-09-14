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
    public partial class AdminPage : Form
    {
        public User admin { get; set; }
        public List<User> users { get; set; }
        public AdminPage(User user, List<User> users)
        {
            InitializeComponent();
            admin = user;
            this.users = users;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AllUsers all = new AllUsers(users, admin);
            this.Hide();
            all.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntranceForm page = new EntranceForm(users);
            this.Hide();
            page.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Task task = new Task();
            task.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reading reading = new Reading();

            if (admin.Password == textBox1.Text)
            {
                    if (Regex.IsMatch(textBox2.Text, "[a-zA-Z]{1,}")
                       && Regex.IsMatch(textBox2.Text, "[0-9]{1,}")
                       && Regex.IsMatch(textBox2.Text, "[-+/*]{1,}")
                       && !Regex.IsMatch(textBox2.Text, "[;]{1,}"))
                    {
                        if (textBox2.Text == textBox3.Text)
                        {
                            string up = $"{admin.Login};{admin.Password};{admin.Role};{admin.Status};{admin.Limitation}";
                            string u = $"{admin.Login};{textBox2.Text};{admin.Role};{admin.Status};{admin.Limitation}";
                            ChangeAgree agree = new ChangeAgree(users, admin, reading, u, up);
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
                
                else
                {
                    label5.Text = "Password is uncorrect!";
                }

            }
        
    }
}
