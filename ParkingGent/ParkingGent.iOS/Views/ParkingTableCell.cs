using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using ParkingGent.Core.Models;

namespace ParkingGent.iOS
{
    public partial class ParkingTableCell : MvxTableViewCell
    {

        internal static readonly NSString Identifier = new NSString("ParkingCell");

        public ParkingTableCell (IntPtr handle) : base (handle)
        {
            
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            MvxFluentBindingDescriptionSet<ParkingTableCell, Parking> set = new MvxFluentBindingDescriptionSet<ParkingTableCell, Parking>(this);
            set.Bind(lblParking).To(res => res.description);
            set.Bind(lblPlaatsen).To(res => res.AvailablePlacesString);
            set.Apply();
        }
    }
}