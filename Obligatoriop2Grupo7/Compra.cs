using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatoriop2Grupo7
{
    public class Compra
    {
        private static int ultimoId = 1;

        public int Id { get; set; }

        public Actividad Actividad { get; set; }

        public byte CantEntradas { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime FechaHora { get; set; }

        public TipoEstado Estado { get; set; }

        public enum TipoEstado
        {
            Anulada,
            Activa

        }

        public Compra(Actividad actividad, byte cantEntradas, Usuario usuario, DateTime fechaHora, TipoEstado estado)
        {
            Id = ultimoId;
            ultimoId++;
            Actividad = actividad;
            CantEntradas = cantEntradas;
            Usuario = usuario;
            FechaHora = fechaHora;
            Estado = estado;
        }

        public double PrecioFinal()
        {
            double precioFinal = Actividad.PrecioBase;
            Lugar l = Actividad.Lugar;
            if (l is LugarAbierto)
            {
                if (l.Dimencion > 1)
                {
                    precioFinal = Actividad.PrecioBase * 1.10;//10
                  }
            }
            else 
            {
                LugarCerrado lc = (LugarCerrado)l;
                if(lc.verValorAforo() < 50)
                {
                    precioFinal = Actividad.PrecioBase * 1.30;
                }else if(lc.verValorAforo() >= 50 || lc.verValorAforo() <= 70)  
                { precioFinal = Actividad.PrecioBase * 1.15; }
            }
            return precioFinal;
        }
        /*si el aforo es inferior al 50 % el precio aumenta un 30% del costo base, y si el 
         aforo está entre el 50 y 70 % se le agrega un 15 % del costo base. Esto permite mitigar las pérdidas de 
        dinero en ventas de entradas*/
        public override string ToString()
        {
            return $"\n Actividad: {Actividad} \n Cantidad entradas: {CantEntradas} \n Hora: {FechaHora} \n Estado: {Estado} \n";
        }
    }
}
