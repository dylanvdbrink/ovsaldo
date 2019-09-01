using Foundation;
using OvChipApi.Responses;
using System;
using UIKit;

namespace ovsaldo.ios
{
    public partial class TransactionTableViewCell : UITableViewCell
    {
        public static string CellIdentifier = "TransactionCell";
        public Transaction Trans;

        public TransactionTableViewCell(IntPtr handle) : base(handle) 
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void UpdateData(Transaction transaction)
        {
            Trans = transaction;

            DescriptionLabel.Text = Trans.TransactionName;
            DateTime transactiondatetime = new DateTime(1970, 1, 1, 1, 0, 0, 0);
            transactiondatetime = transactiondatetime.AddMilliseconds(Trans.TransactionDateTime);
            TimeLabel.Text = transactiondatetime.ToString("HH:mm");
            InfoLabel.Text = Trans.TransactionInfo;

            if (Trans.Fare.HasValue)
            {
                FareLabel.Text = String.Format("€{0:0.00}", Trans.Fare);
            }
            else
            {
                FareLabel.Text = "";
            }
        }
    }
}