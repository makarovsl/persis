﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;
using Client.Controls;
using Client.Extensions;

namespace Client.ListForms
{
    public abstract class BaseListForm : Form
    {
        private readonly Type _detailFormType;

        protected abstract Dictionary<string, Action<Guid>> AdditionalActions { get; set; }
        protected BaseListForm()
        {

        }
        protected BaseListForm(Type detailFormType) : this()
        {
            _detailFormType = detailFormType;
        }

        protected void CellClick(object sender, EventArgs e)
        {
            if (_detailFormType == null)
                return;

            var columnIndex = ((DataGridViewCellEventArgs)e).ColumnIndex;
            var rowIndex = ((DataGridViewCellEventArgs)e).RowIndex;

            if (rowIndex < 0 || columnIndex < 0)
                return;
            var column = ((DataGridView)sender).Columns[columnIndex];

            if (column is DataGridViewImageColumn || column is DataGridViewButtonColumn)
            {
                switch (column.Name)
                {
                    case "ColumnEdit":
                        ((MainForm)MdiParent).CreateNewChilForm(new ButtonNavigation
                        {
                            FormType = _detailFormType,
                            EntityId = (Guid)((DataGridView)sender).Rows[rowIndex].GetRowCell("Id").Value
                        });
                        break;
                    case "ColumnDelete":
                        DeleteRow((Guid)((DataGridView)sender).Rows[rowIndex].GetRowCell("Id").Value);
                        break;
                    default:
                        {
                            if (AdditionalActions == null)
                                return;

                            var action = AdditionalActions.SingleOrDefault(s => s.Key.Equals(column.Name));

                            if (action.Key == null)
                                return;

                            action.Value((Guid)((DataGridView)sender).Rows[rowIndex].GetRowCell("Id").Value);

                            return;
                        }
                }
            }
        }

        protected abstract void Delete(Guid id);
        protected void DeleteRow(Guid id)
        {
            if (MessageBox.Show(@"Вы действительно хотите удалить?", @"Удаление",
                       MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Delete(id);
        }

        public abstract void RebindGrid();

    }
}