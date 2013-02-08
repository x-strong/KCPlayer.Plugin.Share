

namespace KCPlayer.Share.Client
{
    public class SearchInput
    {
        public static void LoadSearchInput()
        {
            // 导航面板添加输入面板
            Load.SearchInput = new App.Style.SearchInputPal { Location = new System.Drawing.Point(436, 0) };
            Load.SearchNavPal.Controls.Add(Load.SearchInput);
            // 输入面板添加元素
            var txtbox = new App.Style.HTxtBox(Load.SearchTip);
            var txtPal = new App.Style.TxtPal(txtbox) {Location = new System.Drawing.Point(29, 0)};
            Load.SearchInput.Controls.Add(txtPal);
            txtbox.KeyDown += txtbox_KeyDown;
        }
        
        private static void txtbox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode != System.Windows.Forms.Keys.Enter) return;
            Load.SearchItemPal.Controls.Add(new App.Style.SearchItem(Load.Demoitem));
        }
    }
}
