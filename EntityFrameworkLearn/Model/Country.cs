using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLearn.Model
{
	public class Country
	{
		[Key]
		public string name { get; set; }
		public string description { get; set; }
	}
}
