using System;
using Microsoft.Band.Sensors;
using NUnit.Framework;
using BandPowerPointRemote.iOS;

namespace BandPowerPointRemote.iOS.UITests
{
	[TestFixture]
	public class CalibratorTests
	{
		private CalibrationData _calibrationData;
		private Calibrator _calibrator;
		private bool _updateEventRaised;

		[SetUp]
		public void SetUp()
		{
			_calibrationData = new CalibrationData ();
			_calibrator = new Calibrator (_calibrationData);
			_updateEventRaised = false;
		}

		[Test]
		public void Test ()
		{
			//var reading = new BandSensorAccelerometerData();
			//_calibrator.UpdateCalibration(reading);
		}
	}
}

