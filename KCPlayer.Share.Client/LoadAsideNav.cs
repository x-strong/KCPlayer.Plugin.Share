using System.Linq;


namespace KCPlayer.Share.Client
{
    public class LoadAsideNav
    {
        public LoadAsideNav()
        {
            Load.AsideNavFly = new App.Style.AsideNavBarFly { Location = new System.Drawing.Point(26, 44 - 10) };
            App.Style.Helper.Ui.Controls.Add(Load.AsideNavFly);

            for (var i = 0; i < AsideKeyWord.Length; i++)
            {
                var asideNavItem = new App.Style.AsideNavBarPal();
                Load.AsideNavFly.Controls.Add(asideNavItem);
                var asideNavcell = i == 0 ? new App.Style.AsideNavBarBase(AsideKeyWord[i], true) : new App.Style.AsideNavBarBase(AsideKeyWord[i], false);
                asideNavItem.Controls.Add(asideNavcell);
                asideNavcell.MouseClick += asideNavcell_MouseClick;
            }
        }

        private static readonly string[] AsideKeyWord = { @"分享", @"记录", @"搜索" };
        private static void asideNavcell_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (var variable in App.Style.Helper.Ui.Controls.OfType<App.Style.SearchItemBarPal>())
            {
                variable.Controls.Clear();
                App.Style.Helper.Ui.Controls.Remove(variable);
                Load.SearchPal = null;
            }
            foreach (var variable in App.Style.Helper.Ui.Controls.OfType<App.Style.ShareItemBarFly>())
            {
                variable.Controls.Clear();
                App.Style.Helper.Ui.Controls.Remove(variable);
                Load.ShareItemFly = null;
            }
            switch (((App.Style.AsideNavBarBase)sender).Text)
            {
                case @"分享":
                    {
                        if (Load.ShareItemFly.IsEmpty())
                        {
                            new LoadShareItem();
                        }
                    }
                    break;
                case @"记录":
                    {
                        
                    }
                    break;
                case @"搜索":
                    {
                        if (Load.SearchPal.IsEmpty())
                        {
                            new LoadSearchItem();
                        }
                    }
                    break;
            }
        }
    }
}
