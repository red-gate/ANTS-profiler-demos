using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RedGate.Demo
{
    /// <summary>
    /// Interaction logic for ConfigurationDialog.xaml
    /// </summary>
    public partial class ConfigurationDialog : Window
    {
        private readonly ApplicationOptions m_currentOptions;
        private readonly ApplicationOptions m_originalOptions;
        private readonly PropertyGrid m_propertyGrid;

        public ConfigurationDialog()
        {
            InitializeComponent();
            m_propertyGrid = new PropertyGrid();
            windowsFormsHost1.Child = m_propertyGrid;
        }

        internal ConfigurationDialog(ApplicationOptions applicationOptions) : this()
        {
            m_currentOptions = applicationOptions;
            m_propertyGrid.SelectedObject = m_currentOptions;
            m_propertyGrid.PropertyValueChanged += PropertyGridPropertyValueChanged;
            m_originalOptions = m_currentOptions.Copy();
        }

        void PropertyGridPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // Validate that the new values are acceptable
            if(e.ChangedItem.PropertyDescriptor.Name == "MaxRandom")
            {
                ulong value = (ulong)e.ChangedItem.Value;
                if(value < 1)
                {
                    m_currentOptions.MaxRandom = (ulong)e.OldValue;
                }
            }
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            // Keep the dialog around
            Hide();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            // Bring back the saved options
            m_currentOptions.CopyFrom(m_originalOptions);
            Hide();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Don't really let it close
            e.Cancel = true;
            Hide();
        }
    }
}
