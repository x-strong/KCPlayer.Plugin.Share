namespace KCPlayer.Share.Client
{
    public class LoadShareItem
    {
        public LoadShareItem()
        {
            Load.ShareItemFly = new App.Style.ShareItemBarFly { Location = new System.Drawing.Point(77, 47), BackColor = System.Drawing.Color.FromArgb(50,250,250,250) };
            App.Style.Helper.Ui.Controls.Add(Load.ShareItemFly);
            Load.ShareItemFly.DragDrop += listItemFly_DragDrop;
        }

        private static void listItemFly_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            var dropitems = ((string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop));
            if (dropitems.IsEmptyStrings()) return;
            foreach (var dropitem in dropitems)
            {
                var dropinfo = new System.IO.FileInfo(dropitem);
                if (dropinfo.Extension.ToLower() != ".torrent") continue;

                var listitem = new App.Style.ShareItemBarPal();
                var listitemcell = new App.Style.ShareItemBarBase(dropinfo.Name);
                listitem.Controls.Add(listitemcell);

                Load.ShareItemFly.Controls.Add(listitem);
                listitemcell.MouseClick += listitemcell_MouseClick;
            }
        }

        private static void listitemcell_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
    }
}
