using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Soporte.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clientId", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productId", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    technicianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    technicianLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    technicianCI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    technicianPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    technicianEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("technicianId", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrders",
                columns: table => new
                {
                    ServiceOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    serviceOrderCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    serviceOrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("serviceOrderId", x => x.ServiceOrderId);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    appointmentStatus = table.Column<int>(type: "int", nullable: false),
                    appointmentVisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointmentId", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ServiceOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrderHasProducts",
                columns: table => new
                {
                    ServiceOrdersHasProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("serviceOrderHasProductsId", x => x.ServiceOrdersHasProductsId);
                    table.ForeignKey(
                        name: "FK_ServiceOrderHasProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceOrderHasProducts_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ServiceOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrdersDetails",
                columns: table => new
                {
                    ServiceOrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    serviceOrderDetailType = table.Column<int>(type: "int", nullable: false),
                    serviceOrderDetailPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ServiceOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    serviceOrderDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceOrderDetailAlternativeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("serviceOrderDetailId", x => x.ServiceOrderDetailId);
                    table.ForeignKey(
                        name: "FK_ServiceOrdersDetails_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ServiceOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentHasTechnicians",
                columns: table => new
                {
                    AppoinmtentHasTechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointmentHasTechnicianId", x => x.AppoinmtentHasTechnicianId);
                    table.ForeignKey(
                        name: "FK_AppointmentHasTechnicians_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentHasTechnicians_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobForms",
                columns: table => new
                {
                    JobFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    jobFormDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jobFormDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("jobFormId", x => x.JobFormId);
                    table.ForeignKey(
                        name: "FK_JobForms_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHasTechnicians_AppointmentId",
                table: "AppointmentHasTechnicians",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHasTechnicians_TechnicianId",
                table: "AppointmentHasTechnicians",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceOrderId",
                table: "Appointments",
                column: "ServiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobForms_AppointmentId",
                table: "JobForms",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderHasProducts_ProductId",
                table: "ServiceOrderHasProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderHasProducts_ServiceOrderId",
                table: "ServiceOrderHasProducts",
                column: "ServiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ClientId",
                table: "ServiceOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrdersDetails_ServiceOrderId",
                table: "ServiceOrdersDetails",
                column: "ServiceOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentHasTechnicians");

            migrationBuilder.DropTable(
                name: "JobForms");

            migrationBuilder.DropTable(
                name: "ServiceOrderHasProducts");

            migrationBuilder.DropTable(
                name: "ServiceOrdersDetails");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
