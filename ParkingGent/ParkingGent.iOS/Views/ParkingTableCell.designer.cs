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
    [Register ("ParkingTableCell")]
    partial class ParkingTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblParking { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPlaatsen { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblParking != null) {
                lblParking.Dispose ();
                lblParking = null;
            }

            if (lblPlaatsen != null) {
                lblPlaatsen.Dispose ();
                lblPlaatsen = null;
            }
        }
    }
}