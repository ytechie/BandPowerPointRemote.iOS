using System;

using Microsoft.Band.Sensors;

namespace BandPowerPointRemote.iOS
{
	public class GestureRecognizer
	{
		private AccelerometerSensor _accelerometerSensor;
		private CalibrationData _calibration;

		private DateTime _lastHit = new DateTime();
		private TimeSpan Debounce = TimeSpan.FromSeconds(1);

		public event EventHandler MoveNext;
		public event EventHandler MovePrev;

		public GestureRecognizer (AccelerometerSensor accelerometerSensor)
		{
			_accelerometerSensor = accelerometerSensor;
		}

		private void ReadingChanged(object sender, BandSensorDataEventArgs<BandSensorAccelerometerData> e)
		{
			//Ignore repeated matches
			if (DateTime.UtcNow.Subtract (_lastHit) < Debounce) {
				return;
			}

			double accel;
			if(_calibration.CalibrationAxis == AccelerometerAxis.X)
				accel = e.SensorReading.AccelerationX;
			else if(_calibration.CalibrationAxis == AccelerometerAxis.Y)
				accel = e.SensorReading.AccelerationY;
			else
				accel = e.SensorReading.AccelerationZ;

			if (accel > _calibration.CalibrationValue * 0.8) {
				_lastHit = DateTime.UtcNow;

				var evt = MoveNext;
				if (evt != null) {
					evt (this, EventArgs.Empty);
				}
			} else if (accel < -_calibration.CalibrationValue * 0.8) {
				_lastHit = DateTime.UtcNow;

				var evt = MovePrev;
				if (evt != null) {
					evt (this, EventArgs.Empty);
				}
			}
		}

		public void Start(CalibrationData calibration)
		{
			_calibration = calibration;
			_accelerometerSensor.ReadingChanged += ReadingChanged;
		}

		public void ChangeCalibration(CalibrationData newCalibration)
		{
			_calibration = newCalibration;
		}
	}
}

