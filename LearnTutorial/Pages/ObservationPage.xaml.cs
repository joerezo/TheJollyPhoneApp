
using LearnTutorial.Models;

namespace LearnTutorial.Pages

{
    public partial class ObservationPage : ContentPage
    {
        
           

        public ObservationPage()
        {
            InitializeComponent();

            DatePicker datePicker = new DatePicker()
            {
                MinimumDate = new DateTime(2024,1,1),
                MaximumDate = new DateTime(2024,12,31),
                Date = DateTime.Now.Date
            };

            TimePicker timePicker = new TimePicker()
            {
                Time = DateTime.Now.TimeOfDay
            };
            
        }

        private async void OnNewObservationButtonClicked(object sender, EventArgs args)
        {
            Observation obs= new Observation();
            statusMessage.Text = "";

            try
            {
                if (visibilityPicker.SelectedItem == null)
                {
                    throw new Exception("Need to enter visibility.");

                }
                else
                {
                    double.TryParse(visibilityPicker.SelectedItem.ToString(), out double vis);
                    obs.Visibility = vis;
                }

                if (leopardSharkPicker.SelectedItem==null || leopardSharkPicker.SelectedItem.ToString()=="Not Seen")
                {
                    obs.LeopardSharkDepth = -1;
                }
                else
                {
                    if (double.TryParse(leopardSharkPicker.SelectedItem.ToString(), out double sharkDepth))
                    {
                        obs.LeopardSharkDepth = sharkDepth;
                    }
                    else
                    {
                        throw new Exception("Leopard Shark Depth Error");
                    }


                }


                if (guitarFishPicker.SelectedItem == null || guitarFishPicker.SelectedItem.ToString() == "Not Seen")
                {
                    obs.GuitarFishDepth = -1;
                }
                else
                {
                    if (double.TryParse(guitarFishPicker.SelectedItem.ToString(), out double guitarDepth))
                    {
                        obs.GuitarFishDepth = guitarDepth;
                    }
                    else
                    {
                        throw new Exception("Guitar Fish Depth Error");
                    }
                }

                if (garibaldiPicker.SelectedItem == null || garibaldiPicker.SelectedItem.ToString() == "Not Seen")
                {
                    obs.GaribaldiDepth = -1;
                }
                else
                {
                    if (double.TryParse(garibaldiPicker.SelectedItem.ToString(), out double garibaldiDepth))
                    {
                        obs.GaribaldiDepth = garibaldiDepth;
                    }
                    else
                    {
                        throw new Exception("Garibaldi Depth Error");
                    }
                }

                if (spinyLobsterPicker.SelectedItem == null || spinyLobsterPicker.SelectedItem.ToString() == "Not Seen")
                {
                    obs.SpinyLobsterDepth = -1;
                }
                else
                {
                    if (double.TryParse(spinyLobsterPicker.SelectedItem.ToString(), out double lobsterDepth))
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

                      
            await App.ObservationRepo.AddNewObservation(
                datePicker.Date,
                timePicker.Time,
                obs.Visibility,
                (double)obs.LeopardSharkDepth,
                (double)obs.GuitarFishDepth,
                (double)obs.SpinyLobsterDepth,
                (double)obs.GaribaldiDepth) ;

            statusMessage.Text=App.ObservationRepo.StatusMessage+ DateTime.Now.ToLocalTime().ToShortTimeString();

            
        }
    }

}
