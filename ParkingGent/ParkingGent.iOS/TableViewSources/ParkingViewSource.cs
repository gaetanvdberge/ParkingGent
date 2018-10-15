using System;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace ParkingGent.iOS.TableViewSources
{
    public class ParkingViewSource : MvxTableViewSource
    {
        public ParkingViewSource(UITableView tableView) : base(tableView)
        {
            
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, Foundation.NSIndexPath indexPath, object item)
        {
            try
            {
                var cell = (ParkingTableCell)tableView.DequeueReusableCell(ParkingTableCell.Identifier, indexPath);
                return cell;
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }
    }
}
