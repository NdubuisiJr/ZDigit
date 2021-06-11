using NdubuisiJr.Z_Digit.Data.DataBase;
using System.Windows;

namespace Z_Digit {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SynchDB();

            var boostrapper = new Bootstrapper();
            boostrapper.Run();
            
        }

        private void SynchDB()
        {
            DBConfiguration.SqliteConfiguration
                           .SynchDataBase();
        }
    }
}
