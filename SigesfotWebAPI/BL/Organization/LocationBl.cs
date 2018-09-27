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
                                 where a.LocationId == locationId
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
                                 where a.IsDeleted == isDelete
                                 select new LocationBE()
                                 {
                                     LocationId = a.LocationId,
                                     OrganizationId = a.OrganizationId,
                                     Name = a.Name,
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

        public bool AddLocation(LocationBE location, int systemUserId)
        {
            try
            {
                LocationBE oLocationBE = new LocationBE()
                {
                    LocationId =  new Utils().GetPrimaryKey(1, 14, "OL"),
                    OrganizationId = location.OrganizationId,
                    Name = location.Name,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
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
                                 where a.LocationId == location.LocationId
                                 select a).FirstOrDefault();

                if (oLocation == null)
                    return false;

                oLocation.OrganizationId = location.OrganizationId;
                oLocation.Name = location.Name;

                //Auditoria

                oLocation.UpdateDate = DateTime.UtcNow;
                oLocation.UpdateUserId = systemUserId;

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
                                 where a.LocationId == locationId
                                 select a).FirstOrDefault();

                if (oLocation == null)
                    return false;

                oLocation.UpdateUserId = systemUserId;
                oLocation.UpdateDate = DateTime.UtcNow;
                oLocation.IsDeleted = (int)Enumeratores.SiNo.Si;

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
