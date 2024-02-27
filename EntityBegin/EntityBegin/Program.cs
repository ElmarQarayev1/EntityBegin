
using EntityBegin.DAL;
using EntityBegin.Models;

foreach (var item in GetBrands())
{
    Console.WriteLine(item);
}

UpdateBrand();

foreach (var item in GetBrands())
{
    Console.WriteLine(item);
}
void AddGroup()
{
    AppDbContext context = new AppDbContext();

    Brand brand = new Brand()
    {
        Name = "apple",
        CreatorName = "elm",
        BrandCount = 2,
    };
    context.Brands.Add(brand);
    context.SaveChanges();

}

List<Brand> GetBrands()
{
    AppDbContext context = new AppDbContext();
    return context.Brands.ToList();
}

Brand GetFirstBrands()
{
    AppDbContext context = new AppDbContext();
    return context.Brands.First();
}

void RemoveBrand()
{
    AppDbContext context = new AppDbContext();
    var brand = context.Brands.First();
    context.Brands.Remove(brand);
    context.SaveChanges();
}

void UpdateBrand()
{
    AppDbContext context = new AppDbContext();
    var brand = context.Brands.First();
    brand.BrandCount = 1;
    context.SaveChanges();
}

Console.ReadLine();