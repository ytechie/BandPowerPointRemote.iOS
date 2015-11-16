using System;
using System.Linq;

using Microsoft.Band;
using Microsoft.Band.Sensors;

namespace BandPowerPointRemote.iOS.Band
{
	public class Band
	{
		private BandClientManager manager;
		private static BandClient client;
		//private AccelerometerSensor accelerometer;
		//private bool sensorStarted;

		public ConnectionState ConnectionState { get; private set; }

		public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;

		public Band ()
		{
			SetConnectionState(ConnectionState.NotConnected);

			manager =  BandClientManager.Instance;
			manager.Connected += (sender, e) => {
				SetConnectionState(ConnectionState.Connected);

				Console.WriteLine("Connected");
			};
			manager.Disconnected += (sender, e) => {
				SetConnectionState(ConnectionState.NotConnected);
				Console.WriteLine("Disconnected");
			};
		}

		private void SetConnectionState(ConnectionState state)
		{
			ConnectionState = state;
			RaiseConnectionStateChangeEvent ();
		}

		private void RaiseConnectionStateChangeEvent()
		{
			var e = ConnectionStateChanged;
			if(e != null)
			{
				e(this, new ConnectionStateChangedEventArgs(ConnectionState));
			}
		}

		public AccelerometerSensor StartReadingAccelerometer() 
		{
			var accelerometer = client.SensorManager.CreateAccelerometerSensor ();
			accelerometer.ReadingChanged += (sender, e) => {
			};
			accelerometer.StartReadings ();

			return accelerometer;
		}

		public async void StartConnecting()
		{
			if (client != null) {
				return;
			}

			// get the client
			client = manager.AttachedClients.FirstOrDefault ();

			if (client == null) {
				Console.WriteLine ("Failed! No Bands attached.");
			} else {
				try {
					SetConnectionState(ConnectionState.Connecting);

					Console.WriteLine ("Please wait. Connecting to Band...");
					await manager.ConnectTaskAsync (client);
				} catch (BandException ex) {
					Console.WriteLine ("Failed to connect to Band:");
					Console.WriteLine (ex.Message);
				}
			}
		}
	}
}

