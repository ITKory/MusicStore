using MusicStore.ViewModels.Base;
using System;
using MusicStore.Infrastructure.Facades;
using MusicStore.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace MusicStore.ViewModels
{
  
    internal class UserModelView:ViewModel
    {
  
        private DataBaseFacade facade;
        public UserModelView()
        {
            facade = new();
    
     
            _popularAlbums = facade.GetAllPopular();
            _newRecords = facade.GetAllNewRecords();
            _publishers = facade.PublisherInfo();
            _genres = facade.GenreInfo();

        }

      

        public string search ;
        public  string Serch  
        {
            get => search;
            set
            {
                _searchableRecords = facade.SerchRecords(_genre, _publisher, OrderBy, search);
                Set(ref search, value, "GetSearchableRecords");
           
                
            }
        }


        private List<TabMusicRecord> _popularAlbums;
        public List<TabMusicRecord> GetPopular
        {
            get => _popularAlbums;
            set {
                _popularAlbums = facade.GetAllPopular();
                Set(ref _popularAlbums, value);
            }
        }

        private List<TabMusicRecord> _newRecords;
        public List<TabMusicRecord> GetNewRecords
        {
            get => _newRecords;
            set
            {
                _newRecords = facade.GetAllNewRecords();
                Set(ref _newRecords, value);
            }
        }


        private List<TabMusicRecord> _searchableRecords;
        public List<TabMusicRecord> GetSearchableRecords
        {
            get => _searchableRecords;
            set => Set(ref _searchableRecords, value);

        }

        private List<TabPublisher> _publishers;
        public List<TabPublisher> GetPublishers
        {
            get => _publishers;
            set=> Set(ref _publishers, value);
        }

        private string _publisher;
        public string SelectedPublisher
        {
            get => _publisher;
            set
            {
                Set(ref _publisher, value, "SelectedPublisher");
                UploadRecords();
            }
        }


        private List<TabGenre> _genres;
        public List<TabGenre> GetGenres
        {
            get => _genres;
            set =>  Set(ref _genres, value);
       
        }
        private string _genre;
        public string SelectedGenre
        {
            get => _genre;
            set
            {
                Set(ref _genre, value, "SelectedGenre");
                UploadRecords();

            }
        }




        private string OrderBy;
        public string SelectOldOrNew
        {
            get => OrderBy;
            set
            {
                Set(ref OrderBy, value);
                UploadRecords();
            }
        }



        private void  UploadRecords()
        {
            _searchableRecords = facade.SerchRecords(_genre, _publisher, OrderBy, search);
            OnPropertyChanged("GetSearchableRecords");

        }


    }
}
