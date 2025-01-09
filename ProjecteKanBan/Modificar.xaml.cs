using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjecteKanBan
{
    /// <summary>
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
                    
        ItemKanBan item = MainWindow.itemSeleccionat;

        public Modificar()
        {
            InitializeComponent();
            
            cmboxResponsable.ItemsSource = MainWindow.llistaResponsables;
            txtTasca.Text = item.tasca;
            cmboxResponsable.SelectedValue = item.responsable;
            datePicker.Text = item.dataFinish;
        }
        
        private void ConfirmarEdit_Click(object sender, RoutedEventArgs e)
        {
            
            item.tasca = txtTasca.Text;
            item.responsable = (Responsable)cmboxResponsable.SelectedItem;
            item.dataFinish = datePicker.SelectedDate.Value.ToShortDateString();

            MainWindow.itemSeleccionat = item;
            this.Close();
            
        }
        
    }
}
