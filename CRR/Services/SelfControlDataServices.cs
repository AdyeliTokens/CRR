using CRR.DAL;
using CRR.Helpers;
using CRR.Models.Entidades;
using CRR.Models.Entidades.SelfControl;
using CRR.Models.Entidades.Specs;
using CRR.Models.Stored_Procedures;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace CRR.Services
{
    public class SelfControlDataServices
    {
        private static CRRContext db = new CRRContext();

        public static bool GetQTMData(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                using (var ctx = new CRRStoredProcedures())
                {
                    var list = ctx.CRR_QTMData(dateBegin, dateEnd).ToList();

                    foreach (var item in list)
                    {
                        var WeekNo = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateBegin, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                        
                        var idItem = db.QTMData
                            .Where(q => (q.IdWorkCenter == item.Machine) && (q.WeekNo == WeekNo))
                            .Select(q => q.Id)
                            .FirstOrDefault();

                        if (idItem != 0)
                        {
                            QTMData qtm = db.QTMData.Find(idItem);
                            qtm.Value = (int) item.Total;
                            db.Entry(qtm).State = EntityState.Modified;
                        }
                        else
                        {
                            QTMData qtm = new QTMData();
                            qtm.IdWorkCenter = item.Machine;
                            qtm.Value = (int)item.Total;
                            qtm.WeekNo = (int)item.WeekNo;
                            qtm.DateBegin = DateTime.Parse(item.DateBegin);
                            qtm.DateEnd = DateTime.Parse(item.DateEnd);
                            qtm.Shift = (int)item.Shift;
                            db.QTMData.Add(qtm);
                        }

                        db.SaveChanges();
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

        public static bool GetVisualData(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                using (var ctx = new CRRStoredProcedures())
                {
                    var list = ctx.CRR_VisualData(dateBegin, dateEnd).ToList();

                    foreach (var item in list)
                    {
                        var WeekNo = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateBegin, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                        
                        var idItem = db.VisualData
                            .Where(q => (q.IdWorkCenter == item.WorkCenter) && (q.WeekNo == WeekNo))
                            .Select(q => q.Id)
                            .FirstOrDefault();

                        if (idItem != 0)
                        {
                            VisualData vd = db.VisualData.Find(idItem);
                            vd.Value = (int)item.Total;
                            db.Entry(vd).State = EntityState.Modified;
                        }
                        else
                        {
                            VisualData vd = new VisualData();
                            vd.IdWorkCenter = item.WorkCenter;
                            vd.Value = (int)item.Total;
                            vd.WeekNo = (int)item.WeekNo;
                            vd.DateBegin = DateTime.Parse(item.DateBegin);
                            vd.DateEnd = DateTime.Parse(item.DateEnd);
                            vd.Shift = (int)item.Shift;
                            db.VisualData.Add(vd);
                        }
                        db.SaveChanges();
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

        public static bool GetRunningTimeData(DateTime dateBegin, DateTime dateEnd)
        {
            try
            {
                using (var ctx = new CRRStoredProcedures())
                {
                    var list = ctx.CRR_RunningTime(dateBegin, dateEnd).ToList();

                    foreach (var item in list)
                    {
                        var WeekNo = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateBegin, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                        var shift = Shift.Get();

                        var idItem = db.RunningTimeData
                            .Where(q => (q.IdWorkCenter == item.WorkCenter) && (q.WeekNo == WeekNo) && (q.Shift == shift))
                            .Select(q => q.Id)
                            .FirstOrDefault();

                        if (idItem != 0)
                        {
                            RunningTimeData rt = db.RunningTimeData.Find(idItem);
                            rt.RunningTime = (int)item.RunningTime;
                            db.Entry(rt).State = EntityState.Modified;
                        }
                        else
                        {
                            RunningTimeData rt = new RunningTimeData();
                            rt.IdWorkCenter = item.WorkCenter;
                            rt.Type = item.Type;
                            rt.RunningTime = (int) item.RunningTime;
                            rt.Shift = (int) item.ShiftNo;
                            rt.ShiftName = item.Shift;
                            rt.WeekNo = (int) item.WeekNo;
                            rt.BeginTime = dateBegin;
                            rt.EndTime = dateEnd;
                            db.RunningTimeData.Add(rt);
                        }
                        db.SaveChanges();
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