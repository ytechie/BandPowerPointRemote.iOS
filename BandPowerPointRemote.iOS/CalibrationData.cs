using System;

namespace BandPowerPointRemote.iOS
{
	public class CalibrationData
	{
		public bool Calibrated { get; set; }
		public double CalibrationValue { get; set; }
		public AccelerometerAxis CalibrationAxis { get; set; }

		public void Reset()
		{
			Calibrated = false;
			CalibrationValue = 0;
			CalibrationAxis = AccelerometerAxis.Z;
		}
	}
}

