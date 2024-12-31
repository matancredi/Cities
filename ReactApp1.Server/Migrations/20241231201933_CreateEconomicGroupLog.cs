using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateEconomicGroupLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "EconomicGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "text", nullable: false),
                    Thread = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<string>(type: "text", nullable: true),
                    Logger = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Exception = table.Column<string>(type: "text", nullable: true),
                    Hostname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountryGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryID = table.Column<int>(type: "integer", nullable: false),
                    GroupID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CountryGroup_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryGroup_EconomicGroup_GroupID",
                        column: x => x.GroupID,
                        principalTable: "EconomicGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 12, 31, 17, 19, 32, 295, DateTimeKind.Local).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 12, 31, 17, 19, 32, 293, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.InsertData(
                table: "EconomicGroup",
                columns: new[] { "ID", "CreationDate", "Name" },
                values: new object[] { 1, new DateTime(2024, 12, 31, 17, 19, 32, 296, DateTimeKind.Local).AddTicks(7350), "Mercosul" });

            migrationBuilder.InsertData(
                table: "ProjectLog",
                columns: new[] { "ID", "DateTime", "Exception", "Hostname", "Level", "Logger", "Message", "Thread" },
                values: new object[] { 1, new DateTime(2024, 12, 31, 17, 19, 32, 301, DateTimeKind.Local).AddTicks(2071), "test", "test", "Test", "Test", "Test", "Test" });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 12, 31, 17, 19, 32, 295, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.InsertData(
                table: "CountryGroup",
                columns: new[] { "ID", "CountryID", "GroupID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CountryGroup_CountryID",
                table: "CountryGroup",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_CountryGroup_GroupID",
                table: "CountryGroup",
                column: "GroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryGroup");

            migrationBuilder.DropTable(
                name: "ProjectLog");

            migrationBuilder.DropTable(
                name: "EconomicGroup");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 12, 29, 23, 53, 51, 163, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 12, 29, 23, 53, 51, 160, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 12, 29, 23, 53, 51, 163, DateTimeKind.Local).AddTicks(1823));
        }
    }
}
