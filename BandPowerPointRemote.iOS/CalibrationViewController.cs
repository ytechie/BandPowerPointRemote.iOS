using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BandPowerPointRemote.iOS
{
	partial class CalibrationViewController : UIViewController
	{
		private Band.Band _band;

		private double xMax;
		private double yMax;
		private double zMax;

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

				if(e.SensorReading.AccelerationX > xMax)
					xMax = e.SensorReading.AccelerationX;
				if(e.SensorReading.AccelerationY > yMax)
					yMax = e.SensorReading.AccelerationY;
				if(e.SensorReading.AccelerationZ > zMax)
					zMax = e.SensorReading.AccelerationZ;

				GForceText.Text = Math.Max(xMax, Math.Max(yMax, zMax)).ToString("#.##");
				if(xMax > Math.Max(yMax, zMax))
					GestureAxisText.Text = "X";
				else if(yMax > Math.Max(xMax, zMax))
					GestureAxisText.Text = "Y";
				else
					GestureAxisText.Text = "Z";
			};
		}

		partial void ResetButton_TouchUpInside (UIButton sender)
		{
			xMax = 0;
			yMax = 0;
			zMax = 0;

			GForceText.Text = "";
			GestureAxisText.Text = "";
		}
	}
}
