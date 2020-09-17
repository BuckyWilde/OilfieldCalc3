using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OilfieldCalc3.ViewModels
{
    public class WipeDatabaseDialogPageViewModel : IDialogAware
    {
        public DelegateCommand CloseCommand { get; }

        public WipeDatabaseDialogPageViewModel()
        {
            System.Diagnostics.Debug.WriteLine("Im the dialog bitch!");
            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
