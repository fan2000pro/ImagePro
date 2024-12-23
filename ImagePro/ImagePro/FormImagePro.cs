using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImagePro
{
    public partial class FormImagePro : Form
    {
        private Bitmap currentBitmap;
        private Graphics graphics;
        private Color currentColor = Color.Black;
        private int brushSize = 5;
        private bool isDrawing = false;
        private Point lastPoint;
        private List<Bitmap> layers = new List<Bitmap>();
        private int currentLayerIndex = 0;
        private enum Tool
        {
            Brush,
            Eraser
        }

        private Tool currentTool = Tool.Brush;

        public FormImagePro()
        {
            InitializeComponent();
            InitializeCanvas();
        }
        private void InitializeCanvas()
        {
            currentBitmap = new Bitmap(927, 614, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            graphics = Graphics.FromImage(currentBitmap);
            graphics.Clear(Color.Transparent);
            layers.Add((Bitmap)currentBitmap.Clone());
            currentLayerIndex = 0;
            pictureBox.Image = currentBitmap;
        }

        private void UpdateCurrentLayer()
        {
            layers[currentLayerIndex] = (Bitmap)currentBitmap.Clone();
        }

        private void UpdateLayerList()
        {
            lstLayers.Items.Clear();
            for (int i = 0; i < layers.Count; i++)
            {
                lstLayers.Items.Add($"Layer {i + 1}");
            }
            lstLayers.SelectedIndex = currentLayerIndex;
        }


        private void FromImagePro_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap loadedBitmap = new Bitmap(openFileDialog.FileName);
                    graphics.DrawImage(loadedBitmap, 0, 0);
                    layers[currentLayerIndex] = (Bitmap)currentBitmap.Clone();
                    pictureBox.Image = currentBitmap;
                }
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentBitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                if (currentTool == Tool.Eraser)
                {
                    using (Brush transparentBrush = new SolidBrush(Color.FromArgb(0, 0, 0, 0)))
                    {
                        graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        graphics.FillEllipse(transparentBrush, e.X - brushSize / 2, e.Y - brushSize / 2, brushSize, brushSize);
                    }
                }
                else if (currentTool == Tool.Brush)
                {
                    using (Pen pen = new Pen(currentColor, brushSize))
                    {
                        pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        graphics.DrawLine(pen, lastPoint, e.Location);
                    }
                }

                lastPoint = e.Location;
                UpdateCurrentLayer();
                pictureBox.Image = currentBitmap;
                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
            }
        }


        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            Bitmap newLayer = new Bitmap(currentBitmap.Width, currentBitmap.Height);
            using (Graphics g = Graphics.FromImage(newLayer))
            {
                g.Clear(Color.Transparent);
            }

            layers.Add(newLayer);
            currentLayerIndex = layers.Count - 1;

            lstLayers.Items.Add($"Layer {layers.Count}");

            currentBitmap = (Bitmap)newLayer.Clone();
            graphics = Graphics.FromImage(currentBitmap);
            pictureBox.Image = currentBitmap;
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            if (layers.Count > 1 && lstLayers.SelectedIndex >= 0)
            {
                layers.RemoveAt(lstLayers.SelectedIndex);
                currentLayerIndex = 0;
                graphics = Graphics.FromImage(layers[currentLayerIndex]);
                pictureBox.Image = layers[currentLayerIndex];
                UpdateLayerList();
            }
            else
            {
                MessageBox.Show("Cannot delete the last layer!");
            }
        }

        private void btnSwitchLayer_Click(object sender, EventArgs e)
        {
            if (lstLayers.SelectedIndex >= 0 && lstLayers.SelectedIndex < layers.Count)
            {
                currentLayerIndex = lstLayers.SelectedIndex;

                currentBitmap = (Bitmap)layers[currentLayerIndex].Clone();

                graphics = Graphics.FromImage(currentBitmap);

                pictureBox.Image = currentBitmap;
                pictureBox.Refresh();
            }
            else
            {
                MessageBox.Show("Select the correct layer from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMergeLayers_Click(object sender, EventArgs e)
        {
            Bitmap mergedBitmap = new Bitmap(currentBitmap.Width, currentBitmap.Height);
            using (Graphics g = Graphics.FromImage(mergedBitmap))
            {
                g.Clear(Color.Transparent);
                foreach (var layer in layers)
                {
                    g.DrawImage(layer, 0, 0);
                }
            }

            layers.Clear();
            layers.Add(mergedBitmap);
            currentLayerIndex = 0;

            lstLayers.Items.Clear();
            lstLayers.Items.Add("Merged Layer");

            currentBitmap = mergedBitmap;
            graphics = Graphics.FromImage(currentBitmap);
            pictureBox.Image = currentBitmap;
            pictureBox.Refresh();
        }

        private void btnBrush_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Brush;
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Eraser;
        }

        private void brushSizeSelector_ValueChanged(object sender, EventArgs e)
        {
            brushSize = (int)brushSizeSelector.Value;
        }

        private void btnBrushColor_Click(object sender, EventArgs e)
        {
            using (FormColorPicker FormcolorPicker = new FormColorPicker(currentColor))
            {
                if (FormcolorPicker.ShowDialog() == DialogResult.OK)
                {
                    currentColor = FormcolorPicker.SelectedColor;
                }
            }
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            using (FormFilters formFilters = new FormFilters(currentBitmap))
            {
                if (formFilters.ShowDialog() == DialogResult.OK)
                {
                    currentBitmap = formFilters.ModifiedBitmap;
                    pictureBox.Image = currentBitmap;
                }
            }
        }

        private void tooExit_Click(object sender, EventArgs e)
        {
            FormMain mainForm = new FormMain();
            mainForm.Show();
            this.Hide();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
