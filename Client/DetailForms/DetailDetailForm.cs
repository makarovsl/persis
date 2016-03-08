using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Models;
using Core.Models.Detail;
using Core.Models.Material;
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
            Bind(model);
        }

        protected override void BindData(DetailUpdateModel model)
        {
            containListMaterial.ItemList = model.Materials;
            Bind(model);
        }
    }
}
