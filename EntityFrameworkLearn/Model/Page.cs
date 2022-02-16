using System;

namespace EntityFrameworkLearn.Model
{
	public class Page
	{
		public string PageTitle { get; set; }
		public int PageId { get; set; }

		public Page(string pageTitle, int pageId) 
		{
			PageTitle = pageTitle;
			PageId = pageId;
		}
	}
}
