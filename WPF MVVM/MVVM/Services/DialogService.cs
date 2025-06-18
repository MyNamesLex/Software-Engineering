using MVVM.View;

namespace MVVM.Services
{
    public class DialogService
    {
        public void ShowAddItemWindow()
        {
            var window = new AddItemWindow();
            window.ShowDialog();
        }
    }
}
