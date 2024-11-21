using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para Responsables.xaml
    /// </summary>
    public partial class Responsables : Window
    {

        
        public Responsables()
        {
            InitializeComponent();

            MainWindow.llistaResponsables.Add("exemple");

        }

        private void afegirResponsableBoto_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nomResponsableTextBox.Text))
            {
                llistaResponsables.Add(nomResponsableTextBox.Text);
            }
        }

        private void eliminarResponsableBoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
