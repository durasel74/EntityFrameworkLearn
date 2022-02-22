using System;
using System.Collections.Generic;
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

    private List<User> users;
    private List<User> usersAdd;
    private List<User> usersAddRange;
    private List<User> usersDelete;
    private List<User> usersDeleteRange;
    private List<User> usersUpdate;

    public ViewModel()
    {
        using (AppDbContext db = new AppDbContext())
        {
			users = db.Users.ToList();

            usersAdd = users.GetRange(0, users.Count);
            var newUser = new User { login = "Новый Пользователь", password = "0000",
                birthDate=DateTime.Now, email="New@mail.ru"};
            usersAdd.Add(newUser);

            usersAddRange = usersAdd.GetRange(0, usersAdd.Count);
            var newUser1 = new User {login = "Новый1", password = "0000",
                birthDate = DateTime.Now, email = "New1@mail.ru"};
            var newUser2 = new User {login = "Новый2", password = "0000",
                birthDate = DateTime.Now, email = "New2@mail.ru"};
            usersAddRange.AddRange(new List<User> { newUser1, newUser2 });

            usersDelete = usersAddRange.GetRange(0, usersAddRange.Count);
            usersDelete.Remove(newUser);
            usersDeleteRange = usersDelete.GetRange(0, usersDelete.Count);
            usersDeleteRange.RemoveRange(usersDelete.IndexOf(newUser1), 2);

            usersUpdate = usersAddRange.GetRange(0, usersAddRange.Count);
            newUser.login = "Измененный Пользователь";
        }

        menuVisible = false;
        Pages = new ObservableCollection<Page>
        {
            new Page("Главная", 0),
            new Lesson1("Введение в Entity Framework Core", 1),
            new Lesson2("Первое приложение Entity Framework", 2),
            new Lesson3("Пример работы", 3) { Table1 = users },
            new Lesson4("Добавление", 4) { Table1 = usersAdd, 
                Table2 = usersAddRange },
            new Lesson5("Удаление", 5) { Table1 = usersDelete,
                Table2 = usersDeleteRange },
            new Lesson6("Редактирование", 6) { Table1 = usersUpdate },
            new Conclusion("Заключение", 7),
        };
        SelectedPage = Pages[0];
        mainPage = Pages[0];
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
              (obj) => SelectedPage.PageId > 1));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
