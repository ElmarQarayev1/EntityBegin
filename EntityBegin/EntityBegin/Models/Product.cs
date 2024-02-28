using System;
namespace EntityBegin.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public DateTime Startdate { get; set; }

		public int BrandId { get; set; }

		public Brand Brand { get; set; }

        public override string ToString()
        {
			return $"{Id}-{Name}-{Startdate}-{BrandId}";
        }

    }
}

