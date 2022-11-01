﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordingOfViolations.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reasons",
                columns: table => new
                {
                    ReasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasons", x => x.ReasonId);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    ViolationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Policeman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Offender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.ViolationId);
                    table.ForeignKey(
                        name: "FK_Violations_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "ReasonId");
                });

            migrationBuilder.CreateTable(
                name: "PaymentСhecks",
                columns: table => new
                {
                    PaymentСheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViolationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentСhecks", x => x.PaymentСheckId);
                    table.ForeignKey(
                        name: "FK_PaymentСhecks_Violations_ViolationId",
                        column: x => x.ViolationId,
                        principalTable: "Violations",
                        principalColumn: "ViolationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reasons",
                columns: new[] { "ReasonId", "Name" },
                values: new object[,]
                {
                    { 1, "Порушення правил користування ременями безпеки або мотошоломами" },
                    { 2, "Нетверезий стан" },
                    { 3, "Порушення правил перевезення дітей" },
                    { 4, "Порушення правил зупинки маршрутних таксі" }
                });

            migrationBuilder.InsertData(
                table: "Violations",
                columns: new[] { "ViolationId", "Address", "Date", "Offender", "Policeman", "Price", "ReasonId" },
                values: new object[,]
                {
                    { 1, "вулиця Інститутська, 22", new DateTime(2022, 10, 24, 12, 23, 5, 872, DateTimeKind.Local).AddTicks(5946), "Cпівак Олег", "Кукурудза Валерій", 1750m, 3 },
                    { 2, "Львівське шосе, 38/1", new DateTime(2022, 10, 9, 12, 23, 5, 872, DateTimeKind.Local).AddTicks(5960), "Ткачук Петро", "Щур Сергій", 510m, 1 },
                    { 3, "вулиця Соборна, 11", new DateTime(2022, 10, 30, 12, 23, 5, 872, DateTimeKind.Local).AddTicks(5970), "Олійник Яна", "Щур Сергій", 750m, 4 },
                    { 4, "вулиця Трудова, 6А", new DateTime(2022, 10, 18, 12, 23, 5, 872, DateTimeKind.Local).AddTicks(5979), "Пристувчук Олександр", "Кукурудза Валерій", 15000m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentСhecks_ViolationId",
                table: "PaymentСhecks",
                column: "ViolationId");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_ReasonId",
                table: "Violations",
                column: "ReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentСhecks");

            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "Reasons");
        }
    }
}
