using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using ParkingGent.Core.ViewModels;
using ParkingGent.iOS.TableViewSources;
using MvvmCross.Binding.BindingContext;

namespace ParkingGent.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class ParkingView : MvxTableViewController<ParkingsViewModel>
    {
        public ParkingView (IntPtr handle) : base (handle)
        {
        }

        private ParkingViewSource _parkingViewSource;

        public override void ViewDidLoad()
        {
            _parkingViewSource = new ParkingViewSource(this.TableView);
            base.ViewDidLoad();

            this.TableView.Source = _parkingViewSource;
            this.TableView.ReloadData();

            //Blauwe achtergrondkleur geven aan top bar
            this.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(0, 159, 227);
            this.NavigationController.NavigationBar.Translucent = false;

            //Kleur scheidingslijn
            this.TableView.SeparatorColor = UIColor.FromRGB(0, 159, 227);

            //Om de overige scheidingslijnen te verbergen
            this.TableView.TableFooterView = new UIView();

            //Tekstkleur in top bar ==> WIT
            UIStringAttributes textColor = new UIStringAttributes() {ForegroundColor = UIColor.White };
            this.NavigationController.NavigationBar.TitleTextAttributes = textColor;

            //Titel geven aan top bar
            this.Title = "Live Parking";

            MvxFluentBindingDescriptionSet<ParkingView, ParkingsViewModel> set = new MvxFluentBindingDescriptionSet<ParkingView, ParkingsViewModel>(this);
            //Lijst opvullen met Parkings
            set.Bind(_parkingViewSource).To(vm => vm.Parkings);

            //Code voor het selecteren van een rij
            set.Bind(_parkingViewSource)
               .For(scr => scr.SelectionChangedCommand)
               .To(vm => vm.ShowDetailCommand);


            //Code voor het refreshen (pull to refresh)
            var refreshControl = new MvxUIRefreshControl();
            this.RefreshControl = refreshControl;
            refreshControl.TintColor = UIColor.FromRGB(0, 159, 227);

            set.Bind(refreshControl).For(r => r.IsRefreshing).To(vm => vm.IsBusy);
            set.Bind(refreshControl).For(r => r.RefreshCommand).To(vm => vm.ReloadCommand);


            set.Apply();
        }
    }
}