using MusicStore.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Infrastructure.Commands
{
    internal class RelayCommand : Command
    {
        private readonly Action<object> _Action;
        private readonly Func<object, bool> _CanExecute;

        public RelayCommand(Action<object> action, Func<object, bool> CanExecute)
        {
            _Action = action ?? throw new ArgumentNullException(nameof(action));
            _CanExecute = CanExecute;
        }
        public override bool CanExecute(object? parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter) => _Action(parameter);
    }
}
