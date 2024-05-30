using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{

    /// <inheritdoc />
    public partial class PopulaProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Products(Name, Description, Price, ImageUrl, Inventory, RegistrationDate, CategoryId)" +
                "Values('Coca-cola', 'Refrigerante de cola 350ml', 5.45, 'cocacola.jpg', 50, now(), 1)");
            mb.Sql("insert into Products(Name, Description, Price, ImageUrl, Inventory, RegistrationDate, CategoryId)" +
                "Values('Lanche de Atum', 'lanche de atum com maionese', 8.50, 'atum.jpg', 10, now(), 2)");
            mb.Sql("insert into Products(Name, Description, Price, ImageUrl, Inventory, RegistrationDate, CategoryId)" +
                "Values('Pudim', 'pudim de leite', 6.75, 'pudim.jpg', 20, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
