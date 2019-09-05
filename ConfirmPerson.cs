using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageChopper
{
    public partial class ConfirmPerson : Form
    {
        public ConfirmPerson()
        {
            InitializeComponent();
        }

        private void ConfirmPerson_Load(object sender, EventArgs e)
        {
            frmMain.people.Sort();
            cmbPersoana.DataSource = frmMain.people;
            cmbPersoana.Text = frmMain.currentPersonText == string.Empty ? cmbPersoana.Text : frmMain.currentPersonText;
        }

        //private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}

        private void CmbPersoana_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbPersoana.Text == string.Empty)
                {
                    lblError.Text = "Trebuie sa alegeti o persoana!";
                    return;
                }
                if (frmMain.people.Where(p => p == cmbPersoana.Text).Count() == 0)
                {
                    frmMain.people.Add(cmbPersoana.Text);

                }
                frmMain.currentPersonText = cmbPersoana.Text;
                this.DialogResult = DialogResult.OK;
                //this.Close();
            }

        }

        private void ConfirmPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
