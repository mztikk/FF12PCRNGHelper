using System.ComponentModel;
using System.Windows.Forms;

namespace FF12PCRNGHelper
{
    public partial class DumpForm : Form
    {
        public DumpForm(DataGridViewSelectedRowCollection dgvSelection)
        {
            this.InitializeComponent();

            foreach (DataGridViewRow row in dgvSelection)
            {
                var index = this.dataGridView2.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    this.dataGridView2.Rows[index].Cells[cell.ColumnIndex].Value = cell.Value;
                }
            }

            this.dataGridView2.Sort(this.dataGridView2.Columns[0], ListSortDirection.Ascending);
        }
    }
}