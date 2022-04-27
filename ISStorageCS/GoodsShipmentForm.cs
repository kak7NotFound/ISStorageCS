using System.Windows.Forms;

namespace ISStorageCS
{
    public partial class GoodsShipmentForm : Form
    {
        public GoodsShipmentForm()
        {
            InitializeComponent();
            refreshData();
        }
        
        public void refreshData()
        {
            comboBox1.Items.Clear();
            using (var reader = Program.database.GetReader("select name from Categories"))
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }
        }
    }
}