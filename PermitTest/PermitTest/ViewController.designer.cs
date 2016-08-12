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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLanguage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLearning { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTest { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnLanguage != null) {
                btnLanguage.Dispose ();
                btnLanguage = null;
            }

            if (btnLearning != null) {
                btnLearning.Dispose ();
                btnLearning = null;
            }

            if (btnTest != null) {
                btnTest.Dispose ();
                btnTest = null;
            }
        }
    }
}