using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;

//using WpfDemo.Commands;
using WpfDemo.model;
using WpfDemo.Services;

namespace WpfDemo.ViewModels
{
    public class MainWindowViewModel: BindableBase    //  NotificationObject
    {

        #region Fields
        //private ObservableCollection<string> _combList;
        private ObservableCollection<Person> _personList;
        private string _userInfo;
        private Person _mySelectedItem;

        private string _nameText;
        private string _idText;

        private string _lbError;
        private string _bdColor;


        private DelegateCommand _addCommand;
        #endregion  //Fields

        #region  Constructors
        public MainWindowViewModel()
        {
            PersonList = PersonDataHelper.GetPersons();

            //ObservableCollection<string> userNameList = new ObservableCollection<string>();

            //foreach (Person p in PersonList)
            //{
            //    userNameList.Add(p.Name);
            //}

            //_combList = userNameList;
            BdColor = "Black";
            _lbError = "Hidden";
        }
        #endregion  //Constructors


        #region Properties
        public ObservableCollection<Person> PersonList
        {
            //{ get; private set; }
            get 
            {
                return _personList;
            }
            set 
            {
                SetProperty(ref _personList, value);
            }
        }

        //public ObservableCollection<string> CombList
        //{
        //    get
        //    {
        //        return _combList;  
        //    }
        //    set 
        //    {
        //        SetProperty(ref _combList, value);
        //        //_combList = value;
        //        //RaisePropertyChange("CombList");
        //    }
        //}

        public string UserInfo
        {
            get
            {
                return _userInfo;
            }
            set
            {
                SetProperty(ref _userInfo, value);
                //_userInfo = value;
                //RaisePropertyChange("UserInfo");
            }
        }

        public Person MySelectedItem
        {
            get { return _mySelectedItem; }
            set 
            {
                Console.WriteLine(value);
                SetProperty(ref _mySelectedItem, value);
                UpdateUserInfo();
                //_mySelectedItem = value;
                //RaisePropertyChange("MySelectedItem"); 
            }
        }

        public void UpdateUserInfo()
        {
            foreach (Person p in PersonList)
            {
                if (p.Name.Equals(MySelectedItem.Name))
                {
                    UserInfo = $"Id:{p.Id}, Name:{p.Name}, Job:{p.Job}";
                }
            }
        }

        public string NameText
        {
            get { return _nameText; }
            set
            {
                SetProperty(ref _nameText, value);
                //_nameText = value;
                //RaisePropertyChange("NameText");
            }
        }

        public string IdText
        {
            get { return _idText; }
            set
            {
                SetProperty(ref _idText, value);
                //_idText = value;
                //RaisePropertyChange("IdText");
            }
        }

        public string LbError
        {
            get { return _lbError; }
            set
            {
                SetProperty(ref _lbError, value);
                //_lbError = value;
                //RaisePropertyChange("LbError");
            }
        }

        public string BdColor
        {
            get { return _bdColor; }
            set
            {
                SetProperty(ref _bdColor, value);
                //_bdColor = value;
                //RaisePropertyChange("BdColor");
            }
        }

        #endregion  //Properties


        #region  ICommand

        public DelegateCommand AddCommand => _addCommand ?? (_addCommand = new DelegateCommand(Add));
        //public ICommand AddCommand 
        //{
        //    get { return new DelegateCommand(Add); }
        //}



        public void Add() //object parameter)
        {
            string pattern = @"^[0-9]+$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(IdText))
            {
                LbError = "Visiable";
                BdColor = "Red";
                return;
            }
            
            Person tmpPerson = new Person() { Name = NameText, Id = IdText, Job = "" };
            PersonList.Add(tmpPerson);

            //ObservableCollection<string> tempList = new ObservableCollection<string>();

            //foreach (Person p in PersonList)
            //{
            //    tempList.Add(p.Name);
            //}

            /*
             * Notes:
             * _combList = tempList
             * The way of above writing can not active Updating <ComboBox> source.
             * Because the "_combList" is just a variable, this step just assignment.
             * So, must distinguish the variable and property, the property is more like a variable of including "get" and "set". You can operate it like variable
             * Normally, the private varibale mustn't be modified, However, the property can modify, so you can define the property to modify private variable.
             */
            //CombList = tempList; //update the source of <ComboBox>
            NameText = "";
            IdText = "";
            LbError = "Hidden";
            BdColor = "";
        }
        #endregion  //ICommand
    }
}
