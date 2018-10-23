using System;
using System.ComponentModel;
using System.Linq;
using WpfFluentValidationExample.Lib;

namespace WPF_IDataErrorInfo_Sample.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly UserValidator _userValidator;
        private string _zip;
        private string _email;
        private string _name;
        private int? _age=null;

        public UserViewModel()
        {
            _userValidator = new UserValidator();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                OnPropertyChanged("Zip");
                
            }
        }

        public int? Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public string this[string columnName]
        {
            get
            {
                var firstError = _userValidator.Validate(this).Errors.FirstOrDefault(e => e.PropertyName == columnName);
                if (firstError != null)
                    return _userValidator != null ? firstError.ErrorMessage : "";
                return "";
            }
        }

        public string Error
        {
            get
            {
                if (_userValidator != null)
                {
                    var results = _userValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

             public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
