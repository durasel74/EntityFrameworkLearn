using System;

namespace EntityFrameworkLearn.Model
{
	public class Lesson2 : Page
	{
		public Lesson2(string pageTitle, int pageId) :
			base(pageTitle, pageId)
		{
			Text1 =
			"Итак, Visual Studio создает проект с базовой примитивной " +
			"структурой, где можно выделить собственно файл логики " +
			"приложения - файл Program.cs. И чтобы начать работать с " +
			"EntityFramework Core, нам необходимо вначале добавить в " +
			"проект пакет EntityFramework Core. Для этого перейдем в " +
			"проекте к пакетному менеджеру NuGet и установим пакет " +
			"Microsoft.EntityFrameworkCore.SqlServer";

			Text2 =
			"Далее нам надо определить модель, которая будет описывать " +
			"данные. Пусть наше приложение будет посвящено работе с " +
			"пользователями. Поэтому добавим в проект новый класс User:";

			CodeText1 =
			"public class User\n" +
			"{\n" +
			"    [Key]\n" +
			"    public string login { get; set; }\n" +
			"    public string password { get; set; }\n" +
			"    public DateTime birthDate { get; set; }\n\n" +
			"    [Column(\"e-mail\")]\n" +
			"    public string email { get; set; }\n" +
			"}\n";

			Text3 =
			"Это обычный класс, который содержит несколько свойств. " +
			"Каждое свойство будет сопоставляться с отдельным столбцом " +
			"в таблице из бд.";

			Text4 =
			"Надо отметить, что Entity Framework требует определения ключа " +
			"элемента для создания первичного ключа в таблице в бд. По " +
			"умолчанию при генерации бд EF в качестве первичных ключей " +
			"будет рассматривать свойства с именами Id или [Имя_класса]Id " +
			"(то есть UserId), также можно задать первичынй ключ через " +
			"аттрибут [Key].";

			Text5 =
			"Взаимодействие с базой данных в Entity Framework Core происходит " +
			"посредством специального класса - контекста данных. Поэтому добавим " +
			"в наш проект новый класс, который назовем ApplicationContext и " +
			"который будет иметь следующий код:";

			CodeText2 =
			"using Microsoft.EntityFrameworkCore;\n\n" +
			"public class ApplicationContext : DbContext\n" +
			"{\n" +
			"    public DbSet<User> Users { get; set; }\n\n" +
			"    protected override void OnConfiguring(\n" +
			"    DbContextOptionsBuilder optionsBuilder)\n" +
			"    {\n" +
			"        optionsBuilder.UseSqlServer(\"Server = (localdb)\\MSSQLLocalDB;\"+\n" +
			"        \"AttachDbFilename=|DataDirectory|\\Recources\\TourDB.mdf;Database=TourDB;\"+\n" +
			"        \"User Id=User;Password=0000;\");\n" +
			"    }\n" +
			"}\n";

			Text6 =
			"Для работы приложения с базой данной через Entity Framework необходим " +
			"контекст данных - класс производный от DbContext. В данном случае " +
			"таким контекстом является класс ApplicationContext.";

			Text7 =
			"И также в классе определено одно свойство Users, которое будет хранить " +
			"набор объектов User. В классе контекста данных набор объектов представляет " +
			"класс DbSet<T>. Через это свойство будет осуществляться связь с таблицей, " +
			"где будут храниться данные объектов User.";

			Text8 =
			"Кроме того, для настройки подключения нам надо переопределить метод " +
			"OnConfiguring. Передаваемый в него параметр класса " +
			"DbContextOptionsBuilder с помощью метода UseSqlite позволяет " +
			"настроить строку подключения для соединения с базой данных SqlServer.";
	}

		public string Text1 { get; set; }
		public string Text2 { get; set; }
		public string Text3 { get; set; }
		public string Text4 { get; set; }
		public string Text5 { get; set; }
		public string Text6 { get; set; }
		public string Text7 { get; set; }
		public string Text8 { get; set; }

		public string CodeText1 { get; set; }
		public string CodeText2 { get; set; }
	}
}
