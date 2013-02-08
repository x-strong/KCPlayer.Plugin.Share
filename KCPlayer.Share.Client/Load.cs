namespace KCPlayer.Share.Client
{
    public class Load
    {
        public static App.FileIO.MovieModel Demoitem = new App.FileIO.MovieModel
        {
            Name = @"一代宗师",
            Score = @"6.1",
            Time = new System.Collections.Generic.Dictionary<string, string>
                {
                    {"中国大陆","2013-01-08"},
                    {"香港","2013-01-10"},
                },
            Director = new System.Collections.Generic.List<string>
                {
                    @"王家卫",@"邹静之",@"徐皓峰"
                },
            Actor = new System.Collections.Generic.List<string>
                {
                    @"梁朝伟",@"章子怡",@"张震",@"宋慧乔",@"赵本山",@"小沈阳",@"王庆祥",@"张晋",@"卢海鹏",@"冯克安",@"刘家勇",@"张智霖",@"金士杰",@"徐锦江",@"刘洵", 
                },
            Tag = new System.Collections.Generic.List<string>
                {
                    @"香港",@"一代宗师",@"动作",@"文艺",@"武侠",@"叶问",@"文艺片",
                },
            Quote = new System.Collections.Generic.List<string>
                {
                    @"http://movie.douban.com/subject/3821067/",@"http://www.imdb.com/title/tt1462900",@"http://site.douban.com/107139/",
                },
            Share = new System.Collections.Generic.List<string>
                {
                    @"5L",@"CraigTaylor",
                },
            Type = new System.Collections.Generic.List<string>
                {
                    @"动作",@"武侠"
                },
            Image =  new System.Collections.Generic.List<string>
                {
                    @"http://img3.douban.com/spic/s24591423.jpg",@"http://img3.douban.com/mpic/s24591423.jpg",@"http://img3.douban.com/lpic/s24591423.jpg",
                },
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
                }
        };
        public static App.Style.ShareItemBarFly ShareItemFly { get; set; }
        public static App.Style.AsideNavBarFly AsideNavFly { get; set; }
        
        #region 搜索变量
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public const string SearchTip = @"回车搜索,无所不能";
        /// <summary>
        /// 搜索总面板
        /// </summary>
        public static App.Style.SearchItemBarPal SearchPal { get; set; }
        /// <summary>
        /// 搜索导航面板
        /// </summary>
        public static App.Style.SearchNavBarPal SearchNavPal { get; set; }
        /// <summary>
        /// 搜索列表面板
        /// </summary>
        public static App.Style.SearchItemBarFly SearchItemPal { get; set; }
        /// <summary>
        /// 搜索专题面板
        /// </summary>
        public static App.Style.SearchTopicPal SearchTopic { get; set; }
        /// <summary>
        /// 搜索输入面板
        /// </summary>
        public static App.Style.SearchInputPal SearchInput { get; set; }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Start()
        {
            App.Style.Helper.Ui.Load += Ui_Load; 
        }

        static void Ui_Load(object sender, System.EventArgs e)
        {
            App.Style.Helper.Start();
            App.Guard.OptimizeHelper.Start();
            App.Style.Helper.Ui.Controls.Add(new App.Style.AppNav(5, false));
            new LoadAsideNav();
        }

    }
}
