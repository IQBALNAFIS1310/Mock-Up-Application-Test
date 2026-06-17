using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bodata_calon_karyawan.Migrations
{
    /// <inheritdoc />
    public partial class stdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biodata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PosisiDilamar = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    NoKtp = table.Column<string>(type: "text", nullable: false),
                    TempatLahir = table.Column<string>(type: "text", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    JenisKelamin = table.Column<string>(type: "text", nullable: false),
                    Agama = table.Column<string>(type: "text", nullable: false),
                    GolonganDarah = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    AlamatKtp = table.Column<string>(type: "text", nullable: false),
                    AlamatTinggal = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    NoTelp = table.Column<string>(type: "text", nullable: false),
                    KontakDarurat = table.Column<string>(type: "text", nullable: false),
                    Skill = table.Column<string>(type: "text", nullable: false),
                    BersediaDitempatkan = table.Column<bool>(type: "boolean", nullable: false),
                    GajiDiharapkan = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biodata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biodata_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pekerjaan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BiodataId = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaPerusahaan = table.Column<string>(type: "text", nullable: false),
                    PosisiTerakhir = table.Column<string>(type: "text", nullable: false),
                    PendapatanTerakhir = table.Column<decimal>(type: "numeric", nullable: true),
                    Tahun = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pekerjaan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pekerjaan_Biodata_BiodataId",
                        column: x => x.BiodataId,
                        principalTable: "Biodata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pelatihan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BiodataId = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaKursus = table.Column<string>(type: "text", nullable: false),
                    Sertifikat = table.Column<bool>(type: "boolean", nullable: false),
                    Tahun = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelatihan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pelatihan_Biodata_BiodataId",
                        column: x => x.BiodataId,
                        principalTable: "Biodata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pendidikan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BiodataId = table.Column<Guid>(type: "uuid", nullable: false),
                    Jenjang = table.Column<string>(type: "text", nullable: false),
                    NamaInstitusi = table.Column<string>(type: "text", nullable: false),
                    Jurusan = table.Column<string>(type: "text", nullable: false),
                    TahunLulus = table.Column<int>(type: "integer", nullable: false),
                    Ipk = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendidikan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pendidikan_Biodata_BiodataId",
                        column: x => x.BiodataId,
                        principalTable: "Biodata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biodata_UserId",
                table: "Biodata",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pekerjaan_BiodataId",
                table: "Pekerjaan",
                column: "BiodataId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelatihan_BiodataId",
                table: "Pelatihan",
                column: "BiodataId");

            migrationBuilder.CreateIndex(
                name: "IX_Pendidikan_BiodataId",
                table: "Pendidikan",
                column: "BiodataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pekerjaan");

            migrationBuilder.DropTable(
                name: "Pelatihan");

            migrationBuilder.DropTable(
                name: "Pendidikan");

            migrationBuilder.DropTable(
                name: "Biodata");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
