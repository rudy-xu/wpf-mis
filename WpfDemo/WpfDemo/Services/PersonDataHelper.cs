using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.model;

namespace WpfDemo.Services
{
    class PersonDataHelper
    {
        public static ObservableCollection<Person> GetPersons()
        {
            ObservableCollection<Person> samplePersons = new ObservableCollection<Person>();
            samplePersons.Add(new Person() { Name = "Tom", Id = "1011", Job = "HR" });
            samplePersons.Add(new Person() { Name = "Jack", Id = "1012", Job = "CFO" });
            samplePersons.Add(new Person() { Name = "Jerry", Id = "1013", Job = "PM" });
            samplePersons.Add(new Person() { Name = "Cade", Id = "1014", Job = "CEO" });

            return samplePersons;
        }

    }
}
