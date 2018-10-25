using System.Collections.Generic;
using Prism.Mvvm;
using System.Collections;
using System.Linq;
using Prism.Commands;
using System;
using System.Windows.Input;
using System.Xml.Linq;

namespace ListboxSelection.ViewModels
{
    public class MainViewModel: BindableBase
    {
        private ObservableDictionary<int, bool> availableSelection;
        private IList selected;
        private DelegateCommand selectCommand;

        public MainViewModel()
        {
            availableSelection = new ObservableDictionary<int, bool>
            {
                {1, true},
                {2, false},
                {3, true},
                {4, false},
                {5, true},
                {6, true},
                {7, true},
                {8, false}
            };
            selected = availableSelection.ToList();
        }

        public ObservableDictionary<int, bool> AvailableSelection
        {
            get { return availableSelection; }
            set { SetProperty(ref availableSelection, value); }
        }

        public IList Selected
        {
            get { return selected; }
            set
            {
                SetProperty(ref selected, value, ()=> RaisePropertyChanged(nameof(IsAllSelected))); 
                RaisePropertyChanged(nameof(Selected));
            }
        }

        public bool IsAllSelected => Selected?.Cast<KeyValuePair<int, bool>>().Count() == AvailableSelection.Count(d=> d.Value);

        public DelegateCommand SelectCommand => selectCommand ?? (selectCommand = new DelegateCommand(ExecuteSelectCommand));
            
        private void ExecuteSelectCommand()
        {

            if (IsAllSelected)
            {
                Selected = null;

            }
            else
            {
                Selected = availableSelection.Where(d=>d.Value).ToList();
            }


        }
    }
}
