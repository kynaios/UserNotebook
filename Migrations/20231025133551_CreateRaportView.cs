using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserNotebook.Migrations
{
    /// <inheritdoc />
    public partial class CreateReportView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR REPLACE VIEW Reports AS
            SELECT
                ""Name"", ""Surname"", ""Birthday"",
                CASE
                    WHEN ""Sex"" = 0 THEN 'Male'
                    WHEN ""Sex"" = 1 THEN 'Female'
                    ELSE ''
                END AS Sex_Name,
                CASE
                    WHEN ""Sex"" = 1 AND EXTRACT(YEAR FROM age(""Birthday"")) >= 18 THEN 'Ms'
                    WHEN ""Sex"" = 1 THEN 'Miss'
                    WHEN ""Sex"" = 0 THEN 'Mr'
                    ELSE ''
                END AS Title,
                EXTRACT(YEAR FROM age(""Birthday"")) AS Age
            FROM
                ""Users"" u ;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS Reports;");
        }
    }
}
