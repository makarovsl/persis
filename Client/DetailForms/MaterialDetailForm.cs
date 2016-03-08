using System;
using Client.ListForms;
using Core.Models.Material;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public partial class MaterialDetailForm :  BaseDetailForm<MaterialUpdateModel, MaterialAddModel, MaterialDetailAnswer>
    {

        protected sealed override MaterialAddModel AddModel { get; set; }
        public MaterialDetailForm(Guid materialId):base(Program.Resolve<IMaterialAction>(), materialId)
        {

            AddModel = new MaterialAddModel();

            InitializeComponent();

            buttonCancel.Click += Exit;
            buttonOk.Click += SaveEndExit;
            RebindData();
        }

        private void Bind<T>(T model)
        {
            materialNameTB.DataBindings.Add("Text", model, "Name");
            materialCountUpDown.DataBindings.Add("Value", model, "Count");
            materialNameTB.KeyDown += DataWasChanged;
            materialCountUpDown.KeyDown += DataWasChanged;
        }

        protected override void BindData(MaterialAddModel model)
        {
            Text = @"Добавления материала";
            Bind(model);
        }

        protected override void BindData(MaterialUpdateModel model)
        {
            Text = String.Format("Редактирование материала \"{0}\"", model.Name);
            Bind(model);
        }

        protected override void AfterSave()
        {
            ((MainForm)MdiParent).RebindListData(typeof(ProductListForm));
            ((MainForm)MdiParent).RebindListData(typeof(MaterialListForm));
        }
    }
}
