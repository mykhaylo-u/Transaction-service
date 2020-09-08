using System;

namespace transaction_service.web.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {

        }
        public BaseViewModel(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; set; }
    }
}
