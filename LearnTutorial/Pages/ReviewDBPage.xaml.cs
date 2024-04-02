
using LearnTutorial.Models;

namespace LearnTutorial.Pages;

public partial class ReviewDBPage : ContentPage
{
	Observation obs;
	public ReviewDBPage()
	{
		InitializeComponent();
		GetReviewList();

    }
	public async void GetReviewList()
	{
        lblDataReview.Text=await App.ObservationRepo.GetAllObservations();

    }
	private async void OnUpdateButtonClicked(object sender, EventArgs e)
	{
		try
		{
			if (int.TryParse(entryId.Text, out int observationId))
			{
				obs.Id = observationId;
			}
            else
            {
                throw new Exception("ID Error");
            }

			if (DateTime.TryParse(entryDateUpdate.Text, out DateTime date))
			{
				obs.Date = date;
			}
            else
            {
                throw new Exception("Date Error");
            }

			if (TimeSpan.TryParse(entryTimeUpdate.Text, out TimeSpan time))
			{
				obs.Time = time;
			}
			else
			{
				throw new Exception("Time Entry Error");
			}

			if(double.TryParse(entryVisibilityUpdate.Text, out double visibility))
			{
                obs.Visibility = visibility;
            }
			else
			{
				throw new Exception("Visibility Entry Error");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("ID/Date/Time/Visibility Error", $"Submission not entered due to error: {ex.Message}", "OK");
			return;
		}

		try
		{
			if (string.IsNullOrEmpty(entryLeopardSharkUpdate.Text.Trim()))
			{
				obs.LeopardSharkDepth = -1;
			}
			else
			{
				if(double.TryParse(entryLeopardSharkUpdate.Text.Trim(), out double sharkDepth))
				{
                    obs.LeopardSharkDepth = sharkDepth;
                }
				else
				{
					throw new Exception("Leopard Shark Depth Error");
				}
				
				
			}


			if (string.IsNullOrEmpty(entryGuitarFishUpdate.Text.Trim()))
			{
				obs.GuitarFishDepth = -1;
			}
			else
			{
				if (double.TryParse(entryGuitarFishUpdate.Text.Trim(), out double guitarDepth))
				{
					obs.GuitarFishDepth = guitarDepth;
				}
				else
				{
					throw new Exception("Guitar Fish Depth Error");
				}
			}

			if (string.IsNullOrEmpty(entryGaribaldiUpdate.Text.Trim()))
			{
				obs.GaribaldiDepth = -1;
			}
			else
			{
				if (double.TryParse(entryGaribaldiUpdate.Text.Trim(), out double garibaldiDepth))
				{
					obs.GaribaldiDepth = garibaldiDepth;
                }
                else
				{
                    throw new Exception("Garibaldi Depth Error");
                }
			}

			if (string.IsNullOrEmpty(entrySpinyLobsterUpdate.Text.Trim()))
			{
				obs.SpinyLobsterDepth = -1;
			}
			else
			{
				if(double.TryParse(entrySpinyLobsterUpdate.Text.Trim(), out double lobsterDepth))
				{
                    obs.SpinyLobsterDepth = lobsterDepth;
                }
				else
				{
					throw new Exception("Spiny Lobster Depth Error");
				}
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("Species Depth Error", $"Please check depth entry data. If species not seen. Leave blank. Record not added. Error: {ex.Message}", "OK");
			return;
		}


		await App.ObservationRepo.Update(new Observation()
		{
			Id = obs.Id,
			Date = obs.Date,
			Time = obs.Time,
			Visibility = obs.Visibility,
			GaribaldiDepth = obs.GaribaldiDepth,
			LeopardSharkDepth = obs.LeopardSharkDepth,
			GuitarFishDepth = obs.GuitarFishDepth,
			SpinyLobsterDepth = obs.SpinyLobsterDepth,
		});
		DisplayAlert("Success!", $"Succesfully updated your entry. Id number {entryId.Text}", "That's how I roll!");
		EmptyForm();
		FillInPLaceholder();
		GetReviewList();
	}
	private async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		try
		{
			if (int.TryParse(entryId.Text, out int DeleteId))
			{
				await App.ObservationRepo.Delete(await App.ObservationRepo.GetByID(DeleteId));
			}
			else
			{
				throw new Exception("Invalid ID entered in order to delete.");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("Deletion Error", $"Verify correct record selected to delete. Item not deleted. Error {ex.Message}", "OK");
			return;
		}
        await DisplayAlert("Success!", $"Succesfully deleted entry {entryId.Text}", "OK");
        EmptyForm();
        FillInPLaceholder();
        GetReviewList();
    }



    private async void OnSelectButtonClicked(object sender, EventArgs e)
	{
		try
		{
			if (Int32.TryParse(entryId.Text.Trim(), out int ID))
			{
				obs = await App.ObservationRepo.GetByID(ID);

			}
			else
			{
				await DisplayAlert("Incorrent ID Entry", $"ID entry must be a valid integer. '{entryId}' was incorrect", "OK");
				return;
			}
			entryDateUpdate.Text = obs.Date.ToShortDateString();
			entryTimeUpdate.Text=obs.Time.ToString();
			entryVisibilityUpdate.Text=obs.Visibility.ToString();
			entrySpinyLobsterUpdate.Text=obs.SpinyLobsterDepth.ToString();
			entryGaribaldiUpdate.Text=obs.GaribaldiDepth.ToString();
			entryGuitarFishUpdate.Text=obs.GuitarFishDepth.ToString();
			entryLeopardSharkUpdate.Text=obs.LeopardSharkDepth.ToString();

		}catch (Exception ex)
		{
			await DisplayAlert("Selection Error",$"Make sure your desired selection exists. Error: {ex.Message}", "OK");
		}
	}
	private void FillInPLaceholder()
	{
		entryId.Placeholder="ID";
        entryDateUpdate.Placeholder="Date";
		entryTimeUpdate.Placeholder = "Time";
        entryVisibilityUpdate.Placeholder= "Visibility(ft)";
        entrySpinyLobsterUpdate.Placeholder= "Depth(ft)";
        entryGaribaldiUpdate.Placeholder= "Depth(ft)";
        entryGuitarFishUpdate.Placeholder= "Depth(ft)";
        entryLeopardSharkUpdate.Placeholder= "Depth(ft)";
    }
	private void EmptyForm()
	{
        entryId.Text = "";
        entryDateUpdate.Text = "";
        entryTimeUpdate.Text = "";
        entryVisibilityUpdate.Text = "";
        entrySpinyLobsterUpdate.Text = "";
        entryGaribaldiUpdate.Text = "";
        entryGuitarFishUpdate.Text = "";
        entryLeopardSharkUpdate.Text = "";
    }
}