using MusicStore.Infrastructure;
using MusicStore.Infrastructure.Commands;
using MusicStore.Infrastructure.Constants;
using MusicStore.Infrastructure.Facades;
using MusicStore.Infrastructure.Interfaces;
using MusicStore.Models;
using MusicStore.ViewModels.Base;
using MusicStore.Views.Windows;
using System;
using System.Windows;

namespace MusicStore.ViewModels
{
    internal class LoginModelView : ViewModel, ICloseWindow
    {
        public Action Close { get; set; }
        private string? _password = null;
        private string? _login = null;
        private DataBaseModel model;

        public LoginModelView()
        {
            model = new();

        }

        public string SetPassword
        {
            get => _password;
            set  => Set(ref _password, value);
        }

        public string SetLogin
        {
            get => _login;
            set => Set(ref _login, value); 
        }
      

        public RelayCommand Login =>
            new(w =>
            {

                if (_password is not null && _login is not null && model.CanUserLogin(_password, _login))
                {
                     Window Window;
                    if (UserConstant.UserIsAdmin)
                        Window = new AdminWindow();
                    else
                        Window = new UserWindow();
                  
                     Close?.Invoke();
                     Window.Show();
                }
                else
                  MessageBox.Show("Не верный пользователь или пароль");
            }, _ => true);
    }
}