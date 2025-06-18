
using CommunityToolkit.Mvvm.Messaging;
using MVVM.Messages;
using MVVM.Model;
using MVVM.ViewModel;
namespace MVVM.Tests
{
    public class UnitTest
    {
        [Fact]
        public void AddItemFunc_SendsItemAddedMessage()
        {
            var viewModel = new AddItemWindowViewModel();
            var testItem = new Item
            {
                Id = 9999999,
                Name = "TestName",
                SerialNumber = "TestSerial",
                Quantity = 9999999
            };

            viewModel.AddItem = testItem;

            Item sentItem = null;

            WeakReferenceMessenger.Default.Register<ItemAddedMessage>(this, (recipient, message) =>
            {
                sentItem = message.NewItem;
            });

            viewModel.AddItemFunc();

            Assert.NotNull(sentItem);
            Assert.Equal(testItem.Id, sentItem.Id);
            Assert.Equal(testItem.Name, sentItem.Name);
        }
    }
}