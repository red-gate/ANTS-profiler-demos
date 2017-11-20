using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QueryBee
{
    public partial class ConnectForm : Form
    {
        public event EventHandler Foregrounded;

        public ConnectForm()
        {
            InitializeComponent();

            //Bind the hotkey
            m_hotkey = new SystemHotkey(components);
            m_hotkey.Shortcut = Shortcut.CtrlQ;
            m_hotkey.Pressed += m_trayIcon_DoubleClick;

            //Set up an event handler to hide when minimized
            Resize += connectForm_Resize;

            //And hide to start with
            Visible = false;
        }

        private void connectForm_Resize(object sender, EventArgs e)
        {
            //When the window gets minimized, hide from the taskbar
            if (WindowState == FormWindowState.Minimized)
                Visible = false;
        }


        private void m_trayIcon_DoubleClick(object sender, EventArgs e)
        {
            //Fire the event so any QueryForms know to become foregrounded too
            if (Foregrounded != null)
            {
                Foregrounded(this, EventArgs.Empty);
            }

            //Bring the form back
            Visible = true;
            WindowState = FormWindowState.Normal;

            //Focus it
            Activate();
        }

        private void m_trayMenuOpen_Click(object sender, EventArgs e)
        {
            m_trayIcon_DoubleClick(sender, e);
        }

        private void m_trayMenuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_comboDatabase_clickIn(object sender, EventArgs e)
        {
            //Set the form up to be "in progress"
            m_connectProgress.Visible = true;
            m_labelError.Visible = false;

            //Prepare the variables the other thread will need
            String hostName = m_comboServer.Text;

            //A background thread to connect to the server and get a list of databases
            System.Threading.ThreadPool.QueueUserWorkItem(
                delegate
                    {
                        try
                        {
                            //Do the request
                            SqlConnection aConnection =
                                new SqlConnection("Data Source=" + hostName + "; Integrated Security=True;");
                            aConnection.Open();
                            DataTable tblDatabases = aConnection.GetSchema("Databases");
                            aConnection.Close(); 

                            //Copy the list of databases for the combobox
                            List<String> databases = new List<string>();
                            foreach(DataRow row in tblDatabases.Rows)
                            {
                                databases.Add((String)row["database_name"]);
                            }

                            //Put the results back into the form
                            try
                            {
                                BeginInvoke((MethodInvoker)
                                            delegate
                                                {
                                                    m_connectProgress.Visible = false;
                                                    m_ComboDatabase.Items.Clear();
                                                    m_ComboDatabase.Items.AddRange(databases.ToArray());
                                                });
                            }
                            catch (InvalidOperationException)
                            {
                                //This is probably just because the window is closing
                            }
                        }
                        catch
                        {
                            //Something has gone wrong with finding the databases.
                            //This doesn't matter, just leave the list blank.
                            try
                            {
                                BeginInvoke((MethodInvoker)
                                            delegate
                                                {
                                                    m_connectProgress.Visible = false;
                                                    m_ComboDatabase.Items.Clear();
                                                });
                            }
                            catch (InvalidOperationException)
                            {
                                //This is probably just because the window is closing
                            }
                        }
                           
                    });
        }

        private void m_connectButton_Click(object sender, EventArgs e)
        {
            //Set the form up to be "in progress"
            m_connectProgress.Visible = true;
            m_labelError.Visible = false;

            //Remember this server for later
            m_comboServer.Items.Add(m_comboServer.Text);

            //Prepare the variables the other thread will need
            String hostName = m_comboServer.Text;
            String database = m_ComboDatabase.Text;

            //A background thread to connect to the database
            System.Threading.ThreadPool.QueueUserWorkItem(
                delegate
                {
                    try
                    {
                        //Do the connection
                        SqlConnection aConnection =
                            new SqlConnection("Data Source=" + hostName + "; Integrated Security=True;Database=" + database + ";");
                        aConnection.Open();

                        try
                        {
                            BeginInvoke((MethodInvoker)
                                   delegate
                                       {
                                           //Right, so now we start the second window
                                           QueryForm myQueryForm = new QueryForm(aConnection, this);
                                           myQueryForm.Text = "QueryBee - " + m_comboServer.Text + " - " +
                                                              m_ComboDatabase.Text;
                                           myQueryForm.Show();

                                           //And reset and minimize this one
                                           m_connectProgress.Visible = false;
                                           WindowState = FormWindowState.Minimized;
                                       });
                        }
                        catch (InvalidOperationException)
                        {
                            //This is probably just because the window is closing
                        }
                    }
                    catch
                    {
                        //Something has gone wrong with connecting
                        try
                        {
                            BeginInvoke((MethodInvoker)
                                   delegate
                                       {
                                           //Show a message
                                           m_connectProgress.Visible = false;
                                           m_labelError.Visible = true;
                                           m_labelError.Text = "Could not connect.";
                                       });
                        }
                        catch (InvalidOperationException)
                        {
                            //This is probably just because the window is closing
                        }
                    }
                });
        }

        private void m_ComboDatabase_TextChanged(object sender, EventArgs e)
        {
            //Keep the connect button grey until the text is non-empty
            m_connectButton.Enabled = (m_ComboDatabase.Text != "");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Detect the escape key and minimize
            if(keyData == Keys.Escape)
            {
                //It is esc, minimize
                WindowState = FormWindowState.Minimized;
                return true;
            }

            //It's not esc, pass to base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}