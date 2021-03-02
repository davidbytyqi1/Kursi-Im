using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KursiIm.SharedModel.General
{
    public class ThreeLanguageBaseModel
    {
        public string TitleSq { get; set; }
        public string TitleEn { get; set; }
        public string TitleSr { get; set; }

        public string Title
        {
            get
            {
                var language = Thread.CurrentThread.CurrentCulture.Name;
                return language == "en-US" ? TitleEn : language == "sr-Latn-RS" ? TitleSr : TitleSq;
            }
        }
    }
}
