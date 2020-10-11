using System;

namespace CompAndDel
{
    /// <summary>
    /// Un filtro condicional.
    /// </summary>
    /// <remarks>
    /// Un filtro que procesa una imagen, buscando si tiene o no cierta caracteristica.
    /// </remarks>
    public interface IConditionalFilter
    {
        /// <summary>
        /// Procesa la imagen pasada por parametro y retorna un valor booleano.
        /// </summary>
        /// <param name="image">La imagen a procesar</param>
        /// <returns>true o false</returns>
        Boolean AreThere(IPicture image);
    }
}

