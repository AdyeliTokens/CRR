using CRR.DAL;
using CRR.Models.Entidades.Admin;
using CRR.Models.RespuestaGenerica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Services
{
    public class UserServices
    {
        private static CRRContext db = new CRRContext();

        public static IRespuestaServicio<User> GetUser(string userId)
        {
            IRespuestaServicio<User> respuesta = new RespuestaServicio<User>();
            var user = db.User.Where(x => x.Id == userId).Select(x => x).FirstOrDefault();
            if (user == null)
            {
                respuesta.Mensaje = "No se encontraron registros";
            }
            else
            {
                respuesta.Respuesta = user;
            }

            return respuesta;
        }
    }
}