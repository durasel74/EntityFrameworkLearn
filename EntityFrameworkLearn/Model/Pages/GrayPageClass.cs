using System;
using System.Collections.Generic;

namespace EntityFrameworkLearn.Model
{
	public class GrayPageClass : Page
	{
		public GrayPageClass(string pageTitle, int pageId) :
			base(pageTitle, pageId)
		{
			Text1 =
			"Entity Framework Core (EF Core) представляет собой " +
			"объектно - ориентированную, легковесную и расширяемую " +
			"технологию от компании Microsoft для доступа к данным. " +
			"EF Core является ORM-инструментом(object - relational " +
			"mapping - отображения данных на реальные объекты).";

			CodeText1 =
			"public void main()\n" +
			"{\n" +
			"    Console.WriteLine(\"HelloWorld\");\n" +
			"}\n";

			// Table1
		}

		public string Text1 { get; set; }
		public string CodeText1 { get; set; }
		public List<User> Table1 { get; set; }
	}
}
