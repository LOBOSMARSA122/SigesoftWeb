using BE.Common;
using BE.Protocol;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Protocol
{
    public class ProtocolComponentBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ProtocolComponentBE GetProtocolComponent(string protocolComponentId)
        {
            try
            {
                var objEntity = (from a in ctx.ProtocolComponent
                                 where a.ProtocolComponentId == protocolComponentId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ProtocolComponentBE> GetAllProtocolComponent()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ProtocolComponent
                                 where a.IsDeleted == isDelete
                                 select new ProtocolComponentBE()
                                 {
                                     ProtocolComponentId = a.ProtocolComponentId,
                                     ProtocolId = a.ProtocolId,
                                     ComponentId = a.ComponentId,
                                     Price = a.Price,
                                     OperatorId = a.OperatorId,
                                     Age = a.Age,
                                     GenderId = a.GenderId,
                                     GrupoEtarioId = a.GrupoEtarioId,
                                     IsConditionalId = a.IsConditionalId,
                                     IsConditionalIMC = a.IsConditionalIMC,
                                     Imc = a.Imc,
                                     IsAdditional = a.IsAdditional,
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

        public bool AddProtocolComponent(ProtocolComponentBE protocolComponent, int systemUserId)
        {
            try
            {
                ProtocolComponentBE oProtocolComponentBE = new ProtocolComponentBE()
                {
                    ProtocolComponentId =  new Utils().GetPrimaryKey(1, 21, "PC"),
                    ProtocolId = protocolComponent.ProtocolId,
                    ComponentId = protocolComponent.ComponentId,
                    Price = protocolComponent.Price,
                    OperatorId = protocolComponent.OperatorId,
                    Age = protocolComponent.Age,
                    GenderId = protocolComponent.GenderId,
                    GrupoEtarioId = protocolComponent.GrupoEtarioId,
                    IsConditionalId = protocolComponent.IsConditionalId,
                    IsConditionalIMC = protocolComponent.IsConditionalIMC,
                    Imc = protocolComponent.Imc,
                    IsAdditional = protocolComponent.IsAdditional,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.ProtocolComponent.Add(oProtocolComponentBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProtocolComponent(ProtocolComponentBE protocolComponent, int systemUserId)
        {
            try
            {
                var oProtocolComponent = (from a in ctx.ProtocolComponent
                            where a.ProtocolComponentId == protocolComponent.ProtocolComponentId
                                          select a).FirstOrDefault();

                if (oProtocolComponent == null)
                    return false;

                oProtocolComponent.ProtocolId = protocolComponent.ProtocolId;
                oProtocolComponent.ComponentId = protocolComponent.ComponentId;
                oProtocolComponent.Price = protocolComponent.Price;
                oProtocolComponent.OperatorId = protocolComponent.OperatorId;
                oProtocolComponent.Age = protocolComponent.Age;
                oProtocolComponent.GenderId = protocolComponent.GenderId;
                oProtocolComponent.GrupoEtarioId = protocolComponent.GrupoEtarioId;
                oProtocolComponent.IsConditionalId = protocolComponent.IsConditionalId;
                oProtocolComponent.IsConditionalIMC = protocolComponent.IsConditionalIMC;
                oProtocolComponent.Imc = protocolComponent.Imc;
                oProtocolComponent.IsAdditional = protocolComponent.IsAdditional;

                //Auditoria

                oProtocolComponent.UpdateDate = DateTime.UtcNow;
                oProtocolComponent.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProtocolComponent(string protocolComponentId, int systemUserId)
        {
            try
            {
                var oProtocolComponent = (from a in ctx.ProtocolComponent
                            where a.ProtocolComponentId == protocolComponentId
                            select a).FirstOrDefault();

                if (oProtocolComponent == null)
                    return false;

                oProtocolComponent.UpdateUserId = systemUserId;
                oProtocolComponent.UpdateDate = DateTime.UtcNow;
                oProtocolComponent.IsDeleted = (int)Enumeratores.SiNo.Si;

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
