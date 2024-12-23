using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePro
{
    public partial class FormColorPicker : Form
    {
        public Color SelectedColor { get; private set; }

        public FormColorPicker(Color initialColor)
        {
            InitializeComponent();

            trackBarRed.Value = initialColor.R;
            trackBarGreen.Value = initialColor.G;
            trackBarBlue.Value = initialColor.B;

            UpdateColorPreview();
        }

        private void UpdateColorPreview()
        {
            Color color = Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            panelColorPreview.BackColor = color;

            SelectedColor = color;
        }

        private void trackBarRed_ValueChanged(object sender, EventArgs e)
        {
            UpdateColorPreview();
        }

        private void trackBarGreen_ValueChanged(object sender, EventArgs e)
        {
            UpdateColorPreview();
        }

        private void trackBarBlue_ValueChanged(object sender, EventArgs e)
        {
            UpdateColorPreview();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormColorPicker_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
