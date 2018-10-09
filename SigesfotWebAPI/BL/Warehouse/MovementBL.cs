using BE.Common;
using BE.Warehouse;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Warehouse
{
    public class MovementBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        public MovementBE GetMovement(string movementId)
        {
            try
            {
                var objEntity = (from a in ctx.Movement
                                 where a.v_MovementId == movementId
                                 select a).FirstOrDefault();

                return objEntity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MovementBE> GetAllMovement()
        {
            try
            {
                var objEntity = (from a in ctx.Movement
                                 
                                 select new MovementBE()
                                 {
                                     v_MovementId = a.v_MovementId,
                                     v_WarehouseId = a.v_WarehouseId,
                                     v_SupplierId = a.v_SupplierId,
                                     i_ProcessTypeId = a.i_ProcessTypeId,
                                     v_ParentMovementId = a.v_ParentMovementId,
                                     v_Motive = a.v_Motive,
                                     i_MotiveTypeId = a.i_MotiveTypeId,
                                     d_Date = a.d_Date,
                                     r_TotalQuantity = a.r_TotalQuantity,
                                     i_MovementTypeId = a.i_MovementTypeId,
                                     i_RequireRemoteProcess = a.i_RequireRemoteProcess,
                                     v_RemoteWarehouseId = a.v_RemoteWarehouseId,
                                     i_CurrencyId = a.i_CurrencyId,
                                     r_ExchangeRate = a.r_ExchangeRate,
                                     v_ReferenceDocument = a.v_ReferenceDocument,
                                     i_CostCenterId = a.i_CostCenterId,
                                     v_Observations = a.v_Observations,
                                     i_IsLocallyProcessed = a.i_IsLocallyProcessed,
                                     i_IsRemoteProcessed = a.i_IsRemoteProcessed,
                                     i_InsertUserId = a.i_InsertUserId,
                                     d_UpdateDate = a.d_UpdateDate,
                                     i_UpdateUserId = a.i_UpdateUserId,
                                     i_UpdateNodeId = a.i_UpdateNodeId
                                 }).ToList();

                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddMovement(MovementBE movement, int systemUserId)
        {
            try
            {
                MovementBE oMovementBE = new MovementBE()
                {
                    v_MovementId = new Utils().GetPrimaryKey(1, 3, "MM"),
                    v_WarehouseId = movement.v_WarehouseId,
                    v_SupplierId = movement.v_SupplierId,
                    i_ProcessTypeId = movement.i_ProcessTypeId,
                    v_ParentMovementId = movement.v_ParentMovementId,
                    v_Motive = movement.v_Motive,
                    i_MotiveTypeId = movement.i_MotiveTypeId,
                    d_Date = movement.d_Date,
                    r_TotalQuantity = movement.r_TotalQuantity,
                    i_MovementTypeId = movement.i_MovementTypeId,
                    i_RequireRemoteProcess = movement.i_RequireRemoteProcess,
                    v_RemoteWarehouseId = movement.v_RemoteWarehouseId,
                    i_CurrencyId = movement.i_CurrencyId,
                    r_ExchangeRate = movement.r_ExchangeRate,
                    v_ReferenceDocument = movement.v_ReferenceDocument,
                    i_CostCenterId = movement.i_CostCenterId,
                    v_Observations = movement.v_Observations,
                    i_IsLocallyProcessed = movement.i_IsLocallyProcessed,
                    i_IsRemoteProcessed = movement.i_IsRemoteProcessed,

                    //Auditoria
                    i_InsertUserId = systemUserId,
                };

                ctx.Movement.Add(oMovementBE);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMovement(MovementBE movement, int systemUserId)
        {
            try
            {
                var oMovement = (from a in ctx.Movement
                                 where a.v_MovementId == movement.v_MovementId
                                 select a).FirstOrDefault();

                if (oMovement == null)
                    return false;

                oMovement.v_WarehouseId = movement.v_WarehouseId;
                oMovement.v_SupplierId = movement.v_SupplierId;
                oMovement.i_ProcessTypeId = movement.i_ProcessTypeId;
                oMovement.v_ParentMovementId = movement.v_ParentMovementId;
                oMovement.v_Motive = movement.v_Motive;
                oMovement.i_MotiveTypeId = movement.i_MotiveTypeId;
                oMovement.d_Date = movement.d_Date;
                oMovement.r_TotalQuantity = movement.r_TotalQuantity;
                oMovement.i_MovementTypeId = movement.i_MovementTypeId;
                oMovement.i_RequireRemoteProcess = movement.i_RequireRemoteProcess;
                oMovement.v_RemoteWarehouseId = movement.v_RemoteWarehouseId;
                oMovement.i_CurrencyId = movement.i_CurrencyId;
                oMovement.r_ExchangeRate = movement.r_ExchangeRate;
                oMovement.v_ReferenceDocument = movement.v_ReferenceDocument;
                oMovement.i_CostCenterId = movement.i_CostCenterId;
                oMovement.v_Observations = movement.v_Observations;
                oMovement.i_IsLocallyProcessed = movement.i_IsLocallyProcessed;
                oMovement.i_IsRemoteProcessed = movement.i_IsRemoteProcessed;

                //Auditoria

                oMovement.d_UpdateDate = DateTime.UtcNow;
                oMovement.i_UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMovement(string movementId, int systemUserId)
        {
            try
            {
                var oMovement = (from a in ctx.Movement
                                 where a.v_MovementId == movementId
                                 select a).FirstOrDefault();

                if (oMovement == null)
                    return false;

                oMovement.i_UpdateUserId = systemUserId;
                oMovement.d_UpdateDate = DateTime.UtcNow;

                int rows = ctx.SaveChanges();

                return rows > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Logic

        public BoardMovement GetMovementsListByWarehouseId(BoardMovement data)
        {
            try
            {
                int skip = (data.Index - 1) * data.Take;
                var warehouseId = data.WarehouseId == null ? "-1" : data.WarehouseId;
                var movementType = data.MovementType.ToString() == "" ? "-1" : data.MovementType.ToString();
                var startDate = data.StartDate.ToString() == "" ? DateTime.Parse("01/01/2000") : data.StartDate;
                var endDate = data.EndDate.ToString() == "" ? DateTime.Parse("01/01/2020") : data.EndDate;
                #region Query
                var list = (from A in ctx.Movement
                           
                        join J1 in ctx.SystemUser on new { i_InsertUserId = A.i_InsertUserId.Value }
                                                equals new { i_InsertUserId = J1.i_SystemUserId.Value } into J1_join
                        from J1 in J1_join.DefaultIfEmpty()

                        join J2 in ctx.SystemUser on new { i_UpdateUserId = A.i_UpdateUserId.Value }
                                                equals new { i_UpdateUserId = J2.i_SystemUserId.Value } into J2_join
                        from J2 in J2_join.DefaultIfEmpty()

                        join J3 in ctx.Node on new { i_UpdateNodeId = A.i_UpdateNodeId.Value }
                            equals new { i_UpdateNodeId = J3.i_NodeId.Value } into J3_join
                        from J3 in J3_join.DefaultIfEmpty()

                        join J5 in ctx.SystemParameter on new { a = 111, b = A.i_IsLocallyProcessed.Value }
                                                            equals new { a = J5.i_GroupId, b = J5.i_ParameterId }

                        join J6 in ctx.Supplier on new { a = A.v_SupplierId } equals new { a = J6.v_SupplierId } into J6_join
                        from J6 in J6_join.DefaultIfEmpty()


                        join J7 in ctx.SystemParameter on new { a = 109, b = A.i_MovementTypeId.Value }
                                                            equals new { a = J7.i_GroupId, b = J7.i_ParameterId }

                        join J8 in ctx.SystemParameter on new { a = 110, b = A.i_MotiveTypeId.Value }
                                                            equals new { a = J8.i_GroupId, b = J8.i_ParameterId }

                        where (warehouseId == "-1" || A.v_WarehouseId == warehouseId) && (movementType == "-1" || A.i_MovementTypeId.ToString() == movementType)
                            && (startDate < A.d_Date && endDate > A.d_Date)
                            

                        orderby A.d_Date descending

                        select new Movements
                        {
                            MovementId = A.v_MovementId,
                            MovementTypeId = J7.v_Value1,
                            Date = A.d_Date,
                            ProcessTypeId = J5.v_Value1,
                            MotiveTypeId = J8.v_Value1,
                            Supplier = J6.v_Name
                            
                        }).ToList();

               

                int totalRecords = list.Count;

                if (data.Take > 0)
                    list = list.Skip(skip).Take(data.Take).ToList();

                data.TotalRecords = totalRecords;
                data.List = list;

                return data;
            }
            catch (Exception ex)
            {               
                return null;
            }
        }
        #endregion
        //Sede
        public List<KeyValueDTO> GetJoinOrganizationAndLocationNotInRestricted(int nodeId)
        {
            //mon.IsActive = true;
            try
            {

                var query = (from n in ctx.Node
                             join a in ctx.NodeOrganizationLocationProfile on n.i_NodeId.Value equals a.i_NodeId.Value
                             join J1 in ctx.NodeOrganizationProfile on new { a = a.i_NodeId.Value, b = a.v_OrganizationId }
                                                      equals new { a = J1.i_NodeId.Value, b = J1.v_OrganizationId } into j1_join
                             from J1 in j1_join.DefaultIfEmpty()
                             join J2 in ctx.NodeOrganizationLocationWarehouseProfile on new { a = a.i_NodeId.Value, b = a.v_OrganizationId, c = a.v_LocationId }
                                                      equals new { a = J2.i_NodeId.Value, b = J2.v_OrganizationId, c = J2.v_LocationId } into j2_join
                             from J2 in j2_join.DefaultIfEmpty()
                             join b in ctx.Organization on J1.v_OrganizationId equals b.v_OrganizationId
                             join c in ctx.Location on a.v_LocationId equals c.v_LocationId
                             where n.i_NodeId.Value == nodeId &&
                                   n.i_IsDeleted == 0 &&
                                   a.i_IsDeleted == 0 &&
                                   J2.i_IsDeleted == 0
                             select new RestrictedWarehouseProfileListBE
                             {
                                 OrganizationName = b.v_Name,
                                 LocationName = c.v_Name,
                                 LocationId = c.v_LocationId,
                                 OrganizationId = b.v_OrganizationId,
                                 NodeId = J1.i_NodeId.Value
                             }
                          ).Distinct();

                var q = from a in query.ToList()
                        select new KeyValueDTO
                        {
                            Id = string.Format("{0}|{1}|{2}", a.NodeId, a.OrganizationId, a.LocationId),
                            Value = string.Format("Empresa: {0} / Sede: {1} ",
                                     a.OrganizationName,
                                     a.LocationName)
                        };



                List<KeyValueDTO> WarehouseList = q.OrderBy(p => p.Value).ToList();
                return WarehouseList;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        //Almacen
        public List<KeyValueDTO> GetWarehouseNotInRestricted( int nodeId, string OrganizationId, string LocationId)
        {
            //Devart.Data.PostgreSql.PgSqlMonitor mon = new Devart.Data.PostgreSql.PgSqlMonitor();

            //mon.IsActive = true;

            try
            {

                var query = (from a in ctx.NodeOrganizationLocationWarehouseProfile
                             join b in ctx.Warehouse on a.v_WarehouseId equals b.v_WarehouseId
                             where a.i_NodeId == nodeId &&
                                   a.v_OrganizationId == OrganizationId &&
                                   a.v_LocationId == LocationId &&
                                   a.i_IsDeleted == 0
                             select new KeyValueDTO
                             {
                                 Id = a.v_WarehouseId,
                                 Value = b.v_Name
                             });

                // Excluir almacenes restringidos
                var queryNotIn = (from a in query.ToList()
                                  where !(from r in ctx.RestrictedWarehouseProfile
                                          where r.i_IsDeleted == 0
                                          select r.v_WarehouseId).Contains(a.Id)
                                  select a);

                List<KeyValueDTO> WarehouseList = queryNotIn.OrderBy(p => p.Value).ToList();

                return WarehouseList;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion
    }
}
