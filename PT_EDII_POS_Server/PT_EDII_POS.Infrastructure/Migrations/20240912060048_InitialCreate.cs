using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PT_EDII_POS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaBarang = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokAwal = table.Column<int>(type: "int", nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UrlGambar = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    JumlahItem = table.Column<int>(type: "int", nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalHarga = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TanggalTransaksi = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
