using System;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class HasFaceConditional : IConditionalFilter
    {
        /// <summary>
        /// Procesa la imagen pasada por parametro y retorna true si aparece un rostro o false de lo contrario.
        /// </summary>
        /// <param name="image">La imagen a procesar</param>
        /// <returns>true o false</returns>
        public Boolean AreThere(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace("620e818a46524ceb92628cde08068242", true);
            cog.Recognize(image.OgImgPath);
            return cog.FaceFound;
        }
    }
}
