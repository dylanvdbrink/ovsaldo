using Foundation;
using Plugin.SecureStorage;
using System;
using UIKit;

namespace ovsaldo.ios
{
    public partial class SettingsViewController : UITableViewController
    {
        public SettingsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            // Restore settings
            String username = CrossSecureStorage.Current.GetValue("username");
            String password = CrossSecureStorage.Current.GetValue("password");

            UsernameField.Text = username;
            PasswordField.Text = password;

            UsernameField.ShouldReturn = OnShouldReturn;
            PasswordField.ShouldReturn = OnShouldReturn;
        }

        private Boolean OnShouldReturn(UITextField field)
        {
            if (field.Tag == 1)
            {
                PasswordField.BecomeFirstResponder();
            }
            else
            {
                field.ResignFirstResponder();
            }
            return false;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            CrossSecureStorage.Current.SetValue("username", UsernameField.Text);
            CrossSecureStorage.Current.SetValue("password", PasswordField.Text);
        }

        [Export("tableView:didSelectRowAtIndexPath:")]
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Username field row
            if (indexPath.Section == 0 && indexPath.Row == 0)
            {
                UsernameField.BecomeFirstResponder();
            }
            // Password field row
            else if (indexPath.Section == 0 && indexPath.Row == 1)
            {
                PasswordField.BecomeFirstResponder();
            }
        }


    }
}