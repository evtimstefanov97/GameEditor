using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using GameEditorData.Stores;
using GameEditorModels;

namespace GameEditor
{
    /// <summary>
    /// Interaction logic for GameEditWindow.xaml
    /// </summary>
    /// 
    /// 
    /// 
    public partial class GameEditWindow : Window
    {
        public class EditModel
        {
            public EditModel()
            {
                this.genres = new ObservableCollection<Genre>();
                this.companies = new ObservableCollection<GameCompany>();
            }
            public ObservableCollection<Genre> genres { get; set; }
            public ObservableCollection<GameCompany> companies { get; set; }
        }

        private Game gameforsave;
        private EditModel em=new EditModel();
        private GameStore localstore;
       
        public GameEditWindow(Game gameforedit,GameStore store)
        {
            localstore = store;
            InitializeComponent();
            InitializeComponent();
            gameforsave = gameforedit;
            Title.Text = gameforedit.Title;
            DateCreated.SelectedDate = gameforedit.DateCreated;
            Rating.Value = gameforedit.Rate;
            Description.Text = gameforedit.Description;
            Price.Text = gameforedit.Price.ToString();
            gameforsave = gameforedit;
            em.companies = new ObservableCollection<GameCompany>(store.ReturnCompanies());
            em.genres = new ObservableCollection<Genre>(store.ReturnGenres());

            DataContext = em;


        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {

            Genre currentgenre = GenreEdit.SelectedItem as Genre;
            GameCompany currentCompany = CompanyEdit.SelectedItem as GameCompany;

            var currentcompanyid = localstore.ReturnGameCompanyId(currentCompany.Name);
            var currentgenreid = localstore.ReturnGenreId(currentgenre.Name);
            gameforsave.Title = Title.Text;
            gameforsave.CreatorCompany = currentCompany;
            gameforsave.CreatorCompanyId = currentcompanyid;
            gameforsave.Price = float.Parse(Price.Text);
            gameforsave.Rate = int.Parse(Rating.Value.ToString());
            gameforsave.DateCreated = DateCreated.SelectedDate.Value;
            gameforsave.Genre = currentgenre;
            gameforsave.GenreId = currentgenreid;
            gameforsave.Image = null;
            try
            {
                localstore.SaveChanges();
                MessageBox.Show("Game edited successfully!");
                this.Close();
            }
            catch (Exception exc)
            {

                throw exc;
            }

        }

        private void EditGameReset(object sender, RoutedEventArgs e)
        {
            Description.Text = String.Empty;
            Price.Text = String.Empty;
            Title.Text = String.Empty;
            DateCreated.SelectedDate = DateTime.Now;
            Rating.Value = 0;
            GenreEdit.SelectedValue = null;
            CompanyEdit.SelectedValue = null;
        }
    }
}
