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
    public class ProtocolBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public ProtocolBE GetProtocol(string protocolId)
        {
            try
            {
                var objEntity = (from a in ctx.Protocol
                                 where a.ProtocolId == protocolId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ProtocolBE> GetAllProtocol()
        {
            try
            {
                var isDelete = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.Protocol
                                 where a.IsDeleted == isDelete
                                 select new ProtocolBE()
                                 {
                                     ProtocolId = a.ProtocolId,
                                     Name = a.Name,
                                     EmployerOrganizationId = a.EmployerOrganizationId,
                                     EmployerLocationId = a.EmployerLocationId,
                                     EsoTypeId = a.EsoTypeId,
                                     GroupOccupationId = a.GroupOccupationId,
                                     CustomerOrganizationId = a.CustomerOrganizationId,
                                     CustomerLocationId = a.CustomerLocationId,
                                     NombreVendedor = a.NombreVendedor,
                                     WorkingOrganizationId = a.WorkingOrganizationId,
                                     WorkingLocationId = a.WorkingLocationId,
                                     CostCenter = a.CostCenter,
                                     MasterServiceTypeId = a.MasterServiceTypeId,
                                     MasterServiceId = a.MasterServiceId,
                                     HasVigency = a.HasVigency,
                                     ValidInDays = a.ValidInDays,
                                     IsActive = a.IsActive,
                                     AseguradoraOrganizationId = a.AseguradoraOrganizationId,
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

        public bool AddProtocol(ProtocolBE protocol, int systemUserId)
        {
            try
            {
                ProtocolBE oProtocolBE = new ProtocolBE()
                {
                    ProtocolId =  new Common.PersonBL().GetPrimaryKey(1, 20, "PR"),
                    Name = protocol.Name,
                    EmployerOrganizationId = protocol.EmployerOrganizationId,
                    EmployerLocationId = protocol.EmployerLocationId,
                    EsoTypeId = protocol.EsoTypeId,
                    GroupOccupationId = protocol.GroupOccupationId,
                    CustomerOrganizationId = protocol.CustomerOrganizationId,
                    CustomerLocationId = protocol.CustomerLocationId,
                    NombreVendedor = protocol.NombreVendedor,
                    WorkingOrganizationId = protocol.WorkingOrganizationId,
                    WorkingLocationId = protocol.WorkingLocationId,
                    CostCenter = protocol.CostCenter,
                    MasterServiceTypeId = protocol.MasterServiceTypeId,
                    MasterServiceId = protocol.MasterServiceId,
                    HasVigency = protocol.HasVigency,
                    ValidInDays = protocol.ValidInDays,
                    IsActive = protocol.IsActive,
                    AseguradoraOrganizationId = protocol.AseguradoraOrganizationId,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,
                };

                ctx.Protocol.Add(oProtocolBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProtocol(ProtocolBE protocol, int systemUserId)
        {
            try
            {
                var oProtocol = (from a in ctx.Protocol
                                 where a.ProtocolId == protocol.ProtocolId
                                 select a).FirstOrDefault();

                if (oProtocol == null)
                    return false;

                oProtocol.Name = protocol.Name;
                oProtocol.EmployerOrganizationId = protocol.EmployerOrganizationId;
                oProtocol.EmployerLocationId = protocol.EmployerLocationId;
                oProtocol.EsoTypeId = protocol.EsoTypeId;
                oProtocol.GroupOccupationId = protocol.GroupOccupationId;
                oProtocol.CustomerOrganizationId = protocol.CustomerOrganizationId;
                oProtocol.CustomerLocationId = protocol.CustomerLocationId;
                oProtocol.NombreVendedor = protocol.NombreVendedor;
                oProtocol.WorkingOrganizationId = protocol.WorkingOrganizationId;
                oProtocol.WorkingLocationId = protocol.WorkingLocationId;
                oProtocol.CostCenter = protocol.CostCenter;
                oProtocol.MasterServiceTypeId = protocol.MasterServiceTypeId;
                oProtocol.MasterServiceId = protocol.MasterServiceId;
                oProtocol.HasVigency = protocol.HasVigency;
                oProtocol.ValidInDays = protocol.ValidInDays;
                oProtocol.IsActive = protocol.IsActive;
                oProtocol.AseguradoraOrganizationId = protocol.AseguradoraOrganizationId;

                //Auditoria

                oProtocol.UpdateDate = DateTime.UtcNow;
                oProtocol.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProtocol(string protocolId, int systemUserId)
        {
            try
            {
                var oProtocol = (from a in ctx.Protocol
                            where a.ProtocolId == protocolId
                            select a).FirstOrDefault();

                if (oProtocol == null)
                    return false;

                oProtocol.UpdateUserId = systemUserId;
                oProtocol.UpdateDate = DateTime.UtcNow;
                oProtocol.IsDeleted = (int)Enumeratores.SiNo.Si;

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
