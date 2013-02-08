namespace App.Style
{
    public class HFlyPal : EFlyPal
    {
        public HFlyPal()
        {
            AllowDrop = true;
            DragEnter += HFlyPal_DragEnter;
        }

        private static void HFlyPal_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            #region DragEnter

            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
                e.Effect = System.Windows.Forms.DragDropEffects.Copy | System.Windows.Forms.DragDropEffects.None;
            else
                e.Effect = System.Windows.Forms.DragDropEffects.None;

            #endregion
        }
    }

    public class HTxtBox:ETxtBox
    {
        public HTxtBox(string tip)
        {
            _tbtip = Text = tip;
            MouseLeave += HTxtBox_MouseLeave;
            MouseDown += HTxtBox_MouseDown;
        }

        #region DownOrLeave
        private static string _tbtip;
        private static HTxtBox _hTxtBox;
        private static void HTxtBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _hTxtBox = (HTxtBox)sender;
            if (_hTxtBox.Text == _tbtip)
            {
                _hTxtBox.Text = "";
            }
        }

        private static void HTxtBox_MouseLeave(object sender, System.EventArgs e)
        {
            _hTxtBox = (HTxtBox)sender;
            if (_hTxtBox.Text != "") return;
            System.Threading.Thread.Sleep(200);
            if (_hTxtBox.Text == "")
            {
                _hTxtBox.Text = _tbtip;
            }
        } 
        #endregion
    }

}
