using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_IDataErrorInfo_Sample
{
    public class PersonModel : IDataErrorInfo,INotifyPropertyChanged
    {
        string name = String.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public int? Age { get; set; }
        public string Position { get; set; }

        string error = String.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        //Обработка ошибок для свойства Name
                        if (Name.Length == 0)
                            error = "Name can't be empty";
                        if (Name.Length > 8)
                            error = "Name lenth must be smaller 8";
                        if (Name.ToCharArray().Any(c => !Char.IsLetter(c)))
                            error = "Name must have only letters";
                        break;
                    case "Age":
                        if ((Age < 0) || (Age > 100))
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }
                        break;
                    case "Position":
                        //Обработка ошибок для свойства Position
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get
            {
                return (this as IDataErrorInfo).Error;
            }
        }
    }
}
