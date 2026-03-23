using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATwo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Trainees_TraineeId",
                table: "CourseResults");

            migrationBuilder.RenameColumn(
                name: "TraineeId",
                table: "CourseResults",
                newName: "traineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseResults_TraineeId",
                table: "CourseResults",
                newName: "IX_CourseResults_traineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Trainees_traineeId",
                table: "CourseResults",
                column: "traineeId",
                principalTable: "Trainees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Trainees_traineeId",
                table: "CourseResults");

            migrationBuilder.RenameColumn(
                name: "traineeId",
                table: "CourseResults",
                newName: "TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseResults_traineeId",
                table: "CourseResults",
                newName: "IX_CourseResults_TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Trainees_TraineeId",
                table: "CourseResults",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id");
        }
    }
}
