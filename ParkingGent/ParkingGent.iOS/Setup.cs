using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.Logging;
using UIKit;

namespace WineApp.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override MvxLogProviderType GetDefaultLogProviderType()
            => MvxLogProviderType.None;


        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
    : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new ParkingGent.Core.App(); //Dit can ook Core.App zijn (of shared.App)
        }
    }
}
