using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades.Specs
{
    public class Label
    {
        #region Properties
        public int Id { get; set; }
        public int IdWaste { get; set; }
        public string Lot { get; set; }
        public string Consecutive { get; set; }
        public string ManufacturingCenter { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProductionDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpirationDate { get; set; }
        public string BrandDescription { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string LabelNumber { get; set; }
        public string FlashPoint { get; set; }
        public Double Weight { get; set; }
        public Double Quantity { get; set; }
        public string ExtractionBank { get; set; }
        public string ExtractionModule { get; set; }
        public string Operator { get; set; }
        #endregion

        #region Navigation properties
        public WasteData Waste { get; set; }
        #endregion
    }
}