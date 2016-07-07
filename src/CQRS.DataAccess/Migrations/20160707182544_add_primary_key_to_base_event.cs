using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRS.DataAccess.Migrations
{
    public partial class add_primary_key_to_base_event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_AggregateId",
                table: "ItemEvents");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ItemEvents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_Id",
                table: "ItemEvents",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_Id",
                table: "ItemEvents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemEvents");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_AggregateId",
                table: "ItemEvents",
                column: "AggregateId");
        }
    }
}
