using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace web_portal.App_Data
{
    using System;
    using System.Drawing;
    using System.Web;

    public class Thumbnail
    {
        private int shtHeight;
        private int shtWidth;
       
        public string ThumbFolderPath = "~/resources/thumb/";
        public string ThumbFolderPathProduct = "~/resources/products/";
        public string ThumbFolderPathSlide = "~/resources/slides/";
        public string ThumbFolderPathCategory = "~/resources/category/";
        public string ThumbFolderPathSP = "~/resources/serviceprovider/";
        private double tile;
        public bool GenerateThumbnail(string fileName, string sourcedes, string filedes, int maxwidth,string spath)
        {
            try
            {
                Image image = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                if (image.Width >= image.Height)
                {
                    this.tile = ((double)image.Width) / ((double)image.Height);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(((double)this.shtWidth) / this.tile));
                }
                else
                {
                    this.tile = ((double)image.Height) / ((double)image.Width);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(this.shtWidth * this.tile));
                }
                image.GetThumbnailImage(this.shtWidth, this.shtHeight, null, new IntPtr()).Save(HttpContext.Current.Server.MapPath(spath + filedes));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void CreateImg(int with, int height,string colorcode,string fileName,string fileas)
        {
            Color _color = System.Drawing.ColorTranslator.FromHtml(colorcode);
            string fullPaths = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/resources/category"), fileas);
            Bitmap imageBMP = new Bitmap(20,20);
            Graphics g = Graphics.FromImage(imageBMP);
            Brush brush =new SolidBrush(_color);

            g.FillRegion(brush, g.Clip);
            imageBMP.Save(fullPaths, ImageFormat.Gif);
           
         
        }
        public bool GenerateThumbnail(string fileName, string sourcedes, string filedes, int maxwidth)
        {
            try
            {
                Image image = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                if (image.Width >= image.Height)
                {
                    this.tile = ((double) image.Width) / ((double) image.Height);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double) (((double) this.shtWidth) / this.tile));
                }
                else
                {
                    
                    this.tile = ((double) image.Height) / ((double) image.Width);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double) (this.shtWidth * this.tile));
                }
                image.GetThumbnailImage(this.shtWidth, this.shtHeight, null, new IntPtr()).Save(HttpContext.Current.Server.MapPath(this.ThumbFolderPath + filedes));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool GenerateThumbnailCategory(string fileName, string sourcedes, string filedes, int maxwidth)
        {
            try
            {
                Image image = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                if (image.Width >= image.Height)
                {
                    this.tile = ((double)image.Width) / ((double)image.Height);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(((double)this.shtWidth) / this.tile));
                }
                else
                {

                    this.tile = ((double)image.Height) / ((double)image.Width);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(this.shtWidth * this.tile));
                }
                image.GetThumbnailImage(this.shtWidth, this.shtHeight, null, new IntPtr()).Save(HttpContext.Current.Server.MapPath(this.ThumbFolderPathCategory + filedes));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool GenerateThumbnailSlides(string fileName, string sourcedes, string filedes, int maxwidth)
        {
            try
            {
                Image image = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                if (image.Width >= image.Height)
                {
                    this.tile = ((double)image.Width) / ((double)image.Height);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(((double)this.shtWidth) / this.tile));
                }
                else
                {

                    this.tile = ((double)image.Height) / ((double)image.Width);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(this.shtWidth * this.tile));
                }
                image.GetThumbnailImage(this.shtWidth, this.shtHeight, null, new IntPtr()).Save(HttpContext.Current.Server.MapPath(this.ThumbFolderPathSlide + filedes));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool GenerateThumbnailProduct(string fileName, string sourcedes, string filedes, int maxwidth)
        {
            try
            {
                Image image = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                if (image.Width >= image.Height)
                {
                    this.tile = ((double)image.Width) / ((double)image.Height);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(((double)this.shtWidth) / this.tile));
                }
                else
                {

                    this.tile = ((double)image.Height) / ((double)image.Width);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(this.shtWidth * this.tile));
                }
                image.GetThumbnailImage(this.shtWidth, this.shtHeight, null, new IntPtr()).Save(HttpContext.Current.Server.MapPath(this.ThumbFolderPathProduct + filedes));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
     
        public bool GenerateThumbnailServicePr(string fileName, string sourcedes, string filedes, int maxwidth)
        {
            try
            {
                Image image = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                if (image.Width >= image.Height)
                {
                    this.tile = ((double)image.Width) / ((double)image.Height);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(((double)this.shtWidth) / this.tile));
                }
                else
                {

                    this.tile = ((double)image.Height) / ((double)image.Width);
                    if (image.Width > maxwidth)
                    {
                        this.shtWidth = maxwidth;
                    }
                    else
                    {
                        this.shtWidth = image.Width;
                    }
                    this.shtHeight = Convert.ToInt32((double)(this.shtWidth * this.tile));
                }
                image.GetThumbnailImage(this.shtWidth, this.shtHeight, null, new IntPtr()).Save(HttpContext.Current.Server.MapPath(this.ThumbFolderPathSP + filedes));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

