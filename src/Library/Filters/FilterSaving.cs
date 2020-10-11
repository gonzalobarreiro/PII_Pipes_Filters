using System;
using System.Collections.Generic;
using System.Text;
using CompAndDel;
using System.Drawing;
using System.Diagnostics;

namespace CompAndDel.Filters
{
    public class FilterSaving : IFilter
    {
        private int count = 0;
        private static FilterSaving instance;
        public int Count
        {
            get;
            set;
        }
        public static FilterSaving Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new FilterSaving();
                }
                return instance;
            }
        }

        public IPicture Filter(IPicture image)
        {
            Count ++;
            IPicture pic = image.Clone();
            PictureProvider picSaved = new PictureProvider();
            picSaved.SavePicture(pic,$@"FilteredImage{Count}.jpg");
            return pic;
        }
    }
}