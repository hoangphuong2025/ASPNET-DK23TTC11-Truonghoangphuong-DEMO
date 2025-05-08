using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_controls;
using web_model;
using web_portal.App_Data;

namespace web_portal.vi.webcontrol
{
    public partial class WebUserControl : System.Web.UI.UserControl
    {
       protected virtual void Page_Load(object sender, EventArgs e)
        {
            
        }
        public List<CategoryInfo> GetAllCategory()
        {
            List<CategoryInfo> vList = new List<CategoryInfo>();
            Object obj = Session["WEBALLCATEGORY"];
            if (obj == null)
            {
                CategoryController controller = new CategoryController();
                vList = controller.GetAllSearch(" Order by Indexs ASC");
                Session["WEBALLCATEGORY"] = vList;
            }
            else
            {
                vList = (List<CategoryInfo>)obj;
            }
            return vList;
        }
        public void ShowGetCategory(Repeater repeater)
        {
            CategoryController productController = new CategoryController();
            List<CategoryInfo> pList = productController.GetAll();
            repeater.DataSource = pList;
            repeater.DataBind();
        }
        public void ShowGetCategoryRoot(Repeater repeater)
        {
            CategoryController productController = new CategoryController();
            List<CategoryInfo> pList = productController.GetAllRoot();
            repeater.DataSource = pList;
            repeater.DataBind();
        }
        public void ShowProductGroup(Repeater repeater)
        {
            ProductGroupController productController = new ProductGroupController();
            List<ProductGroupInfo> pList = productController.GetAll();
            repeater.DataSource = pList;
            repeater.DataBind();
        }
        public void ShowCompanyInfo(Repeater repeater)
        {
            CompanyController productController = new CompanyController();
            CompanyInfo info = productController.GetById(StringApp.getCompannyId());
            List<CompanyInfo> pList =new List<CompanyInfo>();
            pList.Add(info);
            repeater.DataSource = pList;
            repeater.DataBind();
        }
        public CompanyInfo ShowCompanyInfo()
        {
            CompanyController productController = new CompanyController();
            return  productController.GetById(StringApp.getCompannyId());
       
        }
    
        public void ShowProductOther(Repeater repeater,int id)
        {
            ProductController productController = new ProductController();
            List<ProductInfo> pList = productController.GetBySearch(" WHERE StatusId not like '0' AND Id !="+id);
            repeater.DataSource = pList;
            repeater.DataBind();
        }
        public void ShowProductOtherTop(Repeater repeater, int id)
        {
            ProductController productController = new ProductController();
            List<ProductInfo> pList = productController.GetBySearchTop("WHERE StatusId not like '0' AND Id !=" + id);
            repeater.DataSource = pList;
            repeater.DataBind();
        }
    }
}