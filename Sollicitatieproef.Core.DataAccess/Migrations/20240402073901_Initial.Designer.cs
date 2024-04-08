﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sollicitatieproef.Core.DataAccess;

#nullable disable

namespace Sollicitatieproef.Core.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240402073901_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Latin1_General_CI_AI")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sollicitatieproef.Core.DataAccess.Entities.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Emailadres")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Geboortedatum")
                        .HasMaxLength(50)
                        .HasColumnType("date");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Serienummer")
                        .HasColumnType("int");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Emailadres")
                        .IsUnique();

                    b.HasIndex("Serienummer")
                        .IsUnique();

                    b.ToTable("Gebruikers", (string)null);
                });

            modelBuilder.Entity("Sollicitatieproef.Core.DataAccess.Entities.GebruikerRecht", b =>
                {
                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<int>("RechtId")
                        .HasColumnType("int");

                    b.HasKey("GebruikerId", "RechtId");

                    b.HasIndex("RechtId");

                    b.ToTable("GebruikerRechten", (string)null);
                });

            modelBuilder.Entity("Sollicitatieproef.Core.DataAccess.Entities.Recht", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Omschrijving")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Rechten", (string)null);
                });

            modelBuilder.Entity("Sollicitatieproef.Core.DataAccess.Entities.GebruikerRecht", b =>
                {
                    b.HasOne("Sollicitatieproef.Core.DataAccess.Entities.Gebruiker", "Gebruiker")
                        .WithMany("GebruikerRechten")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sollicitatieproef.Core.DataAccess.Entities.Recht", "Recht")
                        .WithMany("GebruikerRechten")
                        .HasForeignKey("RechtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gebruiker");

                    b.Navigation("Recht");
                });

            modelBuilder.Entity("Sollicitatieproef.Core.DataAccess.Entities.Gebruiker", b =>
                {
                    b.Navigation("GebruikerRechten");
                });

            modelBuilder.Entity("Sollicitatieproef.Core.DataAccess.Entities.Recht", b =>
                {
                    b.Navigation("GebruikerRechten");
                });
#pragma warning restore 612, 618
        }
    }
}
