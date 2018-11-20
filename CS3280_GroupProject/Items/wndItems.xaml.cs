using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CS3280_GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// this variable lets the main know if any change occured
        /// please remember to set isChanged = true; 
        /// if InsertButton, UpdateButton, DeleteButton is clicked on
        /// </summary>
        private bool isChanged = false; 

        public wndItems()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main window can access isChanged bool variable 
        /// </summary>
        public bool IsChanged
        {
            get
            {
                return isChanged;
            }
        }

        

    }
}
