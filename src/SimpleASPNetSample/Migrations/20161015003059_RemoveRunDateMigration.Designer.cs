using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SimpleASPNetSample.Context;

namespace SimpleASPNetSample.Migrations
{
    [DbContext(typeof(UltraSonicContext))]
    [Migration("20161015003059_RemoveRunDateMigration")]
    partial class RemoveRunDateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("SimpleASPNetSample.Models.UltraSonicSensorRun", b =>
                {
                    b.Property<int>("SonicId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MeasurementIn");

                    b.Property<int>("PinGPIOEcho");

                    b.Property<int>("PinGPIOTrigger");

                    b.Property<bool>("RequestSentToAzure");

                    b.Property<DateTime>("RunDate");

                    b.Property<bool>("SendRequestToAzure");

                    b.Property<DateTime>("TimeOfMeasureMent");

                    b.Property<double>("TotalDistance");

                    b.HasKey("SonicId");

                    b.ToTable("UltraSonicSensorRuns");
                });

            modelBuilder.Entity("SimpleASPNetSample.Models.UltraSonicSensorRunMeasurement", b =>
                {
                    b.Property<int>("SonicMeasurementId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("MeasurementDistance");

                    b.Property<DateTime>("TimeOfMeasurment");

                    b.Property<int>("UltraSonicSensorRunId");

                    b.HasKey("SonicMeasurementId");

                    b.HasIndex("UltraSonicSensorRunId");

                    b.ToTable("UltraSonicSensorRunMeasurements");
                });

            modelBuilder.Entity("SimpleASPNetSample.Models.UltraSonicSensorRunMeasurement", b =>
                {
                    b.HasOne("SimpleASPNetSample.Models.UltraSonicSensorRun", "Run")
                        .WithMany("SonicMeasurements")
                        .HasForeignKey("UltraSonicSensorRunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
