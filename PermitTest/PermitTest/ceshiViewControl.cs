using Foundation;
using System;
using UIKit;

namespace PermitTest
{
	public partial class ceshiViewControl : UIViewController
    {
        public ceshiViewControl (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			this.NavigationController.NavigationBar.BarTintColor = UIColor.Yellow;
		}
    }
}