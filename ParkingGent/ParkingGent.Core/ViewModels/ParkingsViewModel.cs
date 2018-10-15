using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using ParkingGent.Core.Models;
using ParkingGent.Core.Services;

namespace ParkingGent.Core.ViewModels
{
    public class ParkingsViewModel : MvxViewModel
    {
        //Via de Constructor spreken we de Service aan. (dependency injection)
        private readonly IParkingService _parkingService;
        private readonly IMvxNavigationService _navigationService;

        public ParkingsViewModel(IParkingService parkingService, IMvxNavigationService navigationService)
        {
            this._navigationService = navigationService;
            this._parkingService = parkingService;
            loadData();
        }

        //Lijst van parkings (PROPFULL)
        private List<Parking> _parkings;
        public List<Parking> Parkings
        {
            get
            { return _parkings; }
            set
            {
                _parkings = value;
                RaisePropertyChanged(() => Parkings);
            }
        }

        //Data ophalen
        private async void loadData()
        {
            List<Parking> parkeerLijst = await _parkingService.GetParkings();
            Parkings = parkeerLijst;
            RaisePropertyChanged(() => Parkings);
        }

        public Task<List<Parking>> functieVoorWidget()
        {
            return Task.Run(() => _parkingService.GetParkings());
        }

        //Navigeren naar detailView
        public IMvxCommand ShowDetailCommand {
            get{
                return new MvxCommand<Parking>(
                    SelectedParking => 
                {
                    ShowViewModel<DetailViewModel>(new { parkingId = SelectedParking.id});
                });
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }

        private MvxCommand _reloadCommand;
        public ICommand ReloadCommand
        {
            get { return _reloadCommand ?? (_reloadCommand = new MvxCommand(ExecuteReloadCommand)); }
        }

        private void ExecuteReloadCommand()
        {
            IsBusy = true;
            loadData();
            IsBusy = false;
        }
    }
}
