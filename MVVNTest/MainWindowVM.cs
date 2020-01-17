using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVNTest
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BaseDeDatosCarlosClementEntities ctx;
        public ObservableCollection<CLIENTE> Clients { get; set; }
        public CLIENTE ClientsModifyComboBoxSelectedItem { get; set; }

        public void InitializeVM()
        {
            ctx = new BaseDeDatosCarlosClementEntities();

            ctx.PEDIDOS.Load();
            ctx.CLIENTES.Include("PEDIDOS").Load();

            Clients = ctx.CLIENTES.Local;
        }

        public void SaveData(object sender, RoutedEventArgs e)
        {
            ctx.SaveChanges();
        }


    }
}
