using CommunityToolkit.Mvvm.Messaging;
using MVVM.Data;
using MVVM.Model;
using MVVM.Services;
using MVVM.Messages;
using System.Collections.ObjectModel;
using System.Windows;

namespace MVVM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DialogService _dialogService;

        public AppDbContext dbContext = new AppDbContext();

        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => OpenAddItemWindow());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);

        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());

        public MainWindowViewModel(DialogService dialogService)
        {
            Items = new ObservableCollection<Item>();
            LoadItemsFromDatabase(dialogService);

            WeakReferenceMessenger.Default.Register<ItemAddedMessage>(this, OnItemAddedMessageReceived);
        }

        public Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private double opacity = 1.0f;

        public double Opacity
        {
            get { return opacity; }
            set {
                opacity = value;
                OnPropertyChanged();
            }
        }

        private void OnItemAddedMessageReceived(object recipient, ItemAddedMessage message)
        {
            Items.Add(message.NewItem);
        }

        private void LoadItemsFromDatabase(DialogService dialogService)
        {
            var itemsFromDb = dbContext.Items.ToList();

            Items.Clear();

            _dialogService = dialogService;

            foreach (var item in itemsFromDb)
            {
                Items.Add(item);
            }
        }

        private void OpenAddItemWindow()
        {
            Opacity = 0.4f;
            _dialogService.ShowAddItemWindow();
            Opacity = 1f;
        }

        public void DeleteItem()
        {
            MessageBoxResult box = MessageBox.Show($"Are you sure you want to delete the Item with ID: {SelectedItem.Id}?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (box == MessageBoxResult.Yes)
            {
                dbContext.Items.Remove(SelectedItem);
                Items.Remove(SelectedItem);
                SelectedItem = null;
            }
            else
            {
                return;
            }
        }

        private void Save()
        {
            MessageBoxResult box = MessageBox.Show("Save Changes?", "Save?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (box == MessageBoxResult.Yes)
            {
                foreach (var newItem in Items)
                {
                    var existing = dbContext.Items.Find(newItem.Id);

                    if (existing != null)
                    {

                    }
                    else
                    {
                        dbContext.Items.Add(newItem);
                    }
                }
                MessageBox.Show("Saved", "Saved Changes", MessageBoxButton.OK, MessageBoxImage.Information);
                dbContext.SaveChanges();
            }
            else
            {
                return;
            }
        }

        private bool CanSave()
        {
            return true;
        }
    }
}
