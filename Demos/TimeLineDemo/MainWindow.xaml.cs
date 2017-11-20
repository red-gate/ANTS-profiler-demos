using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RedGate.PrimalityTests;

namespace RedGate.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : Window
    {
        private readonly ObservableCollection<ResultSet> m_data;
        private readonly PrimeTable m_primeTable;
        private readonly ApplicationOptions m_options;
        private ConfigurationDialog m_configurationDialog;
        private bool m_taskInProgress;

        internal MainWindow()
        {
            InitializeComponent();
        }

        internal MainWindow(PrimeTable primeTable) : this()
        {
            m_data = new ObservableCollection<ResultSet>();
            dataGrid1.ItemsSource = m_data;
            m_primeTable = primeTable;
            m_options = new ApplicationOptions
                            {
                                MaxPrime = m_primeTable.MaxPrimeKnown,
                                SampleSize = 500000,
                                MaxRandom = m_primeTable.MaxPrimeKnown * 2,
#if MILLER_RABIN
            Algorithm = PrimalityAlgorithm.MillerRabin
#else
            Algorithm = PrimalityAlgorithm.BruteForce
#endif
                            };
            m_taskInProgress = false;
        }

        private void GoButtonClick(object sender, RoutedEventArgs e)
        {
            m_taskInProgress = true;
            goButton.IsEnabled = false;
            var theTask = new Task<ResultSet>(
                                              () => ResultSet.Generate(m_options, m_primeTable)
                                             );
            theTask.ContinueWith(task => Dispatcher.Invoke(new Action(() =>
                                                                          {
                                                                              m_data.Add(task.Result);
                                                                              goButton.IsEnabled = true;
                                                                              m_taskInProgress = false;
                                                                          })));
            theTask.Start();
        }

        /// <summary>
        /// Display the configuration dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(m_taskInProgress)
                return;

            if (m_configurationDialog == null)
            {
                m_configurationDialog = new ConfigurationDialog(m_options) {Owner = this};
            }

            m_configurationDialog.ShowDialog();
        }

        private void DataGridAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.PropertyName == "PrimePercentage")
            {
                DataGridTextColumn column = e.Column as DataGridTextColumn;
                column.Binding.StringFormat = "{0:#0.##%}";
            }
        }
    }
}
