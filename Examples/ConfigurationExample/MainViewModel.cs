using System;
using System.ComponentModel;
using ToastNotifications;

namespace ConfigurationExample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private NotificationsSource _notificationSource;

        public NotificationsSource NotificationSource
        {
            get { return _notificationSource; }
            set
            {
                _notificationSource = value;
                OnPropertyChanged(nameof(NotificationSource));
            }
        }

        private PopupFlowDirection _popupFlowDirection;

        public PopupFlowDirection PopupFlowDirection
        {
            get { return _popupFlowDirection; }
            set
            {
                _popupFlowDirection = value; 
                OnPropertyChanged(nameof(PopupFlowDirection));
            }
        }


        public MainViewModel()
        {
            NotificationSource = new NotificationsSource
            {
                MaximumNotificationCount = 4,
                NotificationLifeTime = TimeSpan.FromSeconds(3)
            };
        }

        public void ShowInformation(string message)
        {
            NotificationSource.Show(message, NotificationType.Information);
        }

        public void ShowSuccess(string message)
        {
            NotificationSource.Show(message, NotificationType.Success);
        }

        public void ShowWarning(string message)
        {
            NotificationSource.Show(message, NotificationType.Warning);
        }

        public void ShowError(string message)
        {
            NotificationSource.Show(message, NotificationType.Error);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}