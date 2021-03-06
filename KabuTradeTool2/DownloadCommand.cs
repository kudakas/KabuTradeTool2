﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KabuTradeTool2
{
    class DownloadCommand:ICommand
    {
        public bool CanExecute(object parameter) { return true; }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }

        private Action _action;

        public DownloadCommand(Action action)
        {
            _action = action;
        }
    }
}
