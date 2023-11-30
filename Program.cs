using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_and_Dapper_Exercisev2;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

departmentRepo.InsertDepartment("Alexs New Department");

var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
}

var productRepo = new DapperProductRepository(conn);

var productToUpdate = productRepo.GetProduct(941);

productToUpdate.Name = "Updated!!!";
productToUpdate.Price = 12.99;
productToUpdate.CategoryId = 1;
productToUpdate.OnSale = false;
productToUpdate.StockLevel = 1000;

productRepo.UpdateProduct(productToUpdate);

productRepo.DeleteProduct(941);

var products = productRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryId);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
}