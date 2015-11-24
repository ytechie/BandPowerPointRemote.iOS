using System;
using Foundation;

namespace BandPowerPointRemote.iOS
{
	public static class SharedSettings
	{
		public static CalibrationData GetCalibrationData()
		{
			var data = new CalibrationData ();
			data.Calibrated = NSUserDefaults.StandardUserDefaults.BoolForKey ("Calibrated");
			data.CalibrationValue = NSUserDefaults.StandardUserDefaults.DoubleForKey ("CalibrationValue");

			var axisStr = NSUserDefaults.StandardUserDefaults.StringForKey ("CalibrationAxis");
			if (axisStr == "X")
				data.CalibrationAxis = AccelerometerAxis.X;
			else if (axisStr == "Y")
				data.CalibrationAxis = AccelerometerAxis.Y;
			else
				data.CalibrationAxis = AccelerometerAxis.Z;

			return data;
		}

		public static void SaveCalibrationData(CalibrationData data)
		{
			NSUserDefaults.StandardUserDefaults.SetBool (data.Calibrated, "Calibrated");
			NSUserDefaults.StandardUserDefaults.SetDouble (data.CalibrationValue, "CalibrationValue");
			NSUserDefaults.StandardUserDefaults.SetString (data.CalibrationAxis.ToString(), "AccelerometerAxis");
		}
	}
}

