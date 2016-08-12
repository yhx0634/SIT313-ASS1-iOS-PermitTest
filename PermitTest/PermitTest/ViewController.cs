using System;

using UIKit;

namespace PermitTest
{
    public partial class ViewController : UIViewController
    {
		
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			this.NavigationController.NavigationBarHidden = true;
			View.BackgroundColor = UIColor.FromRGB(74, 144, 226);

			int language = 1;

			btnLanguage.TouchUpInside += (object sender, EventArgs e) =>
			{
				if (language == 0)
				{
					btnLanguage.SetTitle("Chinese", UIControlState.Normal);
					language = 1;
					btnTest.SetTitle("Quicke Test", UIControlState.Normal);
					btnLearning.SetTitle("Learning", UIControlState.Normal);
				}
				else
				{
					btnLanguage.SetTitle("English", UIControlState.Normal);
					language = 0;
					btnTest.SetTitle("快速测试", UIControlState.Normal);
					btnLearning.SetTitle("学习模式", UIControlState.Normal);

				};
			};



			btnLanguage.SetTitle("Chinese", UIControlState.Normal);

			btnTest.SetTitle("Quicke Test", UIControlState.Normal);
			btnLearning.SetTitle("Learning", UIControlState.Normal);


			btnTest.TouchUpInside += (object sender, EventArgs e) =>
			{
				Console.WriteLine("sdsdasd");
				TestViewController testControl = this.Storyboard.InstantiateViewController("testView") as TestViewController;
				testControl.language = language;
				testControl.type = 0;
				this.NavigationController.PushViewController(testControl, true);
			};

			btnLearning.TouchUpInside += (object sender, EventArgs e) =>
			{
				Console.WriteLine("sdsdasd");
				TestViewController testControl = this.Storyboard.InstantiateViewController("testView") as TestViewController;
				testControl.type = 1;
				testControl.language = language;
				this.NavigationController.PushViewController(testControl, true);
			};




        }
    }
}