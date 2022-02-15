using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLearn.Model
{
	public class City
	{
		[Key]
		public string name { get; set; }
		public string description { get; set; }
		public string countryName { get; set; }
	}
}
