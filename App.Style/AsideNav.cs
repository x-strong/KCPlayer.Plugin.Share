using System.Linq;

namespace App.Style
{
    public class AsideNavBarFly : EFlyPal
    {
        public AsideNavBarFly()
        {
            Size = new System.Drawing.Size(44, 369);
        }
    }

    public class AsideNavBarPal : EPanel
    {
        public AsideNavBarPal()
        {
            Size = new System.Drawing.Size(40, 116);
            
        }
    }

    public class AsideNavBarBase : ELabel
    {
        public AsideNavBarBase(string key,bool light)
        {
            Text = key;
            Cursor = Helper.HCursors;
            ForeColor = light?Helper.All["ListNavBar"][2]:Helper.All["ListNavBar"][0];
            BackColor = light?Helper.All["ListNavBar"][3]:Helper.All["ListNavBar"][1];
            Font = new System.Drawing.Font(Helper.FontFang, 18F);
            TextAlign = Helper.Align;
            Dock = System.Windows.Forms.DockStyle.Fill;
            MouseDown += ListNavBarBase_MouseDown;
        }

        #region MouseDown
        private static void ListNavBarBase_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (var listNavBaritem in ((AsideNavBarBase)sender).Parent.Parent.Controls.OfType<AsideNavBarPal>().SelectMany(variable => (variable).Controls.OfType<AsideNavBarBase>()))
            {
                GetLeaveOrUp(listNavBaritem);
            }
            SetDownOrHover((AsideNavBarBase)sender);
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
        #endregion
    }
}
