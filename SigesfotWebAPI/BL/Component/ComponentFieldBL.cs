using BE.Common;
using BE.Component;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Component
{
    public class ComponentFieldBL
    {
        private DatabaseContext ctx = new DatabaseContext();
        #region CRUD
        public ComponentFieldBE GetComponentField (string componentFieldId)
        {
            try
            {
                var objEntity = (from a in ctx.ComponentField
                                 where a.ComponentFieldId == componentFieldId
                                 select a).FirstOrDefault();
                return objEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ComponentFieldBE> GetAllComponentField()
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var objEntity = (from a in ctx.ComponentField
                                 where a.IsDeleted == isDeleted
                                 select new ComponentFieldBE()
                                 {
                                     ComponentFieldId = a.ComponentFieldId,
                                     TextLabel = a.TextLabel,
                                     LabelWidth = a.LabelWidth,
                                     abbreviation = a.abbreviation,
                                     DefaultText = a.DefaultText,
                                     ControlId = a.ControlId,
                                     GroupId = a.GroupId,
                                     ItemId = a.ItemId,
                                     WidthControl = a.WidthControl,
                                     HeightControl = a.HeightControl,
                                     MaxLenght = a.MaxLenght,
                                     IsRequired = a.IsRequired,
                                     IsCalculate = a.IsCalculate,
                                     Formula = a.Formula,
                                     Order = a.Order,
                                     MeasurementUnitId = a.MeasurementUnitId,
                                     ValidateValue1 = a.ValidateValue1,
                                     ValidateValue2 = a.ValidateValue2,
                                     Column = a.Column,
                                     defaultIndex = a.defaultIndex,
                                     IsDeleted = a.IsDeleted,
                                     InsertUserId = a.InsertUserId,
                                     InsertDate = a.InsertDate,
                                     UpdateUserId = a.UpdateUserId,
                                     UpdateDate = a.UpdateDate,
                                     NroDecimales = a.NroDecimales,
                                     ReadOnly = a.ReadOnly,
                                     Enabled = a.Enabled,
                                 }).ToList();
                return objEntity;
            }

            
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddComponentField(ComponentFieldBE componentField, int systemUserId)
        {
            try
            {
                ComponentFieldBE oComponentField = new ComponentFieldBE()
                {
                    ComponentFieldId = BE.Utils.GetPrimaryKey(1, 18, "MF"),
                    TextLabel = componentField.TextLabel,
                    LabelWidth = componentField.LabelWidth,
                    abbreviation = componentField.abbreviation,
                    DefaultText = componentField.DefaultText,
                    ControlId = componentField.ControlId,
                    GroupId = componentField.GroupId,
                    ItemId = componentField.ItemId,
                    WidthControl = componentField.WidthControl,
                    HeightControl = componentField.HeightControl,
                    MaxLenght = componentField.MaxLenght,
                    IsRequired = componentField.IsRequired,
                    IsCalculate = componentField.IsCalculate,
                    Formula = componentField.Formula,
                    Order = componentField.Order,
                    MeasurementUnitId = componentField.MeasurementUnitId,
                    ValidateValue1 = componentField.ValidateValue1,
                    ValidateValue2 = componentField.ValidateValue2,
                    Column = componentField.Column,
                    defaultIndex = componentField.defaultIndex,
                    NroDecimales = componentField.NroDecimales,
                    ReadOnly = componentField.ReadOnly,
                    Enabled = componentField.Enabled,

                    //Auditoria
                    IsDeleted = (int)Enumeratores.SiNo.No,
                    InsertDate = DateTime.UtcNow,
                    InsertUserId = systemUserId,

                };

                ctx.ComponentField.Add(oComponentField);

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateComponentField(ComponentFieldBE componentField, int systemUserId)
        {
            try
            {
                var oComponentField = (from a in ctx.ComponentField
                                       where a.ComponentFieldId == componentField.ComponentFieldId
                                       select a).FirstOrDefault();

                if (oComponentField == null)
                    return false;

                oComponentField.TextLabel = componentField.TextLabel;
                oComponentField.LabelWidth = componentField.LabelWidth;
                oComponentField.abbreviation = componentField.abbreviation;
                oComponentField.DefaultText = componentField.DefaultText;
                oComponentField.ControlId = componentField.ControlId;
                oComponentField.GroupId = componentField.GroupId;
                oComponentField.ItemId = componentField.ItemId;
                oComponentField.WidthControl = componentField.WidthControl;
                oComponentField.HeightControl = componentField.HeightControl;
                oComponentField.MaxLenght = componentField.MaxLenght;
                oComponentField.IsRequired = componentField.IsRequired;
                oComponentField.IsCalculate = componentField.IsCalculate;
                oComponentField.Formula = componentField.Formula;
                oComponentField.Order = componentField.Order;
                oComponentField.MeasurementUnitId = componentField.MeasurementUnitId;
                oComponentField.ValidateValue1 = componentField.ValidateValue1;
                componentField.ValidateValue2 = componentField.ValidateValue2;
                oComponentField.Column = componentField.Column;
                oComponentField.defaultIndex = componentField.defaultIndex;
                oComponentField.NroDecimales = componentField.NroDecimales;
                oComponentField.ReadOnly = componentField.ReadOnly;
                oComponentField.Enabled = componentField.Enabled;


                oComponentField.UpdateDate = DateTime.UtcNow;
                oComponentField.UpdateUserId = systemUserId;

                int rows = ctx.SaveChanges();

                return rows > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteComponentField (string componentFieldId ,int systemUserId)
        {
            try
            {
                var oComponentField = (from a in ctx.ComponentField
                                       where a.ComponentFieldId == componentFieldId
                                       select a).FirstOrDefault();

                if (oComponentField == null)
                    return false;

                oComponentField.UpdateUserId = systemUserId;
                oComponentField.UpdateDate = DateTime.UtcNow;
                oComponentField.IsDeleted = (int)Enumeratores.SiNo.Si;

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
