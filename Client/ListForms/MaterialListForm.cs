using System;
using Client.DetailForms;
using Core.Models.Material;
using Core.OperationInterfaces;

namespace Client.ListForms
{
    public partial class MaterialListForm : BaseListForm
    {
        private readonly IMaterialAction _materialOperation;
        public MaterialListForm():base(typeof(MaterialDetailForm))
        {
            _materialOperation = Program.Resolve<IMaterialAction>();
            InitializeComponent();
            paginator.GetRowCount = _materialOperation.GetListCount;
            materialGridView.CellClick += CellClick;
        }


        private void RebindGrid(object sender, EventArgs e)
        {

            materialGridView.DataSource = Program.PerformCall(
                new MaterialListModel {PageSize = paginator.PageSize, PageNumber = paginator.CurrenPage},
                _materialOperation.GetList);
        }

    }
}
