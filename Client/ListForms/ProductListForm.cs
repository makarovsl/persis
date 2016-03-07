using System;
using Client.DetailForms;
using Core.Models.Material;
using Core.Models.Product;
using Core.OperationInterfaces;

namespace Client.ListForms
{
    public partial class ProductListForm : BaseListForm
    {
        private readonly IProductAction _productAction;
        public ProductListForm():base(typeof(ProductDetailForm))
        {
            _productAction = Program.Resolve<IProductAction>();
            InitializeComponent();
            paginator.GetRowCount = _productAction.GetListCount;
            paginator.PageChange += RebindGrid;
            productGridView.CellClick += CellClick;
        }

        public override void RebindGrid(object sender, EventArgs e)
        {

            productGridView.DataSource = Program.PerformCall(
                new ProductListModel { PageSize = paginator.PageSize, PageNumber = paginator.CurrenPage },
                _productAction.GetList);
        }
    }
}
