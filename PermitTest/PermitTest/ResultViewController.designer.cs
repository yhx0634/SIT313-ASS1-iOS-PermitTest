// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PermitTest
{
    [Register ("ResultViewController")]
    partial class ResultViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBackhome { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRestart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnReview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lableCorrect { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lableIncorrect { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lableResult { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView TopView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnBackhome != null) {
                btnBackhome.Dispose ();
                btnBackhome = null;
            }

            if (btnRestart != null) {
                btnRestart.Dispose ();
                btnRestart = null;
            }

            if (btnReview != null) {
                btnReview.Dispose ();
                btnReview = null;
            }

            if (lableCorrect != null) {
                lableCorrect.Dispose ();
                lableCorrect = null;
            }

            if (lableIncorrect != null) {
                lableIncorrect.Dispose ();
                lableIncorrect = null;
            }

            if (lableResult != null) {
                lableResult.Dispose ();
                lableResult = null;
            }

            if (TopView != null) {
                TopView.Dispose ();
                TopView = null;
            }
        }
    }
}