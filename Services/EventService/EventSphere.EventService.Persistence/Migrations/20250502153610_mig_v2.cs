using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSphere.EventService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_v2 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "SpeakerRecordId",
                table: "EventSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SpeakerId",
                table: "EventSessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventRecordId",
                table: "EventSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventSessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_EventSessions_EventId",
                table: "EventSessions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSessions_SpeakerId",
                table: "EventSessions",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSessions_Events_EventId",
                table: "EventSessions",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSessions_Events_EventRecordId",
                table: "EventSessions",
                column: "EventRecordId",
                principalTable: "Events",
                principalColumn: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSessions_Speakers_SpeakerId",
                table: "EventSessions",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSessions_Speakers_SpeakerRecordId",
                table: "EventSessions",
                column: "SpeakerRecordId",
                principalTable: "Speakers",
                principalColumn: "RecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventSessions_Events_EventId",
                table: "EventSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSessions_Events_EventRecordId",
                table: "EventSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSessions_Speakers_SpeakerId",
                table: "EventSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSessions_Speakers_SpeakerRecordId",
                table: "EventSessions");

            migrationBuilder.DropIndex(
                name: "IX_EventSessions_EventId",
                table: "EventSessions");

            migrationBuilder.DropIndex(
                name: "IX_EventSessions_SpeakerId",
                table: "EventSessions");

            migrationBuilder.AlterColumn<int>(
                name: "SpeakerRecordId",
                table: "EventSessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SpeakerId",
                table: "EventSessions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventRecordId",
                table: "EventSessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventSessions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSessions_Events_EventRecordId",
                table: "EventSessions",
                column: "EventRecordId",
                principalTable: "Events",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSessions_Speakers_SpeakerRecordId",
                table: "EventSessions",
                column: "SpeakerRecordId",
                principalTable: "Speakers",
                principalColumn: "RecordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
