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
        public IPicture Filter(IPicture image)
        {
            count ++;
            System.Console.WriteLine(count);
            IPicture pic = image.Clone();
            PictureProvider picSaved = new PictureProvider();
            picSaved.SavePicture(pic,$@"FilteredImage{count}.jpg");
            return pic;
        }
    }
}