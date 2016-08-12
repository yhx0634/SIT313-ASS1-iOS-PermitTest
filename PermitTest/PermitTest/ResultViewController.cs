using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PermitTest
{
	public partial class ResultViewController : UIViewController
    {
		public List<int> WrongAnswer { get; set; }
		public List<int> RightAnswer { get; set; }
		private int count = 0;
		private int rcount = 0;
		public int type;
		public int language;


		public ResultViewController (IntPtr handle) : base (handle)
        {
			WrongAnswer = new List<int>();
			RightAnswer = new List<int>();
        }


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			this.NavigationController.NavigationBarHidden = true;

			btnBackhome.TouchUpInside += (object sender, EventArgs e) =>
			{
				//ViewController homwview = this.Storyboard.InstantiateViewController("homeView") as ViewController;
				//this.NavigationController.PushViewController(homwview, true);

				NavigationController.PopToRootViewController(true);
			};


			WrongCount();
			RightCount();
			int result = 10;
			Console.WriteLine(rcount);
			Console.WriteLine(count);
			Console.WriteLine(result);
			lableResult.Text = Convert.ToString(rcount*10)+"%";
			lableCorrect.Text = Convert.ToString(rcount) + " CORRECT";
			lableIncorrect.Text = Convert.ToString(count) + " INCORRECT";

			if (rcount >= 8)
				TopView.BackgroundColor = UIColor.Green;
			else
				TopView.BackgroundColor = UIColor.Red;

			btnRestart.SetTitle("RESTART", UIControlState.Normal);
			btnRestart.BackgroundColor = UIColor.FromRGB(74, 144, 226);

			btnRestart.TouchUpInside += (object sender, EventArgs e) =>
			{
				TestViewController testview = this.Storyboard.InstantiateViewController("testView") as TestViewController;
				testview.type = type;
				testview.language = language;
				this.NavigationController.PushViewController(testview, true);
			};

			btnReview.SetTitle("REVIEW", UIControlState.Normal);
			btnReview.BackgroundColor = UIColor.FromRGB(74, 144, 226);


			btnReview.TouchUpInside += (object sender, EventArgs e) =>
			{
				TestViewController testview = this.Storyboard.InstantiateViewController("testView") as TestViewController;
				testview.type = 2;
				testview.WrongCount = WrongAnswer;
				testview.language = language;
				this.NavigationController.PushViewController(testview, true);
			};

		}

		public void WrongCount()
		{
			foreach (int w in WrongAnswer)
			{
				count++;
			}
				
		}

		public void RightCount()
		{
			foreach (int r in RightAnswer)
			{
				rcount++;
			}

		}
    }
}