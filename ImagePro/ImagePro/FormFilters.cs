using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePro
{
    public partial class FormFilters : Form
    {
        private Bitmap originalBitmap;
        private Bitmap modifiedBitmap;
        public Bitmap ModifiedBitmap { get; private set; }
        public FormFilters(Bitmap bitmap)
        {
            InitializeComponent();

            trackBarBrightness.Minimum = -100;
            trackBarBrightness.Maximum = 100;
            trackBarBrightness.Value = 0;

            trackBarContrast.Minimum = -100;
            trackBarContrast.Maximum = 100;
            trackBarContrast.Value = 0;

            trackBarSaturation.Minimum = -100;
            trackBarSaturation.Maximum = 100;
            trackBarSaturation.Value = 0;

            originalBitmap = (Bitmap)bitmap.Clone();
            ModifiedBitmap = (Bitmap)bitmap.Clone();

            UpdatePreview();
        }

        private void UpdatePreview()
        {
            Bitmap previewBitmap = (Bitmap)originalBitmap.Clone();

            previewBitmap = ApplyBrightness(previewBitmap, trackBarBrightness.Value);
            previewBitmap = ApplyContrast(previewBitmap, trackBarContrast.Value);
            previewBitmap = ApplySaturation(previewBitmap, trackBarSaturation.Value);

            pictureBoxPreview.Image = previewBitmap;

            ModifiedBitmap?.Dispose();
            ModifiedBitmap = previewBitmap;
        }

        private Bitmap ApplyBrightness(Bitmap bitmap, int value)
        {
            float brightnessFactor = 1 + (value / 100f);
            return ApplyColorMatrix(bitmap, new float[][]
            {
                new float[] {brightnessFactor, 0, 0, 0, 0},
                new float[] {0, brightnessFactor, 0, 0, 0},
                new float[] {0, 0, brightnessFactor, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });
        }

        private Bitmap ApplyContrast(Bitmap bitmap, int value)
        {
            float contrastFactor = 1 + (value / 100f);
            float adjustment = 0.5f * (1 - contrastFactor);
            return ApplyColorMatrix(bitmap, new float[][]
            {
                new float[] {contrastFactor, 0, 0, 0, 0},
                new float[] {0, contrastFactor, 0, 0, 0},
                new float[] {0, 0, contrastFactor, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {adjustment, adjustment, adjustment, 0, 1}
            });
        }

        private Bitmap ApplySaturation(Bitmap bitmap, int value)
        {
            float saturationFactor = 1 + (value / 100f);
            float rWeight = 0.3086f, gWeight = 0.6094f, bWeight = 0.0820f;
            float complement = 1 - saturationFactor;

            return ApplyColorMatrix(bitmap, new float[][]
            {
                new float[] {complement * rWeight + saturationFactor, complement * rWeight, complement * rWeight, 0, 0},
                new float[] {complement * gWeight, complement * gWeight + saturationFactor, complement * gWeight, 0, 0},
                new float[] {complement * bWeight, complement * bWeight, complement * bWeight + saturationFactor, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });
        }

        private Bitmap ApplyColorMatrix(Bitmap bitmap, float[][] colorMatrixElements)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void trackBarSaturation_Scroll(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 0;
            trackBarContrast.Value = 0;
            trackBarSaturation.Value = 0;

            modifiedBitmap = (Bitmap)originalBitmap.Clone();
            pictureBoxPreview.Image = modifiedBitmap;
        }

        private void trackBarApplyGaussianBlur_Scroll(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
