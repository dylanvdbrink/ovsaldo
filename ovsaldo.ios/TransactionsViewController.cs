using Foundation;
using OvChipApi.Responses;
using ovsaldo.ios.UIComponents;
using OVSaldo.ios.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace ovsaldo.ios
{
    public partial class TransactionsViewController : UITableViewController
    {
        public OvCardResponse CardInfo;
        private List<Transaction> Transactions = new List<Transaction>();
        Dictionary<string, List<Transaction>> IndexedTransactions = new Dictionary<string, List<Transaction>>();
        private string[] DateKeys = new string[0];

        public TransactionsViewController() { }

        public TransactionsViewController (IntPtr handle) : base (handle) { }

        public async override void ViewDidLoad()
        {
            this.ExtendedLayoutIncludesOpaqueBars = true;

            TableView.RefreshControl = new UIRefreshControl();
            TableView.RefreshControl.ValueChanged += async (sender, e) =>
            {
                await ReloadData();
            };

            await ReloadData();
        }

        private async Task ReloadData()
        {
            TransactionResponse TransactionResp = await OVChipAPIService.Instance.GetTransactionsAsync(CardInfo.MediumId);
            Transactions = TransactionResp.Records;
            IndexedTransactions = new Dictionary<string, List<Transaction>>();
            foreach (Transaction t in Transactions)
            {
                DateTime transactiondatetime = new DateTime(1970, 1, 1, 1, 0, 0, 0).AddMilliseconds(t.TransactionDateTime);
                string dateKey = transactiondatetime.ToLongDateString();
                if (IndexedTransactions.ContainsKey(dateKey))
                {
                    IndexedTransactions[dateKey].Add(t);
                }
                else
                {
                    IndexedTransactions.Add(dateKey, new List<Transaction>() { t });
                }
            }
            DateKeys = IndexedTransactions.Keys.ToArray();
            TableView.ReloadData();
            TableView.RefreshControl.EndRefreshing();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(new NSString(TransactionTableViewCell.CellIdentifier), indexPath);
            var cell1 = (TransactionTableViewCell)cell;

            Transaction trans = IndexedTransactions[DateKeys[indexPath.Section]][indexPath.Row];
            cell1.UpdateData(trans);

            return cell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 70;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return DateKeys.Length;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return IndexedTransactions[DateKeys[section]].Count;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return DateKeys[section];
        }
    }
}