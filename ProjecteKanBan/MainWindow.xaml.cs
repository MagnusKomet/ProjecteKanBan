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

        ObservableCollection<ItemKanBan> LlistaItems = new ObservableCollection<ItemKanBan>();

        public MainWindow()
        {
            InitializeComponent();

            cmboxEstat.Items.Add("To Do");
            cmboxEstat.Items.Add("Doing");
            cmboxEstat.Items.Add("Done");
        }

        private void ButtonAfegirItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !ItemsListbox.Items.Contains(txtName.Text))
            {
                LlistaItems.Add(new ItemKanBan()
                {
                    tasca = txtName.Text,
                    estat = cmboxEstat.Text
                });
                ItemsListbox.ItemsSource = LlistaItems;
                txtName.Clear();
            }
        }

        private void ButtonTreureItem_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsListbox.SelectedItem != null)
            {
                LlistaItems.Remove((ItemKanBan)ItemsListbox.SelectedItem);
            }
        }

        private void ButtonBuidarLlista_Click(object sender, RoutedEventArgs e)
        {
            ItemsListbox.ItemsSource = null;
        }

    }
}