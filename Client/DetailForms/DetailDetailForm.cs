﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Models;
using Core.Models.Detail;
using Core.Models.Material;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public partial class DetailDetailForm : Form
    {
        private readonly IDetailAction _detailAction;
        private readonly IMaterialAction _materialAction;

        private readonly Guid _detailId;
        private DetailDetailAnswer _detailParams;
        private bool _listDataWasChanged;

        public DetailDetailForm(Guid id)
        {
            _detailId = id;
            _detailAction = Program.Resolve<IDetailAction>();
            _materialAction = Program.Resolve<IMaterialAction>();
            InitializeComponent();
            RebindData();
        }

        public void RebindData()
        {
            if (!_detailId.Equals(Guid.Empty))
            {
                _detailParams = Program.PerformCall((Guid)_detailId, _detailAction.GetDetail);
                detailNameTB.Text = _detailParams.Name;
                Text = String.Format("Редактирование детали \"{0}\"", _detailParams.Name);
            }
            else
            {
                Text = @"Добавление детали";
                _detailParams = new DetailDetailAnswer
                {
                    Materials = new List<ContainObjectItem>()
                };
            }
            containListMaterial.ItemList = _detailParams.Materials;
            containListMaterial.FullList = Program.PerformCall(_materialAction.GetSimpleList).ToList();
            containListMaterial.DataChanged += DataWasChanged;

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

        private void SaveEndExit(object sender, EventArgs e)
        {
            Guid newId;
            if (!_detailId.Equals(Guid.Empty))
            {
                newId = Program.PerformCall(new DetailUpdateModel
                {
                    Id = _detailParams.Id,
                    Name = detailNameTB.Text,
                    Materials = _detailParams.Materials
                }, _detailAction.Update);
            }
            else
            {
                newId = Program.PerformCall(new DetailAddModel
                {
                    Name = detailNameTB.Text,
                    Materials = _detailParams.Materials
                }, _detailAction.Add);
            }

            if (newId == Guid.Empty)
                return;

            MessageBox.Show(@"Сохранение успешно завершено", String.Format("Деталь \"{0}\"", _detailParams.Name));
            Close();
        }

    }
}
