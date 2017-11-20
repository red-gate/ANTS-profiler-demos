using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace RedGate.Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class InitializationWindow : Window
    {
        /// <summary>
        /// The maximum time to run the progress bar for
        /// </summary>
        private const int ProgressBarTimeInSeconds = 5;
        /// <summary>
        /// The number of primes to attempt to create
        /// </summary>
        private const int TableSize = 100000;

        public InitializationWindow()
        {
            Thread.CurrentThread.Name = "UI Thread";
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Create the table of primes, and then run the main application
            Task<PrimeTable> updateTask = new Task<PrimeTable>(PrimeTableCreationTask);
            updateTask.ContinueWith(task => { Dispatcher.Invoke(new Action(() => RunMainApplication(task.Result))); });
            updateTask.Start();
        }

        /// <summary>
        /// Update the progress bar according to how close expiry is
        /// </summary>
        /// <param name="expiryTime">The expiry time</param>
        /// <param name="expiryInterval">How long the 'countdown' was for</param>
        private void UpdateProgressBar(DateTime expiryTime, long expiryInterval)
        {
            double timeLeft = expiryTime.Ticks - DateTime.UtcNow.Ticks;
            progressBar1.Value = Math.Min(100.0, 100.0 * (1.0 - timeLeft / expiryInterval));
        }

        private PrimeTable PrimeTableCreationTask()
        {
            PrimeTable primeTable = new PrimeTable();
            RedGate.Profiler.UserEvents.ProfilerEvent.SignalEvent("Beginning initialization");
            Thread.CurrentThread.Name = "ProgressUpdate";
            // Expiry time data
            DateTime expiry = DateTime.UtcNow.AddSeconds(ProgressBarTimeInSeconds);
            long expiryIntervalInTicks = DateTime.MinValue.AddSeconds(ProgressBarTimeInSeconds).Ticks;

            var cTokenSource = new CancellationTokenSource();
            var cToken = cTokenSource.Token;
            var primeGenerationTask = Task.Factory.StartNew(() => primeTable.CreatePrimes(TableSize, cToken), cToken);
            // This is close enough to the correct interval
            var waitingTask = Task.Factory.StartNew(() => Thread.Sleep(TimeSpan.FromSeconds(ProgressBarTimeInSeconds)));
            // Schedule updates to the progress bar
            var dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), 
                                                      DispatcherPriority.Normal,
                                                      (sender, e) => UpdateProgressBar(expiry, expiryIntervalInTicks),
                                                      Dispatcher);

            dispatcherTimer.Start();
            // Either the task will complete in time, or the waiting task will finish first
            int completedTaskIndex = Task.WaitAny(new[] {primeGenerationTask, waitingTask});
            dispatcherTimer.Stop();

            if (completedTaskIndex == 1)
            {
                // The task didn't complete in time, so cancel it
                cTokenSource.Cancel();
                // Wait for acknowledgement (or it may have completed)
                while (primeGenerationTask.Status != TaskStatus.Canceled && !primeGenerationTask.IsCompleted) {}
            }

            RedGate.Profiler.UserEvents.ProfilerEvent.SignalEvent("Initialization complete");
            return primeTable;
        }

        private void RunMainApplication(PrimeTable p)
        {
            MainWindow mw = new MainWindow(p);
            RedGate.Profiler.UserEvents.ProfilerEvent.SignalEvent("Main window created");
            Close();
            mw.Show();
        }
    }
}
