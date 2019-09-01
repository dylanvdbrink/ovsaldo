// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ovsaldo.ios.UIComponents
{
    [Register ("CardInfoTableViewCell")]
    partial class CardInfoTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AliasLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CentLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EuroLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NumberLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AliasLabel != null) {
                AliasLabel.Dispose ();
                AliasLabel = null;
            }

            if (CentLabel != null) {
                CentLabel.Dispose ();
                CentLabel = null;
            }

            if (EuroLabel != null) {
                EuroLabel.Dispose ();
                EuroLabel = null;
            }

            if (NumberLabel != null) {
                NumberLabel.Dispose ();
                NumberLabel = null;
            }
        }
    }
}