using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw11.Migrations
{
    public partial class AddedPrescriptionAndPrescription_MedicamentTablesWithExampleDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IdPatient = table.Column<int>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_PK", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "Prescription_Doctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription_Patient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false),
                    IdMedicament = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: true),
                    Details = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrescriptionMedicament_PK2", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "PrescriptionMedicament_Medicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PrescriptionMedicament_Prescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "email1@pjwstk.edu.pl", "Jan", "Jankowski" },
                    { 2, "email2@pjwstk.edu.pl", "Adam", "Adamowski" },
                    { 3, "email3@pjwstk.edu.pl", "Karol", "Karolowskiki" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "na sen", "Dobry Sen Forte", "tabletki" },
                    { 2, "na bol glowy", "Ibuprom", "syrop" },
                    { 3, "na bol brzucha", "Witaminium C", "czopki" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon", "Kowal" },
                    { 2, new DateTime(1994, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alicja", "Czarow" },
                    { 3, new DateTime(1980, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joker", "Batman" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 3, new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "Details", "Dose", "IdMedicament" },
                values: new object[] { 1, "Przed posilkiem", 3, 1 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "Details", "Dose", "IdMedicament" },
                values: new object[] { 2, "Popijac duza iloscia wody", 5, 2 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "Details", "Dose", "IdMedicament" },
                values: new object[] { 3, "Po posilku", 10, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}
