using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Categorys(Name, ImageUrl) Values('Bebidas','bebidas.jpg')");
            mb.Sql("insert into Categorys(Name, ImageUrl) Values('Lanches','lanches.jpg')");
            mb.Sql("insert into Categorys(Name, ImageUrl) Values('Sobremesas','sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from category");
        }
    }
}
