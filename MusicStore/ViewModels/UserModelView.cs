using MusicStore.Data;
using MusicStore.Infrastructure.Commands;
using MusicStore.Infrastructure.Constants;
using MusicStore.Infrastructure.Interfaces;
using MusicStore.Models;
using MusicStore.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MusicStore.ViewModels
{
    internal class UserModelView : ViewModel, ICloseWindow
    {
        private DataBaseModel BDModel;

        public UserModelView()
        {
            BDModel = new();
            _basket = new(BDModel.GetBasket(UserConstant.UserId));
            _popularAlbums = BDModel.GetAllPopular();
            _publishers = BDModel.PublisherInfo();
            _newRecords = BDModel.GetAllNewRecords();
            _genres = BDModel.GenreInfo();
            _history = BDModel.GetHistory(UserConstant.UserId);
        }

        private string _search;
        private List<TabMusicRecord> _popularAlbums;
        private List<TabMusicRecord> _newRecords;
        private List<TabPurchaseHistory> _basket;
        private List<TabMusicRecord> _searchableRecords;
        private List<TabPublisher> _publishers;
        private List<TabSale> _history;
        private List<TabGenre> _genres;
        private string _publisher;
        private string _genre;

        public string Serch
        {
            get => _search;
            set
            {
                Set(ref _search, value);
                _searchableRecords = BDModel.SerchRecords(_genre, _publisher, _search);
                OnPropertyChanged("GetSearchableRecords");
            }
        }

        public List<TabPurchaseHistory> GetBasket
        {
            get => _basket;
            set => Set(ref _basket, value, "GetBasket");
        }

        public List<TabMusicRecord> GetPopular
             => _popularAlbums;

        public List<TabMusicRecord> GetNewRecords
             => _newRecords;

        public List<TabMusicRecord> GetSearchableRecords
            => _searchableRecords;

        public List<TabPublisher> GetPublishers
            => _publishers;

        public List<TabSale> GetHistory
            => _history;

        public List<TabGenre> GetGenres
           => _genres;

        public string SelectedPublisher
        {
            get => _publisher;
            set
            {
                Set(ref _publisher, value, "SelectedPublisher");
                UploadRecords();
            }
        }

        public string SelectedGenre
        {
            get => _genre;
            set
            {
                Set(ref _genre, value, "SelectedGenre");
                UploadRecords();
            }
        }

        private void UploadRecords()
        {
            OnPropertyChanged("GetSearchableRecords");
            _searchableRecords = BDModel.SerchRecords(_genre, _publisher, _search);
        }

        public RelayCommand Increment =>
            new(rId =>
            {
                int irId = Convert.ToInt32(rId);

                BDModel.IncrementRecordsCount(_basket, irId);
                BDModel = new DataBaseModel();
                _basket = new(BDModel.GetBasket(UserConstant.UserId));
                OnPropertyChanged("GetBasket");
            }, _ => true);

        public RelayCommand Decrement =>
              new(rId =>
              {
                  BDModel.DecrementRecordsCount(_basket, Convert.ToInt32(rId));
                  BDModel = new DataBaseModel();
                  _basket = new(BDModel.GetBasket(UserConstant.UserId));

                  OnPropertyChanged("GetBasket");
              }, _ => true);

        public RelayCommand BuyAll =>
                    new(rId =>
                    {
                        BDModel.BuyAll(_basket);
                        BDModel.ClearBasket(UserConstant.UserId);

                        BDModel = new DataBaseModel();

                        _basket = BDModel.GetBasket(UserConstant.UserId);
                        _history = BDModel.GetHistory(UserConstant.UserId);
                    }, _ => true);

        public RelayCommand LogOut =>
            new(_ =>
            {
             
               new MainWindow().Show();
                Close?.Invoke();
            }, _ => true);

        public Action Close { get; set; }

        public RelayCommand Clear =>
                new(rId =>
                {
                    MessageBox.Show("dell?", "dell", new MessageBoxButton());
                    BDModel.ClearBasket(UserConstant.UserId);

                    BDModel = new DataBaseModel();
                    _basket = new(BDModel.GetBasket(UserConstant.UserId));
                }, _ => true);
    }
}