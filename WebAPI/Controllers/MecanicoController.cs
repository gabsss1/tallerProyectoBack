using Comun.ViewModels;
using Logica.BLL;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MecanicoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll(int cantidad = 10, int pagina = 0, string textoSearch = null)
        {
            var respuesta = new RespuestaVMR<ListaPaginadoVMR<MecanicoVMR>>();
            try
            {
                respuesta.datos = MecanicoBLL.GetAll(cantidad, pagina, textoSearch);

            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }
            return Content(respuesta.codigo, respuesta);
        }

        [HttpGet]
        public IHttpActionResult getById(int id)
        {
            var respuesta = new RespuestaVMR<MecanicoVMR>();
            try
            {
                respuesta.datos = MecanicoBLL.GetById(id);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            if (respuesta.datos == null && respuesta.mensajes.Count() == 0)
            {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensajes.Add("Elemento no encontrado");
            }
            return Content(respuesta.codigo, respuesta);
        }

        [HttpPost]
        public IHttpActionResult post(Mecanico item)
        {
            var respuesta = new RespuestaVMR<long?>();
            try
            {
                respuesta.datos = MecanicoBLL.Post(item);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }
            return Content(respuesta.codigo, respuesta);
        }

        [HttpPut]
        public IHttpActionResult put(int id, MecanicoVMR item)
        {
            var respuesta = new RespuestaVMR<bool>();
            try
            {
                item.id = id;
                MecanicoBLL.Put(item);
                respuesta.datos = true;
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }
            return Content(respuesta.codigo, respuesta);
        }

        [HttpDelete]
        public IHttpActionResult delete(List<long> ids)
        {
            var respuesta = new RespuestaVMR<bool>();
            try
            {
                MecanicoBLL.Delete(ids);
                respuesta.datos = true;
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }
            return Content(respuesta.codigo, respuesta);
        }
    }
}