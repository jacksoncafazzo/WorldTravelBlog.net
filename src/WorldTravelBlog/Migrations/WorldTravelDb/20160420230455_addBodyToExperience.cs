using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WorldTravelBlog.Migrations.WorldTravelDb
{
    public partial class addBodyToExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ExperienceLocation_Experience_ExperienceId", table: "ExperienceLocations");
            migrationBuilder.DropForeignKey(name: "FK_ExperienceLocation_Location_LocationId", table: "ExperienceLocations");
            migrationBuilder.DropForeignKey(name: "FK_ExperiencePerson_Experience_ExperienceId", table: "ExperiencePeople");
            migrationBuilder.DropForeignKey(name: "FK_ExperiencePerson_Person_PersonId", table: "ExperiencePeople");
            migrationBuilder.DropForeignKey(name: "FK_LocationPerson_Location_LocationId", table: "LocationPeople");
            migrationBuilder.DropForeignKey(name: "FK_LocationPerson_Person_PersonId", table: "LocationPeople");
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Experiences",
                nullable: true);
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
            migrationBuilder.AddForeignKey(
                name: "FK_LocationPerson_Location_LocationId",
                table: "LocationPeople",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_LocationPerson_Person_PersonId",
                table: "LocationPeople",
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
            migrationBuilder.DropForeignKey(name: "FK_LocationPerson_Location_LocationId", table: "LocationPeople");
            migrationBuilder.DropForeignKey(name: "FK_LocationPerson_Person_PersonId", table: "LocationPeople");
            migrationBuilder.DropColumn(name: "Body", table: "Experiences");
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
            migrationBuilder.AddForeignKey(
                name: "FK_LocationPerson_Location_LocationId",
                table: "LocationPeople",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_LocationPerson_Person_PersonId",
                table: "LocationPeople",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
