using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace BindFunction
{
    public sealed partial class MainPage : INotifyPropertyChanged
    {
        public static readonly DependencyProperty TheParameterProperty = DependencyProperty.Register(
            "TheParameter", typeof(int), typeof(MainPage), new PropertyMetadata(default(int)));

        public int TheParameter
        {
            get { return (int) GetValue(TheParameterProperty); }
            set { SetValue(TheParameterProperty, value); }
        }
        public MainPage()
        {
            InitializeComponent();
        }

        internal string SimpleFunction()
        {
            return "Hello World";
        }

        internal string ReverseString(string s)
        {
            return new string(s.Reverse().ToArray());
        }

        internal int GetSlideValue(int d)
        {
            return 128;
        }

        internal void GetBackSlideValue(double value)
        {
            SlideValue.Text = $"Value : {value}";
        }

        private void EventMethod(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("It's alive!!!");
            dialog.ShowAsync();
        }

        private void AnotherEventMethod()
        {
            var dialog = new MessageDialog("It's called too !!!");
            dialog.ShowAsync();
        }

        private void SendPropertyChangedEmpty()
        {
            OnPropertyChanged(string.Empty);
        }

        private void SendPropertyChangedDummy()
        {
            OnPropertyChanged(nameof(TheParameter));
        }

        private void SendPropertyChangedParameterValue()
        {
            TheParameter++;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
