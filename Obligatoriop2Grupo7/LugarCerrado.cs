using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatoriop2Grupo7
{
    public class LugarCerrado:Lugar
    {
        public Acesibilidad Asesible { get; set; }
        static double AforoMaximo { get; set; }
        public int CostoMantemiento { get; set; }//solo va en esta clase
        public enum Acesibilidad
        {
            Total,
            No
        }
        public LugarCerrado(string nom, double dim, Acesibilidad asce, int cost)
            : base(nom, dim)
        {
            Asesible = asce;
            CostoMantemiento = cost;
        }
        public override string ToString()
        {
            return base.ToString() + $" Accesibilidad: {Asesible} \n ";
        }

        public bool cambiarValorAforo(double af)
        {
            if (af > 0)
            {
                AforoMaximo = af;
                return true;
            }
            return false;
        }
        public double verValorAforo()
        {
            return AforoMaximo;
        }




    }
}
