using System;
using System.Windows;
using System.Windows.Controls;

namespace KR
{
    public class Airplane
    {
        /// <summary>
        /// Наименование самолёта.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Число мест в самолёте.
        /// </summary>
        public int NumberOfSeats { get; set; }
        /// <summary>
        /// Крейсерская скорость.
        /// </summary>
        public int CruisingSpeed { get; set; }
        /// <summary>
        /// Дальность полёта.
        /// </summary>
        public int FlightRange { get; set; }
        /// <summary>
        /// Максимальная взлетная масса. 
        /// </summary>
        public int MaxTakeOffWeight { get; set; }
        /// <summary>
        /// Максимальная высота полета.
        /// </summary>
        public int MaxFlightAltitude { get; set; }

        public Action<Airplane>? OnSelected;

        public Airplane(string name,
            int numberOfSeats,
            int cruisingSpeed,
            int flightRange,
            int maximumTakeOffWeight,
            int maximumFlightAltitude)
        {
            Name = name;
            NumberOfSeats = numberOfSeats;
            CruisingSpeed = cruisingSpeed;
            FlightRange = flightRange;
            MaxTakeOffWeight = maximumTakeOffWeight;
            MaxFlightAltitude = maximumFlightAltitude;
        }

        public TreeViewItem AsTreeNode()
        {
            var node = new TreeViewItem();
            node.Selected += NodeSelected;
            node.Header = Name;
            node.Items.Add($"Число мест: {NumberOfSeats}");
            node.Items.Add($"Крейсерская скорость: {CruisingSpeed}");
            node.Items.Add($"Дальность полёта: {FlightRange}");
            node.Items.Add($"Максимальная взлётная масса: {MaxTakeOffWeight}");
            node.Items.Add($"Максимальная высота полета: {MaxFlightAltitude}");
            return node;
        }

        private void NodeSelected(object sender, RoutedEventArgs e)
        {
            if (OnSelected != null)
                OnSelected(this);
        }

        public override string ToString()
        {
            return $"Наименование: {Name}\n" +
                   $"Число мест: {NumberOfSeats}\n" +
                   $"Крейсерская скорость: {CruisingSpeed}\n" +
                   $"Дальность полёта: {FlightRange}\n" +
                   $"Максимальная взлётная масса: {MaxTakeOffWeight}\n" +
                   $"Максимальная высота полета: {MaxFlightAltitude}\n";
        }
    }
}
