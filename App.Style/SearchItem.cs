
using System.Linq;


namespace App.Style
{
    /// <summary>
    /// 总面板
    /// </summary>
    public class SearchItemBarPal:EPanel
    {
        public SearchItemBarPal()
        {
            Size = new System.Drawing.Size(694, 360 + 112);
        }
    }
    /// <summary>
    /// 导航面板
    /// </summary>
    public class SearchNavBarPal : EPanel
    {
        public SearchNavBarPal()
        {
            Size = new System.Drawing.Size(694, 40);
        }
    }
    /// <summary>
    /// 列表面板
    /// </summary>
    public class SearchItemBarFly : HFlyPal
    {
        public SearchItemBarFly()
        {
            Size = new System.Drawing.Size(694, 320 + 112);
        }
    }
    /// <summary>
    /// 搜索专题
    /// </summary>
    public class SearchTopicPal:EPanel
    {
        public SearchTopicPal()
        {
            Size = new System.Drawing.Size(430, 35);
        }
    }
    /// <summary>
    /// 搜索专题元素
    /// </summary>
    public class TopicItem:ELabel
    {
        public TopicItem(string key,bool light)
        {
            Text = key;
            Cursor = System.Windows.Forms.Cursors.Hand;
            Font = new System.Drawing.Font(Helper.FontFang, 23F);
            Size = new System.Drawing.Size(85, 35);
            ForeColor = light?System.Drawing.Color.FromArgb(250, 250, 250):System.Drawing.Color.FromArgb(150, 150, 150);
            BackColor = System.Drawing.Color.Transparent;
            MouseDown += RankItem_MouseDown;
        }

        #region MouseDown
        private static void RankItem_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (var searchTopicitem in (((TopicItem)sender).Parent).Controls.OfType<TopicItem>())
            {
                GetLeaveOrUp(searchTopicitem);
            }
            SetDownOrHover((TopicItem)sender);
        }

        private static void GetLeaveOrUp(System.Windows.Forms.Control control)
        {
            control.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
        }

        private static void SetDownOrHover(System.Windows.Forms.Control control)
        {
            control.ForeColor = System.Drawing.Color.FromArgb(250, 250, 250);
        } 
        #endregion
    }
    /// <summary>
    /// 搜索框面板
    /// </summary>
    public class SearchInputPal:EPanel
    {
        public SearchInputPal()
        {
            Size = new System.Drawing.Size(200 + 35, 35);
            BackColor = Helper.All["TxtPal"][1];
            var searchico = new EPicBox
            {
                Size = new System.Drawing.Size(35, 35),
                Dock = System.Windows.Forms.DockStyle.Left,
                Image = new Resx.ResourcesHelper().GetImage("search.png"),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
            };
            Controls.Add(searchico);
            
        }
    }

    public class TxtPal : EPanel
    {
        public TxtPal(System.Windows.Forms.Control txt)
        {
            Size = new System.Drawing.Size(200, 35);
            txt.ForeColor = Helper.All["TxtPal"][0];
            txt.BackColor = Helper.All["TxtPal"][1];
            txt.Size = new System.Drawing.Size(Width - 16, Height - 8);
            txt.Location = new System.Drawing.Point(8, 5);
            txt.Font = new System.Drawing.Font(Helper.FontFang, 16F);
            Controls.Add(txt);
            
        }
    }
    /// <summary>
    /// 搜索结果元素
    /// </summary>
    public class SearchItem : EPanel
    {
        public SearchItem(FileIO.MovieModel movie)
        {
            Size = new System.Drawing.Size(331, 52);
            BackColor = System.Drawing.Color.FromArgb(50, 250, 250, 250);
            var title = new ELabel
            {
                Text = movie.Name,
                Size = new System.Drawing.Size(195, 24),
                Location = new System.Drawing.Point(5, 0 + 5 ),
                ForeColor = Helper.All["SearchItem"][0],
                BackColor = Helper.All["SearchItem"][1],
                Font = new System.Drawing.Font(Helper.FontNormal, 14F),
            };
            Controls.Add(title);
            var score = new ELabel
            {
                Text = movie.Score + "分",
                Size = new System.Drawing.Size(54, 24),
                Location = new System.Drawing.Point(217, 0 + 5),
                ForeColor = Helper.All["SearchItem"][2],
                BackColor = Helper.All["SearchItem"][3],
                Font = new System.Drawing.Font(Helper.FontNormal, 12F),
            };
            Controls.Add(score);
            var typestr = movie.Type.Aggregate("", (current, typestring) => current + (typestring + "/"));
            typestr = typestr.Substring(0, typestr.Length - 1);
            var type = new ELabel
            {
                Text = typestr,
                Size = new System.Drawing.Size(54, 24),
                Location = new System.Drawing.Point(217 + 54, 0 + 5),
                ForeColor = Helper.All["SearchItem"][2],
                BackColor = Helper.All["SearchItem"][3],
                Font = new System.Drawing.Font(Helper.FontNormal, 12F),
            };
            Controls.Add(type);
            var urlfly = new EFlyPal
            {
                Size = new System.Drawing.Size(331-5, 30),
                Location = new System.Drawing.Point(5, 26 + 7),
                //Dock = System.Windows.Forms.DockStyle.Bottom,
            };
            Controls.Add(urlfly);
            foreach (var keyname in movie.Url.Keys.Select(key => new ELabel
                {
                    Text = key,
                    ForeColor = Helper.All["SearchItem"][4],
                    BackColor = Helper.All["SearchItem"][5],
                }))
            {
                urlfly.Controls.Add(keyname);
            }
        }

    }

    public class SearchRomPal:EPanel
    {
        public SearchRomPal(FileIO.MovieModel movie)
        {
            Size = new System.Drawing.Size(670, 320 + 112);
            BackColor = System.Drawing.Color.IndianRed;
            var pic = new EPicBox { Image = movie.Image[2].Webimage(), Size = new System.Drawing.Size(310, 432), SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage };
            Controls.Add(pic);
        }
    }
}
