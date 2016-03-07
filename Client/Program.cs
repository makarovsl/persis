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
    }
}
