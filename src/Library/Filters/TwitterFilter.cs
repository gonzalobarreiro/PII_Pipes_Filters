using System;
using System.Collections.Generic;
using System.Text;
using CompAndDel;
using System.Drawing;
using System.Diagnostics;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class TwitterFilter : IFilter
    {
        private string consumerKey = "CkovShLMNVCY0STsZlcRUFu99";
        private string consumerKeySecret = "6rc35cHCyqFQSy4vIIjKiCYu31qqkBBkSS5BRlqeYCt5r7zO5B";
        private string accessTokenSecret = "gNytQjJgLvurJekVU0wmBBkrR1Th40sJmTO8JDhiyUkuy";
        private string accessToken = "1396065818-MeBf8ybIXA3FpmldORfBMdmrVJLVgijAXJv3B18";
        public IPicture Filter(IPicture image)
        {
            //FilterSaving.Instance.Filter(image);

            var twitter = new TwitterImage(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            Console.WriteLine(twitter.PublishToTwitter("Nuevo filtro", $@"./../../Program/FilteredImage{FilterSaving.Instance.Count}.jpg"));
            return image;
        }
    }
}