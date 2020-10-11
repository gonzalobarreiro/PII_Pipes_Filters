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
            IPicture pic = p.GetPicture(@"Ghostbusters-bill-murray.jpg");

            PipeSerial greyscale = new PipeSerial(new FilterGreyscale(),new PipeNull());
            pic = greyscale.Send(pic);

            //p.SavePicture(pic,@"matrix2.jpg");

            /*La idea es que cuando pase por el FilterSaving se guarde la imagen con el filto aplicado de donde viene.
            Le paso la foto al pipe grayScale que lo va a pasar por FilterGrayScale y de ahi a un pipe que se llama saveImage
            creado para este ejercicio, este pipe le aplica el filto que gurda la imagen. De ahi se va al pipe negative que hace
            lo mismo, hasta que llega al pipe null.
            */
            FilterSaving saving = new FilterSaving();
            
            PipeSerial saveImageAlreadyWentThrough = new PipeSerial(saving, new PipeNull());
            PipeSerial negative = new PipeSerial(new FilterNegative(), saveImageAlreadyWentThrough);

            PipeSerial saveImage = new PipeSerial(saving, negative);
            PipeSerial grayScale = new PipeSerial(new FilterGreyscale(), saveImage);
            grayScale.Send(pic);



        }
    }
}
