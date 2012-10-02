using System;
using System.Collections.Generic;

namespace UgtvOnYourPhoneCommon
{
    //http://services.usergroup.tv/api/post

    public class Post
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string Exceprt { get; set; }
        public string PostDate { get; set; }
        public double Id { get; set; }
        public string Mp4Video { get; set; }
        public string Mp4VideoLow { get; set; }
        public string OgvVideo { get; set; }
        public List<TaxInfo> Speakers { get; set; }
        public List<TaxInfo> Groups { get; set; }
        public List<TaxInfo> Tags { get; set; }
    }



}