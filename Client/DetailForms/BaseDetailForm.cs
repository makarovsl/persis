using System;
using System.Windows.Forms;
using Core.Models;
using Core.OperationInterfaces;

namespace Client.DetailForms
{
    public abstract class BaseDetailForm<TModelUpdate, TModelAdd, TDetailAnswer> : Form where TDetailAnswer : IAnswerModel<TModelUpdate> 

    {
        private readonly ISaveAction<TModelUpdate, TModelAdd, TDetailAnswer> _actionSave;
        private readonly Guid _id;
        private bool _dataWasChanged;

        protected TModelUpdate UpdateModel { get; set; }
        protected abstract TModelAdd AddModel { get; set; }

        protected BaseDetailForm()
        {

        }
        protected BaseDetailForm(ISaveAction<TModelUpdate, TModelAdd,TDetailAnswer> actionSave, Guid id) : this()
        {
            _actionSave = actionSave;
            _id = id;
        }

        protected void DataWasChanged(object sender, EventArgs e)
        {
            _dataWasChanged = true;
        }

        public void RebindData()
        {
            if (!_id.Equals(Guid.Empty))
            {
                var detailParams = Program.PerformCall(_id, _actionSave.GetDetail);

                if (detailParams == null)
                {
                    Close();
                    return;
                }

                UpdateModel = detailParams.GetUpdateModel();

                BindData(UpdateModel);
            }
            else
            {
                BindData(AddModel);
            }

            

        }

        protected void SaveEndExit(object sender, EventArgs e)
        {
            Guid newId;
            if (!_id.Equals(Guid.Empty))
            {
                newId = Program.PerformCall(UpdateModel, _actionSave.Update);
            }
            else
            {
                newId = Program.PerformCall(AddModel, _actionSave.Add);
            }

            if (newId == Guid.Empty)
                return;

            MessageBox.Show(@"Сохранение успешно завершено");
            AfterSave();
            Close();
            
        }

        protected void Exit(object sender, EventArgs e)
        {
            if (_dataWasChanged)
                if (MessageBox.Show(@"Вы действительно хотите выйти без сохранения?", @"Сохранение",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            Close();
        }

        protected abstract void BindData(TModelAdd model);
        protected abstract void BindData(TModelUpdate model);

        protected abstract void AfterSave();

    }
}