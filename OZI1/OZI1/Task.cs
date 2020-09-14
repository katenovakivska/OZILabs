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
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
            label1.Text = "Student: Kateryna Novakivska\nIndividual task:\npassword should contain\nalmost 1 latin, number\nand ariphmetical operation system";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
