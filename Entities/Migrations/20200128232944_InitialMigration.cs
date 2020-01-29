using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BucketList",
                columns: table => new
                {
                    BucketListId = table.Column<Guid>(nullable: false),
                    BucketListName = table.Column<string>(maxLength: 60, nullable: false),
                    Date_Created = table.Column<DateTime>(nullable: false),
                    Date_Modified = table.Column<DateTime>(nullable: false),
                    Created_By = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketList", x => x.BucketListId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    Item_Name = table.Column<string>(maxLength: 70, nullable: false),
                    Date_Created = table.Column<DateTime>(nullable: false),
                    Date_Modified = table.Column<DateTime>(nullable: false),
                    Done = table.Column<bool>(nullable: false),
                    BucketListId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_BucketList_BucketListId",
                        column: x => x.BucketListId,
                        principalTable: "BucketList",
                        principalColumn: "BucketListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_BucketListId",
                table: "Item",
                column: "BucketListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "BucketList");
        }
    }
}
