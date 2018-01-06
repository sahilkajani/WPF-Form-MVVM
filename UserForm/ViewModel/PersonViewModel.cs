using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserForm.Command;
using UserForm.Model;

namespace UserForm.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        public PersonViewModel()
        {
            Person = new Person();
            Persons = new ObservableCollection<Person>();
        }


        private Person _person;
       public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                NotifyPropertyChanged("Person");
            }
        }

        

        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        { 
            get
            {
                return _persons;
            }
            set
            {
                _persons = value;
                NotifyPropertyChanged("Persons");
            }
        }

        private ICommand _SubmitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if(_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);

                }
                return _SubmitCommand;
            }
        }

        private void SubmitExecute(object paramter)
        {
            Persons.Add(Person);
            System.Windows.MessageBox.Show("Saved Successfully!","Confirmation");
        }

        private bool CanSubmitExecute(object parameter)
        {

            if (string.IsNullOrEmpty(Person.FName) || string.IsNullOrEmpty(Person.LName))
            {
                return false;
            }
            else
            {
                return true;
            }
                 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
                ph(this, new PropertyChangedEventArgs(p));
        }
    }
}
