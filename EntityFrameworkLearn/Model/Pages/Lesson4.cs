using System;
using System.Collections.Generic;

namespace EntityFrameworkLearn.Model
{
	public class Lesson4 : Page
	{
		public Lesson4(string pageTitle, int pageId) :
			base(pageTitle, pageId)
		{
			Text1 =
			"Большинство операций с данными так или иначе представляют " +
			"собой CRUD операции (Create, Read, Update, Delete), то есть " +
			"создание, получение, обновление и удаление. Entity Framework " +
			"Core позволяет легко выполнять все эти действия.";

			Text2 = 
			"Для добавления объекта используется метод Add, определенный у " +
			"класса DbSet, в который передается добавляемый объект:";

			CodeText1 =
			"db.Users.Add(newUser);\n" +
			"db.SaveChanges();\n";

			// Table1

			Text3 =
			"Метод Add устанавливает значение Added в качестве состояния " +
			"нового объекта. Поэтому метод db.SaveChanges() сгенерирует " +
			"выражение INSERT для вставки модели в таблицу.";

			Text4 =
			"Если нам надо добавить сразу несколько объектов, то мы " +
			"можем воспользоваться методом AddRange():";

			CodeText2 =
			"User newUser1 = new User { Login = \"Новый1\", email = \"New1 @mail.ru\"};\n" +
			"User newUser2 = new User { Login = \"Новый2\", email = \"New2 @mail.ru\"};\n" +
			"db.Users.AddRange(tom, alice);";

			// Table2
		}

		public string Text1 { get; set; }
		public string Text2 { get; set; }
		public string Text3 { get; set; }
		public string Text4 { get; set; }

		public string CodeText1 { get; set; }
		public string CodeText2 { get; set; }

		public List<User> Table1 { get; set; }
		public List<User> Table2 { get; set; }
	}
}
