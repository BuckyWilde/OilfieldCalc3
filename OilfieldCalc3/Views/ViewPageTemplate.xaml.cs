using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OilfieldCalc3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ContentProperty("Child")]
    public partial class ViewPageTemplate : ContentView
    {
        public ViewPageTemplate()
        {
            InitializeComponent();
        }

        public View Header
        {
            get => HeaderContent.Content;
            set => HeaderContent.Content = value;
        }
        public View Body
        {
            get => BodyContent.Content;
            set => BodyContent.Content = value;
        }
        public View Footer
        {
            get => FooterContent.Content;
            set => FooterContent.Content = value;
        }
    }
}