using System;
using System.Collections.Generic;
using Client.DetailForms;
using Core.Models.Detail;
using Core.OperationInterfaces;

namespace Client.ListForms
{
    public partial class DetailListForm : BaseListForm
    {
        private readonly IDetailAction _detailOperation;
        protected override Dictionary<string, Action<Guid>> AdditionalActions { get; set; }
        public DetailListForm() : base(typeof(DetailDetailForm))
        {
            _detailOperation = Program.Resolve<IDetailAction>();
            
            InitializeComponent();
            paginator.GetRowCount = _detailOperation.GetListCount;
            paginator.PageChange += RebindGrid;
            detailGridView.CellClick += CellClick;
        }

        public void RebindGrid(object sender, EventArgs e)
        {
            RebindGrid();
        }

        public override void RebindGrid()
        {

            detailGridView.DataSource = Program.PerformCall(
                new DetailListModel { PageSize = paginator.PageSize, PageNumber = paginator.CurrenPage },
                _detailOperation.GetList);
        }


        

        protected override void Delete(Guid id)
        {
            Program.PerformCall(id, _detailOperation.Delete);
            RebindGrid();
        }
    }

}
