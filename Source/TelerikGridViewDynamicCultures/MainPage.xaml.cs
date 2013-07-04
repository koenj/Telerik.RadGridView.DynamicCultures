using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace TelerikGridViewDynamicCultures
{
    public partial class MainPage : UserControl, INotifyPropertyChanged
    {

        #region Binding

        public IEnumerable<Item> Items { get; private set; }
        public IEnumerable<CultureInfo> Languages { get; private set; }

        private CultureInfo selectedLanguage;
        public CultureInfo SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                selectedLanguage = value;
                OnPropertyChanged("SelectedLanguage");
                ChangeApplicationCulture(value);
            }
        }

        #endregion


        public MainPage()
        {
            this.DataContext = this;
            this.Languages = new[]
            {
                new CultureInfo("en"), 
                new CultureInfo("fr"),
            };
            this.Items = new[]
            {
                new Item() {Name = "name1", Sequence = 1},
                new Item() {Name = "name2", Sequence = 2},
                new Item() {Name = "name3", Sequence = 3},
            };
            InitializeComponent();
            this.SelectedLanguage = this.Languages.First();
        }



        private void ChangeApplicationCulture(CultureInfo value)
        {
            Thread.CurrentThread.CurrentCulture = value;
            Thread.CurrentThread.CurrentUICulture = value;
            EventAggregator.Instance.RaiseApplicationCultureChanged();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Item
    {
        public int Sequence { get; set; }
        public string Name { get; set; }
    }
}
