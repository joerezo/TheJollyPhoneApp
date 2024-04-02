namespace LearnTutorial.Pages;

public partial class LocationPage : ContentPage
{
	
	public LocationPage()
	{
		InitializeComponent();
		InitializeUI();

    }

	public async void InitializeUI()
	{
		LeopardSharkSightings();
		GuitarFishSightings();
		GaribaldiSighting();
		SpinyLobsterSightings();
    }
	public async void LeopardSharkSightings()
	{
		
		lblLeopardSightings.Text= await App.ObservationRepo.GetLeopardSharkSightings();//this points to the instantion of the databse in the app
	}

	public async void GuitarFishSightings()
	{
		lblGuitarFishSightings.Text=await App.ObservationRepo.GetGuitarFishSightings();
	}
	public async void GaribaldiSighting()
	{
		lblGaribaldiSightings.Text=await App.ObservationRepo.GetGaribaldiSightings();
	}
	public async void SpinyLobsterSightings()
	{
		lblSpinyLobsterSightings.Text=await App.ObservationRepo.GetSpinyLobsterSightings();
	}
	public async void OnRefreshButtonClicked(object sender, EventArgs e)
	{
		InitializeUI();
	}

}