using MusicStore.Infrastructure.Commands;
using MusicStore.Infrastructure.Interfaces;
using MusicStore.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.ViewModels
{
    internal class AdminModelView: ViewModel,ICloseWindow
    {

        public RelayCommand LogOut =>
            new(_ =>
            {
                new MainWindow().Show();
                Close?.Invoke();
            }, _ => true);

        public Action Close { get; set; }
    }
}
