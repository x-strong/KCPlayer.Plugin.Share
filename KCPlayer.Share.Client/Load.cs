using System.Linq;

namespace KCPlayer.Share.Client
{
    public class Load
    {
        private static App.Style.ListItemBarFly ListItemFly { get; set; }

        public static void Start()
        {
            App.Style.Helper.Ui.Load += Ui_Load; 
        }

        static void Ui_Load(object sender, System.EventArgs e)
        {
            App.Style.Helper.Start();
            App.Guard.OptimizeHelper.Start();
            App.Style.Helper.Ui.Controls.Add(new App.Style.NavPal(5, false));
            LoadNavList();
        }

        #region LoadNavList

        private static void LoadNavList()
        {
            var btnsharecell = new App.Style.ListNavBarBase(@"分享");
            var btnshare = new App.Style.ListNavBarPal { Location = new System.Drawing.Point(30, 47 + (114 + 8) * 0) };
            btnshare.Controls.Add(btnsharecell);

            var btnrecordcell = new App.Style.ListNavBarBase(@"记录");
            var btnrecord = new App.Style.ListNavBarPal { Location = new System.Drawing.Point(30, 47 + (114 + 8) * 1) };
            btnrecord.Controls.Add(btnrecordcell);

            var btnsearchcell = new App.Style.ListNavBarBase(@"搜索");
            var btnsearch = new App.Style.ListNavBarPal { Location = new System.Drawing.Point(30, 47 + (114 + 8) * 2) };
            btnsearch.Controls.Add(btnsearchcell);

            App.Style.Helper.Ui.Controls.Add(btnshare);
            App.Style.Helper.Ui.Controls.Add(btnrecord);
            App.Style.Helper.Ui.Controls.Add(btnsearch);
            btnsharecell.MouseClick += btnshare_MouseClick;
            btnrecordcell.MouseClick += btnrecord_MouseClick;
            btnsearchcell.MouseClick += btnsearch_MouseClick;
        }
        static void btnshare_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (var variable in App.Style.Helper.Ui.Controls.OfType<App.Style.ListItemBarFly>())
            {
                App.Style.Helper.Ui.Controls.Remove(variable);
            }
            LoadShareList();
        }

        static void btnrecord_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (var variable in App.Style.Helper.Ui.Controls.OfType<App.Style.ListItemBarFly>())
            {
                App.Style.Helper.Ui.Controls.Remove(variable);
            }
        }

        static void btnsearch_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (var variable in App.Style.Helper.Ui.Controls.OfType<App.Style.ListItemBarFly>())
            {
                App.Style.Helper.Ui.Controls.Remove(variable);
            }
            var txtbox = new App.Style.ETxtBox();
            var searchPal = new App.Style.SearchPal(txtbox)
            {
                Location = new System.Drawing.Point(77, 47),
            };
            App.Style.Helper.Ui.Controls.Add(searchPal);
            App.Style.Helper.Tip.SetToolTip(txtbox,@"回车搜索");
            txtbox.KeyDown += txtbox_KeyDown;
            ListItemFly = new App.Style.ListItemBarFly { Location = new System.Drawing.Point(77, 94) };
            App.Style.Helper.Ui.Controls.Add(ListItemFly);
        }



        static void txtbox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //var txt = (App.Style.ETxtBox)sender;
            if (e.KeyCode != System.Windows.Forms.Keys.Enter) return;
            var demoitem = new App.FileIO.MovieModel
            {
                Name = @"一代宗师",
                Score = @"6.1",
                Type = new System.Collections.Generic.List<string> {@"动作片"},
                Url = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>
                {
                    {
                        "HD1280高清国语中字",
                        new System.Collections.Generic.List<string>
                            {
                                "thunder://QUFmdHA6Ly9keTpkeUB4bGouMnR1LmNjOjMwMTY1L1vRuMDXz8LU2Hd3dy4ydHUuY2Nd0ru0+tfayqYuSEQxMjgwuN/H5bn60+/W0NfWLm1rdlpa",
                            }
                    },
                    {
                        "DVD国语中字版",
                        new System.Collections.Generic.List<string>
                            {
                                "thunder://QUFmdHA6Ly9keTpkeUB4bGouMnR1LmNjOjMwMTU3L1vRuMDXz8LU2Hd3dy4ydHUuY2Nd0ru0+tfayqYuRFZEufrT79bQ19Yucm12Ylpa",
                            }
                    }
                },
                        
            };
            ListItemFly.Controls.Add(new App.Style.ListMango(demoitem));
            //System.Windows.Forms.MessageBox.Show(@"开始搜索：" + txt.Text);
        }


        #endregion

        #region LoadShareList

        private static void LoadShareList()
        {
            ListItemFly = new App.Style.ListItemBarFly { Location = new System.Drawing.Point(77, 47),BackColor = System.Drawing.Color.White };
            App.Style.Helper.Ui.Controls.Add(ListItemFly);
            ListItemFly.AllowDrop = true;
            ListItemFly.DragDrop += listItemFly_DragDrop;
            ListItemFly.DragEnter += listItemFly_DragEnter;

        }

        static void listItemFly_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            #region listItemFly_DragEnter

            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
                e.Effect = System.Windows.Forms.DragDropEffects.Copy | System.Windows.Forms.DragDropEffects.None;
            else
                e.Effect = System.Windows.Forms.DragDropEffects.None;

            #endregion
        }

        static void listItemFly_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            var dropitems = ((string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop));
            if (dropitems.IsEmptyStrings()) return;
            foreach (var dropitem in dropitems)
            {
                var dropinfo = new System.IO.FileInfo(dropitem);
                if (dropinfo.Extension.ToLower() != ".torrent") continue;
                
                var listitem = new App.Style.ListItemBarPal();
                var listitemcell = new App.Style.ListNavBarBase(dropinfo.Name);
                listitem.Controls.Add(listitemcell);

                ListItemFly.Controls.Add(listitem);
                listitemcell.MouseClick += listitemcell_MouseClick;
            }
        }

        static void listitemcell_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        } 

        #endregion
  
    }
}
