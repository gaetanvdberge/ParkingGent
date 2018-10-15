using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace ParkingGent.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<ViewModels.ParkingsViewModel>();

        }
    }
}
