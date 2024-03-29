﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using appointment_module_api.Models;

namespace appointment_module_api.Data
{
    public partial class appointment_moduleContext : DbContext
    {
        public appointment_moduleContext()
        {
        }

        public appointment_moduleContext(DbContextOptions<appointment_moduleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<BusinessHours> BusinessHours { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SAADPC;Initial Catalog=appointment_module;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.ApptId)
                    .HasName("PK_Table2");

                entity.ToTable("appointments");

                entity.Property(e => e.ApptId).HasColumnName("appt_id");

                entity.Property(e => e.ApptDate)
                    .HasColumnType("date")
                    .HasColumnName("appt_date");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.Confirmed).HasColumnName("confirmed");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("end_time");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.LengthMinutes).HasColumnName("length_minutes");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("start_time");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("business");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.Admin)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("admin");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("business_name");

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .HasColumnName("icon");
            });

            modelBuilder.Entity<BusinessHours>(entity =>
            {
                entity.HasKey(e => e.BusinessHourId);

                entity.ToTable("business_hours");

                entity.Property(e => e.BusinessHourId).HasColumnName("business_hour_id");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.Day)
                    .HasMaxLength(50)
                    .HasColumnName("day");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("end_time");

                entity.Property(e => e.FullInt).HasColumnName("fullInt");

                entity.Property(e => e.HalfInt).HasColumnName("halfInt");

                entity.Property(e => e.QuarterInt).HasColumnName("quarterInt");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("start_time");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK_Table2_1");

                entity.ToTable("services");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.LengthMinutes).HasColumnName("length_minutes");

                entity.Property(e => e.ServiceCategory)
                    .HasMaxLength(150)
                    .HasColumnName("service_category");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("service_name");
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}