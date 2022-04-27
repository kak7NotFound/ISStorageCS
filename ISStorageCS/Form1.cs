using System;
using System.Windows.Forms;

namespace ISStorageCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.Write(DataBase.strExeFilePath.Substring(0,
                DataBase.strExeFilePath.Length - 15) + @"storage.sqlite");
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new GoodsAcceptanceForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new GoodsShipmentForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new GoodsEditorForm().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new WorkingSpace().Show();
        }
    }
}