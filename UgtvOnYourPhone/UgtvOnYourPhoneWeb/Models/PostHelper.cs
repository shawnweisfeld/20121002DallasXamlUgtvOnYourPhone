using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using UgtvOnYourPhoneCommon;

namespace UgtvOnYourPhoneWeb.Models
{
    //http://services.usergroup.tv/api/post

    public class PostHelper
    {
        public static List<Post> GetFromDisk()
        {
            var jsonFilePath = HttpContext.Current.Server.MapPath("~/App_Data/post.json");
            var jsonFile = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Post>>(jsonFile);
        }
    }



}