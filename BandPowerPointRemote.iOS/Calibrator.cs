using System;

using Microsoft.Band.Sensors;

namespace BandPowerPointRemote.iOS
{
	public class Calibrator
	{
		private readonly CalibrationData _calibrationData;
		public event EventHandler CalibrationUpdated;

		public Calibrator (CalibrationData calibrationData)
		{
			_calibrationData = calibrationData;
		}

		private void RaiseCalibrationUpdated()
		{
			var evt = CalibrationUpdated;
			if (evt != null) {
				evt (this, EventArgs.Empty);
			}
		}

		public void UpdateCalibration(BandSensorAccelerometerData reading)
		{
			_calibrationData.Calibrated = true;
			var updated = false;

			if (Math.Abs (reading.AccelerationX) > Math.Abs (_calibrationData.CalibrationValue)) {
				_calibrationData.CalibrationValue = reading.AccelerationX;
				_calibrationData.CalibrationAxis = AccelerometerAxis.X;
				updated = true;
			}
			if (Math.Abs (reading.AccelerationY) > Math.Abs (_calibrationData.CalibrationValue)) {
				_calibrationData.CalibrationValue = reading.AccelerationY;
				_calibrationData.CalibrationAxis = AccelerometerAxis.Y;
				updated = true;
			}
			if (Math.Abs (reading.AccelerationZ) > Math.Abs (_calibrationData.CalibrationValue)) {
				_calibrationData.CalibrationValue = reading.AccelerationZ;
				_calibrationData.CalibrationAxis = AccelerometerAxis.Z;
				updated = true;
			}

			if (updated) {
				RaiseCalibrationUpdated ();
			}
		}
	}
}
