using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatoriop2Grupo7
{
    public class Sistema
    {
        #region Atributos
        List<Usuario> Usuarios = new List<Usuario>();
        List<Compra> Compras = new List<Compra>();
        List<Categoria> Categorias = new List<Categoria>();
        List<Lugar> Lugares = new List<Lugar>();
        List<Actividad> Actividades = new List<Actividad>();
        #endregion
        #region Listados
        public List<Actividad> ListadoActividades()
        {
            return Actividades;
        }
        public List<Usuario> ListadoUsuarios()
        {
            return Usuarios;
        }
        public List<Categoria> ListadoCategorias()
        {
            return Categorias;
        }
        public List<Lugar> ListadoLugares()
        {
            return Lugares;
        }
        public List<Compra> ListadoCompras()
        {
            return Compras;
        }

        //contructor
        public Sistema()
        {
            PrecargaDatos();
        }
        public List<Actividad> ListarXFecha(DateTime f1, DateTime f2, string cat)
        {
            List<Actividad> aux = new List<Actividad>();
            foreach (Actividad a in ListadoActividades())
            {
                if (a.Categoria.Nombre.ToString() == cat)//si es de ese tipo la categoria
                {//que este entre las opciones dadas
                    if (a.FechaHora <= f1 && a.FechaHora <= f2)//verificar que este entre las dos fechas dadas
                    {
                        aux.Add(a); }
                }//listar
            }
            return aux;
        }
        #endregion
        #region Agregados
        public Actividad agregarActividad(string nombre, DateTime fecha, Lugar lugar, Actividad.TipoEdad edadMinima, Categoria categoria)
        {
            if (nombre != "" && fecha != null && lugar != null  && categoria != null)
            {
                Actividad a = new Actividad(nombre, fecha, lugar, edadMinima, categoria);
                if (!Actividades.Contains(a))//si no es ta en la lista
                    Actividades.Add(a);//se agrega
                return a;
            }
            return null;
        }
        public Usuario agregarUsuraio(string nom, string ape, string email, DateTime fecha)
        {
            if (nom != "" && ape != "" && email != "" && fecha != null)
            {
                Usuario u = new Usuario(nom, ape, email, fecha);
                if (!Usuarios.Contains(u))
                    Usuarios.Add(u);
                return u;
            }
            return null;
        }
        public Categoria agregarCategoria(string desc, Categoria.TipoNombre cat)
        {
            if (desc.Length > 0)
            {
                Categoria c = new Categoria(desc, cat);
                if (Categorias.Contains(c))//verifica si hay esa categoria que viene por parametro
                {
                    return null;
                }
                else
                {
                    ListadoCategorias().Add(c);//si no agrega 
                    return c;
                }
            }
            return null;
        }
        public LugarCerrado agregarLugarCerrado(string nom, double dim, LugarCerrado.Acesibilidad acs, int cost)
        {
            if (nom.Length > 0 && dim > 0)
            {
                LugarCerrado l = new LugarCerrado(nom, dim, acs, cost);
                if (!Lugares.Contains(l))
                {
                    Lugares.Add(l);
                    return l;
                }
            }
            return null;
        }
        public LugarAbierto agregarLugarAbierto(string nom, double dim)
        {
            if (nom.Length > 0 && dim > 0)
            {
                LugarAbierto l = new LugarAbierto(nom, dim);
                if (!Lugares.Contains(l))
                {
                    Lugares.Add(l);
                    return l;
                }
            }
            return null;
        }
        public Compra agregarCompra(Actividad a, byte cantE, Usuario u, DateTime fech, Compra.TipoEstado est)
        {
            if (a != null && cantE > 0 && u != null)
            {
                Compra c = new Compra(a, cantE, u, fech, est);
                if (!Compras.Contains(c))
                {
                    ListadoCompras().Add(c);
                }
            }
            return null;
        }
        #endregion
        #region Busquedas
        public LugarCerrado BuscarLugarCerrado(int id)
        {
            foreach (LugarCerrado lc in Lugares)//busco en la lista
            {
                if (lc.Id == id)//si encuentro
                    return lc;//lo retorno
            }
            return null;
        }
        public LugarAbierto BuscarAbierto(int id)
        {
            foreach (LugarAbierto la in Lugares)
            {
                if (la.Id == id)
                    return la;
            }
            return null;
        }
        #endregion
        #region Precargas
        private void PrecargaDatos()
        {
            //precarga Categoria 
            Categoria Cine = agregarCategoria("modo tradicional", Categoria.TipoNombre.Cine);
            Categoria Teatro = agregarCategoria("Teatro", Categoria.TipoNombre.Teatro);
            Categoria Concierto = agregarCategoria("concierto", Categoria.TipoNombre.Concierto);
            Categoria FeriaGastronomia = agregarCategoria("FeriaGastronomia", Categoria.TipoNombre.FeriaGatronomica);

            //precarga lugar abierto
            LugarAbierto la1 = agregarLugarAbierto("Teatro del Valle", 120);
            LugarAbierto la2 = agregarLugarAbierto("El Palacio ", 80);
            LugarAbierto la3 = agregarLugarAbierto("la Parrillada", 100);
            LugarAbierto la4 = agregarLugarAbierto("El Molino", 130);
            LugarAbierto la5 = agregarLugarAbierto("Árbol Blanco", 78);

            //precarga lugar Cerrado 
            LugarCerrado lc1 = agregarLugarCerrado("Montevideo Box", 200, LugarCerrado.Acesibilidad.Total, 500);
            LugarCerrado lc2 = agregarLugarCerrado("Villa da Luz", 110, LugarCerrado.Acesibilidad.Total, 350);
            LugarCerrado lc3 = agregarLugarCerrado("El BarZon", 160, LugarCerrado.Acesibilidad.No, 400);
            LugarCerrado lc4 = agregarLugarCerrado("La Menta", 150, LugarCerrado.Acesibilidad.Total, 600);
            LugarCerrado lc5 = agregarLugarCerrado("La Lampára", 160, LugarCerrado.Acesibilidad.No, 400);

            //precarga actividades
            Actividad a1 = agregarActividad("Mi villano favorito 2", DateTime.Now, lc1, Actividad.TipoEdad.P, Cine);
            Actividad a2 = agregarActividad("Junte", DateTime.Now, lc4, Actividad.TipoEdad.C18, Teatro);
            Actividad a3 = agregarActividad("Salida", DateTime.Now, la1, Actividad.TipoEdad.C16, Concierto);
            Actividad a4 = agregarActividad("Caminata", DateTime.Now, la2, Actividad.TipoEdad.P, FeriaGastronomia);
            Actividad a5 = agregarActividad("Pop", DateTime.Now, la3, Actividad.TipoEdad.C16, Concierto);
            Actividad a6 = agregarActividad("Rock y Metal", DateTime.Now, la4, Actividad.TipoEdad.C18, Concierto);
            Actividad a7 = agregarActividad("Parrillada", DateTime.Now, la5, Actividad.TipoEdad.P, FeriaGastronomia);
            Actividad a8 = agregarActividad("El corredor del Parque", DateTime.Now, lc2, Actividad.TipoEdad.P, Cine);
            Actividad a9 = agregarActividad("Perro Loco", DateTime.Now, lc3, Actividad.TipoEdad.C18, Concierto);
            Actividad a10 = agregarActividad("Concurso de Comidas", DateTime.Now, lc5, Actividad.TipoEdad.P, FeriaGastronomia);


            //usuarios
            Usuario u1 = agregarUsuraio("juan", "perez", "juan@gamil.com", DateTime.Parse("1978/3/12"));
            Usuario u2 = agregarUsuraio("jorje", "lopez", "lopez@gamil.com", DateTime.Parse("1998/3/12"));
            Usuario u3 = agregarUsuraio("mario", "braga", "mario@gamil.com", DateTime.Parse("1986/3/12"));
            //compras
            Compra com1 = agregarCompra(a1, 1, u1, DateTime.Now, Compra.TipoEstado.Activa);
            Compra com2 = agregarCompra(a2, 1, u2, DateTime.Now, Compra.TipoEstado.Activa);
            Compra com3 = agregarCompra(a3, 2, u3, DateTime.Now, Compra.TipoEstado.Activa);
        }
        #endregion
    }
}
