using System.ComponentModel.DataAnnotations;

namespace CRR.Models.Entidades.Admin
{
    public class Login
    {
        [Required]
        [Display(Name = "Email")]
        [StringLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(250)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [StringLength(250)]
        [Display(Name = "Llave")]
        public string Llave { get; set; }
    }
}