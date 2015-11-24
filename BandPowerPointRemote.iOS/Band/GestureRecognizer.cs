using System;

using Microsoft.Band.Sensors;

namespace BandPowerPointRemote.iOS
{
	public class GestureRecognizer
	{
		private AccelerometerSensor _accelerometerSensor;
		private CalibrationData _calibration;

		public GestureRecognizer (AccelerometerSensor accelerometerSensor)
		{
			_accelerometerSensor = accelerometerSensor;
		}

		private void ReadingChanged(object sender, BandSensorDataEventArgs<BandSensorAccelerometerData> e)
		{
			double accel;
			if(_calibration.CalibrationAxis == AccelerometerAxis.X)
				accel = e.SensorReading.AccelerationX;
			else if(_calibration.CalibrationAxis == AccelerometerAxis.Y)
				accel = e.SensorReading.AccelerationY;
			else
				accel = e.SensorReading.AccelerationZ;

			if (accel > _calibration.CalibrationValue * 0.8) {
				Console.WriteLine ("Next!!!");
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

