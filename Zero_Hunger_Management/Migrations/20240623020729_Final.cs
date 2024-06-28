using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zero_Hunger_Management.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NGOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NGOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CollectRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxPreservedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForHowManyPersons = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RID = table.Column<int>(type: "int", nullable: false),
                    NGOID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CollectRequests_NGOS_NGOID",
                        column: x => x.NGOID,
                        principalTable: "NGOS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CollectRequests_Restaurants_RID",
                        column: x => x.RID,
                        principalTable: "Restaurants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignEmployees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EID = table.Column<int>(type: "int", nullable: false),
                    RID = table.Column<int>(type: "int", nullable: false),
                    CRID = table.Column<int>(type: "int", nullable: false),
                    RName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxPreservedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignEmployees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssignEmployees_CollectRequests_CRID",
                        column: x => x.CRID,
                        principalTable: "CollectRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignEmployees_Employees_EID",
                        column: x => x.EID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignEmployees_Restaurants_RID",
                        column: x => x.RID,
                        principalTable: "Restaurants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignEmployees_CRID",
                table: "AssignEmployees",
                column: "CRID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignEmployees_EID",
                table: "AssignEmployees",
                column: "EID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignEmployees_RID",
                table: "AssignEmployees",
                column: "RID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectRequests_NGOID",
                table: "CollectRequests",
                column: "NGOID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectRequests_RID",
                table: "CollectRequests",
                column: "RID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignEmployees");

            migrationBuilder.DropTable(
                name: "CollectRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "NGOS");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
