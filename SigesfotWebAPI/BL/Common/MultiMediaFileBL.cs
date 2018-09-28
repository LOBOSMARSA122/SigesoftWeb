using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class MultimediaFileBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public MultimediaFileBE GetMultimediaFile(string multimediaFileId)
        {
            try
            {
                var objEntity = (from a in ctx.MultimediaFile
                                 where a.MultimediaFileId == multimediaFileId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MultimediaFileBE> GetAllMultimediaFile()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.MultimediaFile
                                 where a.IsDeleted == isDelete
                                 select new MultimediaFileBE()
                                 {
                                     MultimediaFileId = a.MultimediaFileId,
                                     PersonId = a.PersonId,
                                     FileName = a.FileName,
                                     File = a.File,
                                     ThumbnailFile = a.ThumbnailFile,
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

        public bool AddMultimediaFile(MultimediaFileBE multimediaFile, int systemUserId)
        {
            try
            {
                MultimediaFileBE oMultimediaFileBE = new MultimediaFileBE()
                {
                    MultimediaFileId =  new Utils().GetPrimaryKey(1, 45, "FU"),
                    PersonId = multimediaFile.PersonId,
                    FileName = multimediaFile.FileName,
                    File = multimediaFile.File,
                    ThumbnailFile = multimediaFile.ThumbnailFile,
                    Comment = multimediaFile.Comment,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.MultimediaFile.Add(oMultimediaFileBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMultimediaFile(MultimediaFileBE multimediaFile, int systemUserId)
        {
            try
            {
                var oMultimediaFile = (from a in ctx.MultimediaFile
                                       where a.MultimediaFileId == multimediaFile.MultimediaFileId
                                       select a).FirstOrDefault();

                if (oMultimediaFile == null)
                    return false;

                oMultimediaFile.PersonId = multimediaFile.PersonId;
                oMultimediaFile.FileName = multimediaFile.FileName;
                oMultimediaFile.File = multimediaFile.File;
                oMultimediaFile.ThumbnailFile = multimediaFile.ThumbnailFile;
                oMultimediaFile.Comment = multimediaFile.Comment;

                //Auditoria

                oMultimediaFile.UpdateDate = DateTime.UtcNow;
                oMultimediaFile.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMultimediaFile(string multimediaFileId, int systemUserId)
        {
            try
            {
                var oMultimediaFile = (from a in ctx.MultimediaFile
                            where a.MultimediaFileId == multimediaFileId
                            select a).FirstOrDefault();

                if (oMultimediaFile == null)
                    return false;

                oMultimediaFile.UpdateUserId = systemUserId;
                oMultimediaFile.UpdateDate = DateTime.UtcNow;
                oMultimediaFile.IsDeleted = (int)Enumeratores.SiNo.Si;

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
