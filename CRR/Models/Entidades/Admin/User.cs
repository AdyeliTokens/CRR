using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRR.Models.Entidades.Admin
{
    public class User 
    {
        #region Properties
        [Key]
        public string Id { get; set; }

        [StringLength(250)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        [StringLength(250)]
        public string PasswordHash { get; set; }
        [StringLength(250)]
        public string SecurityStamp { get; set; }
        [StringLength(250)]
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool? LockOutEndDateUTC { get; set; }
        public bool LockOutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [StringLength(250)]
        public string UserName { get; set; }
                
        #endregion

        #region Navigation properties
        public ICollection<Rol> Roles { get; set; }
        //public ICollection<WasteData> WasteData { get; set; }
        #endregion
    }
}