using System.Reflection;
using BoysClothingStore;

namespace BoysClothingStore;

class Program
{
    static void Main(string[] args)

}

public class ClothingItem
{
    public int Id { get; set; }
    public string name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUr1 { get; set; }
}
using Microsoft.EntityFrameworkcore;

public class Storecontext: DbContext
{
    public DbSet <ClothingItem> ClothingItems { get; set; }

    protectet override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
            optionsBuilder.useSqlServer{ "YourConnectionStringHer"};
        }
}
using Microsoft.AspNetCore.Mvc;

public class ClothingController : Controller
{
    private readonly StoreContext _context;

    public ClothingController(StoreContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var items = _context.ClothingItems.ToList();
        return View(items);
    }
}
public class Index.cshtml 
@model IEnumerable<ClothingItem>

<h1>Boys' Clothing Store</h1>


  <div>

    @foreach (var item in Model)

{
    <div class="clothing-item">

        <h2>@item.Name</h2>
        <img src="@item.ImageUrl" alt="@item.Name" />
        <p>@item.Description</p>
        <p>Price: @item.Price.ToString("C")</p>
        <button>Add to Cart</button>

     </div>

    }

</div>


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    using (var scope = app.ApplicationServices.CreateScope())

    {
        var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
        SeedData(context);

    }
}

private void SeedData(StoreContext context)

{
    if (!context.ClothingItems.Any())

    {
        context.ClothingItems.AddRange(
            new ClothingItem { Name = "T-shirt", Description = "Cool T-shirt", Price = 19.99m, ImageUrl = "path_to_image" },
            new ClothingItem { Name = "Shorts", Description = "Comfortable Shorts", Price = 29.99m, ImageUrl = "path_to_image" }
            );
        context.SaveChanges();

    }
}