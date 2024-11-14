using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
                        estat = cmboxEstat.Text
                    });
                }
                else if(cmboxEstat.Text == "Doing")
                {
                    LlistaDoing.Add(new ItemKanBan()
                    {
                        tasca = txtName.Text,
                        estat = cmboxEstat.Text
                    });
                }
                else
                {
                    LlistaDone.Add(new ItemKanBan()
                    {
                        tasca = txtName.Text,
                        estat = cmboxEstat.Text
                    });
                }
                
                txtName.Clear();
            }
        }

        private void ButtonTreureItem_Click(object sender, RoutedEventArgs e)
        {
            if (LbToDo.SelectedItem != null)
            {
                LlistaToDo.Remove((ItemKanBan)LbToDo.SelectedItem);
            }
            else if (LbDoing.SelectedItem != null)
            {
                LlistaDoing.Remove((ItemKanBan)LbDoing.SelectedItem);
            }
            else if (LbDone.SelectedItem != null)
            {
                LlistaDone.Remove((ItemKanBan)LbDone.SelectedItem);
            }
        }

        private void ButtonBuidarLlista_Click(object sender, RoutedEventArgs e)
        {
            LlistaToDo.Clear();
            LlistaDoing.Clear();
            LlistaDone.Clear();
        }

    }
}