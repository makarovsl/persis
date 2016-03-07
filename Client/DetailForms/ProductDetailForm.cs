using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Models;
using Core.Models.Product;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public partial class ProductDetailForm : Form
    {
        
        private readonly IDetailAction _detailAction;
        private readonly IProductAction _productAction;

        private readonly Guid _productId;
        private ProductDetailAnswer _detailParams;
        private bool _listDataWasChanged;

        public ProductDetailForm(Guid id)
        {
            _productId = id;
            _productAction = Program.Resolve<IProductAction>();
            _detailAction = Program.Resolve<IDetailAction>();
            InitializeComponent();
            RebindData();
        }

        public void RebindData()
        {
            if (!_productId.Equals(Guid.Empty))
            {
                _detailParams = Program.PerformCall(_productId, _productAction.GetDetail);
                detailNameTB.Text = _detailParams.Name;
                Text = String.Format("Редактирование изделия \"{0}\"", _detailParams.Name);
            }
            else
            {
                Text = @"Добавление изделия";
                _detailParams = new ProductDetailAnswer
                {
                    Details = new List<ContainObjectItem>()
                };
            }

            containListDetail.ItemList = _detailParams.Details;
            containListDetail.FullList = Program.PerformCall(_detailAction.GetSimpleList).ToList();
            containListDetail.DataChanged += DataWasChanged;
        }

        private void DataWasChanged(object sender, EventArgs e)
        {
            _listDataWasChanged = true;
        }

        public void Exit(object sender, EventArgs e)
        {
            if (_listDataWasChanged || _detailParams.Name != detailNameTB.Text)
                if (MessageBox.Show(@"Вы действительно хотите выйти без сохранения?", @"Сохранение",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            Close();
        }

        //todo и тут надо абстракцию сделать
        private void SaveEndExit(object sender, EventArgs e)
        {
            Guid newId;
            if (!_productId.Equals(Guid.Empty))
            {
                newId = Program.PerformCall(new ProductUpdateModel
                {
                    Id = _detailParams.Id,
                    Name = detailNameTB.Text,
                    Details = _detailParams.Details
                }, _productAction.Update);
            }
            else
            {
                newId = Program.PerformCall(new ProductAddModel
                {
                    Name = detailNameTB.Text,
                    Details = _detailParams.Details
                }, _productAction.Add);
            }

            if (newId == Guid.Empty)
                return;

            MessageBox.Show(@"Сохранение успешно завершено", String.Format("Деталь \"{0}\"", detailNameTB.Text));
            Close();
        }
    }
}
