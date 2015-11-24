using Foundation;
using System;
using System.Linq;
using System.CodeDom.Compiler;
using UIKit;

using Microsoft.Band.Sensors;

namespace BandPowerPointRemote.iOS
{
	partial class CalibrationViewController : UIViewController
	{
		private Band.Band _band;

		private double xMax;
		private double yMax;
		private double zMax;

		private CalibrationData _calibrationData;


		public CalibrationViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_calibrationData = SharedSettings.GetCalibrationData ();
			UpdateUI ();

			_band = new Band.Band ();
			var acc = _band.GetAccelerometer ();

			acc.ReadingChanged += (sender, e) => {
				_calibrationData.Calibrated = true;

				AccelXMeter.Progress = (float)(e.SensorReading.AccelerationX / 5);
				AccelYMeter.Progress = (float)(e.SensorReading.AccelerationY / 5);
				AccelZMeter.Progress = (float)(e.SensorReading.AccelerationZ / 5);

				if(e.SensorReading.AccelerationX > xMax)
					xMax = e.SensorReading.AccelerationX;
				if(e.SensorReading.AccelerationY > yMax)
					yMax = e.SensorReading.AccelerationY;
				if(e.SensorReading.AccelerationZ > zMax)
					zMax = e.SensorReading.AccelerationZ;

				var currMax = Enumerable.Max(new []{xMax, yMax, zMax});
				if(_calibrationData.CalibrationValue <= currMax)
				{
					_calibrationData.CalibrationValue = currMax;

					if(xMax > Math.Max(yMax, zMax))
						_calibrationData.CalibrationAxis = AccelerometerAxis.X;
					else if(yMax > Math.Max(xMax, zMax))
						_calibrationData.CalibrationAxis = AccelerometerAxis.Y;
					else
						_calibrationData.CalibrationAxis = AccelerometerAxis.Z;

					UpdateUI();
				}
			};

			acc.StartReadings ();
		}

		private void UpdateUI()
		{
			GForceText.Text = _calibrationData.CalibrationValue.ToString("#.##");
			GestureAxisText.Text = _calibrationData.CalibrationAxis.ToString();
		}

		partial void ResetButton_TouchUpInside (UIButton sender)
		{
			xMax = 0;
			yMax = 0;
			zMax = 0;

			GForceText.Text = "";
			GestureAxisText.Text = "";

			_calibrationData.Reset();
		}

		public override void DidMoveToParentViewController (UIViewController parent)
		{
			base.DidMoveToParentViewController (parent);

			if (parent == null) {
				SharedSettings.SaveCalibrationData (_calibrationData);
			}
		}
	}
}
