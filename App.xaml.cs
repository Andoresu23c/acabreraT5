using acabreraS5.Utils;
using acabreraS5.Views;

namespace acabreraS5
{
    
    public partial class App : Application
    {
        public static personRepository personRepo { get; set; }
        public App(personRepository person)
        {
            InitializeComponent();

            MainPage = new Principal();
            personRepo = person;
        }
    }
}
