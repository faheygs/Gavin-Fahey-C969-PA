using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gavin_Fahey_C969_PA
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            AddCustomerForm ac = new AddCustomerForm();
            ac.ShowDialog();
        }

        private void updateCustomerBtn_Click(object sender, EventArgs e)
        {
            UpdateCustomer uc = new UpdateCustomer();
            uc.ShowDialog();
        }
    }
}
