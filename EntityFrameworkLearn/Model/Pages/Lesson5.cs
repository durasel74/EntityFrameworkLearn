using System;
using System.Collections.Generic;

namespace EntityFrameworkLearn.Model
{
	public class Lesson5 : Page
	{
		public Lesson5(string pageTitle, int pageId) :
			base(pageTitle, pageId)
		{
			Text1 = "Удаление производится с помощью метода Remove:";

			CodeText1 =
			"db.Users.Remove(newUser);\n" +
			"db.SaveChanges();\n";

			// Table1

			Text2 =
			"Данный метод установит статус объекта в Deleted, благодаря " +
			"чему Entity Framework при выполнении метода db.SaveChanges() " +
			"сгенерирует SQL-выражение DELETE.";

			Text3 =
			"Если необходимо удалить сразу несколько объектов, то можно " +
			"использовать метод RemoveRange():";

			CodeText2 =
			"db.Users.RemoveRange(newUser1, newUser2);\n" +
			"db.SaveChanges();\n";

			// Table2
		}

		public string Text1 { get; set; }
		public string Text2 { get; set; }
		public string Text3 { get; set; }

		public string CodeText1 { get; set; }
		public string CodeText2 { get; set; }

		public List<User> Table1 { get; set; }
		public List<User> Table2 { get; set; }
	}
}
