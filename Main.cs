using ImageChopper.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageChopper
{
    public partial class frmMain : Form
    {
        ConfirmPerson confirmPerson;
        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();

        private Brush selectionBrush = new SolidBrush(Color.White);//.FromArgb(128, 72, 145, 220));

        private List<RectangleF> rects = new List<RectangleF>();
        public frmMain()
        {
            InitializeComponent();
        }


        private bool imageFocus = true;

        private String srcFolder = string.Empty;
        private String destFolder = string.Empty;
        private String peopleFile = string.Empty;
        private String[] allowedExtensions = null;
        private float zoomFactor = 1;
        public static List<string> people = new List<string>();
        private List<ImageFile> images = new List<ImageFile>();
        public static ImageFile currentImage = null;
        private string outputFilenameFormat = "{0}{1}";
        public static string currentPersonText = string.Empty;
        //private List<Image> intermediaryImages = new List<Image>();
        private Guid guid = Guid.NewGuid();

        private bool forceSave = false;
        private Bitmap MakeImageWithoutArea(Bitmap source_bm)
        {

            // Copy the image.
            Bitmap bm = new Bitmap(source_bm);

            // Clear the selected area.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(Rect);

                gr.SetClip(path);
                gr.Clear(Color.White);
                gr.ResetClip();
            }
            return bm;
        }

        private Bitmap MakeImageWithoutRectangles(Bitmap source_bm)
        {
            //MessageBox.Show(rects.Count.ToString());
            // Copy the image.
            Bitmap bm = new Bitmap(source_bm);

            // Clear the selected area.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                GraphicsPath path = new GraphicsPath();
                foreach (var rect in rects)
                {
                    path.AddRectangle(rect);
                    gr.SetClip(path);
                    gr.Clear(Color.White);
                    gr.ResetClip();
                }



            }
            return bm;
        }


        private void SaveZoomedRectangle()
        {

            RectangleF f = new RectangleF(new PointF(
                   Rect.X / currentImage.ZoomFactor,
                    Rect.Y / currentImage.ZoomFactor
                       ), new SizeF(
                           Rect.Size.Width / currentImage.ZoomFactor,
                           Rect.Size.Height / currentImage.ZoomFactor
                           ));
            if (f.Width * f.Height > 0)
            {
                rects.Add(f);
                WriteLog(string.Format("S={0}, nr_rects={1}", (f.Width * f.Height), rects.Count));
            }

        }
        private Bitmap MakeOriginalImageWithoutArea(Bitmap source_bm)
        {

            // Copy the image.
            Bitmap bm = new Bitmap(source_bm);

            // Clear the selected area.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                GraphicsPath path = new GraphicsPath();

                RectangleF f = new RectangleF(new PointF(
                    Rect.X / currentImage.ZoomFactor,
                     Rect.Y / currentImage.ZoomFactor
                        ), new SizeF(
                            Rect.Size.Width / currentImage.ZoomFactor,
                            Rect.Size.Height / currentImage.ZoomFactor
                            ));
                path.AddRectangle(f);
                gr.SetClip(path);
                gr.Clear(Color.White);
                gr.ResetClip();
            }
            return bm;
        }

        private Bitmap MakeSampleImage(Bitmap bitmap)
        {
            const int box_wid = 20;
            const int box_hgt = 20;

            Bitmap bm = new Bitmap(
               bitmap.Width, bitmap.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Start with a checkerboard pattern.
                gr.Clear(Color.White);
                int num_rows = bm.Height / box_hgt;
                int num_cols = bm.Width / box_wid;
                for (int row = 0; row < num_rows; row++)
                {
                    int y = row * box_hgt;
                    for (int col = 0; col < num_cols; col++)
                    {
                        int x = 2 * col * box_wid;
                        if (row % 2 == 1) x += box_wid;
                        gr.FillRectangle(Brushes.White,
                            x, y, box_wid, box_hgt);
                    }
                }

                // Draw the image on top.
                gr.DrawImageUnscaled(bitmap, 0, 0);
            }
            return bm;
        }


        private void PictureBoxSrc_MouseDown(object sender, MouseEventArgs e)
        {

            RectStartPoint = new Point(e.Location.X,
          e.Location.Y);

            pictureBoxCurrent.Invalidate();
        }

        private void PictureBoxSrc_MouseUp(object sender, MouseEventArgs e)
        {
            btnUndo.Enabled = true;

            // Make the image without the area.
            Bitmap without_area_bitmap =
                MakeImageWithoutArea((Bitmap)pictureBoxCurrent.Image);
            pictureBoxCurrent.Image = MakeSampleImage(without_area_bitmap);
            without_area_bitmap = null;

            SaveZoomedRectangle();
            WriteImageInfo();

        }

        private void WriteImageInfo()
        {
            var countSavedImages = images.Where(i => i.HasBeenSaved).Count();
            var filename = currentImage.SaveFilePath != string.Empty ?currentImage.SaveFilePath.Substring(currentImage.SaveFilePath.LastIndexOf("\\")+1,currentImage.SaveFilePath.Length- currentImage.SaveFilePath.LastIndexOf("\\")-1): "";
            lblInfo.Text = String.Format("{7}\n{0}\nPersoana: {1}\nSalvata: {2}\nSalvata ca: {6}\nZoomFactor: {3}\nTotal imagini: {4}\nImagini procesate: {5}", currentImage.Filename, currentImage.Person, currentImage.HasBeenSaved, zoomFactor, images.Count, countSavedImages, filename,guid);


        }
        private void PictureBoxSrc_MouseMove(object sender, MouseEventArgs e)
        {
            Rect = new Rectangle();
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;


            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                 Math.Min(RectStartPoint.Y, tempEndPoint.Y)
                );

            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));

            pictureBoxCurrent.Invalidate();

        }

        private void PictureBoxSrc_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pictureBoxCurrent.Image != null)

            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    var zoomedRect = new Rectangle(new Point(
                        Convert.ToInt32(Rect.X * currentImage.ZoomFactor),
                        Convert.ToInt32(Rect.Y * currentImage.ZoomFactor)
                        ), new Size(Convert.ToInt32(Rect.Size.Width * currentImage.ZoomFactor),
                        Convert.ToInt32((Rect.Size.Height * currentImage.ZoomFactor))));
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {

            if (rects.Count == 0)
            {
                WriteLog("Am  revent la imaginea originala, nu se mai poate face undo!");
                btnUndo.Enabled = false;
                return;
            }
            //remove current rect
            rects.RemoveAt(rects.Count - 1);

            ZoomImage();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            lblImgInfo.Text = "";


            lblLog.Text = "";
            lblInfo.Text = "";
            outputFilenameFormat = System.Configuration.ConfigurationSettings.AppSettings["outputFilenameFormat"];
            srcFolder = System.Configuration.ConfigurationSettings.AppSettings["sourceFolder"];
            destFolder = System.Configuration.ConfigurationSettings.AppSettings["destFolder"];
            peopleFile = System.Configuration.ConfigurationSettings.AppSettings["peopleFile"];
            allowedExtensions = System.Configuration.ConfigurationSettings.AppSettings["allowedExtensions"].Split(new string[] { "," }, 30, StringSplitOptions.RemoveEmptyEntries);
            zoomFactor = float.Parse(System.Configuration.ConfigurationSettings.AppSettings["zoomFactor"]);
            destFolder = (destFolder.EndsWith("\\") ? destFolder.Substring(destFolder.Length - 1) : destFolder) + guid;



            try {
                Directory.CreateDirectory(destFolder);
            }
            catch (Exception xcp) {
                MessageBox.Show("Directorul de output nu a putut fi creat, se va utiliza directorul default!!");
                destFolder = System.Configuration.ConfigurationSettings.AppSettings["destFolder"];
            }
            foreach (String file in Directory.GetFiles(srcFolder).Where(file => allowedExtensions.Any(file.ToLower().EndsWith)).ToList())
            {
                images.Add(new ImageFile(file, string.Empty, zoomFactor));
                cmbFile.Items.Add(file);
            }
            foreach (string person in File.ReadAllLines(peopleFile))
            {
                people.Add(person);
            }

            if (images.Count > 0)
            {

                currentImage = images[0];

                ResetProcessing();


            }
            else
            {
                btnNextFile.Enabled = false;
                btnPrevFile.Enabled = false;
                btnSave.Enabled = false;
                cmbFile.Enabled = false;
            }

            people.Sort();
            
            
        }

        private void CmbFile_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbFile.SelectedItem.ToString() == currentImage.Filename)
                return;

            if (rects.Count > 0)
            {
                if (MessageBox.Show("Fisierul curent a suferit modificari ce nu au fost salvate care vor fi pierdute! Sigur doriti sa continuati?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;

                }
            }

            currentImage = images.Where(i => i.Filename == cmbFile.SelectedItem.ToString()).First();
            ResetProcessing();
        }

        private void ResetProcessing()
        {
            rects = null;
            rects = new List<RectangleF>();
            btnOpen.Enabled = currentImage.HasBeenSaved;
            if (currentImage.HasBeenSaved)
            {
                lblImgInfo.Text = currentImage.SaveFilePath;
                lblImgInfo.BackColor = Color.FromArgb(255, 243, 205);
                lblImgInfo.ForeColor = Color.FromArgb(204, 0, 0);
            }
            else
            {
                lblImgInfo.Text = currentImage.Filename;
                lblImgInfo.BackColor = Color.FromArgb(255, 243, 205);
                lblImgInfo.ForeColor = Color.FromArgb(15, 87, 36);

            }





            //pictureBoxCurrent.Image = newImage;
            ZoomImage();
            WriteImageInfo();

        }

        private void ZoomIn()
        {
            if (currentImage.ZoomFactor <= 1f)
            {
                currentImage.ZoomFactor *= 1.4f;
                ZoomImage();
            }
            else
                WriteLog("Nu se poate face zoom mai mare decat imaginea originala");
        }

        private void ZoomOut()
        {
            if (currentImage.ZoomFactor > 0.1f)
            {
                currentImage.ZoomFactor /= 1.4f;
                ZoomImage();
            }
            else
                WriteLog("Nu se poate face zoom mai mic de 10%");
        }

        private void ZoomImage()
        {

            WriteLog("Zoom factor: " + currentImage.ZoomFactor);

            var latestImage = MakeImageWithoutRectangles((Bitmap)Image.FromFile(currentImage.Filename));

            SizeF newSize = new SizeF(latestImage.Width * currentImage.ZoomFactor,
                latestImage.Height * currentImage.ZoomFactor);
            Bitmap bmp = new Bitmap((Image)latestImage, Size.Round(newSize));


            pictureBoxCurrent.Size = Size.Round(newSize);
            pictureBoxCurrent.Image = bmp;

        }



        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (rects.Count > 0 || forceSave)
            {
                confirmPerson = new ConfirmPerson();

                confirmPerson.pictureBox1.Image = pictureBoxCurrent.Image;
                //confirmPerson.pictureBox1.Size = pictureBoxCurrent.Size;
                if (confirmPerson.ShowDialog() == DialogResult.Cancel)
                {
                    MessageBox.Show("Fisierul " + currentImage.Filename + " nu a fost salvat, trebuie sa confirmati persoana!");
                    return;
                }

            }
            else
            {
                return;
            }
            forceSave = false;




            int imageIndex = images.Where(i => i.Person == currentImage.Person && i.Filename != currentImage.Filename).Count() + 1;
            var filename = string.Format(@"{0}\{1}", destFolder, string.Format(outputFilenameFormat, currentImage.Person, imageIndex));

            if (currentImage.HasBeenSaved)
            {
                if (MessageBox.Show("Imaginea exista deja si va fi suprascrisa! Sigur doriti sa continuati?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;

                }
            }
            MakeImageWithoutRectangles((Bitmap)Image.FromFile(currentImage.Filename)).Save(filename);
            WriteLog("Salvare cu succes! " + filename);
            currentImage.SaveFilePath = filename;
            currentImage.HasBeenSaved = true;

        }

        private void WriteLog(string message)
        {
            lblLog.Text = string.Format("{0} - {1}\r\n", System.DateTime.Now.ToString("dd.MM HH:mm:ss"), message) + lblLog.Text;
        }

        private void BtnPrevFile_Click(object sender, EventArgs e)
        {
            SaveImage();
            var currIndex = images.IndexOf(currentImage);

            if (currIndex == 0)
                currIndex = images.Count - 1;
            else currIndex--;
            currentImage = images[currIndex];
            WriteLog("Prev index: " + currIndex);
            ResetProcessing();
        }

        private void SaveImage()
        {
            //save image
            btnSave.PerformClick();
        }

        private void BtnNextFile_Click(object sender, EventArgs e)
        {


            SaveImage();
            var currIndex = images.IndexOf(currentImage);
            if (currIndex == images.Count - 1)
                currIndex = 0;
            else currIndex++;
            currentImage = images[currIndex];
            WriteLog("Next index: " + currIndex);
            ResetProcessing();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {



            if (keyData == (Keys.Right) && imageFocus)
            {
                btnNextFile.PerformClick();
                return true;
            }
            if (keyData == (Keys.Left) && imageFocus)
            {
                btnPrevFile.PerformClick();
                return true;
            }

            if (keyData == (Keys.Add) && imageFocus)
            {
                btnZoomIn.PerformClick();
                return true;
            }

            if (keyData == (Keys.Subtract) && imageFocus)
            {
                btnZoomOut.PerformClick();
                return true;
            }

            if (keyData == (Keys.Z) && imageFocus)
            {
                btnUndo.PerformClick();
                return true;
            }

            if (keyData == (Keys.S) && imageFocus)
            {
                btnSave.PerformClick();
                return true;
            }

            if (keyData == (Keys.Multiply) && imageFocus)
            {
                forceSave = true;
                btnSave.PerformClick();
                return true;
            }


            if (keyData == (Keys.V) && imageFocus)
            {
                
                var people=images.Where(i => i.HasBeenSaved).Distinct().Select(p=>p.Person).ToList();
                var outFile= destFolder + @"\lucru.txt";
                try
                {
                    using (TextWriter tw = new StreamWriter(outFile))
                    {
                        foreach (String s in people)
                            tw.WriteLine(s);
                    }
                    MessageBox.Show("Fisierul a fost salvat ca: " + outFile);
                }
                catch (Exception xcp) {
                    MessageBox.Show("Fisierul nu a fost salvat! "+xcp.ToString() );

                }
                return true;
            }



            return base.ProcessCmdKey(ref msg, keyData);
        }

        private int GetIndexFocusedControl()
        {
            int ind = -1;
            foreach (Control ctr in this.Controls)
            {
                if (ctr.Focused)
                {
                    ind = (int)this.Controls.IndexOf(ctr);
                }
            }
            return ind;
        }

        private void CmbPeople_Click(object sender, EventArgs e)
        {
            imageFocus = false;
        }

        private void CmbPeople_MouseLeave(object sender, EventArgs e)
        {
            imageFocus = true;
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(currentImage.SaveFilePath);
            }
            catch (Exception xcp)
            {

            }

        }
    }






}