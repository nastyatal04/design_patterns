using System.Windows;
using System.Windows.Controls;

namespace KR
{
    public partial class MainWindow : Window
    {
        Singletone singletoneAir;
        public MainWindow()
        {
            InitializeComponent();
            singletoneAir = Singletone.GetInstance();
            
            singletoneAir.Airplanes.AddObserve(PrintAirplaneTree);
        }
        private void PrintAirplaneTree()
        {
            AirplanesTree.Items.Clear();
            foreach(var air in singletoneAir.Airplanes.Data)
            {
                AirplanesTree.Items.Add(air.AsTreeNode());                
            }    
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            var tvItem = (TreeViewItem)sender;
            MessageBox.Show("Выбран узел: " + tvItem.Header.ToString());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new CreateWindow();
            window1.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedAirplaneIndex = singletoneAir.Airplanes.SelectedAirplaneIndex;
            singletoneAir.Airplanes.RemoveAt(selectedAirplaneIndex);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedAirplaneIndex = singletoneAir.Airplanes.SelectedAirplaneIndex;
            var window1 = new CreateWindow(selectedAirplaneIndex);
            window1.Show();
        }
    }
}
