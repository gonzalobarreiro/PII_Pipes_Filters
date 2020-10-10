using System;
using CompAndDel.Filters;
using CompAndDel.Pipes;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            IPicture pic = p.GetPicture(@"./../../img/bill2.jpg");

            PipeSerial greyscale = new PipeSerial(new FilterGreyscale(),new PipeNull());
            pic = greyscale.Send(pic);

            p.SavePicture(pic,@"./../../img/bill_greyscale.jpg");
        }
    }
}
