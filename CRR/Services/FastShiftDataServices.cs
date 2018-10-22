using CRR.DAL;
using CRR.Models.Entidades;
using CRR.Models.Entidades.Specs;
using CRR.Models.Stored_Procedures;
using System;
using System.Data.Entity;
using System.Linq;

namespace CRR.Services
{
    public class FastShiftDataServices
    {
        private static CRRContext db = new CRRContext();


        public static bool GetData(DateTime dateBegin, DateTime dateEnd)
        {

            UpdateWorkCenters();

            using (var ctx = new CRRStoredProcedures())
            {
                var fsdList = ctx.CRR_FastShiftData(dateBegin, dateEnd).ToList();

                foreach (var item in fsdList)
                {
                    Brand brand = db.Brands.Find(item.FA);
                    if (brand == null)
                    {
                        AddBrand(item.FA,item.FAName, item.Cigarette);
                    }
                    
                    var OrderNo = Int32.Parse(item.OrderNo);

                    var idItem = db.FastShiftData
                        .Where(f => (f.IdWorkcenter == item.WorkCenter && f.IdBrand == item.FA && f.OrderNo == OrderNo))
                        .Select(f => f.Id)
                        .FirstOrDefault();

                    if (idItem != 0)
                    {
                        FastShiftData fsd = db.FastShiftData.Find(idItem);
                        fsd.IdWorkcenter = item.WorkCenter;
                        fsd.IdDepartment = item.Department;
                        fsd.IdBrand = item.FA;
                        fsd.FAName = item.FAName;
                        fsd.ProdVol = Convert.ToDouble(item.ProdVol);
                        fsd.TargetQty = Convert.ToDouble(item.TargetQty);
                        fsd.OrderNo = Int32.Parse(item.OrderNo);
                        fsd.OrderStatus = item.OrderStatus;
                        fsd.CigaretteCode = item.Cigarette;
                        fsd.CigaretteName = item.CigaretteName;
                        fsd.RegistrationDate = dateBegin;
                        db.Entry(fsd).State = EntityState.Modified;
                    }
                    else
                    {
                        FastShiftData fsd = new FastShiftData();
                        fsd.IdWorkcenter = item.WorkCenter;
                        fsd.IdDepartment = item.Department;
                        fsd.IdBrand = item.FA;
                        fsd.FAName = item.FAName;
                        fsd.ProdVol = Convert.ToDouble(item.ProdVol);
                        fsd.TargetQty = Convert.ToDouble(item.TargetQty);
                        fsd.OrderNo = Int32.Parse(item.OrderNo);
                        fsd.OrderStatus = item.OrderStatus;
                        fsd.CigaretteCode = item.Cigarette;
                        fsd.CigaretteName = item.CigaretteName;
                        fsd.RegistrationDate = dateBegin;
                        db.FastShiftData.Add(fsd);
                    }

                    db.SaveChanges();
                }
            }

            return true;            
        }


        public static bool AddBrand(String CodeFA, string FAName, string Cigarette)
        {
            try
            {
                using (var ctx = new CRRStoredProcedures())
                {
                    var brandWeight = ctx.CRR_ProductDetails(CodeFA).FirstOrDefault();

                    Brand newBrand = new Brand();
                    newBrand.CodeFA = CodeFA;
                    newBrand.Description = FAName;
                    newBrand.CigaretteCode = Cigarette;
                    newBrand.CigaretteWeight = Convert.ToDouble(brandWeight.CigareteWeight);
                    newBrand.Active = true;
                    db.Brands.Add(newBrand);
                    db.SaveChanges();
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        public static bool UpdateWorkCenters()
        {
            try
            {
                using (var ctx = new CRRStoredProcedures())
                {
                    var list = ctx.CRR_WorkCenter().ToList();

                    foreach (var item in list)
                    {
                        if (db.WorkCenters.Find(item.WorkCenter) == null)
                        {
                            WorkCenter workCenter = new WorkCenter();
                            workCenter.Name = item.WorkCenter;
                            workCenter.TextID = Convert.ToInt32(item.TextID);
                            workCenter.DepartmentName = item.Department;
                            workCenter.Facility = item.Facility;
                            workCenter.Company = item.Company;
                            db.WorkCenters.Add(workCenter);

                            WasteWorkCenter wasteW = new WasteWorkCenter();
                            wasteW.IdWorkCenter = item.WorkCenter;
                            wasteW.Value = 1.9;
                            wasteW.Active = true;
                            db.WasteWorkCenters.Add(wasteW);

                            db.SaveChanges();
                        }
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        public static bool UpdateDepartments()
        {
            try
            {
                using (var ctx = new CRRStoredProcedures())
                {
                    var list = ctx.CRR_Department().ToList();

                    foreach (var item in list)
                    {
                        if (db.Departments.Find(item.Department) == null)
                        {
                            Department department = new Department();
                            department.Name = item.Department;
                            department.IdLESMES = Convert.ToInt32(item.TextID);
                            department.Facility = item.Facility;
                            department.CalendarID = Convert.ToInt32(item.CalendarID);
                            department.Company = item.Company;
                            department.Active = true;
                            db.Departments.Add(department);

                            WasteDepartment wasteD = new WasteDepartment();
                            wasteD.IdDepartment = item.Department;
                            wasteD.Value = 1.9;
                            wasteD.Active = true;

                            db.SaveChanges();
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

    }
}