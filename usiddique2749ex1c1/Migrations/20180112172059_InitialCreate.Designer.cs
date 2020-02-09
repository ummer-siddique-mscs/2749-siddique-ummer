﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using usiddique2749ex1c1.Data;

namespace usiddique2749ex1c1.Migrations
{
    [DbContext(typeof(WideWorldContext))]
    [Migration("20180112172059_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("usiddique2749ex1c1.Models.Cities", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("LastEditedBy");

                    b.Property<long?>("LatestRecordedPopulation");

                    b.Property<int>("StateProvinceId")
                        .HasColumnName("StateProvinceID");

                    b.HasKey("CityId");

                    b.HasIndex("StateProvinceId")
                        .HasName("FK_Application_Cities_StateProvinceID");

                    b.ToTable("Cities","Application");
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.Countries", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CountryID");

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("CountryType")
                        .HasMaxLength(20);

                    b.Property<string>("FormalName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("IsoAlpha3Code")
                        .HasMaxLength(3);

                    b.Property<int?>("IsoNumericCode");

                    b.Property<int>("LastEditedBy");

                    b.Property<long?>("LatestRecordedPopulation");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Subregion")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("CountryId");

                    b.HasIndex("CountryName")
                        .IsUnique()
                        .HasName("UQ_Application_Countries_CountryName");

                    b.HasIndex("FormalName")
                        .IsUnique()
                        .HasName("UQ_Application_Countries_FormalName");

                    b.ToTable("Countries","Application");
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.CustomerCategories", b =>
                {
                    b.Property<int>("CustomerCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CustomerCategoryID");

                    b.Property<string>("CustomerCategoryName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("LastEditedBy");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerCategoryId");

                    b.ToTable("CustomerCategories","Sales");
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CustomerID");

                    b.Property<DateTime>("AccountOpenedDate")
                        .HasColumnType("date");

                    b.Property<int>("AlternateContactPersonId")
                        .HasColumnName("AlternateContactPersonID");

                    b.Property<int>("BillToCustomerId")
                        .HasColumnName("BillToCustomerID");

                    b.Property<int>("BuyingGroupId")
                        .HasColumnName("BuyingGroupID");

                    b.Property<decimal?>("CreditLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerCategoryId")
                        .HasColumnName("CustomerCategoryID");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("DeliveryAddressLine1")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("DeliveryAddressLine2")
                        .HasMaxLength(60);

                    b.Property<int>("DeliveryCityId")
                        .HasColumnName("DeliveryCityID");

                    b.Property<string>("DeliveryLocation")
                        .HasMaxLength(50);

                    b.Property<int>("DeliveryMethodId")
                        .HasColumnName("DeliveryMethodID");

                    b.Property<string>("DeliveryPostalCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("DeliveryRun")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("FaxNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsOnCreditHold")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStatementSent")
                        .HasColumnType("bit");

                    b.Property<int>("LastEditedBy");

                    b.Property<int>("PaymentDays");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PostalAddressLine1")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("PostalAddressLine2")
                        .HasMaxLength(60);

                    b.Property<int>("PostalCityId")
                        .HasColumnName("PostalCityID");

                    b.Property<string>("PostalPostalCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("PrimaryContactPersonId")
                        .HasColumnName("PrimaryContactPersonID");

                    b.Property<string>("RunPosition")
                        .HasMaxLength(5);

                    b.Property<decimal>("StandardDiscountPercentage")
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2(7)");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("WebsiteURL")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("CustomerId");

                    b.HasIndex("AlternateContactPersonId");

                    b.HasIndex("CustomerCategoryId");

                    b.HasIndex("DeliveryCityId");

                    b.HasIndex("PostalCityId");

                    b.HasIndex("PrimaryContactPersonId");

                    b.ToTable("Customers","Sales");
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.People", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PersonID");

                    b.Property<string>("CustomFields");

                    b.Property<string>("EMailAddress")
                        .HasMaxLength(256);

                    b.Property<string>("FaxNumber")
                        .HasMaxLength(20);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("HashedPassword")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsEmployee")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExternalLogonProvider")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPermittedToLogon")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSalesperson")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystemUser")
                        .HasColumnType("bit");

                    b.Property<int>("LastEditedBy");

                    b.Property<string>("LogonName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<string>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PreferredName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserPreferences");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2");

                    b.HasKey("PersonId");

                    b.ToTable("People","Application");
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.RawSqlReturn", b =>
                {
                    b.Property<int>("Id");

                    b.HasKey("Id");

                    b.ToTable("RawSqlReturn");
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.StateProvinces", b =>
                {
                    b.Property<int>("StateProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StateProvinceID");

                    b.Property<int>("CountryId")
                        .HasColumnName("CountryID");

                    b.Property<int>("LastEditedBy");

                    b.Property<long?>("LatestRecordedPopulation");

                    b.Property<string>("SalesTerritory")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("StateProvinceCode")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("StateProvinceName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("StateProvinceId");

                    b.HasIndex("CountryId")
                        .HasName("FK_Application_StateProvinces_CountryID");

                    b.HasIndex("SalesTerritory")
                        .HasName("IX_Application_StateProvinces_SalesTerritory");

                    b.HasIndex("StateProvinceName")
                        .IsUnique()
                        .HasName("UQ_Application_StateProvinces_StateProvinceName");

                    b.ToTable("StateProvinces","Application");
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.Cities", b =>
                {
                    b.HasOne("usiddique2749ex1c1.Models.StateProvinces", "StateProvince")
                        .WithMany("Cities")
                        .HasForeignKey("StateProvinceId")
                        .HasConstraintName("FK_Application_Cities_StateProvinceID_Application_StateProvinces");
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.Customers", b =>
                {
                    b.HasOne("usiddique2749ex1c1.Models.People", "AlternateContactPerson")
                        .WithMany("CustomersAlternateContact")
                        .HasForeignKey("AlternateContactPersonId")
                        .HasConstraintName("FK_AppPeople_SalesCustomers_AlternateContact")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("usiddique2749ex1c1.Models.CustomerCategories", "CustomerCategory")
                        .WithMany()
                        .HasForeignKey("CustomerCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("usiddique2749ex1c1.Models.Cities", "DeliveryCity")
                        .WithMany("CustomersDelivery")
                        .HasForeignKey("DeliveryCityId")
                        .HasConstraintName("FK_Sales_Cities_Sales_Customers_Delivery")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("usiddique2749ex1c1.Models.Cities", "PostalCity")
                        .WithMany("CustomersPostal")
                        .HasForeignKey("PostalCityId")
                        .HasConstraintName("FK_Sales_Cities_Sales_Customers")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("usiddique2749ex1c1.Models.People", "PrimaryContactPerson")
                        .WithMany("CustomersPrimaryContact")
                        .HasForeignKey("PrimaryContactPersonId")
                        .HasConstraintName("FK_AppPeople_SalesCustomers_PrimaryContact")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("usiddique2749ex1c1.Models.StateProvinces", b =>
                {
                    b.HasOne("usiddique2749ex1c1.Models.Countries", "Country")
                        .WithMany("StateProvinces")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Application_StateProvinces_CountryID_Application_Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
