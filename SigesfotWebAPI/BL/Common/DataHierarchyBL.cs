using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class DataHierarchyBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public DataHierarchyBE GetDataHierarchy(int groupId, int itemId)
        {
            try
            {
                var objEntity = (from a in ctx.DataHierarchy
                                 where a.GroupId == groupId && a.ItemId == itemId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DataHierarchyBE> GetAllDataHierarchy()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.DataHierarchy
                                 where a.IsDeleted == isDelete
                                 select new DataHierarchyBE()
                                 {
                                     GroupId = a.GroupId,
                                     ItemId = a.ItemId,
                                     Value1 = a.Value1,
                                     Value2 = a.Value2,
                                     Field = a.Field,
                                     ParentItemId = a.ParentItemId,
                                     Sort = a.Sort,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateDate = a.UpdateDate,
                                     UpdateUserId = a.UpdateUserId
                                 }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddDataHierarchy(DataHierarchyBE dataHierarchy, int systemUserId)
        {
            try
            {
                DataHierarchyBE oDataHierarchyBE = new DataHierarchyBE()
                {
                    //GroupId = BE.Utils.GetPrimaryKey("no usa"),

                    Value1 = dataHierarchy.Value1,
                    Value2 = dataHierarchy.Value2,
                    Field = dataHierarchy.Field,
                    ParentItemId = dataHierarchy.ParentItemId,
                    Sort = dataHierarchy.Sort,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.DataHierarchy.Add(oDataHierarchyBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDataHierarchy(DataHierarchyBE dataHierarchy, int systemUserId)
        {
            try
            {
                var oDataHierarchy = (from a in ctx.DataHierarchy
                                      where a.GroupId == dataHierarchy.GroupId && a.ItemId == dataHierarchy.ItemId
                                      select a).FirstOrDefault();

                if (oDataHierarchy == null)
                    return false;

                oDataHierarchy.Value1 = dataHierarchy.Value1;
                oDataHierarchy.Value2 = dataHierarchy.Value2;
                oDataHierarchy.Field = dataHierarchy.Field;
                oDataHierarchy.ParentItemId = dataHierarchy.ParentItemId;
                oDataHierarchy.Sort = dataHierarchy.Sort;

                //Auditoria

                oDataHierarchy.UpdateDate = DateTime.UtcNow;
                oDataHierarchy.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDataHierarchy(int groupId, int itemId, int systemUserId)
        {
            try
            {
                var oDataHierarchy = (from a in ctx.DataHierarchy
                            where a.GroupId == groupId && a.ItemId == itemId
                            select a).FirstOrDefault();

                if (oDataHierarchy == null)
                    return false;

                oDataHierarchy.UpdateUserId = systemUserId;
                oDataHierarchy.UpdateDate = DateTime.UtcNow;
                oDataHierarchy.IsDeleted = (int)Enumeratores.SiNo.Si;

                int rows = ctx.SaveChanges();

                return rows > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
