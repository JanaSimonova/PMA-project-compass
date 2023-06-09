namespace Pololetni_projekt;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void ToggleCompass(object sender, EventArgs e)
    {
        if (Compass.Default.IsSupported)
        {
            if (!Compass.Default.IsMonitoring)
            {
                // Turn on compass
                Compass.Default.ReadingChanged += Compass_ReadingChanged;
                Compass.Default.Start(SensorSpeed.UI);
            }
            else
            {
                //// Turn off compass
                //Compass.Default.Stop();
                //Compass.Default.ReadingChanged -= Compass_ReadingChanged;
                //CompassLabel.Text = "Off";
                return;
            }
        }
    }
    private void OffToggleCompass(object sender, EventArgs e)
    {
        // Turn off compass
        Compass.Default.Stop();
        Compass.Default.ReadingChanged -= Compass_ReadingChanged;
        CompassLabel.Text = "Off";
        Direction.Text = "Turn on compass to see direction";
    }

    private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
    {
        // Update UI Label with compass state
        //CompassLabel.Text = Math.Round($"Compass: {e.Reading}");

        decimal roundedReading = decimal.Round((decimal)e.Reading.HeadingMagneticNorth, 1); // Zaokrouhlení na dvě desetinná místa

        CompassLabel.Text = Convert.ToString( roundedReading)+"°";

        // Direction conditions
        
        if(roundedReading > 315 || roundedReading <= 45 )
        {
            Direction.Text = "Heading to North";
        }
        if (roundedReading > 45 && roundedReading <= 135)
        {
            Direction.Text = "Heading to East";
        }
        if(roundedReading > 135 && roundedReading <= 225)
        {
            Direction.Text = "Heading to South";
        }
        if(roundedReading > 225 && roundedReading <= 315 )
        {
            Direction.Text = "Heading to West";
        }
        

    }

}

