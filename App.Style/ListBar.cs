using System.Linq;


namespace App.Style
{
    public class ListMango:ELabel
    {
        public ListMango(FileIO.MovieModel share)
        {
            
            Size = new System.Drawing.Size(331, 52);
            var title = new ELabel
            {
                Text = share.Name,
                Size = new System.Drawing.Size(195, 24),
                Location = new System.Drawing.Point(0, 0),
                ForeColor = Helper.All["ListMango"][0],
                BackColor = Helper.All["ListMango"][1],
                Font = new System.Drawing.Font(Helper.FontNormal, 14F),
            };
            Controls.Add(title);
            var score =new ELabel
            {
                Text = share.Score + "分",
                Size = new System.Drawing.Size(54, 24),
                Location = new System.Drawing.Point(217, 0),
                ForeColor = Helper.All["ListMango"][2],
                BackColor = Helper.All["ListMango"][3],
                Font = new System.Drawing.Font(Helper.FontNormal, 12F),
            };
            Controls.Add(score);
            var typestr = share.Type.Aggregate("", (current, typestring) => current + (typestring + "/"));
            typestr = typestr.Substring(0, typestr.Length - 1);
            var type = new ELabel
            {
                Text = typestr,
                Size = new System.Drawing.Size(54, 24),
                Location = new System.Drawing.Point(217+54, 0),
                ForeColor = Helper.All["ListMango"][2],
                BackColor = Helper.All["ListMango"][3],
                Font = new System.Drawing.Font(Helper.FontNormal, 12F),
            };
            Controls.Add(type);
            var urlfly = new EFlyPal
                {
                    Size = new System.Drawing.Size(331, 24),
                    Location = new System.Drawing.Point(0, 26),
                    Dock =  System.Windows.Forms.DockStyle.Bottom,
                };
            Controls.Add(urlfly);
            foreach (var key in share.Url.Keys)
            {
                var keyname = new ELabel
                    {
                        Text = key,
                        ForeColor = Helper.All["ListMango"][4],
                        BackColor = Helper.All["ListMango"][5],
                    };
                urlfly.Controls.Add(keyname);
            }
        }
    }
    public class ListItemBarFly:EFlyPal
    {
        public ListItemBarFly()
        {
            Size = new System.Drawing.Size(694, 358);
        }
    }

    public class ListItemBarPal:EPanel
    {
        public ListItemBarPal()
        {
            Size = new System.Drawing.Size(525, 37);
        }
    }

    public class ListNavBarPal : EPanel
    {
        public ListNavBarPal()
        {
            Size = new System.Drawing.Size(40, 114);
        }
    }

    public class ListNavBarBase : ELabel
    {
        public ListNavBarBase(string key)
        {
            Text = key;
            Cursor = Helper.HCursors;
            ForeColor = Helper.All["ListNavBar"][0];
            BackColor = Helper.All["ListNavBar"][1];
            Font = new System.Drawing.Font(Helper.FontFang, 18F);
            TextAlign = Helper.Align;
            Dock = System.Windows.Forms.DockStyle.Fill;
            MouseDown += ListNavBarBase_MouseDown;
        }

        static void ListNavBarBase_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (var listNavBaritem in ((ListNavBarBase)sender).Parent.Parent.Controls.OfType<ListNavBarPal>().SelectMany(variable => (variable).Controls.OfType<ListNavBarBase>()))
            {
                GetLeaveOrUp(listNavBaritem);
            }
            SetDownOrHover((ListNavBarBase)sender);
        }


        private static void GetLeaveOrUp(System.Windows.Forms.Control control)
        {
            control.ForeColor = Helper.All["ListNavBar"][0];
            control.BackColor = Helper.All["ListNavBar"][1];
        }
        private static void SetDownOrHover(System.Windows.Forms.Control control)
        {
            control.ForeColor = Helper.All["ListNavBar"][2];
            control.BackColor = Helper.All["ListNavBar"][3];
        }
    }
}
