using System;
namespace EntityBegin.Models
{
	public class Brand
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string CreatorName { get; set; }

		public int BrandCount { get; set; }

        public override string ToString()
        {
			return $"{Id}-{Name}-{CreatorName}-{BrandCount}";
        }
    }

	
}

