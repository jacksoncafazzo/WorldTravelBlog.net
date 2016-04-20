using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WorldTravelBlog.Models;

namespace WorldTravelBlog.Migrations.WorldTravelDb
{
    [DbContext(typeof(WorldTravelDbContext))]
    [Migration("20160420170812_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorldTravelBlog.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("ExperienceId");

                    b.HasAnnotation("Relational:TableName", "Experiences");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.ExperienceLocation", b =>
                {
                    b.Property<int>("ExperienceLocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExperienceId");

                    b.Property<int>("LocationId");

                    b.HasKey("ExperienceLocationId");

                    b.HasAnnotation("Relational:TableName", "ExperienceLocations");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.ExperiencePerson", b =>
                {
                    b.Property<int>("ExperiencePersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExperienceId");

                    b.Property<int>("PersonId");

                    b.HasKey("ExperiencePersonId");

                    b.HasAnnotation("Relational:TableName", "ExperiencePeople");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("LocationId");

                    b.HasAnnotation("Relational:TableName", "Locations");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.LocationPerson", b =>
                {
                    b.Property<int>("LocationPersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocationId");

                    b.Property<int>("PersonId");

                    b.HasKey("LocationPersonId");

                    b.HasAnnotation("Relational:TableName", "LocationPeople");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PersonId");

                    b.HasAnnotation("Relational:TableName", "People");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.ExperienceLocation", b =>
                {
                    b.HasOne("WorldTravelBlog.Models.Experience")
                        .WithMany()
                        .HasForeignKey("ExperienceId");

                    b.HasOne("WorldTravelBlog.Models.Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.ExperiencePerson", b =>
                {
                    b.HasOne("WorldTravelBlog.Models.Experience")
                        .WithMany()
                        .HasForeignKey("ExperienceId");

                    b.HasOne("WorldTravelBlog.Models.Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.LocationPerson", b =>
                {
                    b.HasOne("WorldTravelBlog.Models.Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("WorldTravelBlog.Models.Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });
        }
    }
}
