using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntityFrameworkLearn.Model;

namespace EntityFrameworkLearn.VM;

public class ViewModel : INotifyPropertyChanged
{

    public ViewModel()
    {
        var db = new AppDbContext();

        var users = db.Cities.ToList();
        Console.WriteLine("Список объектов:");
        foreach (Cities u in users)
        {
            Console.WriteLine($"{u.name} {u.description}");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
