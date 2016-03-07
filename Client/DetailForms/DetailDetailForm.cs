using System;
using System.Linq;
using System.Windows.Forms;
using Core.Models.Detail;
using Core.Models.Material;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public partial class DetailDetailForm : Form
    {
        private readonly IDetailAction _detailAction;
        private readonly IMaterialAction _materialAction;

        private readonly Guid _detailId;
        private DetailDetailAnswer _detailParams;
        private bool _listDataWasChanged;

        public DetailDetailForm(Guid id)
        {
            _detailId = id;
            _detailAction = Program.Resolve<IDetailAction>();
            _materialAction = Program.Resolve<IMaterialAction>();
            InitializeComponent();
            RebindData();
        }

        public void RebindData()
        {

            _detailParams = Program.PerformCall(_detailId,_detailAction.GetDetail);
            detailNameTB.Text = _detailParams.Name;
            Text = String.Format("Редактирование детали \"{0}\"", _detailParams.Name);
            containListMaterial.ItemList = _detailParams.Materials;
            containListMaterial.FullList = Program.PerformCall(_materialAction.GetSimpleList).ToList();
            containListMaterial.DataChanged += DataWasChanged;

        }

        private void DataWasChanged(object sender, EventArgs e)
        {
            _listDataWasChanged = true;
        }

        public void Exit(object sender, EventArgs e)
        {
            if (_listDataWasChanged || _detailParams.Name != detailNameTB.Text)
                if (MessageBox.Show(@"Вы действительно хотите выйти без сохранения?", @"Сохранение",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            Close();
        }

        private void SaveEndExit(object sender, EventArgs e)
        {

            Guid newId = Program.PerformCall(new DetailUpdateModel
            {
                Id = _detailParams.Id,
                Name = detailNameTB.Text,
                Materials = _detailParams.Materials
            }, _detailAction.UpdateDetail);

            if (newId == Guid.Empty)
                return;

            MessageBox.Show(@"Сохранение успешно завершено", String.Format("Деталь \"{0}\"", _detailParams.Name));
            Close();
        }

    }
}
