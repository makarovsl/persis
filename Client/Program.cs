using System;
using System.Windows.Forms;
using Core.OperationInterfaces;
using Core.Operations;
using DAL.Common.DbEntity;
using DAL.Common.DbInterface;
using DAL.Entity;
using DAL.EntityDb;
using Microsoft.Practices.Unity;

namespace Client
{
    static class Program
    {
        private static UnityContainer _container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] 
        static void Main()
        {
            _container = new UnityContainer();
            RegisterDependency();
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

             Application.Run(new MainForm());
        }

        public static T Resolve<T>() where T: class
        {
            return _container.Resolve<T>();

        }

        /// <summary>
        /// Регистрация типов для DI
        /// </summary>
        private static void RegisterDependency()
        {
            _container.RegisterInstance(typeof(MainDbContext));
            _container.RegisterType<IDbContext, MainDbContext>(new ContainerControlledLifetimeManager());

            #region entities

            _container.RegisterInstance(typeof(MaterialDb));
            _container.RegisterType<IRemovableEntityDb<Material>, MaterialDb>();

            _container.RegisterInstance(typeof(MaterialOperationDb));
            _container.RegisterType<IEntityDb<MaterialOperation>, MaterialOperationDb>();

            _container.RegisterInstance(typeof(DetailDb));
            _container.RegisterType<IRemovableEntityDb<Detail>, DetailDb>();

            _container.RegisterInstance(typeof(ProductDb));
            _container.RegisterType<IEntityDb<Product>, ProductDb>();

            _container.RegisterInstance(typeof(MaterialOfDetailDb));
            _container.RegisterType<IM2MEntityDb<MaterialOfDetail>, MaterialOfDetailDb>();

            _container.RegisterInstance(typeof(DetailOfProductDb));
            _container.RegisterType<IM2MEntityDb<DetailOfProduct>, DetailOfProductDb>();

            #endregion

            #region actions

            _container.RegisterInstance(typeof(MaterialAction));
            _container.RegisterType<IMaterialAction, MaterialAction>(new ContainerControlledLifetimeManager());

            _container.RegisterInstance(typeof(DetailAction));
            _container.RegisterType<IDetailAction, DetailAction>(new ContainerControlledLifetimeManager());

            _container.RegisterInstance(typeof(ProductAction));
            _container.RegisterType<IProductAction, ProductAction>(new ContainerControlledLifetimeManager());

            #endregion
        }

        public static T PerformCall<T, TP>(TP param, Func<TP, T> func)
        {
             try
             {
                 return func(param);
             }
             catch (Exception ex)
             {

                 MessageBox.Show(ex.Message, @"Ошибка!");
                 return default(T);
             }
        }

        public static T PerformCall<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, @"Ошибка!");
                return default(T);
            }
        }

        public static void PerformCall<T>(T param, Action<T> func)
        {
            try
            {
                func(param);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, @"Ошибка!");
            }
        }

        public static decimal ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            var textLabel = new Label { Left = 50, Top = 20, Text = text, Width = 300};
            var textBox = new NumericUpDown { Left = 50, Top = 50, Width = 400, Minimum = 1, Maximum = decimal.MaxValue};
            var confirmation = new Button { Text = @"Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Value : 0;
        }
    }
}
