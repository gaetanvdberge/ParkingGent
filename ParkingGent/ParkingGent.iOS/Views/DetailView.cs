using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using ParkingGent.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MapKit;
using CoreLocation;
using CoreGraphics;

namespace ParkingGent.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class DetailView : MvxViewController<DetailViewModel>
    {
        public DetailView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            MvxFluentBindingDescriptionSet<DetailView, DetailViewModel> set =
                this.CreateBindingSet<DetailView, DetailViewModel>();
            
            //Kleur Tekst in baar
            this.NavigationController.NavigationBar.TintColor = UIColor.White;

            //Titel geven aan pagina
            set.Bind(this).For(v => v.Title).To(vm => vm.ParkingContent.description);

            //"Back" instellen ipv "Live Parking"
            //this.NavigationController.NavigationBar.TopItem.Title = "Back";

            set.Bind(lblParkingName).To(vm => vm.ParkingContent.description);
            set.Bind(lblAddress).To(vm => vm.ParkingContent.address);
            set.Bind(lblFreePlaces).To(vm => vm.ParkingContent.parkingStatus.availableCapacity);
            set.Bind(btnNavigate).To(vm => vm.NavigateCommand);

            set.Bind(lblPlacesTaken).To(vm => vm.ParkingContent.PlacesTaken);
            set.Bind(lblPlacesTotal).To(vm => vm.ParkingContent.parkingStatus.totalCapacity);


            //Navigatiebaar vullen
            set.Bind(pbBaar).For(s => s.Progress).To(vm => vm.ParkingContent.Progress);


            //Gebied van de map waarop gefocust moet worden
            set.Bind(mpMap).For(s => s.Region).To(vm => vm.FocusRegion);

            //Annotatie op de map toevoegen
            // add an annotation:
            //set.Bind(mpMap).For(s => s.SelectedAnnotations).To(vm => vm.ParkingContent.MapAnnotation);
            mpMap.AddAnnotations(ViewModel.ParkingContent.MapAnnotation);

            #region ENKEL NODIG BIJ DEPLOYEN OP FYSIEKE IPHONE DOOR BUG
            //Map bij laden focussen op gebied:
            CLLocationCoordinate2D coords = new CLLocationCoordinate2D(ViewModel.ParkingContent.latitude, ViewModel.ParkingContent.longitude);
            MKCoordinateSpan span = new MKCoordinateSpan(0.01, 0.01);
            mpMap.Region = new MKCoordinateRegion(coords, span);
            #endregion

            set.Apply();
        }

    }
}