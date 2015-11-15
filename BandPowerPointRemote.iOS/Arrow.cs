using System;
using System.ComponentModel;

using Foundation;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace BandPowerPointRemote.iOS
{
	[Register("Arrow"), DesignTimeVisible(true)]
	public class Arrow : UIView
	{
		public Arrow (IntPtr p) : base(p)
		{
			BackgroundColor = UIColor.Clear;

			SetConnectionStatus (BandPowerPointRemote.iOS.Band.ConnectionState.NotConnected);
		}

		public override void Draw (CGRect rect)
		{
			base.Draw (rect);

			var gctx = UIGraphics.GetCurrentContext ();

			// setting blend mode to clear and filling with
			// a clear color results in a transparent fill
			gctx.SetFillColor (UIColor.Clear.CGColor);
			gctx.FillRect (rect);

			//gctx.SetBlendMode (CGBlendMode.Clear);
			UIColor.Black.SetColor ();

			// create some cutout geometry
			var path = new CGPath ();   
			path.AddLines(new CGPoint[]{
				new CGPoint(0,rect.Height * (1.0/4.0)),
				new CGPoint(rect.Width * (3.0/5.0),rect.Height * (1.0/4.0)),
				new CGPoint(rect.Width * (3.0/5.0),0),
				new CGPoint(rect.Width,rect.Height / 2),
				new CGPoint(rect.Width * (3.0/5.0), rect.Height),
				new CGPoint(rect.Width * (3.0/5.0),rect.Height * (3.0/4.0)),
				new CGPoint(0, rect.Height * (3.0/4.0))
			}); 
			path.CloseSubpath();

			gctx.AddPath(path);
			gctx.DrawPath(CGPathDrawingMode.Fill);  
		}

		private void Flash()
		{
			UIView.AnimationsEnabled = true;

			this.Layer.Opacity = 1;
			UIView.Animate (1, 0, UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat, () => {
				this.Layer.Opacity = 0;
			}, null);

		}

		public void SetConnectionStatus(Band.ConnectionState newState)
		{
			if (newState == BandPowerPointRemote.iOS.Band.ConnectionState.Connecting) {
				Flash ();
			} else if (newState == BandPowerPointRemote.iOS.Band.ConnectionState.NotConnected) {
				UIView.AnimationsEnabled = false;
				this.Layer.Opacity = 0;
			} else if (newState == BandPowerPointRemote.iOS.Band.ConnectionState.Connected) {
				this.Layer.Opacity = 1;
			}
		}
	}
}

