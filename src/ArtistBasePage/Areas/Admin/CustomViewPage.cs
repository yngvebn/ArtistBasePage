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
                return Session["token"] != null ? Session["token"].ToString() : ""; 
            }
        }
        
        public override void Execute()
        {
        }
    }
}