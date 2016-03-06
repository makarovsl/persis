using System;
using Client.DetailForms;
using Core.Models.Detail;
using Core.OperationInterfaces;

namespace Client.ListForms
{
    public partial class DetailListForm : BaseListForm
    {
        private readonly IDetailAction _detailOperation;
   
        public DetailListForm() : base(typeof(DetailDetailForm))
        {
            _detailOperation = Program.Resolve<IDetailAction>();
            
            InitializeComponent();
            paginator.GetRowCount = _detailOperation.GetListCount;
            paginator.PageChange += RebindGrid;
            detailGridView.CellClick += CellClick;
        }

        private void RebindGrid(object sender, EventArgs e)
        {


            detailGridView.DataSource = Program.PerformCall(
                new DetailListModel { PageSize = paginator.PageSize, PageNumber = paginator.CurrenPage },
                _detailOperation.GetList);
        }

        
    }
}
