using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bangazon_Task_Tracker.Data;

namespace BangazonTaskTracker.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    partial class BangazonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bangazon_Task_Tracker.Models.UserTask", b =>
                {
                    b.Property<int>("UserTaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CompletedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("UserTaskId");

                    b.ToTable("UserTask");
                });
        }
    }
}
