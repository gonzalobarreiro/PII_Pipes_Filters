using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeFork : IPipe
    {
        IPipe next2Pipe;
        IPipe nextPipe;
        IConditionalFilter Condition {get;}
        
        /// <summary>
        /// La cañería recibe una imagen y, según un condicional, se envía por una cañería o la otra
        /// </summary>
        /// <param name="truePipe">Cañeria si filtro igual a true</param>
        /// <param name="falsePipe">Cañeria si filtro igual a false</param>
        /// <param name="condition">Condición a cumplir para que se utilice un filtro u otro</param>

        public PipeFork(IPipe truePipe, IPipe falsePipe, IConditionalFilter condition) 
        {
            this.nextPipe = truePipe;
            this.next2Pipe = falsePipe;
            this.Condition = condition;           
        }
        
        /// <summary>
        /// La cañería recibe una imagen y, según un condicional, se envía por una cañería o la otra
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            if(this.Condition.AreThere(picture))
            {
                return this.nextPipe.Send(picture);
            }
            else
            {
                return this.next2Pipe.Send(picture);
            }            
        }
    }
}
