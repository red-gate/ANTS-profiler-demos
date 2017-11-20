using System;
using System.Threading;
using System.Windows.Forms;

namespace WSClient
{
    /// <summary>
    /// A form to allow sumbission of new top-level articles to Shovell.
    /// </summary>
    public partial class ShovellSubmitterForm : Form
    {
        public ShovellSubmitterForm()
        {
            InitializeComponent();
        }

        private void m_submit_Click(object sender, EventArgs e)
        {
            //Grey the submit button to show something's happening
            m_submit.Enabled = false;

            //Create the WebService object
            WebService shovellWebService = new WebService();

            //Make copies of the information in the fireground thread
            String username = m_username.Text;
            String password = m_password.Text;
            String title = m_title.Text;
            String contents = m_contents.Text;

            ThreadPool.QueueUserWorkItem(
                delegate
                    {
                        //Do the request
                        shovellWebService.SubmitArticle(username, password, title, contents, null);

                        //Now the request is done, re-enable the submit button
                        Invoke((MethodInvoker)
                               delegate
                                   {
                                       m_submit.Enabled = true;
                                   });
                    });

        }
    }
}