using System;
using System.Collections.Generic;
using Client.DetailForms;
using Core.Models.Material;
using Core.OperationInterfaces;

namespace Client.ListForms
{
    public partial class MaterialListForm : BaseListForm
    {
        private readonly IMaterialAction _materialOperation;
        protected override Dictionary<string, Action<Guid>> AdditionalActions { get; set; }
        public MaterialListForm():base(typeof(MaterialDetailForm))
        {
            _materialOperation = Program.Resolve<IMaterialAction>();
            InitializeComponent();
            paginator.GetRowCount = _materialOperation.GetListCount;
            materialGridView.CellClick += CellClick;
        }


        public void RebindGrid(object sender, EventArgs e)
        {

            RebindGrid();
        }

        public override void RebindGrid()
        {

            materialGridView.DataSource = Program.PerformCall(
                new MaterialListModel { PageSize = paginator.PageSize, PageNumber = paginator.CurrenPage },
                _materialOperation.GetList);
        }

        protected override void Delete(Guid id)
        {
            Program.PerformCall(id,_materialOperation.Delete);
            RebindGrid();
        }
    }
}
