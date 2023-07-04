using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class SeveralRelationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "Fluent_Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Fluent_BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fluent_BookReader",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookReader", x => new { x.BookId, x.ReaderId });
                    table.ForeignKey(
                        name: "FK_Fluent_BookReader_Fluent_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Fluent_Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_BookReader_Fluent_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Fluent_Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_PublisherId",
                table: "Fluent_Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookDetails_BookId",
                table: "Fluent_BookDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookReader_ReaderId",
                table: "Fluent_BookReader",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Books_BookId",
                table: "Fluent_BookDetails",
                column: "BookId",
                principalTable: "Fluent_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_PublisherId",
                table: "Fluent_Books",
                column: "PublisherId",
                principalTable: "Fluent_Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Books_BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_PublisherId",
                table: "Fluent_Books");

            migrationBuilder.DropTable(
                name: "Fluent_BookReader");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_PublisherId",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookDetails_BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
