using System;
using System.Collections.Generic;
using System.Linq;
using Client.ListForms;
using Core.Models;
using Core.Models.Detail;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public partial class DetailDetailForm : BaseDetailForm<DetailUpdateModel, DetailAddModel, DetailDetailAnswer>
    {

        protected sealed override DetailAddModel AddModel { get; set; }
        private readonly IMaterialAction _materialAction;

        public DetailDetailForm(Guid id):base(Program.Resolve<IDetailAction>(), id)
        {
            _materialAction = Program.Resolve<IMaterialAction>();
            AddModel = new DetailAddModel {Materials = new List<ContainObjectItem>()};

            InitializeComponent();

            buttonCancel.Click += Exit;
            buttonOk.Click += SaveEndExit;

            RebindData();
        }

        private void Bind<T>(T model)
        {
            detailNameTB.DataBindings.Add("Text", model, "Name");
            detailNameTB.KeyDown += DataWasChanged;
            containListMaterial.FullList = Program.PerformCall(_materialAction.GetSimpleList).ToList();
        }
        

        protected override void BindData(DetailAddModel model)
        {
            containListMaterial.ItemList = model.Materials;
            Text = @"Добавления детали";
            Bind(model);
        }

        protected override void BindData(DetailUpdateModel model)
        {
            containListMaterial.ItemList = model.Materials;
            Text = String.Format("Редактирование детали \"{0}\"", model.Name);
            Bind(model);
        }

        protected override void AfterSave()
        {
            ((MainForm)MdiParent).RebindListData(typeof(ProductListForm));
            ((MainForm)MdiParent).RebindListData(typeof(DetailListForm));
        }
    }
}
