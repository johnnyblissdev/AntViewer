using System.Windows.Forms;

namespace AntViewer.UserControls
{
    public class BaseUserControl : UserControl
    {
        public delegate void UserControlFinished(object source);

        public event UserControlFinished Finished;

        protected void CloseUserControl()
        {
            Finished(this);
        }
    }
}
