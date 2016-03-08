using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Client.DetailForms;
using Core.Models.Product;
using Core.OperationInterfaces;

namespace Client.ListForms
{
    public partial class ProductListForm : BaseListForm
    {
        private readonly IProductAction _productAction;
        protected sealed override Dictionary<string, Action<Guid>> AdditionalActions { get; set; }
        public ProductListForm():base(typeof(ProductDetailForm))
        {
            _productAction = Program.Resolve<IProductAction>();
            InitializeComponent();

            AdditionalActions = new Dictionary<string, Action<Guid>> {{"ColumnProduce", Produce}};

            paginator.GetRowCount = _productAction.GetListCount;
            paginator.PageChange += RebindGrid;
            productGridView.CellClick += CellClick;
        }

        public void RebindGrid(object sender, EventArgs e)
        {

            RebindGrid();
        }

        public override void RebindGrid()
        {

            productGridView.DataSource = Program.PerformCall(
                new ProductListModel { PageSize = paginator.PageSize, PageNumber = paginator.CurrenPage },
                _productAction.GetList);
        }


        protected override void Delete(Guid id)
        {
            Program.PerformCall(id, _productAction.Delete);
            RebindGrid();
        }

        public void Produce(Guid id)
        {
            var count = Program.ShowDialog("Введите количество изделий", "Выпуск изделий");

            var result = Program.PerformCall(new ProduceModel {ProductId = id, ProductCount = count},
                _productAction.Produce);

            if (!result)
                return;

            ((MainForm)MdiParent).RebindListData(typeof(MaterialListForm));
            ((MainForm)MdiParent).RebindListData(typeof(ProductListForm));
            MessageBox.Show(@"Изделия произведены!");
        }
    }
}
