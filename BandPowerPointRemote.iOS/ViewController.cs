using System;

using UIKit;

using BandPowerPointRemote.iOS.Band;

using Microsoft.Band.Sensors;

namespace BandPowerPointRemote.iOS
{
	public partial class ViewController : UIViewController
	{
		private Band.Band _band;
		private CalibrationData _calibrationData;
		private GestureRecognizer _gestureRecognizer;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			BandConnectionArrow.SetConnectionStatus (ConnectionState.NotConnected);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void ConnectToBand() {
			if(_band != null) {
				//Don't try to connect twice
				return;
			}

			_band = new Band.Band();
			_band.ConnectionStateChanged += (s, e) => {
				bandStatusLabel.Text = e.NewState.ToString();

				BandConnectionArrow.SetConnectionStatus(e.NewState);

				if(e.NewState == Band.ConnectionState.Connected) {
					CalibrateButton.Enabled = true;
					BandConnected();
				}
			};

			_band.StartConnecting();
		}

		private void BandConnected()
		{
			var acc = _band.GetAccelerometer ();
			_gestureRecognizer = new GestureRecognizer (acc);

			_gestureRecognizer.Start (_calibrationData);

			acc.StartReadings ();
		}

		partial void ConnectToServerButton_TouchUpInside (UIButton sender)
		{
			AccessCodeTextBox.Text = "5555";
		}
			
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			//Do this on "appear" in case a child screen changed it
			_calibrationData = SharedSettings.GetCalibrationData ();

			this.ConnectToBand ();
		}
	}
}

