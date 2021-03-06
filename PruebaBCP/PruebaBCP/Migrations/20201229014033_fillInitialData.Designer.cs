﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaBCP.Contexts;

namespace PruebaBCP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201229014033_fillInitialData")]
    partial class fillInitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PruebaBCP.Models.Currency", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("PruebaBCP.Models.CurrencyExchange", b =>
                {
                    b.Property<string>("FromCurrencyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ToCurrencyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(8,4)");

                    b.HasKey("FromCurrencyCode", "ToCurrencyCode");

                    b.HasIndex("ToCurrencyCode");

                    b.ToTable("CurrencyExchanges");
                });

            modelBuilder.Entity("PruebaBCP.Models.CurrencyExchange", b =>
                {
                    b.HasOne("PruebaBCP.Models.Currency", "FromCurrency")
                        .WithMany()
                        .HasForeignKey("FromCurrencyCode")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PruebaBCP.Models.Currency", "ToCurrency")
                        .WithMany()
                        .HasForeignKey("ToCurrencyCode")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FromCurrency");

                    b.Navigation("ToCurrency");
                });
#pragma warning restore 612, 618
        }
    }
}
