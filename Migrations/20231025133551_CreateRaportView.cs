using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserNotebook.Migrations
{
    /// <inheritdoc />
    public partial class CreateRaportView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR REPLACE VIEW Raports AS
            SELECT
                ""Name"", ""Surname"", ""BirthDay"",
                CASE
                    WHEN ""Sex"" = 0 THEN 'Male'
                    WHEN ""Sex"" = 1 THEN 'Female'
                    ELSE ''
                END AS Sex_Name,
                CASE
                    WHEN ""Sex"" = 1 AND EXTRACT(YEAR FROM age(""BirthDay"")) >= 18 THEN 'Ms'
                    WHEN ""Sex"" = 1 THEN 'Miss'
                    WHEN ""Sex"" = 0 THEN 'Mr'
                    ELSE ''
                END AS Title,
                EXTRACT(YEAR FROM age(""BirthDay"")) AS Age
            FROM
                ""Users"" u ;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS Raports;");
        }
    }
}
