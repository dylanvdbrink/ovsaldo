// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ovsaldo.ios.watchExtension
{
    [Register ("InterfaceController")]
    partial class InterfaceController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel CardIDLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel CentsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel EuroLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel EuroSignLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CardIDLabel != null) {
                CardIDLabel.Dispose ();
                CardIDLabel = null;
            }

            if (CentsLabel != null) {
                CentsLabel.Dispose ();
                CentsLabel = null;
            }

            if (EuroLabel != null) {
                EuroLabel.Dispose ();
                EuroLabel = null;
            }

            if (EuroSignLabel != null) {
                EuroSignLabel.Dispose ();
                EuroSignLabel = null;
            }
        }
    }
}