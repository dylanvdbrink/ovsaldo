using Foundation;
using OvChipApi.Responses;
using ovsaldo.ios.UIComponents;
using OVSaldo.ios.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UIKit;

namespace ovsaldo.ios
{
    public partial class OverviewViewController : UITableViewController
    {
        private string CellIdentifier = "CardInfoTableViewCell";
        List<OvCardResponse> cards = new List<OvCardResponse>();

        public OverviewViewController (IntPtr handle) : base (handle) { }

        public override async void ViewDidLoad()
        {
            this.ExtendedLayoutIncludesOpaqueBars = true;

            TableView.RefreshControl = new UIRefreshControl();
            TableView.RefreshControl.ValueChanged += async (sender, e) =>
            {
                await GetData();
            };

            await GetData();
        }

        private async Task GetData()
        {
            cards = await OVChipAPIService.Instance.GetCardsAsync();
            TableView.ReloadData();
            TableView.RefreshControl.EndRefreshing();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CardInfoTableViewCell)tableView.DequeueReusableCell(CellIdentifier);

            OvCardResponse card = cards[indexPath.Row];
            cell.UpdateData(card);

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            CardInfoTableViewCell cell = (CardInfoTableViewCell)tableView.CellAt(indexPath);

            TransactionsViewController vc = (TransactionsViewController) Storyboard.InstantiateViewController("TransactionsViewController");
            vc.CardInfo = cell.CardInfo;
            NavigationController.PushViewController(vc, true);


            tableView.DeselectRow(indexPath, true);
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return cards.Count;
        }
    }
}