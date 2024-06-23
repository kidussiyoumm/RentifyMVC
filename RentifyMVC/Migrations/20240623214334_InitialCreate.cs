using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentifyMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    agentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    officeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.agentID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<byte>(type: "tinyint", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "AgentUser",
                columns: table => new
                {
                    AgentsagentID = table.Column<int>(type: "int", nullable: false),
                    UsersuserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentUser", x => new { x.AgentsagentID, x.UsersuserID });
                    table.ForeignKey(
                        name: "FK_AgentUser_Agents_AgentsagentID",
                        column: x => x.AgentsagentID,
                        principalTable: "Agents",
                        principalColumn: "agentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentUser_Users_UsersuserID",
                        column: x => x.UsersuserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    propertyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    numberOfRooms = table.Column<int>(type: "int", nullable: false),
                    numberOfBathrooms = table.Column<int>(type: "int", nullable: false),
                    ssAvailable = table.Column<bool>(type: "bit", nullable: false),
                    dateAvailable = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false),
                    agentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.propertyID);
                    table.ForeignKey(
                        name: "FK_Properties_Agents_agentID",
                        column: x => x.agentID,
                        principalTable: "Agents",
                        principalColumn: "agentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalApplications",
                columns: table => new
                {
                    applicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    applicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    moveInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false),
                    propertyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalApplications", x => x.applicationId);
                    table.ForeignKey(
                        name: "FK_RentalApplications_Properties_propertyID",
                        column: x => x.propertyID,
                        principalTable: "Properties",
                        principalColumn: "propertyID",
                        onDelete: ReferentialAction.Restrict);// Disable cascade delete on this relationship
                    table.ForeignKey(
                        name: "FK_RentalApplications_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);// Disable cascade delete on this relationship
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    reviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    propertyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Properties_propertyID",
                        column: x => x.propertyID,
                        principalTable: "Properties",
                        principalColumn: "propertyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentUser_UsersuserID",
                table: "AgentUser",
                column: "UsersuserID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_agentID",
                table: "Properties",
                column: "agentID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_userID",
                table: "Properties",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalApplications_propertyID",
                table: "RentalApplications",
                column: "propertyID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalApplications_userID",
                table: "RentalApplications",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_propertyID",
                table: "Reviews",
                column: "propertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_userID",
                table: "Reviews",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentUser");

            migrationBuilder.DropTable(
                name: "RentalApplications");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
