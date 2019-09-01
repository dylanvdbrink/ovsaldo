using System;

using Foundation;
using OvChipApi.Responses;
using UIKit;

namespace ovsaldo.ios.UIComponents
{
    public partial class CardInfoTableViewCell : UITableViewCell
    {
        public OvCardResponse CardInfo;

        public CardInfoTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void UpdateData(OvCardResponse response)
        {
            CardInfo = response;

            AliasLabel.Text = response.Alias;
            NumberLabel.Text = response.MediumId
                                            .Insert(4, " ")
                                            .Insert(9, " ")
                                            .Insert(14, " ");

            string balance = response.Balance.ToString();
            EuroLabel.Text = balance.Substring(0, balance.Length - 2) + ",";
            CentLabel.Text = balance.Substring(balance.Length - 2, 2);
        }
    }
}
