
using System;
using EntityBegin.DAL;
using EntityBegin.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("ProductApp");

string opt;
do
{
    Console.WriteLine("1.Create Product");
    Console.WriteLine("2.Delete Pruduct");
    Console.WriteLine("3.Get All Products");
    Console.WriteLine("4.Get Pruduct by id");
    Console.WriteLine("5.Create Brand");
    Console.WriteLine("6.Delete Brand");
    Console.WriteLine("7.Get All Brands");
    Console.WriteLine("8.Get Brand by id");
    opt = Console.ReadLine();
    AppDbContext context = new AppDbContext();

    switch (opt)
    {
        case "1":
            CreateProduct(context);
            break;
        case "2":
            DeleteProduct(context);
            break;
        case "3":
            GetProducts(context);
            break;
        case "4":
            GetProductById(context);
            break;
        case "5":
            CreateBrand(context);
            break;
        case "6":
            DeleteBrand(context);
            break;
        case "7":
            GetBrands(context);
            break;
        case "8":
            GetBrandById(context);
            break;
        case "0":
            Console.WriteLine("Program Finished...");
            break;
        default:
            Console.WriteLine("Wrong Option!");
            break;
    }

} while (opt!="0");

void CreateProduct(AppDbContext context)
{ 
    Name:
        Console.WriteLine("productun adini daxil edin:");
        string name = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto Name;
        }

    Start:
        Console.WriteLine("Startdate daxil edin:");
        string startStr = Console.ReadLine();
        DateTime startdate;
        if (!DateTime.TryParse(startStr, out startdate))
        {
            Console.WriteLine("duzgun daxil edin!");
            goto Start;
        }

        var data4 = context.Brands.ToList();
        Console.WriteLine("All Brands:");
        foreach (var item in data4)
        {
            Console.WriteLine(item);
        }
    BrandId:
        Console.WriteLine("Brand Id daxil edin:");
        string brandIdStr = Console.ReadLine();
        int brandId;
        if (!int.TryParse(brandIdStr, out brandId) || brandId <= 0)
        {
            Console.WriteLine("duzgun daxil edin!");
            goto BrandId;
        }
        if (context.Brands.Any(x => x.Id == brandId))
        {
            Product product = new Product()
            {

                Name = name,
                Startdate = startdate,
                BrandId = brandId
            };
            context.Products.Add(product);

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Id not found");
        }
    }

void DeleteProduct(AppDbContext context)
{
DeleteId:
    Console.WriteLine("Product Id daxil edin:");
    string deleteStr = Console.ReadLine();
    int deleteId;
    if (!int.TryParse(deleteStr, out deleteId) || deleteId <= 0)
    {
        Console.WriteLine("duzgun daxil edin!");
        goto DeleteId;
    }
    if (context.Products.Any(x => x.Id == deleteId))
    {
        var data1 = context.Products.Find(deleteId);
        context.Products.Remove(data1);
        context.SaveChanges();
    }
    else
    {
        Console.WriteLine("product id not found");
    }
}
void GetProducts(AppDbContext context)
{
    var data = context.Products.Include(x => x.Brand).ToList();
    Console.WriteLine("All products:");
    foreach (var item in data)
    {
        Console.WriteLine(item + "-" + item.Brand.Name);
    }
}
void GetProductById(AppDbContext context)
{
    Console.WriteLine("axtaracaginiz id ni daxil edin:");
SProductId:
    Console.WriteLine("Product Id daxil edin:");
    string SearchPId = Console.ReadLine();
    int sProductId;
    if (!int.TryParse(SearchPId, out sProductId))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto SProductId;
    }
    var product1 = context.Products.Find(sProductId);
    if (product1 == null)
    {
        Console.WriteLine("axtardiginiz id li product yoxdur");
    }
    Console.WriteLine(product1);
}
void CreateBrand(AppDbContext context)
{
BName:
    Console.WriteLine("Brandin adini daxil edin:");
    string brandName = Console.ReadLine();
    if (String.IsNullOrWhiteSpace(brandName))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto BName;
    }
cBName:
    Console.WriteLine("Brandin CreatorName'i daxil edin:");
    string creatorName = Console.ReadLine();
    if (String.IsNullOrWhiteSpace(creatorName))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto cBName;
    }
Count:
    Console.WriteLine("Brandin count'nu daxil edin:");
    string countStr = Console.ReadLine();
    int count;
    if (!int.TryParse(countStr, out count) || count < 0)
    {
        Console.WriteLine("duzgun daxil edin!");
        goto Count;
    }
    Brand brand = new Brand()
    {
        Name = brandName,
        CreatorName = creatorName,
        BrandCount = count
    };
    context.Brands.Add(brand);
    context.SaveChanges();
}
void DeleteBrand(AppDbContext context)
{
BDeleteId:
    Console.WriteLine("Brand Id daxil edin:");
    string deleteBrandIdStr = Console.ReadLine();
    int deleteBrandId;
    if (!int.TryParse(deleteBrandIdStr, out deleteBrandId) || deleteBrandId <= 0)
    {
        Console.WriteLine("duzgun daxil edin!");
        goto BDeleteId;
    }
    var data2 = context.Brands.Find(deleteBrandId);
    //Any ilede yazmaq olar..
    if (data2 == null)
    {
        Console.WriteLine("id not found");
    }
    else
    {
        context.Brands.Remove(data2);
        context.SaveChanges();
    }
}
void GetBrands(AppDbContext context)
{
    var data3 = context.Brands.Include(x => x.Products).ToList();
    Console.WriteLine("All Brands:");
    foreach (var item in data3)
    {
        Console.WriteLine(item + "-" + item.Products.Count);
    }
}
void GetBrandById(AppDbContext context)
{
    Console.WriteLine("axtaracaginiz id ni daxil edin:");
SBrandId:
    Console.WriteLine("Brand Id daxil edin:");
    string SearchId = Console.ReadLine();
    int sBrandId;
    if (!int.TryParse(SearchId, out sBrandId) || sBrandId <= 0)
    {
        Console.WriteLine("duzgun daxil edin!");
        goto SBrandId;
    }
    var product2 = context.Brands.Find(sBrandId);
    if (product2 == null)
    {
        Console.WriteLine("id not found");
    }
    else
        Console.WriteLine(product2);
}