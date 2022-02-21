using System;
using System.Collections.Generic;

namespace EntityFrameworkLearn.Model
{
	public class Conclusion : Page
	{
		public Conclusion(string pageTitle, int pageId) :
			base(pageTitle, pageId)
		{
			Text1 =
			"Платформу Entity Framework Core можно применять в различных " +
			"технологиях стека .NET - консольных приложениях, программах на " +
			"WinForms, WPF, UWP, веб-приложения ASP.NET и так далее. Кроме " +
			"того, EF Core может работать с различными системами баз данных.";

			Text2 =
			"В этом учебнике были затронуты лишь самые базовые детали работы " +
			"с Entity Framework Core. Многие другие материалы вы сможете " +
			"найти в интернете или книгах. ";
		}

		public string Text1 { get; set; }
		public string Text2 { get; set; }
	}
}
