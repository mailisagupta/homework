using ClassLibraryDataAccess;
using ClassLibraryModels;
using ClassLibraryViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DataService dataService = new();
            DataProvider dataProvider = new(dataService);
            EventAggregator eventAggregator = new();
            IRainMeasurementCollection rainC = new RainMeasurementCollection(() => dataProvider.ReturnMeasurement(),
                eventAggregator);

            ClassLibraryViewModels.ViewModel  viewModel =
                new ClassLibraryViewModels.ViewModel (rainC, dataProvider, eventAggregator);
            MainWindow mainWindow = new MainWindow(viewModel);
            mainWindow.Show();


        }
    }
}
