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
    public class LocationBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public LocationBE GetLocation(string locationId)
        {
            try
            {
                var objEntity = (from a in ctx.Location
                                 where a.v_LocationId == locationId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<LocationBE> GetAllLocation()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Location
                                 where a.i_IsDeleted == isDelete
                                 select new LocationBE()
                                 {
                                     v_LocationId = a.v_LocationId,
                                     v_OrganizationId = a.v_OrganizationId,
                                     v_Name = a.v_Name,
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

        public bool AddLocation(LocationBE location, int systemUserId)
        {
            try
            {
                LocationBE oLocationBE = new LocationBE()
                {
                    v_LocationId =  new Utils().GetPrimaryKey(1, 14, "OL"),
                    v_OrganizationId = location.v_OrganizationId,
                    v_Name = location.v_Name,

                    //Auditoria
                    i_IsDeleted = (int)Enumeratores.SiNo.No,
                    d_InsertDate = DateTime.UtcNow,
                    i_InsertUserId = systemUserId,
                };

                ctx.Location.Add(oLocationBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateLocation(LocationBE location, int systemUserId)
        {
            try
            {
                var oLocation = (from a in ctx.Location
                                 where a.v_LocationId == location.v_LocationId
                                 select a).FirstOrDefault();

                if (oLocation == null)
                    return false;

                oLocation.v_OrganizationId = location.v_OrganizationId;
                oLocation.v_Name = location.v_Name;

                //Auditoria

                oLocation.d_UpdateDate = DateTime.UtcNow;
                oLocation.i_UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteLocation(string locationId, int systemUserId)
        {
            try
            {
                var oLocation = (from a in ctx.Location
                                 where a.v_LocationId == locationId
                                 select a).FirstOrDefault();

                if (oLocation == null)
                    return false;

                oLocation.i_UpdateUserId = systemUserId;
                oLocation.d_UpdateDate = DateTime.UtcNow;
                oLocation.i_IsDeleted = (int)Enumeratores.SiNo.Si;

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
