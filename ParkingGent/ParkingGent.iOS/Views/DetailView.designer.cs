// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ParkingGent.iOS
{
    [Register ("DetailView")]
    partial class DetailView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnNavigate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAddress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblFreePlaces { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblParkingName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPlacesTaken { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPlacesTotal { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView mpMap { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIProgressView pbBaar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnNavigate != null) {
                btnNavigate.Dispose ();
                btnNavigate = null;
            }

            if (lblAddress != null) {
                lblAddress.Dispose ();
                lblAddress = null;
            }

            if (lblFreePlaces != null) {
                lblFreePlaces.Dispose ();
                lblFreePlaces = null;
            }

            if (lblParkingName != null) {
                lblParkingName.Dispose ();
                lblParkingName = null;
            }

            if (lblPlacesTaken != null) {
                lblPlacesTaken.Dispose ();
                lblPlacesTaken = null;
            }

            if (lblPlacesTotal != null) {
                lblPlacesTotal.Dispose ();
                lblPlacesTotal = null;
            }

            if (mpMap != null) {
                mpMap.Dispose ();
                mpMap = null;
            }

            if (pbBaar != null) {
                pbBaar.Dispose ();
                pbBaar = null;
            }
        }
    }
}