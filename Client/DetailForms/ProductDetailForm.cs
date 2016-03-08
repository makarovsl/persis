using System;
using System.Collections.Generic;
using System.Linq;
using Client.ListForms;
using Core.Models;
using Core.Models.Product;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public partial class ProductDetailForm : BaseDetailForm<ProductUpdateModel, ProductAddModel, ProductDetailAnswer>
    {
        
        private readonly IDetailAction _detailAction;
        protected sealed override ProductAddModel AddModel { get; set; }

        public ProductDetailForm(Guid id) :base(Program.Resolve<IProductAction>(), id)
        {
            _detailAction = Program.Resolve<IDetailAction>();

            AddModel = new ProductAddModel {Details = new List<ContainObjectItem>()};

            InitializeComponent();

            buttonCancel.Click += Exit; 
            buttonOk.Click += SaveEndExit; 

            RebindData();

        }

        

        protected override void BindData (ProductAddModel model)
        {
            Text = @"Добавления изделия";
            containListDetail.ItemList = model.Details;
            Bind(model);
        }

        protected override void BindData(ProductUpdateModel model)
        {
            Text = String.Format("Редактирование изделия \"{0}\"", model.Name);
            containListDetail.ItemList = model.Details;
            Bind(model);
        }

        protected override void AfterSave()
        {
            ((MainForm)MdiParent).RebindListData(typeof(ProductListForm));
        }

        private void Bind<T>(T model)
        {
            detailNameTB.DataBindings.Add("Text", model, "Name");
            detailNameTB.KeyDown += DataWasChanged;
            containListDetail.FullList = Program.PerformCall(_detailAction.GetSimpleList).ToList();
            containListDetail.DataChanged += DataWasChanged;

        }


    }
}
