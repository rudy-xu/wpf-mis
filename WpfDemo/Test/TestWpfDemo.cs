using System;
using Xunit;
using WpfDemo.ViewModels;
using System.Collections.ObjectModel;
using WpfDemo.model;
using WpfDemo.Services;
using Prism.Mvvm;
using Prism.Commands;

namespace Test
{
    public class TestWpfDemo
    {
        [Fact]
        public void TestComboBox()
        {
            MainWindowViewModel mwvm = new MainWindowViewModel();
            mwvm.PersonList.Add(new Person() { Name = "dell", Id = "1017", Job = "PO" });
            Assert.True(mwvm.PersonList.Count == 5);
        }

        [Fact]
        public void TestAdd()
        {
            MainWindowViewModel mwvm = new MainWindowViewModel();
            mwvm.NameText = "Joe";
            mwvm.IdText = "1018";
            mwvm.Add();
            Assert.True(mwvm.PersonList.Count == 5);
        }
    }
}
