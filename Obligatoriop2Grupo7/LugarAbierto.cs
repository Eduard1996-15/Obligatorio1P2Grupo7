using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatoriop2Grupo7
{
    public class LugarAbierto :Lugar
    {
         static decimal PrecioButaca = 50;
       
        public LugarAbierto(string nom, double dim)
            :base(nom,dim){
           
        }
        public override string ToString()
        {
            return base.ToString() + $" Precio Butaca{PrecioButaca}\n";
        }
        public  bool cambiarPrecioButaca(decimal dec)
        {
            if (dec > 0)
            {
                PrecioButaca = dec;
                return true;
            }
            return false;
        }
        public decimal VerPrecioButaca()
        {
            return PrecioButaca;
        }
    }
}
