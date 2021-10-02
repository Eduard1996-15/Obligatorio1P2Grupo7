using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatoriop2Grupo7
{
    public class Categoria
    {
        public string Descripcion { get; set; }
        public  TipoNombre  Nombre {get;set;}
        public enum TipoNombre
        {
            Cine,
            Teatro,
            Concierto,
            FeriaGatronomica
        }
        public Categoria(string desc, TipoNombre nom)
        {
            Nombre = nom;
            Descripcion = desc;
        }
        public override string ToString()
        {
            return $"\n Nombre {Nombre} \n Descripcion: {Descripcion} \n";
        }
    }
}
