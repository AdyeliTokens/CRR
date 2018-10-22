using CRR.Models.Entidades.Admin;
using CRR.Models.Entidades.Specs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades
{
    public class WasteData
    {
        #region Properties
        public int Id { get; set; }
        public string IdWorkCenter { get; set; }
        public int Shift { get; set; }
        public string IdBrand { get; set; }
        public int BankExtraction { get; set; }
        public double VolumeWaste { get; set; }        
        public double CigaretteWeight { get; set; }
        public double CigaretteWaste { get; set; }
        public string IdUser { get; set; }
        public DateTime RegistrationDate { get; set; }
        #endregion

        #region Navigation properties
        public WorkCenter WorkCenter { get; set; }
        public Brand Brand { get; set; }
        //public User User { get; set; }
        public ICollection<Label> Labels { get; set; }
        #endregion
    }
}