using System;
using System.Windows.Forms;

namespace ISStorageCS
{
    public partial class WorkingSpace : Form
    {
        public WorkingSpace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddCategoryForm().Show();
        }
    }
}