using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.Specs
{
    public class LabelView
    {
        #region Properties
        public int Id { get; set; }
        public int IdWaste { get; set; }
        public string Lot { get; set; }
        public string Consecutive { get; set; }
        public string ManufacturingCenter { get; set; }
        public DateTime ProductionDate { get; set; }
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
        public WasteDataView Waste { get; set; }
        #endregion
    }
}