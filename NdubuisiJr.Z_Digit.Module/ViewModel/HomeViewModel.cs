using Prism.Commands;
using NdubuisiJr.Z_Digit.Infrastructure;
using NdubuisiJr.Z_Digit.Infrastructure.Save;
using System.Collections.Generic;
using NdubuisiJr.Z_Digit.Domain;
using NdubuisiJr.Z_Digit.Infrastructure.Event;
using static NdubuisiJr.Z_Digit.Module.Utils.Helper;
using System;

namespace NdubuisiJr.Z_Digit.Module.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            SaveCommand = new DelegateCommand(SaveAction,SavePredicate);
            NewCommand = new DelegateCommand(NewAction,NewPredicate);
            LoadCommand = new DelegateCommand(LoadAction,LoadPredicate);
            EventAggregator.GetEvent<ViewChangedEvent>().Subscribe(ViewChangedAction);
        }

        private void ViewChangedAction() {
            SavedEntries = null;
            SaveCommand.RaiseCanExecuteChanged();
            LoadCommand.RaiseCanExecuteChanged();
            NewCommand.RaiseCanExecuteChanged();
        }

        private bool LoadPredicate() {
            return GetActiveViewModel<ISaver>() != null ? true : false;
        }

        private void LoadAction()
        {
            var entry = new Entity();
            var list = new List<Entity>();
            list.Add(entry);
            foreach (var savedEntry in GetActiveViewModel<ISaver>().LoadComboBox()) {
                list.Add(savedEntry);
            }
            SavedEntries = list;
            SelectedEntry = list[0];
            //SavedEntries = GetActiveViewModel<ISaver>().LoadComboBox();
        }

        private bool NewPredicate() {
            var result = false;
            var activeVm = GetActiveViewModel<INewable>();
            if (activeVm==null) {
                return false;
            }
            if (activeVm.GetType()==typeof(PseudoCriticalViewModel) || activeVm.GetType()==typeof(PseudoReducedViewModel)) {
                result = true;
            }
            return result;
        }

        private void NewAction()
        {
            GetActiveViewModel<INewable>()?.ClearContent();
        }

        private bool SavePredicate() {
            return GetActiveViewModel<ISaver>() != null ? true : false;
        }
        private void SaveAction()
        {
            GetActiveViewModel<ISaver>().Save();
        }

        private IEnumerable<Entity> _savedEntries;
        public IEnumerable<Entity> SavedEntries
        {
            get { return _savedEntries; }
            set
            {
                _savedEntries = value;
                RaisePropertyChanged();
            }
        }

        private Entity _selectedEntry;
        public Entity SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                if (_selectedEntry == value) { return; }
                _selectedEntry = value;
                RaisePropertyChanged();
                EventAggregator.GetEvent<SelectedEntryChangedEvent>().Publish(_selectedEntry);
            }
        }

        public DelegateCommand LoadCommand { get; }

        public DelegateCommand SaveCommand {get; }

        public DelegateCommand NewCommand { get; }
    }
}
