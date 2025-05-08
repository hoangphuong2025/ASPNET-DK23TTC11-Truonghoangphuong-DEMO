<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextFreecode.ascx.cs" Inherits="web_portal.webadmin.webcontrol.TextFreecode" %>
 <FTB:FreeTextBox ID="FreeTextBox1" 
            EnableHtmlMode="true"
            toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
            runat="server" ImageGalleryPath="~/Resources/news/" Width="98%" SupportFolder="~/aspnet_client/FreeTextBox/" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&cif={0}"
            DesignModeCss="designmode.css"
			JavaScriptLocation="ExternalFile" 
			ButtonImagesLocation="ExternalFile"
			ToolbarImagesLocation="ExternalFile"
			AutoGenerateToolbarsFromString="true"
			BreakMode="LineBreak"
			EnableToolbars="true"	
			BackColor="#FFFFFF"
        >
 </FTB:FreeTextBox>     