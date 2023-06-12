using MauiPopup.Views;

namespace Pololetni_projekt;

public partial class PopupPage : BasePopupPage
{
	public PopupPage()
	{
		InitializeComponent();
        //Task.Delay(5000);
        //Vibration.Default.Vibrate(500);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

    }

    private async void Btn_Start(object sender, EventArgs e)
    {
        // Wait for 5 seconds
        await Task.Delay(5000);

        // Vibrate for 0.5 seconds
        Vibration.Vibrate(500);
        MauiPopup.PopupAction.ClosePopup();
    }

    /*
    private void Btn_Done(object sender, EventArgs e)
    {
        
    }*/
}