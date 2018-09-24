using BE.Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Common
{
    public class PacientBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        #region CRUD



        #endregion

        #region Bussiness Logic
        public BoardPacient GetAllPacients(BoardPacient data)
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                int groupDocTypeId = (int)Enumeratores.Parameters.TypeDocument;
                int skip = (data.Index - 1) * data.Take;

                //filters
                string filterPacient = string.IsNullOrWhiteSpace(data.Pacient) ? "" : data.Pacient;
                string filterDocNumber = string.IsNullOrWhiteSpace(data.DocNumber) ? "" : data.DocNumber;

                var list = (from a in ctx.Pacient
                            join b in ctx.Person on a.v_PersonId equals b.v_PersonId
                            join c in ctx.SystemParameter on new { a = b.i_DocTypeId.Value, b = groupDocTypeId } equals new { a = c.i_ParameterId, b = c.i_GroupId }
                            where (data.Pacient.Contains(filterPacient))
                                && (data.DocNumber == filterDocNumber)
                                && (data.DocTypeId == -1 || b.v_DocNumber == filterDocNumber)
                                && (a.i_IsDeleted == isDeleted)
                            select new Pacients
                            {
                                PacientFullName = b.v_FirstName + " " + b.v_FirstLastName + " " + b.v_SecondLastName,
                                DocType = c.v_Value1,
                                DocNumber = b.v_DocNumber,
                                TelephoneNumber = b.v_TelephoneNumber

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
                throw;
            }
        }
        #endregion
    }
}
