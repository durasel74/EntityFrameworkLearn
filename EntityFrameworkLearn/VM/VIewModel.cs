using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using EntityFrameworkLearn.Model;

namespace EntityFrameworkLearn.VM;

public class ViewModel : INotifyPropertyChanged
{
    private bool menuVisible;
    private Page selectedPage;
    private Page mainPage;

    public ViewModel()
    {
		var db = new AppDbContext();

		var tables = db.Users_Tours.ToList();
		foreach (var table in tables)
		{
			string output = $"{table.userLogin} {table.tourName} " +
	            $"{table.tourDate}";
			Console.WriteLine(output);
		}

		menuVisible = false;
        Pages = new ObservableCollection<Page>
        {
            new GrayPageClass("ТЕСТОВАЯ СТРАНИЦА", 0),
            new Page("Главная", 1),
            new Lesson1("Введение в Entity Framework Core", 2),
        };
        SelectedPage = Pages[0];
        mainPage = Pages[1];
    }
    
    public ObservableCollection<String> PagesList { get; set; }
    public ObservableCollection<Page> Pages { get; set; }

    public bool MenuVisible
    {
        get { return menuVisible; }
        set
		{
            menuVisible = value;
            OnPropertyChanged("MenuVisible");
		}
    }

    public Page SelectedPage
    {
        get { return selectedPage; }
        set
		{
            selectedPage = value;
            OnPropertyChanged("SelectedPage");
		}
	}

    private ButtonCommand goMainPageCommand;
    public ButtonCommand GoMainPageCommand
    {
        get
        {
            return goMainPageCommand ??
              (goMainPageCommand = new ButtonCommand(obj =>
              {
                  SelectedPage = mainPage;
              }));
        }
    }

    private ButtonCommand goNextPageCommand;
    public ButtonCommand GoNextPageCommand
    {
        get
        {
            return goNextPageCommand ??
              (goNextPageCommand = new ButtonCommand(obj =>
              {
                  SelectedPage = Pages[SelectedPage.PageId + 1];
              },
              (obj) => SelectedPage.PageId < Pages.Count - 1));
        }
    }

    private ButtonCommand goBackPageCommand;
    public ButtonCommand GoBackPageCommand
    {
        get
        {
            return goBackPageCommand ??
              (goBackPageCommand = new ButtonCommand(obj =>
              {
                  SelectedPage = Pages[SelectedPage.PageId - 1];
              },
              (obj) => SelectedPage.PageId > 0));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
