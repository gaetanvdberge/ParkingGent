using System;
using MapKit;
using UIKit;

namespace ParkingGent.iOS
{
    public class LinkerPleaseInclude
    {
        public LinkerPleaseInclude()
        {
        }

        public void Include(ConsoleColor color)
        {
            Console.Write("");
            Console.WriteLine("");
            color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void Include(UITextField textField)
        {
            textField.Text = textField.Text + "";
            textField.EditingChanged += (sender, args) => { textField.Text = ""; };
        }

        public void Include(UIProgressView progressView)
        {
            progressView.Progress = progressView.Progress;
        }

        public void Include(UIButton uiButton)
        {
            uiButton.TouchUpInside += (s, e) =>
                uiButton.SetTitle(uiButton.Title(UIControlState.Normal), UIControlState.Normal);
        }
    }
}
