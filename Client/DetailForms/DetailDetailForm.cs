using System;
using System.Linq;
using System.Windows.Forms;
using Client.Extensions;
using Core.Models;
using Core.Models.Detail;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public partial class DetailDetailForm : Form
    {
        private readonly IDetailAction _detailAction;
        private readonly IMaterialAction _materialAction;

        private readonly Guid _detailId;
        private DetailDetailAnswer _detailParams;
        private SimpleListItem[] _fullMaterialList;

        public DetailDetailForm(Guid id)
        {
            _detailId = id;
            _detailAction = Program.Resolve<IDetailAction>();
            _materialAction = Program.Resolve<IMaterialAction>();
            InitializeComponent();
        }

        public void RebindData(object sender, EventArgs e)
        {

            _detailParams = Program.PerformCall(_detailId,_detailAction.GetDetail);
            detailNameTB.Text = _detailParams.Name;
            materialGridView.DataSource = _detailParams.Materials;
            Text = String.Format("Редактирование детали \"{0}\"", _detailParams.Name);

            MaterialName.DisplayMember = "MaterialName";
            MaterialName.DisplayMember = "MaterialId";

            _fullMaterialList = Program.PerformCall(_materialAction.GetSimpleList);
            foreach (DataGridViewRow row in materialGridView.Rows)
            {
                var cell = (DataGridViewComboBoxCell)row.GetRowCell("MaterialName");
                var currentId = row.GetRowCell("MaterialId").Value;
                var range = _fullMaterialList.Where(
                        w => !_detailParams.Materials.Select(s => s.MaterialId).Contains(w.Id) || w.Id.Equals(currentId)).ToList();
                cell.Items.Clear();
                cell.Items.AddRange(range);
                  
            }

            var a = 1;

        }

        private void materialGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!materialGridView.Columns[e.ColumnIndex].Name.Equals("MaterialName"))
                return;

            var cell = (DataGridViewComboBoxCell) materialGridView.Rows[e.RowIndex].GetRowCell("MaterialName");
            var currentId = materialGridView.Rows[e.RowIndex].GetRowCell("MaterialId").Value;
            cell.Items.Clear();
            cell.Items.AddRange(
                _fullMaterialList.Where(
                    w => !_detailParams.Materials.Select(s => s.MaterialId).Contains(w.Id) || w.Id.Equals(currentId)));

        }

        private void materialGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
