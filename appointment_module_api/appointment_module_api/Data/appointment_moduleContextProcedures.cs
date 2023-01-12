﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using appointment_module_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace appointment_module_api.Data
{
    public partial class appointment_moduleContext
    {
        private Iappointment_moduleContextProcedures _procedures;

        public virtual Iappointment_moduleContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new appointment_moduleContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public Iappointment_moduleContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<get_all_servicesResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<get_business_for_adminResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<get_times_for_serviceResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<selecting_business_servicesResult>().HasNoKey().ToView(null);
        }
    }

    public partial class appointment_moduleContextProcedures : Iappointment_moduleContextProcedures
    {
        private readonly appointment_moduleContext _context;

        public appointment_moduleContextProcedures(appointment_moduleContext context)
        {
            _context = context;
        }

        public virtual async Task<int> create_appointmentAsync(string firstName, string lastName, string startTime, string endTime, int? serviceId, int? confirmed, string phoneNumber, string email, DateTime? apptDate, int? lengthMinutes, int? businessId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "firstName",
                    Size = 100,
                    Value = firstName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "lastName",
                    Size = 100,
                    Value = lastName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "startTime",
                    Size = 20,
                    Value = startTime ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "endTime",
                    Size = 2,
                    Value = endTime ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "serviceId",
                    Value = serviceId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "confirmed",
                    Value = confirmed ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "phoneNumber",
                    Size = 20,
                    Value = phoneNumber ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "email",
                    Size = 100,
                    Value = email ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "apptDate",
                    Value = apptDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "lengthMinutes",
                    Value = lengthMinutes ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "businessId",
                    Value = businessId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[create_appointment] @firstName, @lastName, @startTime, @endTime, @serviceId, @confirmed, @phoneNumber, @email, @apptDate, @lengthMinutes, @businessId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<get_all_servicesResult>> get_all_servicesAsync(int? serviceId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "serviceId",
                    Value = serviceId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<get_all_servicesResult>("EXEC @returnValue = [dbo].[get_all_services] @serviceId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<get_business_for_adminResult>> get_business_for_adminAsync(string admin, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "admin",
                    Size = 200,
                    Value = admin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<get_business_for_adminResult>("EXEC @returnValue = [dbo].[get_business_for_admin] @admin", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<get_times_for_serviceResult>> get_times_for_serviceAsync(DateTime? apptDate, int? serviceId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "apptDate",
                    Value = apptDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "serviceId",
                    Value = serviceId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<get_times_for_serviceResult>("EXEC @returnValue = [dbo].[get_times_for_service] @apptDate, @serviceId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<selecting_business_servicesResult>> selecting_business_servicesAsync(int? businessIdParam, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "businessIdParam",
                    Value = businessIdParam ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<selecting_business_servicesResult>("EXEC @returnValue = [dbo].[selecting_business_services] @businessIdParam", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
