using SE1611_Group3_A2.Controller;
using SE1611_Group3_A2.Models;
using System;
using System.Collections.Generic;
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

namespace SE1611_Group3_A2.ResourceXAML
{
    /// <summary>
    /// Interaction logic for AlbumWindow.xaml
    /// </summary>
    public partial class AlbumWindow : Window
    {

        private AlbumController albumController = new AlbumController();
        private GenreController genreController = new GenreController();
        private ArtistController artistController = new ArtistController();
        public AlbumWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            List<Genre> genres = genreController.GetAllGenre();
            cbGenre.ItemsSource = genres;
            cbGenre.DisplayMemberPath = "Name";
            cbGenre.SelectedValuePath = "GenreId";
            cbGenre.SelectedIndex = 0;

            List<Artist> artists = artistController.GetAllArtist();
            cbArtist.ItemsSource = artists;
            cbArtist.DisplayMemberPath = "Name";
            cbArtist.SelectedValuePath = "ArtistId";
            cbArtist.SelectedIndex = 0;

            List<Album> albums = albumController.GetAllAlbums();

            listView.Items.Clear();

            foreach (var album in albums)
            {
                listView.Items.Add(new
                {
                    Id = album.AlbumId,
                    Genre = genreController.GetGenreByGenreId(album.GenreId),
                    Artist = artistController.GetArtistByArtistId(album.ArtistId),
                    Title = album.Title,
                    Price = album.Price,
                    AlbumUrl = album.AlbumUrl
                });
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validation() == false)
            {
                return;
            }

            int genreId = genreController.GetGenreByGenreId(int.Parse(cbGenre.SelectedValue.ToString())).GenreId;
            int artistId = artistController.GetArtistByArtistId(int.Parse(cbArtist.SelectedValue.ToString())).ArtistId;

            Album newAlbum = new Album
            {
                GenreId = genreId,
                ArtistId = artistId,
                Title = txtTitle.Text,
                Price = decimal.Parse(txtPrice.Text),
                AlbumUrl = txtAlbumUrl.Text
            };

            albumController.AddAlbum(newAlbum);
            MessageBox.Show("A new album is added");
            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Length < 1)
            {
                MessageBox.Show("Please select Album!");
                return;
            }
            else if (validation() == false)
            {
                return;
            }
            else
            {

                int genreId = genreController.GetGenreByGenreId(int.Parse(cbGenre.SelectedValue.ToString())).GenreId;
                int artistId = artistController.GetArtistByArtistId(int.Parse(cbArtist.SelectedValue.ToString())).ArtistId;

                Album newAlbum = new Album
                {
                    AlbumId = int.Parse(txtId.Text),
                    GenreId = genreId,
                    ArtistId = artistId,
                    Title = txtTitle.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    AlbumUrl = txtAlbumUrl.Text
                };

                albumController.UpdateAlbum(newAlbum);
                MessageBox.Show("This album is updated");
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Length < 1)
            {
                MessageBox.Show("Please select Album!");
                return;
            }

            int albumId = int.Parse(txtId.Text);
            Album album = albumController.GetAlbumByAlbumId(albumId);

            MessageBoxResult confirmResult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButton.YesNo);
            if (confirmResult == MessageBoxResult.Yes)
            {
                albumController.RemoveAlbum(album);
                MessageBox.Show("That album is deleted!");
                LoadData();
            }
        }
        public Boolean validation()
        {
            Boolean ischeck = true;

            if (cbGenre.Text.Length < 1)
            {
                ischeck = false;
                lbGenreErr.Visibility = Visibility.Visible;
            }
            else
            {

                lbGenreErr.Visibility = Visibility.Hidden;
            }
            if (cbArtist.Text.Length < 1)
            {
                ischeck = false;
                lbArtistErr.Visibility = Visibility.Visible;
            }
            else
            {

                lbArtistErr.Visibility = Visibility.Hidden;
            }
            if (txtTitle.Text.Length < 1)
            {
                ischeck = false;
                lbTitleErr.Visibility = Visibility.Visible;
            }
            else
            {

                lbTitleErr.Visibility = Visibility.Hidden;
            }
            if (txtPrice.Text.Length < 1)
            {
                ischeck = false;
                lbPriceErr.Visibility = Visibility.Visible;
            }
            else
            {

                lbPriceErr.Visibility = Visibility.Hidden;
            }
            if (txtAlbumUrl.Text.Length < 1)
            {
                ischeck = false;
                lbAlbumUrlErr.Visibility = Visibility.Visible;
            }
            else
            {

                lbAlbumUrlErr.Visibility = Visibility.Hidden;
            }

            return ischeck;
        }
    }
}
