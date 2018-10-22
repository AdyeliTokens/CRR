using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace CRR.Models.Vistas.Admin
{
    public class RolView
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public ICollection<UserView> Users { get; set; }
        #endregion
    }
}