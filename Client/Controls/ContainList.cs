using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Client.Extensions;
using Core.Models;

namespace Client.Controls
{
    public partial class ContainList : UserControl
    {
        public List<SimpleListItem> FullList { get; set; }
        public event EventHandler DataChanged;
        private readonly BindingSource _bindingSource = new BindingSource();
        public List<ContainObjectItem> ItemList
        {
            get { return (_bindingSource.DataSource as List<ContainObjectItem>)??new List<ContainObjectItem>(); }
            set {if(value!=null) _bindingSource.DataSource = value; }
        }

        
        public ContainList()
        {
            InitializeComponent();
        }

        private void InitGrid(object sender, EventArgs e)
        {
            if (_bindingSource == null)
                return;

            if (FullList == null)
                return;
            
            selectGridView.DataSource = _bindingSource;

            FullList.Add(new SimpleListItem
            {
                Id = Guid.Empty,
                Name = ""
            });
            Id.DataSource = FullList;
            
        }


        private SimpleListItem[] GetListForSelect(Guid id)
        {
            return FullList.Where(w => w.Id.Equals(id) || !((List<ContainObjectItem>) _bindingSource.DataSource).Select(si => si.Id).Contains(w.Id)).ToArray();
        }

        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!selectGridView.Columns[e.ColumnIndex].Name.Equals("Id")) return;
            ((DataGridViewComboBoxCell) selectGridView.Rows[e.RowIndex].Cells["Id"]).DataSource =
                GetListForSelect((Guid) (selectGridView.Rows[e.RowIndex].Cells["Id"].Value??Guid.Empty));
        }

        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= CheckKey;
            if (selectGridView.CurrentCell.OwningColumn.Name.Equals("Count"))
            {
                var tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += CheckKey;
                }
            }
        }

        private void AddNewItem(object sender, EventArgs e)
        {
            _bindingSource.Add(new ContainObjectItem
            {
                Id = null,
                Count = 0
            });
            selectGridView.Refresh();
            OnDataChanged();
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            if(selectGridView.SelectedRows.Count!=1)
                return;

            selectGridView.Rows.Remove(selectGridView.SelectedRows[0]);
            OnDataChanged();
        }

        protected virtual void OnDataChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void selectGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            OnDataChanged();
        }
    }
}
