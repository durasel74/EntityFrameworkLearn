using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLearn.Model
{
	public class Cities
	{
		[Key]
		public string name { get; set; }
		public string description { get; set; }
		public string countryName { get; set; }
	}
}
