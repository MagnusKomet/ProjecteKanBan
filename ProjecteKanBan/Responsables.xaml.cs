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
        ResponsablesApiClient api;
        public Responsables()
        {
            InitializeComponent();

            llistaResponsablesListBox.ItemsSource = MainWindow.llistaResponsables;
            api = new ResponsablesApiClient();
        }

        private async void LoadResponsables()
        {
            var responsables = await api.GetResponsableAsync();
            llistaResponsablesListBox.ItemsSource = responsables;
        }

        private async void CarregarResponsableBoto_Click(object sender, RoutedEventArgs e)
        {
            if (llistaResponsablesListBox.SelectedItem is Responsable selectedResponsable)
            {
                var responsable = await api.GetResponsableAsync(selectedResponsable.id);
                if (responsable != null)
                {
                    nomResponsableTextBox.Text = responsable.nom;
                    cognomResponsableTextBox.Text = responsable.cognom;
                    correuResponsableTextBox.Text = responsable.correu;
                }
                else
                {
                    MessageBox.Show("No s'ha trobat el responsable.");
                }
            }
        }

        private async void AfegirResponsableBoto_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nomResponsableTextBox.Text) &&
                !string.IsNullOrWhiteSpace(cognomResponsableTextBox.Text) &&
                !string.IsNullOrWhiteSpace(correuResponsableTextBox.Text))
            {
                Responsable nouResponsable = new Responsable(nomResponsableTextBox.Text, cognomResponsableTextBox.Text, correuResponsableTextBox.Text);
                MainWindow.llistaResponsables.Add(nouResponsable);
                await api.AddAsync(nouResponsable); 
                nomResponsableTextBox.Text = string.Empty;
                cognomResponsableTextBox.Text = string.Empty;
                correuResponsableTextBox.Text = string.Empty;
            }
            
        }

        private async void EliminarResponsableBoto_Click(object sender, RoutedEventArgs e)
        {
            
            if (llistaResponsablesListBox.SelectedItem is Responsable responsable)
            {
                MainWindow.llistaResponsables.Remove(responsable);
                await api.DeleteAsync(responsable.id);
            }
            
        }
        public async void refresh()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            llistaResponsablesListBox.ItemsSource = await api.GetResponsableAsync();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }

    }
    }
