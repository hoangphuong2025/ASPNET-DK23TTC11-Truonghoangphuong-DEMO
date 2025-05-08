using System;
using System.Collections.Generic;
using web_controls;
using web_model;

namespace web_portal.vi.webcontrol
{
    public partial class m_intro : WebUserControl
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            IntroController introController =new IntroController();
            List<IntroInfo> vList = introController.GetAll();
            pintro.DataSource = vList;
            pintro.DataBind(); 
        }
    }
}