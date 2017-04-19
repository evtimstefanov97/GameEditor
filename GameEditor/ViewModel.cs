using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEditorData.Stores;
using GameEditorModels;

public class ViewModel
{
    public ViewModel()
    {
        this.genres = new ObservableCollection<Genre>();
        this.companies = new ObservableCollection<GameCompany>();
        this.games = new ObservableCollection<Game>();
        store = new GameStore();
    }


    public GameStore store { get; set; }

    public ObservableCollection<Genre> genres { get; set; }
    public ObservableCollection<Game> games { get; set; }
    public ObservableCollection<GameCompany> companies { get; set; }
}
