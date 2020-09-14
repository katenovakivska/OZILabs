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
    public partial class AllUsers : Form
    {
        public List<User> users { get; set; }
        public User user { get; set; }
        public AllUsers(List<User> users, User user)
        {
            InitializeComponent();
            this.users = users;
            this.user = user;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            FillDataGrid();
            
        }
        public void FillDataGrid()
        {
            List<string[]> data = new List<string[]>();
            foreach (var u in users)
            {
                if (u.Role != "Admin")
                {
                    data.Add(new string[5]);

                    data[data.Count - 1][0] = u.Login.ToString();
                    data[data.Count - 1][1] = u.Password.ToString();
                    data[data.Count - 1][2] = u.Role.ToString();
                    data[data.Count - 1][3] = u.Status.ToString();
                    data[data.Count - 1][4] = u.Limitation.ToString();
                    if (u.Status == "Unblocked")
                    {
                        comboBox1.Items.Add(u.Login.ToString());
                    }
                    else if (u.Status == "Blocked")
                    {
                        comboBox2.Items.Add(u.Login.ToString());
                    }
                    if (u.Limitation == false)
                    {
                        comboBox3.Items.Add(u.Login.ToString());
                    }
                }

            }

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reading reading = new Reading();
            User user = users.Find(x => x.Login == comboBox1.Text);
            string up = $"{user.Login};{user.Password};{user.Role};{user.Status};{user.Limitation}";
            user.Status = "Blocked";
            string u = $"{user.Login};{user.Password};{user.Role};{user.Status};{user.Limitation}";
            users = reading.FileDelete(up, u, "file1.csv");
            dataGridView1.Rows.Clear();
            comboBox1.Text = String.Empty;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            FillDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reading reading = new Reading();
            User user = users.Find(x => x.Login == comboBox2.Text);
            string up = $"{user.Login};{user.Password};{user.Role};{user.Status};{user.Limitation}";
            user.Status = "Unblocked";
            string u = $"{user.Login};{user.Password};{user.Role};{user.Status};{user.Limitation}";
            users = reading.FileDelete(up, u, "file1.csv");
            dataGridView1.Rows.Clear();
            comboBox2.Text = String.Empty;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            FillDataGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reading reading = new Reading();
            User user = users.Find(x => x.Login == textBox1.Text);
            if (user.Login == null)
            {
                string newUser = $"{textBox1.Text};{""};{"User"};{"Unblocked"};{"False"}";
                users = reading.FileWrite(newUser, "file1.csv");
                dataGridView1.Rows.Clear();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                FillDataGrid();
                
            }
            textBox1.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reading reading = new Reading();
            User user = users.Find(x => x.Login == comboBox3.Text);
            string up = $"{user.Login};{user.Password};{user.Role};{user.Status};{user.Limitation}";
            user.Limitation = true;
            string u = $"{user.Login};{user.Password};{user.Role};{user.Status};{user.Limitation}";
            users = reading.FileDelete(up, u, "file1.csv");
            dataGridView1.Rows.Clear();
            comboBox3.Text = String.Empty;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            FillDataGrid();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminPage page = new AdminPage(user, users);
            this.Hide();
            page.Show();

        }
    }
}
