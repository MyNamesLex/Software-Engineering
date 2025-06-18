// File: Messages/ItemAddedMessage.cs
using MVVM.Model;

namespace MVVM.Messages
{
    public class ItemAddedMessage
    {
        public Item NewItem { get; }

        public ItemAddedMessage(Item item)
        {
            NewItem = item;
        }
    }
}
