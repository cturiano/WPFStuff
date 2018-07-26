using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Chat.Core.ViewModels
{
    public class ChatListViewModel : BaseViewModel
    {
        #region Constructors

        public ChatListViewModel() => Items.CollectionChanged += CollectionChanged;

        #endregion

        #region Properties

        public ObservableCollection<ChatListItemViewModel> Items { get; protected set; } = new ObservableCollection<ChatListItemViewModel>();

        #endregion

        #region Private Methods

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<ChatListItemViewModel> items)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        items[e.NewStartingIndex].PropertyChanged += Item_PropertyChanged;
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        items[e.NewStartingIndex].PropertyChanged -= Item_PropertyChanged;
                        break;
                }
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                foreach (var item in Items)
                {
                    if (ReferenceEquals(item, sender))
                    {
                        continue;
                    }

                    item.PropertyChanged -= Item_PropertyChanged;
                    item.IsSelected = false;
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
        }

        #endregion
    }
}