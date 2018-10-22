using CRR.Models.Vistas.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas
{
    public class WasteDataView
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
        public string UserName { get; set; }
        public DateTime RegistrationDate { get; set; }
        #endregion

        #region Navigation properties
        public WorkCenterView WorkCenter { get; set; }
        public BrandView Brand { get; set; }
        //public UserView User { get; set; }
        #endregion
    }
}