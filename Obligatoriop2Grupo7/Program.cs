using System;
using System.Collections.Generic;

namespace Obligatoriop2Grupo7
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();
            Menu(s);
            //Listar todas las actividades(sin especificar el precio de la entrada)
            //• Cambiar valor del aforo máximo.
            //• Cambiar valor del precio de butacas que se utilizan en lugares abiertos.
            //• Dada una categoría, listar las actividades de esa categoría que se realicen en un rango de fechas dado
            //• Listar espectáculos aptos para todo público.
        }
        #region Menu
        private static void Menu(Sistema s)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                try
                {                        //opciones
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("*#*#*#*#*#*#*#*#*#*#*#*#       DIRECCION NACIONAL DE CULTURA   *#*#*#*#*#*#*#*#*#*#*#*#*\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_______________________________________________________________________________________");
                    Console.WriteLine("                                      MENU PRINCIPAL                                   ");
                    Console.WriteLine("_______________________________________________________________________________________");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("************************ 1-         LISTAR ACTIVIDADES          ************************");
                    Console.WriteLine("************************ 2- LISTAR ACTIVIDADES POR CATEGORIA    ************************");
                    Console.WriteLine("************************ 3-     LISTAR ESPETACULOS POR EDAD     ************************");
                    Console.WriteLine("************************ 4-  CAMBIAR VALOR DE AFORO MAXIMO      ************************");
                    Console.WriteLine("************************ 5-      CAMBIAR VALOR DE BUTACA        ************************");
                    Console.WriteLine("************************ 6- LISTAR ACTIVIDADES ENTRE DOS FECHAS ************************");
                    Console.WriteLine("************************ 0-              -SALIR-                ************************");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    int op = Int32.Parse(Console.ReadLine());
                    if (op == 0) salir = true;
                    //llamar Opciones
                    Opciones(op, s);
                }
                catch (Exception ex)
                {
                    Console.Write("Error- opcion incorrecta seleccione una de 1 a 5 \n" + ex.Message);
                }

                Console.ReadKey();
            }
        }
        #endregion
        private static void Opciones(int op, Sistema s)
        {
            switch (op)
            {
                case 1:
                    ListarActividades(s);
                    break;
                case 2:
                    ListarActividadesCategoria(s);
                    break;
                case 3:
                    ListarEspetaculosAptosParaTodoPublico(s);
                    break;
                case 4:
                    CambiarValorAforoMaximo(s);
                    break;
                case 5:
                    CambiarValorButaca(s);
                    break; 
                case 6:
                    ListarActividadesEntreDosFechas(s);
                    break;
                default:
                    break;
            }
        }
        private static void CambiarValorAforoMaximo(Sistema s)
        {
            Console.Clear();
            LugarCerrado aux = null;
            Console.WriteLine(" LISTA LUGARES CERRADOS \n elija uno :\n");
            foreach (LugarCerrado l in s.ListadoLugares())
            {
                Console.WriteLine(l.Id + "- " + $" Nombre: " + l.Nombre + " Aforo Maximo: " + l.verValorAforo());
            }
            bool errorIngreso = false;
            while (!errorIngreso)
            {
                int op = Int32.Parse(Console.ReadLine());
                aux = s.BuscarLugarCerrado(op);

                int valor = 0;
                if (op > 0 && aux != null)
                {
                    ValidarAforo(ref errorIngreso, valor, aux);
                }
                else
                {
                    errorIngreso = false;
                }
            }
        }
        private static void ValidarAforo(ref bool error, int v, LugarCerrado l1)
        {
            Console.Clear();
            Console.WriteLine("Ingrese nuevo valor: ");
            v = Int32.Parse(Console.ReadLine());
            if (v > 0)
            {
                l1.cambiarValorAforo(v);
                Console.WriteLine("Valor cambiado con exito a " + l1.verValorAforo());
                Console.ReadKey();
                error = true;
            }
            else
            {
                Console.Write("Error valor no valido");
                error = false;
            }
        }
        private static void CambiarValorButaca(Sistema s)
        {
            LugarAbierto aux = null;

            Console.WriteLine(" LISTA LUGARES ABIERTOS \n elija uno :\n");
            foreach (LugarAbierto l in s.ListadoLugares())
            {
                Console.WriteLine(l.Id + "- " + $" Nombre: " + l.Nombre + " Precio Butaca: ");//+ //l);
            }
            bool errorIngreso = false;
            while (!errorIngreso)
            {
                int op = Int32.Parse(Console.ReadLine());
                decimal valor = 0;
                aux = s.BuscarAbierto(op);
                if (op > 0 && aux != null)
                {
                    ValidarButaca(ref errorIngreso, valor, aux);
                }
                else
                {
                    errorIngreso = false;
                }
            }
        }
        private static void ValidarButaca(ref bool error, decimal valor, LugarAbierto l1)
        {

            Console.Clear();
            if (valor > 0)
            {
                l1.cambiarPrecioButaca(valor);

                Console.WriteLine("Valor cambiado con exito a " + l1.VerPrecioButaca());
                Console.ReadKey();
                error = true;
            }
            else
            {
                Console.Write("Error valor no valido");
                error = false;
            }
        }

        private static void ListarEspetaculosAptosParaTodoPublico(Sistema s)
        {
            Console.WriteLine("ACTIVIDADES PARA TODO PÚBLICO: \n");
            foreach (Actividad a in s.ListadoActividades())
            {
                if (a.EdadMin == Actividad.TipoEdad.P)
                {
                    Console.WriteLine(a);
                }
            }
        }

        private static void ListarActividadesCategoria(Sistema s)
        {
            Console.Clear();

            Console.WriteLine("Cual es el nombre de categoria? ");
            Console.WriteLine("\n 1 " + Categoria.TipoNombre.Cine.ToString());
            Console.WriteLine("\n 2 " + Categoria.TipoNombre.Teatro.ToString());
            Console.WriteLine("\n 3 " + Categoria.TipoNombre.Concierto.ToString());
            Console.WriteLine("\n 4 " + Categoria.TipoNombre.FeriaGatronomica.ToString());

            int op = Int32.Parse(Console.ReadLine());
            string cat = "";
            switch (op)
            {
                case 1:
                    cat = Categoria.TipoNombre.Cine.ToString();
                    break;
                case 2:
                    cat = Categoria.TipoNombre.Teatro.ToString();
                    break;
                case 3:
                    cat = Categoria.TipoNombre.Concierto.ToString();
                    break;
                case 4:
                    cat = Categoria.TipoNombre.FeriaGatronomica.ToString();
                    break;
            }
            Console.Clear();
            foreach (Actividad a in s.ListadoActividades())
            {
                if (a.Categoria.Nombre.ToString() == cat)
                    Console.WriteLine(a);
            }
        }

        private static void ListarActividades(Sistema s)
        {
            Console.Clear();
            foreach (Actividad a in s.ListadoActividades())
            {
                Console.WriteLine(a + "\n");
            }
        }

        private static void ListarActividadesEntreDosFechas(Sistema s)
        {
            List<Actividad> aux = new List<Actividad>();

            Console.WriteLine("Cual es el nombre de categoria? ");
            Console.WriteLine("\n 1 " + Categoria.TipoNombre.Cine.ToString());
            Console.WriteLine("\n 2 " + Categoria.TipoNombre.Teatro.ToString());
            Console.WriteLine("\n 3 " + Categoria.TipoNombre.Concierto.ToString());
            Console.WriteLine("\n 4 " + Categoria.TipoNombre.FeriaGatronomica.ToString());

            int op = Int32.Parse(Console.ReadLine());
            string cat = "";
            switch (op)
            {
                case 1:
                    cat = Categoria.TipoNombre.Cine.ToString();
                    break;
                case 2:
                    cat = Categoria.TipoNombre.Teatro.ToString();
                    break;
                case 3:
                    cat = Categoria.TipoNombre.Concierto.ToString();
                    break;
                case 4:
                    cat = Categoria.TipoNombre.FeriaGatronomica.ToString();
                    break;
            }
            Console.Clear();
            bool errorIngreso = false;
            DateTime f1;
            DateTime f2;
            while (!errorIngreso)
            {
                Console.WriteLine("Ingrese fecha 1: ");
                f1 = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese fecha 2: ");
                f2 = DateTime.Parse(Console.ReadLine());
                if (f1 != null && f2 != null && f1 < f2)//que no sea null
                {
                     aux = s.ListarXFecha(f1, f2, cat);//guardo la lista de fechas x categoria
                    errorIngreso = true;
                }
                else
                {
                    Console.WriteLine("error- \n 1-favor ingrese nuevamente fecha \n 2- fecha 1 debe ser menor a fecha 2 \n ");
                }
            }

            foreach (Actividad a in aux)
            {
                Console.WriteLine(a);
            }
        }
    }
}

//1.Precarga de actividades, lugares y categorías.
//2. Listar todas las actividades (sin especificar el precio de la entrada)
//3.Cambiar valor del aforo máximo.
//4. Cambiar valor del precio de butacas que se utilizan en lugares abiertos.
//5. Dada una categoría, listar las actividades de esa categoría que se realicen en un rango de fechas dado
//6. Listar espectáculos aptos para todo público