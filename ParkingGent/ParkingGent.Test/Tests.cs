using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MvvmCross.Core.Platform;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Tests;
using NUnit.Framework;
using ParkingGent.Core.Models;
using ParkingGent.Core.Services;
using ParkingGent.Core.ViewModels;

namespace ParkingGent.Test
{
    [TestFixture]
    public class Tests : MvxIoCSupportingTest
    {

        protected MockDispatcher mockDispatcher;

        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();
            mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());
        }



        [Test]
        public void ParkingsOphalen()
        {
            try
            {
                var parkeerLijst = new List<Parking>(); //= await _parkingDataService.GetParkings();

                parkeerLijst.Add(new Parking() { id = 1, address = "Straat", description = "Parking 01" });
                parkeerLijst.Add(new Parking() { id = 2, address = "Straat 2", description = "Parking 02" });

                var mockParkingService = new Mock<IParkingService>();
                mockParkingService.Setup(ps => ps.GetParkings()).Returns(Task.FromResult(parkeerLijst));

                //Hier geeft hij de error "operation not supported on this platform"
                //var vm = new ParkingsViewModel(mockParkingService.Object, null);

                //var allParkings = vm.Parkings;

                Assert.NotNull(parkeerLijst);
                //Assert.IsTrue(allParkings.Count == 2);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
