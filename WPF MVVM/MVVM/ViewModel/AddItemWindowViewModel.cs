using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using MVVM.Data;
using MVVM.Messages;
using MVVM.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace MVVM.ViewModel
{
    public class AddItemWindowViewModel : ViewModelBase
    {
        public AppDbContext dbContext = new AppDbContext();
        public ObservableCollection<Item> Items { get; set; }
        public RelayCommand AddItemCommand => new RelayCommand(execute => AddItemFunc());

        private Item addItem;

        public Item AddItem
        {
            get { return addItem; }
            set {
                addItem = value;
                OnPropertyChanged();
            }
        }

        public AddItemWindowViewModel()
        {
            addItem = new Item();
        }

        public void AddItemFunc()
        {
            if (AddItem.Id == 0 || AddItem.Name == null || AddItem.SerialNumber == null)
            {
                MessageBox.Show("Please Enter Data Into All Available Fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingId = dbContext.Items.Find(AddItem.Id);

            if (existingId != null)
            {
                MessageBox.Show("ID already exists, please enter in another ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var dbContext = new AppDbContext();

                var newItem = new Item
                {
                    Id = AddItem.Id,
                    Name = AddItem.Name,
                    SerialNumber = AddItem.SerialNumber,
                    Quantity = AddItem.Quantity,
                };

                WeakReferenceMessenger.Default.Send(new ItemAddedMessage(newItem));
            }
        }
    }
}
