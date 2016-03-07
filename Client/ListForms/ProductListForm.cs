using System;
using Core.Models.Material;
using Core.Models.Product;
using Core.OperationInterfaces;

namespace Client.ListForms
{
    public partial class ProductListForm : BaseListForm
    {
        private readonly IProductAction _productAction;
        public ProductListForm()
        {
            _productAction = Program.Resolve<IProductAction>();
            InitializeComponent();
            paginator.GetRowCount = _productAction.GetListCount;
            productGridView.CellClick += CellClick;
        }

        private void RebindGrid(object sender, EventArgs e)
        {

            productGridView.DataSource = Program.PerformCall(
                new ProductListModel { PageSize = paginator.PageSize, PageNumber = paginator.CurrenPage },
                _productAction.GetList);
        }
    }
}
