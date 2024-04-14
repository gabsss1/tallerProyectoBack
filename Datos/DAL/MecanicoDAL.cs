using Comun.ViewModels;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class MecanicoDAL
    {
        public static ListaPaginadoVMR<MecanicoVMR> GetAll(int cantidad, int pagina, string textoBusqueda)
        {
            ListaPaginadoVMR<MecanicoVMR> resultado = new ListaPaginadoVMR<MecanicoVMR>();

            using (var db = DbConexion.Create())
            {
                var query = db.Mecanico.Where(x => !x.borrado).Select(x => new MecanicoVMR
                {
                    id = x.id,
                    nombre = x.nombre,
                    apellidoPaterno = x.apellidoPaterno,
                    apellidoMaterno = x.apellidoMaterno,

                });

                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    query = query.Where(x => x.nombre.Contains(textoBusqueda) || x.apellidoPaterno.Contains(textoBusqueda));
                }

                resultado.cantidadTotal = query.Count();

                resultado.elemento = query
                    .OrderBy(x => x.id)
                    .Skip(pagina * cantidad)
                    .Take(cantidad)
                    .ToList();
            }

            return resultado;
        }

        public static MecanicoVMR GetById(int id)
        {
            MecanicoVMR item = null;

            using (var db = DbConexion.Create())
            {
                item = db.Mecanico.Where(x=> !x.borrado && x.id == id).Select(x => new MecanicoVMR
                {
                    id = x.id,
                    nombre = x.nombre,
                    apellidoPaterno = x.apellidoPaterno,
                    apellidoMaterno = x.apellidoMaterno,
                    habilitado = x.habilitado

                }).FirstOrDefault();
            }

            return item;
        }

        public static long Post(Mecanico item)
        {

            using (var db = DbConexion.Create())
            {
                db.Mecanico.Add(item);
                db.SaveChanges();
            }

            return item.id;
        }

        public static void Put(MecanicoVMR item)
        {
            using (var db = DbConexion.Create())
            {
                var itemPut = db.Mecanico.Find(item.id);

                itemPut.nombre = item.nombre;
                itemPut.apellidoPaterno = item.apellidoPaterno;
                itemPut.apellidoMaterno = item.apellidoMaterno;
                itemPut.habilitado = item.habilitado;

                db.Entry(itemPut).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Delete(List<long> ids)
        {
            using (var db = DbConexion.Create())
            {
                var items = db.Mecanico.Where(x => ids.Contains(x.id));

                foreach (var item in items)
                {
                    item.borrado = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
            }
        }
    }
}
