
namespace App.Style
{
    public class SearchPal:EPanel
    {
        public SearchPal(System.Windows.Forms.Control txt)
        {
            Size = new System.Drawing.Size(200 + 35, 35);
            BackColor = Helper.All["TxtPal"][1];
            var searchico= new EPicBox
            {
                Size = new System.Drawing.Size(35, 35),
                Dock = System.Windows.Forms.DockStyle.Left,
                Image = System.Drawing.Image.FromStream(new Resx.ResourcesHelper().GetImageStream("search.png")),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
            };
            Controls.Add(searchico);
            var txtPal = new TxtPal(txt)
            {
                Location =new System.Drawing.Point(27,0)
            };
            Controls.Add(txtPal);
        }
    }

    public class TxtPal:EPanel
    {
        public TxtPal(System.Windows.Forms.Control txt)
        {
            Size = new System.Drawing.Size(200, 35);

            txt.ForeColor = Helper.All["TxtPal"][0];
            txt.BackColor = Helper.All["TxtPal"][1];
            txt.Size = new System.Drawing.Size(Width - 16, Height - 8);
            txt.Location = new System.Drawing.Point(8, 5);
            txt.Font = new System.Drawing.Font(Helper.FontNormal, 14F);
            Controls.Add(txt);

            var txtbg = new ELabel
            {
                AutoSize = false,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Text = @"",
                ForeColor = Helper.All["TxtPal"][0],
                BackColor = Helper.All["TxtPal"][1],
            };
            Controls.Add(txtbg);
            
        }
    }
}
