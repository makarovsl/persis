using System;
using System.Linq;
using System.Windows.Forms;
using Client.AddForms;
using Client.Controls;
using Client.ListForms;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            addMaterialButtomMenu.Tag = new ButtonNavigation {FormType = typeof (MaterialAddForm)};
            materialListButtomMenu.Tag = new ButtonNavigation {FormType = typeof (MaterialListForm)};
            detailButtonMenu.Tag = new ButtonNavigation {FormType = typeof (DetailListForm)};
            addDetailButtonMenu.Tag = new ButtonNavigation {FormType = typeof (DetailAddForm)};
        }

        public void OpenMdiChildForm(object sender, EventArgs e)
        {
            ButtonNavigation buttonTag = null;

            if (sender is ToolStripItem)
                buttonTag =  ((ToolStripItem) sender).Tag as ButtonNavigation;


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


    }
}
