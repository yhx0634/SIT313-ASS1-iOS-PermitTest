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
    [Register ("TestViewController")]
    partial class TestViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnA { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnB { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnC { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnNext { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnPreview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageViewQues { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lableQues { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView topView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnA != null) {
                btnA.Dispose ();
                btnA = null;
            }

            if (btnB != null) {
                btnB.Dispose ();
                btnB = null;
            }

            if (btnBack != null) {
                btnBack.Dispose ();
                btnBack = null;
            }

            if (btnC != null) {
                btnC.Dispose ();
                btnC = null;
            }

            if (btnNext != null) {
                btnNext.Dispose ();
                btnNext = null;
            }

            if (btnPreview != null) {
                btnPreview.Dispose ();
                btnPreview = null;
            }

            if (imageViewQues != null) {
                imageViewQues.Dispose ();
                imageViewQues = null;
            }

            if (labelTitle != null) {
                labelTitle.Dispose ();
                labelTitle = null;
            }

            if (lableQues != null) {
                lableQues.Dispose ();
                lableQues = null;
            }

            if (topView != null) {
                topView.Dispose ();
                topView = null;
            }
        }
    }
}