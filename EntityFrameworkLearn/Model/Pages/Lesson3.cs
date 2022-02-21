using System;
using System.Collections.Generic;

namespace EntityFrameworkLearn.Model
{
	public class Lesson3 : Page
	{
		public Lesson3(string pageTitle, int pageId) :
			base(pageTitle, pageId)
		{
			Text1 =
			"В прошлом уроке мы настроили все необходимые инструменты " +
			"и подключиись к базе данных. Теперь определим сам код " +
			"программы, который будет взаимодействовать с созданной БД. " +
			"Для этого изменим файл Program.cs следующим образом:";

			CodeText1 =
			"using (AppDbContext db = new AppDbContext())\n" +
			"{\n" +
			"    users = db.Users.ToList();\n" +
			"}\n";

			Text2 = "Полученный результат:";

			// Table1

			Text3 =
			"Так как класс ApplicationContext через базовый класс " +
			"DbContext реализует интерфейс IDisposable, то для работы " +
			"с ApplicationContext с автоматическим закрытием данного " +
			"объекта мы можем использовать конструкцию using.";

			Text4 =
			"Таким образом, Entity Framework Core обеспечивает простое " +
			"и удобное управление объектами из базы данных. При том в " +
			"данном случае нам не надо даже создавать базу данных и " +
			"определять в ней таблицы. Entity Framework все сделает за " +
			"нас на основе определения класса контекста данных и классов " +
			"моделей. И если база данных уже имеется, то EF не будет " +
			"повторно создавать ее.";
		}

		public string Text1 { get; set; }
		public string Text2 { get; set; }
		public string Text3 { get; set; }
		public string Text4 { get; set; }

		public string CodeText1 { get; set; }

		public List<User> Table1 { get; set; }
	}
}
