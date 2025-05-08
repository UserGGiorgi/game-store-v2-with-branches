using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Infrastructure.Migrations
{
    /// <summary>
    /// Empty migration used to trigger database updates without schema changes.
    /// This serves as a marker for EF Core to recognize the migration history.
    /// </summary>
    public partial class UpdateCascadeDeleteBehavior : Migration
    {
        /// <summary>
        /// Empty by design - this migration exists only in the version history
        /// </summary>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Intentional no-op - migration exists only for version control
        }

        /// <summary>
        /// Empty by design - this migration exists only in the version history
        /// </summary>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Intentional no-op - no changes to revert
        }
    }
}
