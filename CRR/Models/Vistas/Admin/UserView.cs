using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace CRR.Models.Vistas.Admin
{
    public class UserView
    {
        #region Properties
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool? LockOutEndDateUTC { get; set; }
        public bool LockOutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
       
        #endregion

        #region Navigation properties
        public ICollection<RolView> Roles { get; set; }
        //public ICollection<WasteDataView> WasteData { get; set; }
        #endregion
    }
}