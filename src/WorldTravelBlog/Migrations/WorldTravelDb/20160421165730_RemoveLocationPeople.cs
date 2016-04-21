using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace WorldTravelBlog.Migrations.WorldTravelDb
{
    public partial class RemoveLocationPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ExperienceLocation_Experience_ExperienceId", table: "ExperienceLocations");
            migrationBuilder.DropForeignKey(name: "FK_ExperienceLocation_Location_LocationId", table: "ExperienceLocations");
            migrationBuilder.DropForeignKey(name: "FK_ExperiencePerson_Experience_ExperienceId", table: "ExperiencePeople");
            migrationBuilder.DropForeignKey(name: "FK_ExperiencePerson_Person_PersonId", table: "ExperiencePeople");
            migrationBuilder.DropTable("LocationPeople");
            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceLocation_Experience_ExperienceId",
                table: "ExperienceLocations",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceLocation_Location_LocationId",
                table: "ExperienceLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencePerson_Experience_ExperienceId",
                table: "ExperiencePeople",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencePerson_Person_PersonId",
                table: "ExperiencePeople",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ExperienceLocation_Experience_ExperienceId", table: "ExperienceLocations");
            migrationBuilder.DropForeignKey(name: "FK_ExperienceLocation_Location_LocationId", table: "ExperienceLocations");
            migrationBuilder.DropForeignKey(name: "FK_ExperiencePerson_Experience_ExperienceId", table: "ExperiencePeople");
            migrationBuilder.DropForeignKey(name: "FK_ExperiencePerson_Person_PersonId", table: "ExperiencePeople");
            migrationBuilder.CreateTable(
                name: "LocationPeople",
                columns: table => new
                {
                    LocationPersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPerson", x => x.LocationPersonId);
                    table.ForeignKey(
                        name: "FK_LocationPerson_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceLocation_Experience_ExperienceId",
                table: "ExperienceLocations",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceLocation_Location_LocationId",
                table: "ExperienceLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencePerson_Experience_ExperienceId",
                table: "ExperiencePeople",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencePerson_Person_PersonId",
                table: "ExperiencePeople",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
