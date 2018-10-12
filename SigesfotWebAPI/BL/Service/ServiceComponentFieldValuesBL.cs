using BE.Common;
using BE.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class ServiceComponentFieldValuesBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        //public ServiceComponentFieldValuesBE GetServiceComponentFieldValues(string serviceComponentFieldValuesId)
        //{
        //    try
        //    {
        //        var objEntity = (from a in ctx.ServiceComponentFieldValues
        //                         where a.ServiceComponentFieldValuesId == serviceComponentFieldValuesId
        //                         select a).FirstOrDefault();

        //        return objEntity;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public List<ServiceComponentFieldValuesBE> GetAllServiceComponentFieldValues()
        //{
        //    try
        //    {
        //        var isDelete = (int)Enumeratores.SiNo.No;
        //        var objEntity = (from a in ctx.ServiceComponentFieldValues
        //                         where a.IsDeleted == isDelete
        //                         select new ServiceComponentFieldValuesBE()
        //                         {
        //                             ServiceComponentFieldValuesId = a.ServiceComponentFieldValuesId,
        //                             ComponentFieldValuesId = a.ComponentFieldValuesId,
        //                             ServiceComponentFieldsId = a.ServiceComponentFieldsId,
        //                             Value1 = a.Value1,
        //                             Value2 = a.Value2,
        //                             Index = a.Index,
        //                             ValueInt1 = a.ValueInt1,
        //                             IsDeleted = a.IsDeleted,
        //                             InsertUserId = a.InsertUserId,
        //                             InsertDate = a.InsertDate,
        //                             UpdateDate = a.UpdateDate,
        //                             UpdateUserId = a.UpdateUserId
        //                         }).ToList();

        //        return objEntity;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public bool AddServiceComponentFieldValues(ServiceComponentFieldValuesBE serviceComponentFieldValues, int systemUserId)
        //{
        //    try
        //    {
        //        ServiceComponentFieldValuesBE oServiceComponentFieldValuesBE = new ServiceComponentFieldValuesBE()
        //        {
        //            ServiceComponentFieldValuesId = new Utils().GetPrimaryKey(1, 36, "CV"),
        //            ComponentFieldValuesId = serviceComponentFieldValues.ComponentFieldValuesId,
        //            ServiceComponentFieldsId = serviceComponentFieldValues.ServiceComponentFieldsId,
        //            Value1 = serviceComponentFieldValues.Value1,
        //            Value2 = serviceComponentFieldValues.Value2,
        //            Index = serviceComponentFieldValues.Index,
        //            ValueInt1 = serviceComponentFieldValues.ValueInt1,

        //            //Auditoria
        //            IsDeleted = (int)Enumeratores.SiNo.No,
        //            InsertDate = DateTime.UtcNow,
        //            InsertUserId = systemUserId,
        //        };

        //        ctx.ServiceComponentFieldValues.Add(oServiceComponentFieldValuesBE);

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateServiceComponentFieldValues(ServiceComponentFieldValuesBE serviceComponentFieldValues, int systemUserId)
        //{
        //    try
        //    {
        //        var oServiceComponentFieldValues = (from a in ctx.ServiceComponentFieldValues
        //                                            where a.ServiceComponentFieldValuesId == serviceComponentFieldValues.ServiceComponentFieldValuesId
        //                                            select a).FirstOrDefault();

        //        if (oServiceComponentFieldValues == null)
        //            return false;

        //        oServiceComponentFieldValues.ComponentFieldValuesId = serviceComponentFieldValues.ComponentFieldValuesId;
        //        oServiceComponentFieldValues.ServiceComponentFieldsId = serviceComponentFieldValues.ServiceComponentFieldsId;
        //        oServiceComponentFieldValues.Value1 = serviceComponentFieldValues.Value1;
        //        oServiceComponentFieldValues.Value2 = serviceComponentFieldValues.Value2;
        //        oServiceComponentFieldValues.Index = serviceComponentFieldValues.Index;
        //        oServiceComponentFieldValues.ValueInt1 = serviceComponentFieldValues.ValueInt1;
        //        //Auditoria

        //        oServiceComponentFieldValues.UpdateDate = DateTime.UtcNow;
        //        oServiceComponentFieldValues.UpdateUserId = systemUserId;

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteServiceComponentFieldValues(string serviceComponentFieldValuesId, int systemUserId)
        //{
        //    try
        //    {
        //        var oServiceComponentFieldValues = (from a in ctx.ServiceComponentFieldValues
        //                                            where a.ServiceComponentFieldValuesId == serviceComponentFieldValuesId
        //                                            select a).FirstOrDefault();

        //        if (oServiceComponentFieldValues == null)
        //            return false;

        //        oServiceComponentFieldValues.UpdateUserId = systemUserId;
        //        oServiceComponentFieldValues.UpdateDate = DateTime.UtcNow;
        //        oServiceComponentFieldValues.IsDeleted = (int)Enumeratores.SiNo.Si;

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        #endregion
    }
}
