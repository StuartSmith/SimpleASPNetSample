using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SimpleASPNetSample.Context;

namespace SimpleASPNetSample.Migrations.PiGeneral
{
    [DbContext(typeof(PiGeneralContext))]
    [Migration("20161210141315_InitialGeneralMigration")]
    partial class InitialGeneralMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("SimpleASPNetSample.Models.PiNameValuePair", b =>
                {
                    b.Property<int>("NameValuePairId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("NameValuePairId");

                    b.ToTable("PiNameValuePairs");
                });
        }
    }
}
