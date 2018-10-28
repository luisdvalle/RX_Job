using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rx_job_webapi.Migrations
{
    public partial class InitialCreateDemoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RxRoomTypeTbl",
                columns: table => new
                {
                    RoomType = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RxRoomTypeTbl", x => x.RoomType);
                });

            migrationBuilder.CreateTable(
                name: "RxJobTbl",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractorID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    Room = table.Column<int>(nullable: false),
                    DelayReason = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    DateDelayed = table.Column<DateTime>(nullable: false),
                    StatusNum = table.Column<int>(nullable: false),
                    RoomType1 = table.Column<string>(nullable: true),
                    RJobID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RxJobTbl", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_RxJobTbl_RxRoomTypeTbl_RoomType1",
                        column: x => x.RoomType1,
                        principalTable: "RxRoomTypeTbl",
                        principalColumn: "RoomType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RxJobTbl_RoomType1",
                table: "RxJobTbl",
                column: "RoomType1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RxJobTbl");

            migrationBuilder.DropTable(
                name: "RxRoomTypeTbl");
        }
    }
}
