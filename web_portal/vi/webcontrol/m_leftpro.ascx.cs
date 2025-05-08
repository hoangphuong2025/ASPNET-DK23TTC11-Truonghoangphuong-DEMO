using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_util;

namespace web_portal.vi.webcontrol
{
    public partial class m_leftpro : WebUserControl
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
            ShowProductOther(plistleft,Util.convertToInt(Request["pid"],0));
        }
    }
}