using System;
using System.Collections.Generic;

namespace EntityFrameworkLearn.Model
{
	public class Lesson6 : Page
	{
		public Lesson6(string pageTitle, int pageId) :
			base(pageTitle, pageId)
		{
			Text1 = 
			"При изменении объекта Entity Framework сам отслеживает " +
			"все изменения, и когда вызывается метод SaveChanges(), будет " +
			"сформировано SQL-выражение UPDATE для данного объекта, которое " +
			"обновит объект в базе данных.";

			Text2 =
			"Но надо отметить, что в данном случае действие контекста данных " +
			"ограничивается пределами конструкции using, которая определяет " +
			"область действия объекта ApplicationContext.";

			Text3 =
			"Несмотря на то, что объект user не равен null, имеется в базе данных, " +
			"но во втором блоке using обновления соответствующего объекта в БД не " +
			"произойдет. Потому что объект User больше не отслеживается контекстом " +
			"данных. И в этом случае во второй конструкции using, где происходит " +
			"редактирование, нам надо использовать метод Update:";

			CodeText1 =
			"db.Users.Update(user);\n" +
			"db.SaveChanges();\n";

			// Table1
		}

		public string Text1 { get; set; }
		public string Text2 { get; set; }
		public string Text3 { get; set; }

		public string CodeText1 { get; set; }
		public List<User> Table1 { get; set; }
	}
}
