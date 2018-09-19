using BE.Common;
using BE.Organization;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Organization
{
    public class AreaBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD

        public AreaBE GetArea(string areaId)
        {
            try
            {
                var objEntity = (from a in ctx.Area
                                 where a.AreaId == areaId
                                 select a).FirstOrDefault();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AreaBE> GetAllArea()
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Area
                                 where a.IsDeleted == isDeleted
                                 select new AreaBE()
                                 {
                                    AreaId = a.AreaId,
                                    LocationId = a.LocationId,
                                     Name = a.Name,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateUserId = a.UpdateUserId,
                                     UpdateDate = a.UpdateDate,
                                 }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddArea(AreaBE area, int systemUserId)
        {
            try
            {
                AreaBE oAreaBE = new AreaBE()
                {
                    //PK
                    AreaId =  BE.Utils.GetPrimaryKey(1, 11, "OA"),
                    LocationId = area.LocationId,
                    Name = area.Name,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId
                };

                ctx.Area.Add(oAreaBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateArea(AreaBE area, int systemUserId)
        {
            try
            {
                var oArea = (from a in ctx.Area where a.AreaId == area.AreaId select a).FirstOrDefault();

                if (oArea == null)
                    return false;

                oArea.LocationId = area.LocationId;
                oArea.Name = area.Name;

                //Auditoria
                oArea.UpdateDate = DateTime.UtcNow;
                oArea.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool DeleteArea(string areaId, int systemUserId)
        {
            try
            {
                var oArea = (from a in ctx.Area where a.AreaId == areaId select a).FirstOrDefault();

                if (oArea == null)
                    return false;

                oArea.UpdateUserId = systemUserId;
                oArea.UpdateDate = DateTime.UtcNow;
                oArea.IsDeleted = (int)Enumeratores.SiNo.Si;

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
