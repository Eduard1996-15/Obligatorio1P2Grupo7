using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatoriop2Grupo7
{
    public class Actividad
    {
        private static int ultimoId = 1;
        public static int PrecioBase = 100;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHora { get; set; }
        public Lugar Lugar { get; set; }
        public TipoEdad EdadMin {get; set; }
        public Categoria Categoria { get; set; }
        public enum TipoEdad
        {
            P, C13, C16, C18
        }

        public Actividad(string nombre, DateTime fechaHora, Lugar lugar, TipoEdad edadMin, Categoria categoria)
        {
            Id  = ultimoId;
            ultimoId++;
            Nombre = nombre;
            FechaHora = fechaHora;
            Lugar = lugar;
            EdadMin = edadMin;
            Categoria = categoria;
        }
        
        public override string ToString()
        {
            return $"\n Nombre: {Nombre} \n Fecha y Hora: {FechaHora} \n Lugar: {Lugar} \n Edad Minima: {EdadMin} \n Precio Base: {PrecioBase} \n Categoria: {Categoria} \n";
        }

        public int cambiarPrecioActividad(int pr)
        {
            if (pr > 0)
            {
                PrecioBase = pr;//si es mayor cambio 
            }
            return PrecioBase;//retorno el precio base
        }

        public int VerPrecioBase()
        {
            return PrecioBase;
        }




    }
}
