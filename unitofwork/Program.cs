using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Models;

var options = new DbContextOptionsBuilder<AplicacionDbContext>()
    .UseInMemoryDatabase("MiTienda") 
    .Options;

using var context = new AplicacionDbContext(options);
using var unitOfWork = new UnitOfWork(context);


var producto = new Producto { Nombre = "Laptop", Precio = 1500 };
await unitOfWork.Productos.AddAsync(producto);
await unitOfWork.CompleteAsync();
Console.WriteLine("Producto agregado.");


var productos = await unitOfWork.Productos.GetAllAsync();
foreach (var p in productos)
{
    Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}");
}


producto.Precio = 1400;
unitOfWork.Productos.Update(producto);
await unitOfWork.CompleteAsync();
Console.WriteLine("Producto actualizado.");

unitOfWork.Productos.Delete(producto);
await unitOfWork.CompleteAsync();
Console.WriteLine("Producto eliminado.");