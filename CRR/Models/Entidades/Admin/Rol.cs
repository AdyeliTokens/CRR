using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades.Admin
{
    public class Rol 
    {
        #region Properties
        [Key]
        public int  Id { get; set; }
        public string Name { get; set; }
        //public bool Create { get; set; }
        //public bool Read { get; set; }
        //public bool Update { get; set; }
        //public bool Delete { get; set; }
        //public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public ICollection<User> Users { get; set; }
        #endregion
    }
}