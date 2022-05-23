using System.Windows.Forms;

namespace ElasticRecruitmentTask
{
    public class DialogWindow
    {
        public string OpenDialogWindow()
        {
            OpenFileDialog openFileDialog = initializeOpenFileDialog();
            string filePath = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                return filePath;
            }
            else
            {
                return null;
            }
        }

        private static OpenFileDialog initializeOpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)| *.csv";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            return openFileDialog;
        }
    }
}
