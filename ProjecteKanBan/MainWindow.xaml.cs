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

        ObservableCollection<ItemKanBan> LlistaToDo = new ObservableCollection<ItemKanBan>();
        ObservableCollection<ItemKanBan> LlistaDoing = new ObservableCollection<ItemKanBan>();
        ObservableCollection<ItemKanBan> LlistaDone = new ObservableCollection<ItemKanBan>();

        string defaultColor = "Transparent";

        public MainWindow()
        {
            InitializeComponent();

            cmboxEstat.Items.Add("To Do");
            cmboxEstat.Items.Add("Doing");
            cmboxEstat.Items.Add("Done");

            LbToDo.ItemsSource = LlistaToDo;
            LbDoing.ItemsSource = LlistaDoing;
            LbDone.ItemsSource = LlistaDone;
        }

        private void ButtonAfegirItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                
                if(cmboxEstat.Text == "To Do")
                {
                    LlistaToDo.Add(new ItemKanBan()
                    {
                        tasca = txtName.Text,
                        estat = cmboxEstat.Text,
                        color = defaultColor
                    });
                }
                else if(cmboxEstat.Text == "Doing")
                {
                    LlistaDoing.Add(new ItemKanBan()
                    {
                        tasca = txtName.Text,
                        estat = cmboxEstat.Text,
                        color = defaultColor
                    });
                }
                else
                {
                    LlistaDone.Add(new ItemKanBan()
                    {
                        tasca = txtName.Text,
                        estat = cmboxEstat.Text,
                        color = defaultColor
                    });
                }
                
                txtName.Clear();
            }
        }

        private void ButtonTreureItem_Click(object sender, RoutedEventArgs e)
        {
            if (LbToDo.SelectedItem is ItemKanBan selectedItem)
            {
                LlistaToDo.Remove(selectedItem);
            }
            else if (LbDoing.SelectedItem is ItemKanBan selectedItem2)
            {
                LlistaDoing.Remove(selectedItem2);
            }
            else if (LbDone.SelectedItem is ItemKanBan selectedItem3)
            {
                LlistaDone.Remove(selectedItem3);
            }
        }

        private void ButtonBuidarLlista_Click(object sender, RoutedEventArgs e)
        {
            LlistaToDo.Clear();
            LlistaDoing.Clear();
            LlistaDone.Clear();
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
                selectedItem.color = "Blue";
            }
            else if (sender == btnGreen)
            {
                selectedItem.color = "Green";
            }
            else if (sender == btnRed)
            {
                selectedItem.color = "Red";
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

    }
}