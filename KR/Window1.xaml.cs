using System;
using System.Windows;
namespace KR
{
    public partial class CreateWindow : Window
    {
        Singletone singletoneAir = Singletone.GetInstance();
        int SelectedIndex;
        public CreateWindow(int selectedAirplaneIndex = -1)
        {
            InitializeComponent();
            SelectedIndex = selectedAirplaneIndex;
            if (SelectedIndex != -1)
                FillFields(singletoneAir.Airplanes[SelectedIndex]);
            else
            {
                AirName.Text = "Ту-124";
                AirNumberOfSeats.Text = Convert.ToString(100);
                AirCruisingSpeed.Text = Convert.ToString(100);
                AirFlightRange.Text = Convert.ToString(100);
                AirMaxWeight.Text = Convert.ToString(100);
                AirMaxFlightAltitude.Text = Convert.ToString(100);
            }
        }
        private void FillFields(Airplane airplane)
        {
            AirName.Text = airplane.Name;
            AirNumberOfSeats.Text = Convert.ToString(airplane.NumberOfSeats);
            AirCruisingSpeed.Text = Convert.ToString(airplane.CruisingSpeed);
            AirFlightRange.Text = Convert.ToString(airplane.FlightRange);
            AirMaxWeight.Text = Convert.ToString(airplane.MaxTakeOffWeight);
            AirMaxFlightAltitude.Text = Convert.ToString(airplane.MaxFlightAltitude);
        }
        private void SaveAdd_Click(object sender, RoutedEventArgs e)
        {
            var air = new Airplane(
                    AirName.Text,
                    Convert.ToInt32(AirNumberOfSeats.Text),
                    Convert.ToInt32(AirCruisingSpeed.Text),
                    Convert.ToInt32(AirFlightRange.Text),
                    Convert.ToInt32(AirMaxWeight.Text),
                    Convert.ToInt32(AirMaxFlightAltitude.Text));
            if (SelectedIndex == -1)
                singletoneAir.Airplanes.Add(air);   
            else
                singletoneAir.Airplanes[SelectedIndex] = air;
        }
    }
}
