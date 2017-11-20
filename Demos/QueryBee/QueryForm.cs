using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QueryBee
{
    public partial class QueryForm : Form
    {
        private readonly SqlConnection m_connection;

        public QueryForm(SqlConnection aConnection, ConnectForm parentConnectForm)
        {
            InitializeComponent();

            //Remember the connection
            m_connection = aConnection;

            //Subscribe to the foregrounded event so we are notified when the hotkey is pressed
            parentConnectForm.Foregrounded += OnForegrounded;
        }

        private void OnForegrounded(object sender, EventArgs e)
        {
            //Restore the form
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            //Focus it
            Activate();
        }

        private void m_execute_Click(object sender, EventArgs e)
        {
            //Set up the form to be "in progress"
            m_labelErrorTri.Visible = false;
            m_labelError.Visible = false;
            m_progress.Visible = true;
            
            //Set a background thread to do the request
            System.Threading.ThreadPool.QueueUserWorkItem(
                delegate
                    {
                        //First, check that the connection is still working
                        if (m_connection.State != ConnectionState.Open)
                        {
                            //It isn't normal, leave a message
                            try
                            {
                                BeginInvoke((MethodInvoker)
                                       delegate
                                           {
                                               m_labelErrorTri.Visible = true;
                                               m_labelError.Visible = true;
                                               m_labelError.Text = "The connection has been lost";
                                           });
                            }
                            catch (InvalidOperationException)
                            {
                                //This is probably just because the window is closing
                            }

                            //And give up
                            return;
                        }

                        //Now, try to get some data
                        try
                        {

                            using (SqlCommand aCommand = new SqlCommand(m_textQuery.Text, m_connection))
                            {
                                using (SqlDataReader aReader = aCommand.ExecuteReader())
                                {

                                    DataSet ds = new DataSet();
                                    DataTable dt = new DataTable("Table1");
                                    ds.Tables.Add(dt);
                                    ds.Load(aReader, LoadOption.PreserveChanges, ds.Tables[0]);

                                    RedGate.Profiler.UserEvents.ProfilerEvent.SignalEvent(
                                        "Telling foreground to render table");

                                    //Ask the forground thread to show it
                                    try
                                    {
                                        BeginInvoke((MethodInvoker)
                                               delegate
                                                   {
                                                       m_dataGridView.DataSource = ds.Tables[0];
                                                   });
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        //This is probably just because the window is closing
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //Something went wrong with the query
                            //Ask the foreground thread to leave a message
                            try
                            {
                                BeginInvoke((MethodInvoker)
                                       delegate
                                           {
                                               m_labelErrorTri.Visible = true;
                                               m_labelError.Visible = true;
                                               m_labelError.Text = ex.Message;
                                           });
                            }
                            catch (InvalidOperationException)
                            {
                                //This is probably just because the window is closing
                            }
                        }

                        //Reset the form ready for the next query
                        try
                        {
                            BeginInvoke((MethodInvoker)
                                   delegate
                                       {
                                           m_textQuery.SelectAll();
                                           m_textQuery.Focus();
                                           m_progress.Visible = false;
                                       });
                        }
                        catch (InvalidOperationException)
                        {
                            //This is probably just because the window is closing
                        }

                    });
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            //Select the instruction so you can immediately start typing
            m_textQuery.Select();
        }

        private void QueryForm_Resize(object sender, EventArgs e)
        {
            //Move the progress bar depending on the window's size
            m_progress.Location = new Point((Size.Width-m_progress.Size.Width)/2, (Size.Height-90)/2);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Detect the escape key and close
            if (keyData == Keys.Escape)
            {
                //It is esc, close
                Close();
                return true;
            }

            //It's not esc, pass to base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}