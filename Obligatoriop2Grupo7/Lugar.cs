using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatoriop2Grupo7
{
    public abstract class Lugar
    {
        public int Id { get; set; }
        public string    Nombre { get; set; }
        public double Dimencion { get; set; }
        static int ultimoID =1;
        public Lugar(string nom, double dim)
        {
            Nombre = nom;
            Dimencion = dim;
            Id = ultimoID;
            ultimoID++;
        }

        public override string ToString()
        {
            return $"\n {Nombre} \n Dimencion:{Dimencion} \n";
        }
    }
}
