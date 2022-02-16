using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using EntityFrameworkLearn.Model;

namespace EntityFrameworkLearn.VM;

public class ViewModel : INotifyPropertyChanged
{
    private Page selectedPage;

    public ViewModel()
    {
        // var db = new AppDbContext();

        // var tables = db.Users_Tours.ToList();
        // foreach (var table in tables)
        // {
        //     string output = $"{table.userLogin} {table.tourName} " +
        //$"{table.tourDate}";
        //     Console.WriteLine(output);
        // }

        Pages = new ObservableCollection<Page> 
        { 
            new Page("GrayPage", 0),
            new Page("MainPage", 1),
        };
        SelectedPage = Pages[0];
    }

    public ObservableCollection<String> PagesList { get; set; }
    public ObservableCollection<Page> Pages { get; set; }

    public Page SelectedPage
    {
        get { return selectedPage; }
        set
		{
            selectedPage = value;
            OnPropertyChanged("SelectedPage");
		}
	}

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
