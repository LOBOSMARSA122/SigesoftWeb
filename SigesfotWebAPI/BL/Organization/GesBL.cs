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
    public class GesBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public GesBE GetGes (string gesId )
        {
            try
            {
                var objEntity = (from a in ctx.Ges
                                 where a.GesId == gesId
                                 select a).FirstOrDefault();

                return objEntity;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GesBE> GetAllGes ()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Ges
                                 where a.IsDeleted == isDelete
                                 select new GesBE()
                                 {
                                     GesId = a.GesId,
                                     AreaId = a.AreaId,
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

        public bool AddGes (GesBE ges, int systemUserId)
        {
            try
            {
                GesBE oGesBE = new GesBE()
                {
                    GesId =  new Common.PersonBL().GetPrimaryKey(1, 12, "OE"),
                    AreaId = ges.AreaId,
                    Name = ges.Name,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Ges.Add(oGesBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateGes (GesBE ges, int systemUserId)
        {
            try
            {
                var oGes = (from a in ctx.Ges
                            where a.GesId == ges.GesId
                            select a).FirstOrDefault();

                if (oGes == null)
                    return false;

                oGes.AreaId = ges.AreaId;
                oGes.Name = ges.Name;

                //Auditoria

                oGes.UpdateDate = DateTime.UtcNow;
                oGes.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteGes (string gesId, int systemUserId)
        {
            try
            {
                var oGes = (from a in ctx.Ges
                            where a.GesId == gesId
                            select a).FirstOrDefault();

                if (oGes == null)
                    return false;

                oGes.UpdateUserId = systemUserId;               
                oGes.UpdateDate = DateTime.UtcNow;
                oGes.IsDeleted = (int)Enumeratores.SiNo.Si;

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
