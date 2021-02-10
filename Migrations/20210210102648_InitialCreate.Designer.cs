﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyExchangeAppForBrainence.Data;

namespace MoneyExchangeAppForBrainence.Migrations
{
    [DbContext(typeof(ExchangeRequestContext))]
    [Migration("20210210102648_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoneyExchangeAppForBrainence.Models.ExchangeRequest", b =>
                {
                    b.Property<int>("ExchangeRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FromAmount")
                        .HasColumnType("float");

                    b.Property<string>("FromCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ToAmount")
                        .HasColumnType("float");

                    b.Property<string>("ToCorrency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExchangeRequestId");

                    b.ToTable("ExchangeRequests");
                });
#pragma warning restore 612, 618
        }
    }
}