using System;

using UIKit;

namespace BandPowerPointRemote.iOS
{
	public partial class ViewController : UIViewController
	{
		private Band.Band _band;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.ConnectToBand ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void ConnectToBand() {
			_band = new Band.Band();
			_band.ConnectionStateChanged += (s, e) => {
				bandStatusLabel.Text = e.NewState.ToString();

				BandConnectionArrow.SetConnectionStatus(e.NewState);

			};
			_band.StartConnecting();
		}

		partial void ConnectToServerButton_TouchUpInside (UIButton sender)
		{
			AccessCodeTextBox.Text = "5555";
		}
	}
}

