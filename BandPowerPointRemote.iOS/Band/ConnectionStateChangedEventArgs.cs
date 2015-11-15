using System;

namespace BandPowerPointRemote.iOS.Band
{
	public class ConnectionStateChangedEventArgs : EventArgs
	{
		public ConnectionState NewState { get; private set; }

		public ConnectionStateChangedEventArgs (ConnectionState newState)
		{
			this.NewState = newState;
		}
	}
}

