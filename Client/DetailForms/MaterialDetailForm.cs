using System;
using System.Windows.Forms;
using Client.Controls;
using Core.Models.Material;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public partial class MaterialDetailForm : Form
    {
        private readonly IMaterialAction _materialAction;
        private readonly Guid _materialId;
        private MaterialDetailAnswer _materialParams;
        private MaterialUpdateModel _updateModel;
        public MaterialDetailForm(Guid materialId)
        {
            _materialAction = Program.Resolve<IMaterialAction>();
            _materialId = materialId;

            InitializeComponent();
        }

        public void RebindData(object sender, EventArgs e)
        {
            _materialParams = Program.PerformCall(_materialId, _materialAction.GetDetail);
            if (_materialParams == null)
            {
                Close();
                return;
            }
            materialNameTB.Text = _materialParams.Name;
            materialCountUpDown.Value = _materialParams.Count;
            Text = String.Format("Редактирование материала : \"{0}\"", _materialParams.Name);
        }
        public void Exit(object sender, EventArgs e)
        {
            if (_materialParams.Count != materialCountUpDown.Value || _materialParams.Name != materialNameTB.Text)
                if (MessageBox.Show(@"Вы действительно хотите выйти без сохранения?", @"Сохранение",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            Close();
        }

        private void SaveEndExit(object sender, EventArgs e)
        {
            _updateModel = new MaterialUpdateModel
            {
                Id = _materialParams.Id,
                Name = materialNameTB.Text,
                Count = materialCountUpDown.Value
            };

            Guid newId = Program.PerformCall(_updateModel, _materialAction.UpdateMaterial);

            if (newId == Guid.Empty)
                return;

            MessageBox.Show(@"Сохранение успешно завершено", String.Format("Материал \"{0}\"", _materialParams.Name));
            Close();
        }


    }
}
