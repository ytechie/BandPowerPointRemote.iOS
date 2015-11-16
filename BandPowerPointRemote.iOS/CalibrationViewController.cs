using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BandPowerPointRemote.iOS
{
	partial class CalibrationViewController : UIViewController
	{
		private Band.Band _band;

		public CalibrationViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_band = new Band.Band ();
			var acc = _band.StartReadingAccelerometer ();
			acc.ReadingChanged += (sender, e) => {
				AccelXMeter.Progress = (float)(e.SensorReading.AccelerationX / 5);
				AccelYMeter.Progress = (float)(e.SensorReading.AccelerationY / 5);
				AccelZMeter.Progress = (float)(e.SensorReading.AccelerationZ / 5);
			};
		}
	}
}
