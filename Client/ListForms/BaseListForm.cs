using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Client.Controls;
using Client.Extensions;

namespace Client.ListForms
{
    public class BaseListForm : Form
    {
        private readonly Type _detailFormType;

        protected BaseListForm()
        {
            
        }
        protected BaseListForm(Type detailFormType) : this()
        {
            _detailFormType = detailFormType;
        }

        protected void CellClick(object sender, EventArgs e)
        {
            if (_detailFormType==null)
                return;

            var columnIndex = ((DataGridViewCellEventArgs)e).ColumnIndex;
            var rowIndex = ((DataGridViewCellEventArgs)e).RowIndex;

            if(rowIndex<0 || columnIndex<0)
                return;
            var column = ((DataGridView)sender).Columns[columnIndex];

            if (column is DataGridViewImageColumn || column is DataGridViewButtonColumn)
            {
                switch (column.Name)
                {
                    case "Edit":
                        ((MainForm)MdiParent).CreateNewChilForm(new ButtonNavigation
                        {
                            FormType = _detailFormType,
                            EntityId = (Guid)((DataGridView)sender).Rows[rowIndex].GetRowCell("Id").Value
                        });
                        break;
                    default:
                        return;
                }
            }
        }
    }
}