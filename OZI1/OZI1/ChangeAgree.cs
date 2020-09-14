using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI1
{
    public partial class ChangeAgree : Form
    {
        public User user { get; set; }
        public List<User> users { get; set; }
        public Reading reading { get; set;}
        public string u { get; set; }
        public string up { get; set; }
        public ChangeAgree(List<User> users, User user, Reading reading, string u, string up)
        {
            InitializeComponent();
            this.users = users;
            this.user = user;
            this.reading = reading;
            this.u = u;
            this.up = up;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            users = reading.FileDelete(up, u, "file1.csv");
            EntranceForm page = new EntranceForm(users);
            this.Hide();
            page.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user.Role == "User")
            {
                PersonalPage page = new PersonalPage(user, users);
                this.Hide();
                page.Show();
            }
            else if(user.Role == "Admin")
            {
                AdminPage page = new AdminPage(user, users);
                this.Hide();
                page.Show();
            }
        }
    }
}
