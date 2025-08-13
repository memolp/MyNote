using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNote.View
{
    public partial class SyncLoading : Form
    {
        private static SyncLoading _dlg = null;
        public SyncLoading()
        {
            InitializeComponent();
        }

        public static void ShowLoading(string msg)
        {
            if (_dlg == null)
            {
                _dlg = new SyncLoading();
            }
            _dlg.ShowDialog();
        }

        public static void HideLoading()
        {
            if (_dlg == null) return;
            _dlg.Close();
            _dlg = null;
        }
    }

}
