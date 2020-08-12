using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.Mvvm;
using System.Windows.Media;

namespace DXGridSample {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }
    public class ViewModel : BindableBase {
        public ObservableCollection<Country> Countries {
            get { return GetValue<ObservableCollection<Country>>(); }
            set { SetValue(value); }
        }
        public ObservableCollection<Item> Items {
            get { return GetValue<ObservableCollection<Item>>(); }
            set { SetValue(value); }
        }

        public ViewModel() {
            Countries = new ObservableCollection<Country> {
                new Country {
                    Name = "USA",
                    Cities = new ObservableCollection<string> { "Washington, D.C.", "New York", "Los Angeles", "Las Vegas" }
                },
                new Country {
                    Name = "Germany",
                    Cities = new ObservableCollection<string> { "Berlin", "Munich", "Frankfurt" }
                },
                new Country {
                    Name = "Russia",
                    Cities = new ObservableCollection<string> { "Moscow", "Saint-Petersburg" }
                }
            };

            Items = new ObservableCollection<Item>();
            int i = 0;
            foreach (var country in Countries)
                Items.Add(new Item { Country = country, Visits = i++ });
        }
    }
    public class Item : BindableBase {
        public Country Country {
            get { return GetValue<Country>(); }
            set {
                SetValue(value);
                City = value?.Cities[0];
            }
        }
        public string City {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int Visits {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public Color Color {
            get { return GetValue<Color>(); }
            set { SetValue(value); }
        }
    }
    public class Country : BindableBase {
        public string Name {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public ObservableCollection<string> Cities {
            get { return GetValue<ObservableCollection<string>>(); }
            set { SetValue(value); }
        }
        public override string ToString() {
            return Name;
        }
    }
    public class CellTooltipConverter : MarkupExtension, IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            return values[0] != null && values[1] != null ? string.Format("{0}: {1}", values[0], values[1]) : null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}