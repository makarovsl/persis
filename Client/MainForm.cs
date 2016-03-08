using System;
using System.Linq;
using System.Windows.Forms;
using Client.Controls;
using Client.DetailForms;
using Client.ListForms;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            addMaterialButtomMenu.Tag = new ButtonNavigation { FormType = typeof(MaterialDetailForm), EntityId = Guid.Empty };
            materialListButtomMenu.Tag = new ButtonNavigation { FormType = typeof(MaterialListForm) };
            detailButtonMenu.Tag = new ButtonNavigation { FormType = typeof(DetailListForm) };
            addDetailButtonMenu.Tag = new ButtonNavigation { FormType = typeof(DetailDetailForm), EntityId = Guid.Empty };
            productButtonMenu.Tag = new ButtonNavigation { FormType = typeof(ProductListForm) };
            addProductButtonMenu.Tag = new ButtonNavigation { FormType = typeof(ProductDetailForm), EntityId = Guid.Empty };
        }

        public void OpenMdiChildForm(object sender, EventArgs e)
        {
            ButtonNavigation buttonTag = null;

            if (sender is ToolStripItem)
                buttonTag = ((ToolStripItem)sender).Tag as ButtonNavigation;


            if (sender is DataGridViewImageCell)
                buttonTag = ((DataGridViewImageCell)sender).Tag as ButtonNavigation;

            if (buttonTag == null)
                return;

            CreateNewChilForm(buttonTag);

        }

        public void CreateNewChilForm(ButtonNavigation navigation)
        {

            var form =
                MdiChildren.SingleOrDefault(
                    s =>
                        ((ButtonNavigation)s.Tag).EntityId == navigation.EntityId &&
                        ((ButtonNavigation)s.Tag).FormType == navigation.FormType);

            if (form != null)
            {
                form.Activate();
                form.BringToFront();
                form.WindowState = FormWindowState.Maximized;
                return;
            }

            if (navigation.FormType == null)
                throw new Exception("Неизвестная форма");

            var constructor =
                navigation.FormType.GetConstructor(navigation.EntityId == null ? Type.EmptyTypes : new[] { typeof(Guid) });

            if (constructor == null)
                throw new Exception("Ошибка в конструктор формы");


            var constructorParams = navigation.EntityId == null ? new object[] { } : new object[] { navigation.EntityId };

            form = (Form)constructor.Invoke(constructorParams);
            form.Tag = navigation;
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        public void RebindListData(Type listFormType)
        {
            if (!listFormType.IsSubclassOf(typeof(BaseListForm)))
                return;

            var form =
                        MdiChildren.SingleOrDefault(
                            s => ((ButtonNavigation)s.Tag).FormType == listFormType);

            var baseListForm = (BaseListForm)form;
            baseListForm?.RebindGrid();
        }


    }
}
