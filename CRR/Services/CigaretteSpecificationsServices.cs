using CRR.DAL;
using CRR.Models.Entidades;
using CRR.Models.Entidades.Specs;
using CRR.Models.Stored_Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace CRR.Services
{
    public class CigaretteSpecificationsServices
    {
        private static CRRContext db = new CRRContext();

        public static bool addLabel(string OrderNo, WasteData waste, string Operator)
        {
            try
            {
                using (var ctx = new CRRStoredProcedures())
                {
                    var data = ctx.CRR_CigaretteSpecifications(OrderNo).FirstOrDefault();

                    Label label = new Label();
                    label.IdWaste = waste.Id;
                    label.Lot = "MG-L000000";
                    label.Consecutive = "0000";
                    label.ManufacturingCenter = "Philip Morris Mexico-MS14";
                    label.ProductionDate = data.EffectivityFromDate ?? DateTime.Now;
                    label.ExpirationDate = label.ProductionDate.AddDays(15);
                    label.BrandDescription = data.MaterialDescription;
                    label.ProductCode = data.CigaretteCode + "RT";
                    var market = data.Destination.Contains("MEXICO") ? "LOCAL" : "EXP - IMMEX";
                    label.ProductDescription = data.BrandCode + " " + data.CutFiller + " " + market;
                    label.LabelNumber = "400000" + (waste.VolumeWaste * 100) + ((waste.VolumeWaste + 15) * 100) + "00" + label.Lot + data.CigaretteCode + "RTB";
                    label.FlashPoint = "N/A";
                    label.Weight = waste.VolumeWaste + 15;
                    label.Quantity = waste.VolumeWaste;
                    label.ExtractionBank = "0";
                    label.ExtractionModule = data.Linkup;
                    string[] lName = waste.IdUser.Split('@');
                    label.Operator = (Operator == null || Operator == "") ? lName[0].Replace("."," ") : Operator.ToUpper();

                    db.Label.Add(label);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        public static double getCigaretteWeigth(string OrderNo)
        {
            try
            {
                using (var ctx = new CRRStoredProcedures())
                {
                    return (double) ctx.CRR_CigaretteWeight(OrderNo).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return 0;
            }
        }

    }
}