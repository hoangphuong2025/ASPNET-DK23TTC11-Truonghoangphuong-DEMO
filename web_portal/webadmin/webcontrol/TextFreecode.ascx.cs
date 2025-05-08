using System;
using System.Web.UI;
using FreeTextBoxControls;

namespace web_portal.webadmin.webcontrol
{
    public partial class TextFreecode : UserControl
    {
        protected FreeTextBox FreeTextBox1;

        protected void Page_Load(object sender, EventArgs e)
        {
            FreeTextBoxControls.NetSpell item = new FreeTextBoxControls.NetSpell();
            FreeTextBoxControls.Toolbar t = new FreeTextBoxControls.Toolbar();
            t.Items.Add(item);
            FreeTextBox1.Toolbars.Add(t);
        }

        public string TextData
        {
            get
            {
                
                return FreeTextBox1.Text;
            }
            set
            {
                FreeTextBox1.Text = value;
            }
        }
    }
}