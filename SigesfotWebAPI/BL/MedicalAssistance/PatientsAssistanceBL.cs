﻿using BE.Common;
using BE.MedicalAssistance;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL.MedicalAssistance
{
    public class PatientsAssistanceBL
    {
        private DatabaseContext ctx = new DatabaseContext();

        public BoardPatient GetAllPatientsAssistance(BoardPatient data)
        {
            try
            {
                //Thread.Sleep(20000);
                var isDeleted = (int)Enumeratores.SiNo.No;
                int groupDocTypeId = (int)Enumeratores.DataHierarchy.TypeDoc;
                int genderId = (int)Enumeratores.Parameters.Gender;
                int skip = (data.Index - 1) * data.Take;

                string filterPacient = string.IsNullOrWhiteSpace(data.Patient) ? "" : data.Patient;
                var startDate = data.StartDate.ToString() == "" ? DateTime.Parse("01/01/2000") : data.StartDate;
                var endDate = data.EndDate.ToString() == "" ? DateTime.Parse("01/01/2020") : data.EndDate;

                var preList = (from a in ctx.Service
                            join b in ctx.Person on a.v_PersonId equals b.v_PersonId
                            join c in ctx.DataHierarchy on new { a = b.i_DocTypeId.Value, b = groupDocTypeId } equals new { a = c.i_ItemId, b = c.i_GroupId }
                            join d in ctx.SystemParameter on new { a = b.i_SexTypeId.Value, b = genderId } equals new { a = d.i_ParameterId, b = d.i_GroupId }
                            join e in ctx.Protocol on a.v_ProtocolId equals e.v_ProtocolId
                            join f in ctx.Organization on e.v_CustomerOrganizationId equals f.v_OrganizationId
                            join g in ctx.Location on e.v_CustomerLocationId equals g.v_LocationId
                            join h in ctx.GroupOccupation on e.v_GroupOccupationId equals h.v_GroupOccupationId

                            where a.i_IsDeleted == isDeleted
                                    && (b.v_FirstName.Contains(filterPacient) || b.v_FirstLastName.Contains(filterPacient) || b.v_SecondLastName.Contains(filterPacient) || b.v_DocNumber.Contains(filterPacient))
                                      && (startDate < a.d_ServiceDate && endDate > a.d_ServiceDate)
                               select new Patients
                            {
                                PatientId = a.v_PersonId,
                                PatientFullName = b.v_FirstName + " " + b.v_FirstLastName + " " + b.v_SecondLastName,
                                DocumentType = c.v_Value1,
                                DocumentNumber = b.v_DocNumber,
                                ServiceDate = a.d_ServiceDate.Value,
                                Occupation = b.v_CurrentOccupation,
                                Birthdate = b.d_Birthdate.Value,
                                Gender = d.v_Value1,
                                ProtocolName = e.v_Name,
                                OrganizationLocation = f.v_Name + " " + g.v_Name,
                                Geso = h.v_Name
                            }).ToList();

                var list = (from a in preList
                            select new Patients
                            {
                                PatientId = a.PatientId,
                                PatientFullName = a.PatientFullName,
                                DocumentType = a.DocumentType,
                                DocumentNumber = a.DocumentNumber,
                                ServiceDate = a.ServiceDate,
                                Occupation = a.Occupation,
                                Birthdate = a.Birthdate,
                                Age = Utils.GetAge(a.Birthdate.Value),
                                Gender = a.Gender,
                                ProtocolName =a.ProtocolName,
                                OrganizationLocation = a.OrganizationLocation,
                                Geso = a.Geso
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

        public int Test()
        {
            try
            {
                Thread.Sleep(20000);
                return 20;
                //var preList = (from a in ctx.Diseases
                //               select new Patients
                //               {
                //                   PatientId = a.v_DiseasesId,

                //               }).ToList();

                //int totalRecords = preList.Count;

                //return totalRecords;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Test2()
        {
            try
            {
                Thread.Sleep(5000);
                return 20;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Schedule> GetSchedule()
        {
            try
            {
                var isDeleted = (int)Enumeratores.SiNo.No;
                var list = (from a in ctx.Service
                               join b in ctx.Person on a.v_PersonId equals b.v_PersonId                               
                               where a.i_IsDeleted == isDeleted                                     
                               select new Schedule
                               {
                                   PacientId = a.v_PersonId,
                                   Pacient = b.v_FirstName + " " + b.v_FirstLastName + " " + b.v_SecondLastName,                               
                                   ServiceDate = a.d_ServiceDate.Value                               
                               }).ToList();               

                return list;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<TopDiagnostic> TopDiagnostic()
        {
            try
            {
                //Thread.Sleep(5000);
                var isDeleted = (int)Enumeratores.SiNo.No;
                var list = (from a in ctx.DiagnosticRepository
                            join b in ctx.Diseases on a.v_DiseasesId equals b.v_DiseasesId
                            where a.i_IsDeleted == isDeleted
                            select new 
                            {
                                DiagnosticId = a.v_DiseasesId,
                                Diagnostic = b.v_Name,                               
                            }).ToList();

                var group = list
                            .GroupBy(n => n.Diagnostic)
                            .Select(n => new TopDiagnostic
                            {
                                name = n.Key,
                                y = n.Count()
                            }).OrderByDescending(n => n.y).Take(10);

                return group.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
