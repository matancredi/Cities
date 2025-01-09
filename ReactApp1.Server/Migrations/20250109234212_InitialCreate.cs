using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReactApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EconomicGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<string>(type: "text", nullable: false)
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<string>(type: "text", nullable: false),
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
                name: "State",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryID = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.ID);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StateID = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_State_StateID",
                        column: x => x.StateID,
                        principalTable: "State",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "ID", "CreationDate", "Name" },
                values: new object[] { 1, "2025-01-09 20:42:12.0018906", "Brasil" });

            migrationBuilder.InsertData(
                table: "EconomicGroup",
                columns: new[] { "ID", "CreationDate", "Name" },
                values: new object[] { 1, "2025-01-09 20:42:12.0042066", "Mercosul" });

            migrationBuilder.InsertData(
                table: "ProjectLog",
                columns: new[] { "ID", "DateTime", "Exception", "Hostname", "Level", "Logger", "Message", "Thread" },
                values: new object[] { 1, "2025-01-09 20:42:12.008816", "test", "test", "Test", "Test", "Test", "Test" });

            migrationBuilder.InsertData(
                table: "CountryGroup",
                columns: new[] { "ID", "CountryID", "GroupID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "ID", "CountryID", "CreationDate", "Name" },
                values: new object[] { 1, 1, "2025-01-09 20:42:12.0029667", "São Paulo" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "ID", "CreationDate", "Name", "StateID" },
                values: new object[] { 1, "2025-01-09 20:42:12.0031317", "Guararema", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateID",
                table: "City",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_CountryGroup_CountryID",
                table: "CountryGroup",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_CountryGroup_GroupID",
                table: "CountryGroup",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryID",
                table: "State",
                column: "CountryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CountryGroup");

            migrationBuilder.DropTable(
                name: "ProjectLog");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "EconomicGroup");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
