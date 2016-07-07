using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CQRS.DataAccess;

namespace CQRS.DataAccess.Migrations
{
    [DbContext(typeof(WriteContext))]
    partial class WriteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CQRS.Contracts.Events.ItemBaseEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AggregateId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasName("PrimaryKey_Id");

                    b.ToTable("ItemEvents");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ItemBaseEvent");
                });

            modelBuilder.Entity("CQRS.Contracts.Events.ItemAddedEvent", b =>
                {
                    b.HasBaseType("CQRS.Contracts.Events.ItemBaseEvent");

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.ToTable("ItemAddedEvent");

                    b.HasDiscriminator().HasValue("ItemAddedEvent");
                });

            modelBuilder.Entity("CQRS.Contracts.Events.ItemDeletedEvent", b =>
                {
                    b.HasBaseType("CQRS.Contracts.Events.ItemBaseEvent");


                    b.ToTable("ItemDeletedEvent");

                    b.HasDiscriminator().HasValue("ItemDeletedEvent");
                });

            modelBuilder.Entity("CQRS.Contracts.Events.ItemUpdatedEvent", b =>
                {
                    b.HasBaseType("CQRS.Contracts.Events.ItemBaseEvent");

                    b.Property<string>("Name");

                    b.Property<int?>("Quantity");

                    b.ToTable("ItemUpdatedEvent");

                    b.HasDiscriminator().HasValue("ItemUpdatedEvent");
                });
        }
    }
}
