
namespace KCPlayer.Share.Client
{
    public class LoadSearchItem
    {
        public LoadSearchItem()
        {
            // 搜索主面板
            Load.SearchPal = new App.Style.SearchItemBarPal { Location = new System.Drawing.Point(77, 47 - 10) };
            App.Style.Helper.Ui.Controls.Add(Load.SearchPal);
            // 搜索导航面板
            Load.SearchNavPal = new App.Style.SearchNavBarPal{ Location = new System.Drawing.Point(0, 0) };
            Load.SearchPal.Controls.Add(Load.SearchNavPal);
            // 搜索列表面板
            Load.SearchItemPal = new App.Style.SearchItemBarFly { Location = new System.Drawing.Point(0, Load.SearchNavPal.Size.Height) };
            Load.SearchPal.Controls.Add(Load.SearchItemPal);
            // 搜索专题面板
            SearchTopic.LoadSearchTopic();
            SearchInput.LoadSearchInput();
        }
    }
}
