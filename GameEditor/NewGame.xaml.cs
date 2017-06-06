using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameEditorModels;
using Newtonsoft.Json;

namespace GameEditor
{
    /// <summary>
    /// Interaction logic for GameSearch.xaml
    /// </summary>
    public partial class GameSearch : Page
    {

        private static ViewModel vm = new ViewModel();
        public ObservableCollection<Game> gamesforexport;
        public ObservableCollection<Game> games;
        public GameSearch()
        {
            
            InitializeComponent();




            vm.genres = new ObservableCollection<Genre>(vm.store.ReturnGenres());
            vm.companies = new ObservableCollection<GameCompany>(vm.store.ReturnCompanies());
            games=new ObservableCollection<Game>(vm.store.ReturnGames());
            DataContext = vm;
            GamesList.ItemsSource = games;

        }

        private void ApplyFilters(object sender, RoutedEventArgs e)
        {
            var selectedcompany = CompanyBox.SelectedItem;
            var selectedgenre = GenreBox.SelectedItem;         
            var orderbyprice = PriceRadio.IsChecked;
            var orderbyrate = RateRadio.IsChecked;
            if (orderbyprice == true)
            {
                games =
                    new ObservableCollection<Game>(
                        vm.store.ReturnGames()
                            .Where(x => x.CreatorCompany == selectedcompany && x.Genre == selectedgenre)
                            .OrderByDescending(c => c.Price));
            }
            else if (orderbyrate == true)
            {
                games =
                    new ObservableCollection<Game>(
                        vm.store.ReturnGames()
                            .Where(x => x.CreatorCompany == selectedcompany && x.Genre == selectedgenre)
                            .OrderByDescending(c => c.Rate));
            }
            GamesList.ItemsSource = games;
            gamesforexport = games;

        }
        
        private void ExportJSON(object sender, RoutedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(gamesforexport.Select(x => new
            {
                Name = x.Title,
                Price = x.Price,
                Rating = x.Rate,
                CreatedBy = x.CreatorCompany.Name,
                Genre = x.Genre.Name
            }), Formatting.Indented);
            GameCompany companynameexport = (GameCompany) CompanyBox.SelectedItem;

            try
            {
                File.WriteAllText($"../../Exports/games-by-{companynameexport.Name}.json", json);
                MessageBox.Show("Successfully exported your games! Look in Exports folder :)");
            }
            catch (Exception exc)
            {

                MessageBox.Show("Oops! Something went wrong :(");
            }

        }

        private void EditSelected(object sender, RoutedEventArgs e)
        {
            var currentgame = (Game) GamesList.SelectedItem;
            if (currentgame == null)
            {
                MessageBox.Show("No game selected");
            }
            else
            {
                var test = ((MainWindow)Application.Current.MainWindow);

                GameEditWindow win2 = new GameEditWindow(currentgame, vm.store);

                win2.CompanyEdit.SelectedIndex = this.CompanyBox.SelectedIndex;
                win2.GenreEdit.SelectedIndex = this.GenreBox.SelectedIndex;
                win2.Show();
            }
         

        }

        private void DeleteSelected(object sender, RoutedEventArgs e)
        {
            var gamefordelete = (Game) GamesList.SelectedItem;
            if (gamefordelete == null)
            {
                MessageBox.Show("No game selected");

            }
            else
            {
                try
                {
                    vm.store.DeleteEntry(gamefordelete);
                    games.Remove(gamefordelete);
                    MessageBox.Show("Selected game has been deleted!");
                    
                }
                catch (Exception exc)
                {

                    throw exc;
                }
            }
          
           
        }
    }
}
