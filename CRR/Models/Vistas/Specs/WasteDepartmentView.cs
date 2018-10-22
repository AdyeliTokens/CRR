﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRR.Models.Vistas.Specs
{
    public class WasteDepartmentView
    {
        #region Properties
        public int Id { get; set; }
        public string IdDepartment { get; set; }
        public double Value { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Navigation properties
        public DepartmentView department { get; set; }
        #endregion
    }
}