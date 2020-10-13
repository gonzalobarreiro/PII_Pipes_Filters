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
            IPicture pic = p.GetPicture(@"Silla.jpg");

            PipeSerial greyscale = new PipeSerial(new FilterGreyscale(),new PipeNull());
            pic = greyscale.Send(pic);

            //p.SavePicture(pic,@"matrix2.jpg");

            /*
            La idea es que cuando pase por el FilterSaving se guarde la imagen con el filtro aplicado de donde viene.
            Le paso la foto al pipe grayScale que lo va a pasar por FilterGrayScale y de ahi a un pipe que se llama saveImage
            creado para este ejercicio, este pipe le aplica el filto que guarda la imagen. De ahi se va al pipe fork donde decide
            dependiendo de si tiene cara o no si va al twitterfilter o al negative.
            Después de ese filtro llega al pipe null.
            */
            FilterSaving saving = FilterSaving.Instance;

            PipeSerial saveImageAlreadyWentThrough = new PipeSerial(saving, new PipeNull());
            PipeSerial negative = new PipeSerial(new FilterNegative(), saveImageAlreadyWentThrough);
            
            PipeSerial twitterFilter = new PipeSerial(new TwitterFilter(), new PipeNull());

            PipeFork DoesItHaveAFace = new PipeFork (twitterFilter, negative, new HasFaceConditional());
            
            PipeSerial saveImage = new PipeSerial(saving, DoesItHaveAFace);
            PipeSerial grayScale = new PipeSerial(new FilterGreyscale(), saveImage);
            
            grayScale.Send(pic);
            



        }
    }
}
