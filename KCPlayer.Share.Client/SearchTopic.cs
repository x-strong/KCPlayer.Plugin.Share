

namespace KCPlayer.Share.Client
{
    public class SearchTopic
    {
        private static readonly string[] TopicKeyWord = {@"随机", @"热门", @"最新", @"好评", @"经典"};
        public static void LoadSearchTopic()
        {
            // 导航面板添加专题面板
            Load.SearchTopic = new App.Style.SearchTopicPal { Location = new System.Drawing.Point(0, 0) };
            Load.SearchNavPal.Controls.Add(Load.SearchTopic);
            // 专题面板添加元素
            for (var i = 0; i < TopicKeyWord.Length; i++)
            {
                var topicword = i == 0 ? new App.Style.TopicItem(TopicKeyWord[i], true) { Location = new System.Drawing.Point(85 * i + 10, 0) } : new App.Style.TopicItem(TopicKeyWord[i], false) { Location = new System.Drawing.Point(85 * i + 10, 0) };
                Load.SearchTopic.Controls.Add(topicword);
                topicword.MouseClick += topicword_MouseClick;
            } 
        }

        private static void topicword_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Load.SearchItemPal.Controls.Clear();
            switch (((App.Style.TopicItem)sender).Text)
            {
                case @"随机":
                    {
                        Load.SearchItemPal.Controls.Add(new App.Style.SearchRomPal(Load.Demoitem));
                    } 
                    break;
                case @"热门":
                    {
                        
                    } 
                    break;
                case @"最新":
                    {
                        
                    } 
                    break;
                case @"好评":
                    {
                        
                    } 
                    break;
                case @"经典":
                    {
                        
                    } 
                    break;
            }
        }
    }
}
