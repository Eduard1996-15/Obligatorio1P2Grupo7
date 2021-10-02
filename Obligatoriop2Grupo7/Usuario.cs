using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatoriop2Grupo7
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaaNacimiento { get; set; }
        static int ulitmoID = 1;
        public Usuario(string nom, string ape, string email, DateTime fecha)
        {
            Id = ulitmoID;
            ulitmoID++;
            Nombre = nom;
            Apellido = ape;
            Email = email;
            FechaaNacimiento = fecha;
        }
        public override string ToString()
        {
            return $"\n Nombre : {Nombre} \n Apellido: {Apellido} Email:{Email} Facha Nacimiento: {FechaaNacimiento} \n";
        }
    }
}
