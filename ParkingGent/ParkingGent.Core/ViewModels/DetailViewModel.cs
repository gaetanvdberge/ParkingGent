using System;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Core.ViewModels;
using ParkingGent.Core.Models;
using ParkingGent.Core.Services;
using UIKit;

namespace ParkingGent.Core.ViewModels
{
    public class DetailViewModel : MvxViewModel
    {
        public DetailViewModel(IParkingService parkingDataService)
        {
            this._parkingDataService = parkingDataService;
        }

        private readonly IParkingService _parkingDataService;


        public async void Init(int parkingId)
        {
            this.ParkingContent = await _parkingDataService.GetParkingById(parkingId);
            GetParkingData();
            FocusMap();
        }

        //--------------------------------
        //Begin Parking -------
        private Parking _parkingContent;
        public Parking ParkingContent
        {
            get { return _parkingContent; }
            set
            {
                _parkingContent = value;
                RaisePropertyChanged(() => ParkingContent);
            }
        }

        private MKCoordinateRegion _focusRegion;
        public MKCoordinateRegion FocusRegion
        {
            get { return _focusRegion; }
            set
            {
                _focusRegion = value;
                RaisePropertyChanged(() => FocusRegion);
            }
        }


        public void GetParkingData() //Dit was vroeger async
        {
            RaisePropertyChanged(() => ParkingContent);
        }

        public IMvxCommand NavigateCommand
        {
            get
            {
                return new MvxCommand<Parking>(
                    SelectedParking =>
                    {
                        UIAlertView alert = new UIAlertView(){Title = "Navigate to " + _parkingContent.description, Message = "Choose the navigation service you prefer.", CancelButtonIndex = 3};
                        alert.AddButton("Apple Maps");
                        alert.AddButton("Google Maps");
                        alert.AddButton("Waze");
                        alert.AddButton("Cancel");

                        alert.Clicked += (sender, buttonArgs) =>
                        {
                            if (buttonArgs.ButtonIndex == 0){
                                UIKit.UIApplication.SharedApplication.OpenUrl(new NSUrl(ParkingContent.NavigateLinkAppleMaps));
                            }
                            else if(buttonArgs.ButtonIndex == 1){
                                UIKit.UIApplication.SharedApplication.OpenUrl(new NSUrl(ParkingContent.NavigateLinkGoogleMaps));
                            }
                            else if (buttonArgs.ButtonIndex == 2)
                            {
                                UIKit.UIApplication.SharedApplication.OpenUrl(new NSUrl(ParkingContent.NavigateLinkWaze));
                            }
                        };
                        alert.Show();
                    });
            }
        }

        public void FocusMap()
        {
            //Map bij laden focussen op gebied:
            CLLocationCoordinate2D coords = new CLLocationCoordinate2D(ParkingContent.latitude, ParkingContent.longitude);
            MKCoordinateSpan span = new MKCoordinateSpan(0.01, 0.01);
            FocusRegion = new MKCoordinateRegion(coords, span);
        }
    }
}