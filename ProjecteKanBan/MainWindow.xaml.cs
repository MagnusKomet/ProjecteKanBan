using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjecteKanBan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<string> llistaResponsables = new ObservableCollection<string>();

        ObservableCollection<ItemKanBan> llistaToDo = new ObservableCollection<ItemKanBan>();
        ObservableCollection<ItemKanBan> llistaDoing = new ObservableCollection<ItemKanBan>();
        ObservableCollection<ItemKanBan> llistaDone = new ObservableCollection<ItemKanBan>();        

        string defaultColor = "Transparent";
        int idCounter = 0;

        public MainWindow()
        {
            InitializeComponent();

            cmboxEstat.Items.Add("To Do");
            cmboxEstat.Items.Add("Doing");
            cmboxEstat.Items.Add("Done");

            cmboxResponsable.ItemsSource = llistaResponsables;

            LbToDo.ItemsSource = llistaToDo;
            LbDoing.ItemsSource = llistaDoing;
            LbDone.ItemsSource = llistaDone;
        }

        private void ButtonAfegirItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(cmboxResponsable.Text))
            {
                idCounter++;

                ItemKanBan nouElement = new ItemKanBan()
                {
                    id = idCounter,
                    tasca = txtName.Text,
                    estat = cmboxEstat.Text,
                    color = defaultColor,
                    dataStart = DateTime.Now,
                    responsable = cmboxResponsable.Text,

                    itemFinal = "Codi: " + idCounter +
                    "\nTasca: " + txtName.Text +
                    "\nData Inici: " + DateTime.Now +
                    "\nResponsable: " + cmboxResponsable.Text

                };

                if (cmboxEstat.Text == "To Do")
                {
                    llistaToDo.Add(nouElement);
                }
                else if(cmboxEstat.Text == "Doing")
                {
                    llistaDoing.Add(nouElement);
                }
                else
                {
                    llistaDone.Add(nouElement);
                }
                
                txtName.Clear();
            }
            else
            {
                MessageBox.Show("Falta assignar una tasca o responsable");
            }
        }

        private void ButtonTreureItem_Click(object sender, RoutedEventArgs e)
        {
            if (LbToDo.SelectedItem is ItemKanBan selectedItem)
            {
                llistaToDo.Remove(selectedItem);
            }
            else if (LbDoing.SelectedItem is ItemKanBan selectedItem2)
            {
                llistaDoing.Remove(selectedItem2);
            }
            else if (LbDone.SelectedItem is ItemKanBan selectedItem3)
            {
                llistaDone.Remove(selectedItem3);
            }
        }

        private void ButtonBuidarLlista_Click(object sender, RoutedEventArgs e)
        {
            llistaToDo.Clear();
            llistaDoing.Clear();
            llistaDone.Clear();
        }

        private void ButtonAfegirColor_Click(object sender, RoutedEventArgs e)
        {
            if (LbToDo.SelectedItem is ItemKanBan selectedItem)
            {
                PosarColor(selectedItem, sender);
                LbToDo.Items.Refresh();
                LbToDo.SelectedItem = null;
            }
            else if (LbDoing.SelectedItem is ItemKanBan selectedItem2)
            {
                PosarColor(selectedItem2, sender);
                LbDoing.Items.Refresh();
                LbDoing.SelectedItem = null;
            }
            else if (LbDone.SelectedItem is ItemKanBan selectedItem3)
            {
                PosarColor(selectedItem3, sender);
                LbDone.Items.Refresh();
                LbDone.SelectedItem = null;
            }

        }

        private void PosarColor(ItemKanBan selectedItem, object sender)
        {
            if (sender == btnBlue)
            {
                selectedItem.color = "CornflowerBlue";
            }
            else if (sender == btnGreen)
            {
                selectedItem.color = "LimeGreen";
            }
            else if (sender == btnRed)
            {
                selectedItem.color = "Tomato";
            }
            else
            {
                selectedItem.color = "Transparent";
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (sender == LbToDo)
                {
                    LbDoing.SelectedItem = null;
                    LbDone.SelectedItem = null;
                }
                else if (sender == LbDoing)
                {
                    LbDone.SelectedItem = null;
                    LbToDo.SelectedItem = null;
                }
                else if (sender == LbDone)
                {
                    LbDoing.SelectedItem = null;
                    LbToDo.SelectedItem = null;
                }
            }

        }

        private void btnGestionarResponsables_Click(object sender, RoutedEventArgs e)
        {
            Window responsables = new Responsables();

            responsables.Show();
            
        }
    }
}