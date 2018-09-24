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
                                 where a.i_GroupId == groupId && a.i_ItemId == itemId
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
                                 where a.i_IsDeleted == isDelete
                                 select new DataHierarchyBE()
                                 {
                                     i_GroupId = a.i_GroupId,
                                     i_ItemId = a.i_ItemId,
                                     v_Value1 = a.v_Value1,
                                     v_Value2 = a.v_Value2,
                                     v_Field = a.v_Field,
                                     i_ParentItemId = a.i_ParentItemId,
                                     i_Sort = a.i_Sort,
                                     i_IsDeleted = a.i_IsDeleted,
                                     i_InsertUserId = a.i_InsertUserId,
                                     d_InsertDate = a.d_InsertDate,
                                     d_UpdateDate = a.d_UpdateDate,
                                     i_UpdateUserId = a.i_UpdateUserId
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

                    v_Value1 = dataHierarchy.v_Value1,
                    v_Value2 = dataHierarchy.v_Value2,
                    v_Field = dataHierarchy.v_Field,
                    i_ParentItemId = dataHierarchy.i_ParentItemId,
                    i_Sort = dataHierarchy.i_Sort,

                    //Auditoria
                    i_IsDeleted = (int)Enumeratores.SiNo.No,
                    d_InsertDate = DateTime.UtcNow,
                    i_InsertUserId = systemUserId,
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
                                      where a.i_GroupId == dataHierarchy.i_GroupId && a.i_ItemId == dataHierarchy.i_ItemId
                                      select a).FirstOrDefault();

                if (oDataHierarchy == null)
                    return false;

                oDataHierarchy.v_Value1 = dataHierarchy.v_Value1;
                oDataHierarchy.v_Value2 = dataHierarchy.v_Value2;
                oDataHierarchy.v_Field = dataHierarchy.v_Field;
                oDataHierarchy.i_ParentItemId = dataHierarchy.i_ParentItemId;
                oDataHierarchy.i_Sort = dataHierarchy.i_Sort;

                //Auditoria

                oDataHierarchy.d_UpdateDate = DateTime.UtcNow;
                oDataHierarchy.i_UpdateUserId = systemUserId;

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
                            where a.i_GroupId == groupId && a.i_ItemId == itemId
                            select a).FirstOrDefault();

                if (oDataHierarchy == null)
                    return false;

                oDataHierarchy.i_UpdateUserId = systemUserId;
                oDataHierarchy.d_UpdateDate = DateTime.UtcNow;
                oDataHierarchy.i_IsDeleted = (int)Enumeratores.SiNo.Si;

                int rows = ctx.SaveChanges();

                return rows > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Bussines Logic

        public List<Dropdownlist> GetDatahierarchyByGrupoId(int grupoId)
        {
            var isDeleted = (int)Enumeratores.SiNo.No;
            List<Dropdownlist> result = (from a in ctx.DataHierarchy
                                         where a.i_IsDeleted == isDeleted && a.i_GroupId == grupoId
                                         orderby a.i_Sort ascending
                                         select new Dropdownlist
                                         {
                                             Id = a.i_ItemId,
                                             Value = a.v_Value1
                                         }).ToList();
            return result;
        }
        #endregion
    }
}
