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

            llistaResponsablesListBox.ItemsSource = MainWindow.llistaResponsables;
        }

        
        private void AfegirResponsableBoto_Click(object sender, RoutedEventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(nomResponsableTextBox.Text) &&
                !string.IsNullOrWhiteSpace(cognomResponsableTextBox.Text) &&
                !string.IsNullOrWhiteSpace(correuResponsableTextBox.Text))
            {
                MainWindow.llistaResponsables.Add(new Responsable(nomResponsableTextBox.Text, cognomResponsableTextBox.Text, correuResponsableTextBox.Text));
                nomResponsableTextBox.Text = string.Empty;
            }
            
        }

        private void EliminarResponsableBoto_Click(object sender, RoutedEventArgs e)
        {
            
            if (llistaResponsablesListBox.SelectedItem is Responsable responsable)
            {
                MainWindow.llistaResponsables.Remove(responsable);
            }
            
        }


    }
    }
