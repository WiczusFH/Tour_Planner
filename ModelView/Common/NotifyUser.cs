using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class NotifyUser
    {

        public event EventHandler<string> SuccessOccured;

        public event EventHandler<string> ErrorOccured;

        public NotifyUser()
        {
            SuccessOccured += (sender, args) =>
            {
                PopupNotificationViewModel.address.displayError(args);
            };
            ErrorOccured += (sender, args) =>
            {
                PopupNotificationViewModel.address.displayError(args);
            };
        }
        public void OnSuccess(string name)
        {
            SuccessOccured(this, name);
        }

        public void OnError(string name)
        {
            ErrorOccured(this, name);
        }
    }
}
