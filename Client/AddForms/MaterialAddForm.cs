using System;
using System.Windows.Forms;
using Client.Controls;
using Client.DetailForms;
using Core.Models.Material;
using Core.OperationInterfaces;

namespace Client.AddForms
{
    public partial class MaterialAddForm : Form
    {
        private readonly MaterialAddModel _addModel = new MaterialAddModel();
        private readonly IMaterialAction _materialAction;
        public MaterialAddForm()
        {
            _materialAction = Program.Resolve<IMaterialAction>();
            InitializeComponent();
        }

        private void Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Вы действительно хотите выйти без сохранения?", @"Сохранение",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }

        private void SaveEndExit(object sender, EventArgs e)
        {
            _addModel.Name = materialNameTB.Text;
            _addModel.Count = materialCountUpDown.Value;
            var newId = Program.PerformCall(_addModel, _materialAction.AddMaterial);

            if (newId==Guid.Empty)
                return;

            ((MainForm)MdiParent).CreateNewChilForm(new ButtonNavigation
            {
                FormType = typeof(MaterialDetailForm),
                EntityId = newId
            });

            MessageBox.Show(@"Сохранение успешно завершено", String.Format("Материал \"{0}\"", _addModel.Name));
            Close();
        }

       
    }
}
