using Comun.ViewModels;
using Datos.DAL;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.BLL
{
    public class MecanicoBLL
    {
        public static ListaPaginadoVMR<MecanicoVMR> GetAll(int cantidad, int pagina, string textoBusqueda)
        {
            return MecanicoDAL.GetAll(cantidad, pagina, textoBusqueda);
        }

        public static MecanicoVMR GetById(int id)
        {
            return MecanicoDAL.GetById(id);
        }

        public static long Post(Mecanico item)
        {
            return MecanicoDAL.Post(item);
        }

        public static void Put(MecanicoVMR item)
        {
            MecanicoDAL.Put(item);
        }

        public static void Delete(List<long> ids)
        {
            MecanicoDAL.Delete(ids);
        }
    }
}
