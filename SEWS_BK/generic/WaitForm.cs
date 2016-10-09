using System.Windows.Forms;

namespace SEWS_BK.generic
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();

            loadingCircle.Start();
        }

        public WaitForm(string text)
        {
            InitializeComponent();

            this.lblText.Text = text;
            loadingCircle.Start();
        }
    }
}
