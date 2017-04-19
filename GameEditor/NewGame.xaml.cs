using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using GameEditorData.Stores;
using GameEditorModels;
using Microsoft.Win32;

namespace GameEditor
{
    /// <summary>
    /// Interaction logic for NewGame.xaml
    /// </summary>
    /// 
    /// 
   
    public partial class NewGame : Page
    {

        public static ViewModel VM;
        public NewGame()
        {
            ViewModel vm=new ViewModel();
            VM = vm;
            vm.genres = new ObservableCollection<Genre>(vm.store.ReturnGenres());
            vm.companies = new ObservableCollection<GameCompany>(vm.store.ReturnCompanies());
            InitializeComponent();

            DataContext = vm;

            Uri resourceUri = new Uri("/Images/imagebtn.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;

            AddImage.Background = brush;
        }
        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder(); // or some other encoder
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
        private void AddNewGame(object sender, RoutedEventArgs e)
        {
            
            Genre currentgenre = GenreNew.SelectedItem as Genre;
            GameCompany currentCompany = CompanyNew.SelectedItem as GameCompany;
            if (VM.store.isGameAlreadyExisting(Title.Text) == true)
            {
                MessageBox.Show("A game with the same title already exists!");

            }
            else
            {
                if (currentgenre == null || currentCompany == null ||
               Description.Text == null || Price.Text == null || Price.Text.ToString().All(char.IsDigit) == false ||
               Rating.Value == null || Title.Text == null)
                {
                    MessageBox.Show("Some of the input data is invalid!");
                }
                else
                {
                    var currentcompanyid = VM.store.ReturnGameCompanyId(currentCompany.Name);
                    var currentgenreid = VM.store.ReturnGenreId(currentgenre.Name);
                    var imagefrombyte = BitmapSourceToByteArray((BitmapSource)ImageToImport.Source);
                    Game gametoadd = new Game()
                    {
                        CreatorCompany = currentCompany,
                        CreatorCompanyId = currentcompanyid,
                        DateCreated = DateTime.Parse(DateCreated.Text),
                        Description = Description.Text,
                        Genre = currentgenre,
                        GenreId = currentgenreid,
                        Price = float.Parse(Price.Text),
                        Rate = (int)Rating.Value,
                        Title = Title.Text,
                        Image = imagefrombyte
                    };

                    gametoadd.CreatorCompany.GamesProduced.Add(gametoadd);
                    gametoadd.Genre.GamesOfGenre.Add(gametoadd);
                    VM.store.AddGame(gametoadd);
                    MessageBox.Show("Game successfully added do database! :)");
                    Description.Text = String.Empty;
                    Price.Text = String.Empty;
                    Title.Text = String.Empty;
                    DateCreated.SelectedDate = DateTime.Now;
                    Rating.Value = 0;
                    ImageToImport.Source = null;
                    GenreNew.SelectedValue = null;
                    CompanyNew.SelectedValue = null;
                }
            }
           
           
            
           
        }
       

        private void ImageSelect(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = "*.jpg";
            openfile.Filter = "Image Files|*.jpg";
            Nullable<bool> result = openfile.ShowDialog();
            if (File.Exists(openfile.FileName))
            {
                ImageToImport.Source = new BitmapImage(new Uri(openfile.FileName));

            }
           
        }

      

        private void ResetGame(object sender, RoutedEventArgs e)
        {
            Description.Text = String.Empty;
            Price.Text = String.Empty;
            Title.Text = String.Empty;
            DateCreated.SelectedDate = DateTime.Now;
            Rating.Value = 0;
            ImageToImport.Source = null;
           
            GenreNew.SelectedValue = null;
            CompanyNew.SelectedValue = null;
        }
    }
}
