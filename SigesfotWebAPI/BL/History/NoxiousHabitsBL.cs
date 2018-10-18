using BE.Common;
using BE.History;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.History
{
    public class NoxiousHabitsBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD
        //public NoxiousHabitsBE GetNoxiousHabits(string noxiousHabitsId)
        //{
        //    try
        //    {
        //        var objEntity = (from a in ctx.NoxiousHabits
        //                         where a.NoxiousHabitsId == noxiousHabitsId
        //                         select a).FirstOrDefault();

        //        return objEntity;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public List<NoxiousHabitsBE> GetAllNoxiousHabits()
        //{
        //    try
        //    {
        //        var isDelete = (int)Enumeratores.SiNo.No;
        //        var objEntity = (from a in ctx.NoxiousHabits
        //                         where a.IsDeleted == isDelete
        //                         select new NoxiousHabitsBE()
        //                         {
        //                             NoxiousHabitsId = a.NoxiousHabitsId,
        //                             PersonId = a.PersonId,
        //                             TypeHabitsId = a.TypeHabitsId,
        //                             Frequency = a.Frequency,
        //                             Comment = a.Comment,
        //                             DescriptionHabit = a.DescriptionHabit,
        //                             DescriptionQuantity = a.DescriptionQuantity,
        //                             IsDeleted = a.IsDeleted,
        //                             InsertUserId = a.InsertUserId,
        //                             InsertDate = a.InsertDate,
        //                             UpdateDate = a.UpdateDate,
        //                             UpdateUserId = a.UpdateUserId
        //                         }).ToList();

        //        return objEntity;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public bool AddNoxiousHabits(NoxiousHabitsBE noxiousHabits, int systemUserId)
        //{
        //    try
        //    {
        //        NoxiousHabitsBE oNoxiousHabitsBE = new NoxiousHabitsBE()
        //        {
        //            NoxiousHabitsId =  new Utils().GetPrimaryKey(1, 41, "NX"),
        //            PersonId = noxiousHabits.PersonId,
        //            TypeHabitsId = noxiousHabits.TypeHabitsId,
        //            Frequency = noxiousHabits.Frequency,
        //            Comment = noxiousHabits.Comment,
        //            DescriptionHabit = noxiousHabits.DescriptionHabit,
        //            DescriptionQuantity = noxiousHabits.DescriptionQuantity,

        //            //Auditoria
        //            IsDeleted = (int)Enumeratores.SiNo.No,
        //            InsertDate = DateTime.UtcNow,
        //            InsertUserId = systemUserId,
        //        };

        //        ctx.NoxiousHabits.Add(oNoxiousHabitsBE);

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateNoxiousHabits(NoxiousHabitsBE noxiousHabits, int systemUserId)
        //{
        //    try
        //    {
        //        var oNoxiousHabits = (from a in ctx.NoxiousHabits
        //                              where a.NoxiousHabitsId == noxiousHabits.NoxiousHabitsId
        //                              select a).FirstOrDefault();

        //        if (oNoxiousHabits == null)
        //            return false;

        //        oNoxiousHabits.PersonId = noxiousHabits.PersonId;
        //        oNoxiousHabits.TypeHabitsId = noxiousHabits.TypeHabitsId;
        //        oNoxiousHabits.Frequency = noxiousHabits.Frequency;
        //        oNoxiousHabits.Comment = noxiousHabits.Comment;
        //        oNoxiousHabits.DescriptionHabit = noxiousHabits.DescriptionHabit;
        //        oNoxiousHabits.DescriptionQuantity = noxiousHabits.DescriptionQuantity;

        //        //Auditoria

        //        oNoxiousHabits.UpdateDate = DateTime.UtcNow;
        //        oNoxiousHabits.UpdateUserId = systemUserId;

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteNoxiousHabits(string noxiousHabitsId, int systemUserId)
        //{
        //    try
        //    {
        //        var oNoxiousHabits = (from a in ctx.NoxiousHabits
        //                              where a.NoxiousHabitsId == noxiousHabitsId
        //                              select a).FirstOrDefault();

        //        if (oNoxiousHabits == null)
        //            return false;

        //        oNoxiousHabits.UpdateUserId = systemUserId;
        //        oNoxiousHabits.UpdateDate = DateTime.UtcNow;
        //        oNoxiousHabits.IsDeleted = (int)Enumeratores.SiNo.Si;

        //        int rows = ctx.SaveChanges();

        //        return rows > 0;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        #endregion
    }
}
