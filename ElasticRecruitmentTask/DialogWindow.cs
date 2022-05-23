using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElasticRecruitmentTask
{
    public class DialogWindow
    {
        public string OpenDialogWindow()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV files (*.csv)| *.csv";
            openFile.FilterIndex = 1;
            openFile.Multiselect = false;
            string filePath = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filePath = openFile.FileName;
                return filePath;
            }
            else
            {
                return null;
            }
        }
    }
}
