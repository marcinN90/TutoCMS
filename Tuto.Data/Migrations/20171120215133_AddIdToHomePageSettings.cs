using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tuto.Data.Migrations
{
    public partial class AddIdToHomePageSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePageSettings",
                schema: "dbo",
                table: "HomePageSettings");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "HomePageSettings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "HomePageSettings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePageSettings",
                schema: "dbo",
                table: "HomePageSettings",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePageSettings",
                schema: "dbo",
                table: "HomePageSettings");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "HomePageSettings");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "HomePageSettings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePageSettings",
                schema: "dbo",
                table: "HomePageSettings",
                column: "Title");
        }
    }
}
