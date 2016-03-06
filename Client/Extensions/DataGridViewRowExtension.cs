using System.Linq;
using System.Windows.Forms;

namespace Client.Extensions
{
    public static class DataGridViewRowExtension
    {
        public static DataGridViewCell GetRowCell(this DataGridViewRow row, string cellName)
        {
            return row.Cells.Cast<DataGridViewCell>().Single(s => s.OwningColumn.Name.Equals(cellName));
        }
    }
}
