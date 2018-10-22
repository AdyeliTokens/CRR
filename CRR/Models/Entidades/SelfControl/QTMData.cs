using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Entidades.SelfControl
{
    public class QTMData
    {
        #region Properties
        [Key, Required]
        public int Id { get; set; }
        public string IdWorkCenter { get; set; }
        public int Value { get; set; }
        public int WeekNo { get; set; }
        public DateTime DateBegin  { get; set; }
        public DateTime DateEnd { get; set; }
        public int Shift { get; set; }
        #endregion

        #region Navigation properties
        public WorkCenter WorkCenter { get; set; }
        #endregion
    }
}