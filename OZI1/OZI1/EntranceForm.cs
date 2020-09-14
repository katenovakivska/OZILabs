using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI1
{
    public partial class EntranceForm : Form
    {
        public List<User> users = new List<User>();
        public int errorCount = 0;
        public EntranceForm(List<User> users)
        {
            this.users = users;
            InitializeComponent();
        }
        public void Authorization(string login, string password)
        {
            User log = users.Find(x => x.Login == login);
            User user = users.Find(x => x.Login == login && x.Password == password);
            if (login != "")
            {
                if (log.Login != null)
                {
                        if (user.Password != null)
                        {
                            if (user.Status != "Blocked")
                            {
                                if (radioButton1.Checked == false && radioButton2.Checked == false)
                                {
                                    label3.Text = "Please, choose your role!";
                                }
                                else 
                                {
                                    if (user.Role == "Admin" && radioButton2.Checked == true)
                                    {
                                        AdminPage admin = new AdminPage(user, users);
                                        Hide();
                                        admin.Show();
                                    }
                                    else if (user.Role == "User" && radioButton1.Checked == true)
                                    {
                                        if (user.Limitation == false)
                                        {
                                            PersonalPage page = new PersonalPage(user, users);
                                            Hide();
                                            page.Show();
                                        }
                                        else
                                        {
                                            Limitation(user);
                                        }
                                    }
                                    else
                                    {
                                        label3.Text = "There is no user with this role and login!";
                                    }
                                }
                                
                            }
                            else
                            {
                                label3.Text = "You are blocked by ADMIN";
                            }
                        }
                        else 
                        {
                            label3.Text = "Password is uncorrect!";
                            errorCount++;
                            if (errorCount == 3)
                            {
                                Application.Exit();
                            }
                            
                        }                  
                }
                else
                {
                    label3.Text = "Login is uncorrect!";
                }
            }
            else 
            {
                label3.Text = "Enter login, please!";
            }
            
        }
        public void Limitation(User user)
        {
            if (Regex.IsMatch(user.Password, "[a-zA-Z]{1,}")
                && Regex.IsMatch(user.Password, "[0-9]{1,}")
                && Regex.IsMatch(user.Password, "[-+/*]{1,}"))
            {
                PersonalPage page = new PersonalPage(user, users);
                Hide();
                page.Show();
            }
            else
            {
                label3.Text = "Password must contain almost 1 latin, number and ariphmetical operation symbol";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Authorization(textBox1.Text, textBox2.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
