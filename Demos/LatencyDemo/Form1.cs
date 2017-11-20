using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RedGate.Demo
{
    public partial class TabbedForm : Form
    {
        delegate void HttpErrorDelegate(string s);
        // These are the RSS feeds for two of the discussion areas on the Red Gate messageboard
        private readonly string[] m_webSites =
        {
            "https://forum.red-gate.com/categories/ants-memory-profiler-8/feed.rss",
            "https://forum.red-gate.com/categories/ants-performance-profiler-9/feed.rss",
        };

        public TabbedForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Read the XML from the given URL. Execute errorDelegate if anything goes wrong
        /// </summary>
        /// <param name="url">Url to retrieve</param>
        /// <param name="errorDelegate">A function to execute if an error occurs</param>
        /// <returns>An XmlDocument representing the RSS feed</returns>
        private static XmlDocument RssFeed(string url, HttpErrorDelegate errorDelegate)
        {
            HttpWebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                response = (HttpWebResponse) request.GetResponse();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(response.GetResponseStream());
                return xDoc;
            }
            catch (Exception e)
            {
                errorDelegate(e.Message);
                return null;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        /*
         * The error here is that the tab is reloaded from the web every time it's clicked. RSS feeds have a field indicating
         * their update frequency, and this should be used to decide whether the content should be refreshed.
         */
        private void TabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            // Don't do anything if it's the introduction page
            if (tabControl.SelectedIndex == 0)
                return;

            // Each tab only has one child control, the text box
            TextBox currentTextBox = ((TextBox) tabControl.Controls[tabControl.SelectedIndex].Controls[0]);

            XmlDocument xDoc = RssFeed(m_webSites[tabControl.SelectedIndex - 1],
                                       delegate(string s) { currentTextBox.Text = s; });

            if (xDoc != null)
            {
                StringBuilder sb = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter xmlWriter = XmlWriter.Create(sb, settings);
                xDoc.WriteTo(xmlWriter);
                xmlWriter.Close();
                currentTextBox.Text = sb.ToString();
            }
        }

        private void AutoTestClick(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                tabControl1.SelectedIndex = 1;
                tabControl1.SelectedIndex = 2;
            }
        }
    }
}
