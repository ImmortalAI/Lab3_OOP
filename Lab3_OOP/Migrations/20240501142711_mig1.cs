using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3_OOP.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klempner_Human_MenschID",
                table: "Klempner");

            migrationBuilder.DropIndex(
                name: "IX_Klempner_MenschID",
                table: "Klempner");

            migrationBuilder.DropColumn(
                name: "Studak",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Gehalt",
                table: "Klempner");

            migrationBuilder.DropColumn(
                name: "INN",
                table: "Klempner");

            migrationBuilder.DropColumn(
                name: "MenschID",
                table: "Klempner");

            migrationBuilder.AlterColumn<int>(
                name: "HumanID",
                table: "Student",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Student",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionID",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Klempner",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Klempner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Human",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Human",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ProfessionID",
                table: "Student",
                column: "ProfessionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Klempner_ProfessionID",
                table: "Student",
                column: "ProfessionID",
                principalTable: "Klempner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Klempner_ProfessionID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ProfessionID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ProfessionID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Klempner");

            migrationBuilder.AlterColumn<int>(
                name: "HumanID",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Studak",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Klempner",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Gehalt",
                table: "Klempner",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "INN",
                table: "Klempner",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenschID",
                table: "Klempner",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Human",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Human",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Klempner_MenschID",
                table: "Klempner",
                column: "MenschID");

            migrationBuilder.AddForeignKey(
                name: "FK_Klempner_Human_MenschID",
                table: "Klempner",
                column: "MenschID",
                principalTable: "Human",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
