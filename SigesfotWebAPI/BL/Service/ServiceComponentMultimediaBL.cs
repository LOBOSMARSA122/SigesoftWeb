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
    public class ServiceComponentMultimediaBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ServiceComponentMultimediaBE GetServiceComponentMultimedia(string serviceComponentMultimediaId)
        {
            try
            {
                var objEntity = (from a in ctx.ServiceComponentMultimedia
                                 where a.ServiceComponentMultimediaId == serviceComponentMultimediaId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ServiceComponentMultimediaBE> GetAllServiceComponentMultimedia()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ServiceComponentMultimedia
                                 where a.IsDeleted == isDelete
                                 select new ServiceComponentMultimediaBE()
                                 {
                                     ServiceComponentMultimediaId = a.ServiceComponentMultimediaId,
                                     ServiceComponentId = a.ServiceComponentId,
                                     MultimediaFileId = a.MultimediaFileId,
                                     Comment = a.Comment,
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

        public bool AddServiceComponentMultimedia(ServiceComponentMultimediaBE serviceComponentMultimedia, int systemUserId)
        {
            try
            {
                ServiceComponentMultimediaBE oServiceComponentMultimediaBE = new ServiceComponentMultimediaBE()
                {
                    ServiceComponentMultimediaId = BE.Utils.GetPrimaryKey(1, 46, "FC"),
                    ServiceComponentId = serviceComponentMultimedia.ServiceComponentId,
                    MultimediaFileId = serviceComponentMultimedia.MultimediaFileId,
                    Comment = serviceComponentMultimedia.Comment,
                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.ServiceComponentMultimedia.Add(oServiceComponentMultimediaBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateServiceComponentMultimedia(ServiceComponentMultimediaBE serviceComponentMultimedia, int systemUserId)
        {
            try
            {
                var oServiceComponentMultimedia = (from a in ctx.ServiceComponentMultimedia
                                                   where a.ServiceComponentMultimediaId == serviceComponentMultimedia.ServiceComponentMultimediaId
                                                   select a).FirstOrDefault();

                if (oServiceComponentMultimedia == null)
                    return false;

                oServiceComponentMultimedia.ServiceComponentId = serviceComponentMultimedia.ServiceComponentId;
                oServiceComponentMultimedia.MultimediaFileId = serviceComponentMultimedia.MultimediaFileId;
                oServiceComponentMultimedia.Comment = serviceComponentMultimedia.Comment;
                //Auditoria

                oServiceComponentMultimedia.UpdateDate = DateTime.UtcNow;
                oServiceComponentMultimedia.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteServiceComponentMultimedia(string serviceComponentMultimediaId, int systemUserId)
        {
            try
            {
                var oServiceComponentMultimedia = (from a in ctx.ServiceComponentMultimedia
                                                   where a.ServiceComponentMultimediaId == serviceComponentMultimediaId
                                                   select a).FirstOrDefault();

                if (oServiceComponentMultimedia == null)
                    return false;

                oServiceComponentMultimedia.UpdateUserId = systemUserId;
                oServiceComponentMultimedia.UpdateDate = DateTime.UtcNow;
                oServiceComponentMultimedia.IsDeleted = (int)Enumeratores.SiNo.Si;

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
