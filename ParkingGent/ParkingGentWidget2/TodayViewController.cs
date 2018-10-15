using System;

using NotificationCenter;
using Foundation;
using UIKit;
using System.Collections.Generic;
using ParkingGent.Core.Models;
using ParkingGent.Core.CodeForWidget;
using System.Diagnostics;
using ParkingGent.Core.Services;
using CoreGraphics;

namespace ParkingGentWidget2
{
    public partial class TodayViewController : UIViewController, INCWidgetProviding
    {
        //private readonly WidgetCode _widgetCode;
        protected TodayViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.i
            //this._widgetCode = widgetCode;
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            loadData();
            this.ExtensionContext?.SetWidgetLargestAvailableDisplayMode(NCWidgetDisplayMode.Expanded);
        }

        private const int PrefferedHeight = 310;

        [Export("widgetActiveDisplayModeDidChange:withMaximumSize:")]
        public void WidgetActiveDisplayModeDidChange(NCWidgetDisplayMode activeDisplayMode, CGSize maxSize)
        {
            switch (activeDisplayMode)
            {
                case NCWidgetDisplayMode.Compact:
                    PreferredContentSize = maxSize;
                    break;

                case NCWidgetDisplayMode.Expanded:
                    PreferredContentSize = new CGSize(maxSize.Width, PrefferedHeight);
                    break;
            }
        }


        [Export("widgetPerformUpdateWithCompletionHandler:")]
        public void WidgetPerformUpdate(Action<NCUpdateResult> completionHandler)
        {
            // Perform any setup necessary in order to update the view.

            // If an error is encoutered, use NCUpdateResultFailed
            // If there's no update required, use NCUpdateResultNoData
            // If there's an update, use NCUpdateResultNewData

            completionHandler(NCUpdateResult.NewData);
        }
        List<Parking> parkeerlijst = new List<Parking>();

        public async void loadData(){
            WidgetCode widgetCode = new WidgetCode();
            parkeerlijst = await widgetCode.GetParkings();
            lblStad1.Text = parkeerlijst[0].description;
            lblStad2.Text = parkeerlijst[1].description;
            lblStad3.Text = parkeerlijst[2].description;
            lblStad4.Text = parkeerlijst[3].description;
            lblStad5.Text = parkeerlijst[4].description;
            lblStad6.Text = parkeerlijst[5].description;

            lblStad1Plaatsen.Text = parkeerlijst[0].parkingStatus.availableCapacity.ToString();
            lblStad2Plaatsen.Text = parkeerlijst[1].parkingStatus.availableCapacity.ToString();
            lblStad3Plaatsen.Text = parkeerlijst[2].parkingStatus.availableCapacity.ToString();
            lblStad4Plaatsen.Text = parkeerlijst[3].parkingStatus.availableCapacity.ToString();
            lblStad5Plaatsen.Text = parkeerlijst[4].parkingStatus.availableCapacity.ToString();
            lblStad6Plaatsen.Text = parkeerlijst[5].parkingStatus.availableCapacity.ToString();

            lblStad1Straat.Text = parkeerlijst[0].address;
            lblStad2Straat.Text = parkeerlijst[1].address;
            lblStad3Straat.Text = parkeerlijst[2].address;
            lblStad4Straat.Text = parkeerlijst[3].address;
            lblStad5Straat.Text = parkeerlijst[4].address;
            lblStad6Straat.Text = parkeerlijst[5].address;

            Debug.WriteLine(parkeerlijst);
        }
    }
}
