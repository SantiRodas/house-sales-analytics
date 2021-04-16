using HSA.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HSA.UserInterface
{
    public partial class MainWindow : Form
    {
        private DataSetManager manager;

        public DataSetManager Manager
        {
            get
            {
                return manager;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            mainWindowTabs.DrawItem += new DrawItemEventHandler(mainWindowTabs_DrawItem);

            manager = new DataSetManager();

            dataViewerControl.Initialize(manager);
            
        }

        //Allows vertical tabs, not possible within tab control properties
        //https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-display-side-aligned-tabs-with-tabcontrol?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
        private void mainWindowTabs_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = mainWindowTabs.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = mainWindowTabs.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Segoe UI", 12.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
    }
}
