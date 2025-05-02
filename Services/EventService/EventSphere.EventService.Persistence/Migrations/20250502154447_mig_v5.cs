using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSphere.EventService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventSessions_Events_EventRecordId",
                table: "EventSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSessions_Speakers_SpeakerRecordId",
                table: "EventSessions");

            migrationBuilder.DropIndex(
                name: "IX_EventSessions_EventRecordId",
                table: "EventSessions");

            migrationBuilder.DropIndex(
                name: "IX_EventSessions_SpeakerRecordId",
                table: "EventSessions");

            migrationBuilder.DropColumn(
                name: "EventRecordId",
                table: "EventSessions");

            migrationBuilder.DropColumn(
                name: "SpeakerRecordId",
                table: "EventSessions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventRecordId",
                table: "EventSessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerRecordId",
                table: "EventSessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventSessions_EventRecordId",
                table: "EventSessions",
                column: "EventRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSessions_SpeakerRecordId",
                table: "EventSessions",
                column: "SpeakerRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSessions_Events_EventRecordId",
                table: "EventSessions",
                column: "EventRecordId",
                principalTable: "Events",
                principalColumn: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSessions_Speakers_SpeakerRecordId",
                table: "EventSessions",
                column: "SpeakerRecordId",
                principalTable: "Speakers",
                principalColumn: "RecordId");
        }
    }
}
