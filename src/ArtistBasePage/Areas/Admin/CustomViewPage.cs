using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtistBasePage.Areas.Admin
{

    public class CustomViewPage: CustomViewPage<dynamic>
    {
        
    }

    public class CustomViewPage<T>: WebViewPage<T>
    {
        public string Token
        {
            get
            {
                return "7151898f8f654d3da0847a131301278b"; // Session["token"] != null ? Session["token"].ToString() : ""; 
            }
        }


        public override void Execute()
        {
        }
    }
}