namespace ImagePro
{
    partial class FormImagePro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImagePro));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.brushSizeSelector = new System.Windows.Forms.NumericUpDown();
            this.lstLayers = new System.Windows.Forms.ListBox();
            this.btnClouse = new System.Windows.Forms.Button();
            this.tooExit = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnBrushColor = new System.Windows.Forms.Button();
            this.btnBrush = new System.Windows.Forms.Button();
            this.btnEraser = new System.Windows.Forms.Button();
            this.btnFilters = new System.Windows.Forms.Button();
            this.MergeLayers = new System.Windows.Forms.Button();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.btnSwitchLayer = new System.Windows.Forms.Button();
            this.btnDeleteLayer = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox.Location = new System.Drawing.Point(8, 49);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(927, 614);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // brushSizeSelector
            // 
            this.brushSizeSelector.BackColor = System.Drawing.SystemColors.Control;
            this.brushSizeSelector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.brushSizeSelector.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brushSizeSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.brushSizeSelector.Location = new System.Drawing.Point(457, 11);
            this.brushSizeSelector.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.brushSizeSelector.Name = "brushSizeSelector";
            this.brushSizeSelector.Size = new System.Drawing.Size(120, 30);
            this.brushSizeSelector.TabIndex = 4;
            this.brushSizeSelector.ValueChanged += new System.EventHandler(this.brushSizeSelector_ValueChanged);
            // 
            // lstLayers
            // 
            this.lstLayers.FormattingEnabled = true;
            this.lstLayers.Location = new System.Drawing.Point(935, 90);
            this.lstLayers.Name = "lstLayers";
            this.lstLayers.Size = new System.Drawing.Size(210, 576);
            this.lstLayers.TabIndex = 9;
            // 
            // btnClouse
            // 
            this.btnClouse.BackColor = System.Drawing.SystemColors.Control;
            this.btnClouse.FlatAppearance.BorderSize = 0;
            this.btnClouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClouse.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnClouse.Location = new System.Drawing.Point(1105, 1);
            this.btnClouse.Name = "btnClouse";
            this.btnClouse.Size = new System.Drawing.Size(40, 40);
            this.btnClouse.TabIndex = 16;
            this.btnClouse.Text = "X";
            this.btnClouse.UseVisualStyleBackColor = false;
            this.btnClouse.Click += new System.EventHandler(this.btnClouse_Click);
            // 
            // tooExit
            // 
            this.tooExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.tooExit.FlatAppearance.BorderSize = 0;
            this.tooExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tooExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tooExit.ForeColor = System.Drawing.Color.White;
            this.tooExit.Location = new System.Drawing.Point(53, 8);
            this.tooExit.Name = "tooExit";
            this.tooExit.Size = new System.Drawing.Size(86, 35);
            this.tooExit.TabIndex = 17;
            this.tooExit.Text = "Exit";
            this.tooExit.UseVisualStyleBackColor = true;
            this.tooExit.Click += new System.EventHandler(this.tooExit_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnLoadImage.FlatAppearance.BorderSize = 0;
            this.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadImage.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadImage.ForeColor = System.Drawing.Color.White;
            this.btnLoadImage.Location = new System.Drawing.Point(145, 8);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(104, 35);
            this.btnLoadImage.TabIndex = 18;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnSaveImage.FlatAppearance.BorderSize = 0;
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImage.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveImage.ForeColor = System.Drawing.Color.White;
            this.btnSaveImage.Location = new System.Drawing.Point(255, 8);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(86, 35);
            this.btnSaveImage.TabIndex = 19;
            this.btnSaveImage.Text = "Save";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnBrushColor
            // 
            this.btnBrushColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnBrushColor.FlatAppearance.BorderSize = 0;
            this.btnBrushColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrushColor.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrushColor.ForeColor = System.Drawing.Color.White;
            this.btnBrushColor.Location = new System.Drawing.Point(347, 8);
            this.btnBrushColor.Name = "btnBrushColor";
            this.btnBrushColor.Size = new System.Drawing.Size(104, 35);
            this.btnBrushColor.TabIndex = 20;
            this.btnBrushColor.Text = "Brush Color";
            this.btnBrushColor.UseVisualStyleBackColor = true;
            this.btnBrushColor.Click += new System.EventHandler(this.btnBrushColor_Click);
            // 
            // btnBrush
            // 
            this.btnBrush.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnBrush.FlatAppearance.BorderSize = 0;
            this.btnBrush.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrush.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrush.ForeColor = System.Drawing.Color.White;
            this.btnBrush.Location = new System.Drawing.Point(583, 8);
            this.btnBrush.Name = "btnBrush";
            this.btnBrush.Size = new System.Drawing.Size(86, 35);
            this.btnBrush.TabIndex = 21;
            this.btnBrush.Text = "Brush";
            this.btnBrush.UseVisualStyleBackColor = true;
            this.btnBrush.Click += new System.EventHandler(this.btnBrush_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnEraser.FlatAppearance.BorderSize = 0;
            this.btnEraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEraser.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEraser.ForeColor = System.Drawing.Color.White;
            this.btnEraser.Location = new System.Drawing.Point(675, 8);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(86, 35);
            this.btnEraser.TabIndex = 22;
            this.btnEraser.Text = "Eraser";
            this.btnEraser.UseVisualStyleBackColor = true;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // btnFilters
            // 
            this.btnFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnFilters.FlatAppearance.BorderSize = 0;
            this.btnFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilters.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFilters.ForeColor = System.Drawing.Color.White;
            this.btnFilters.Location = new System.Drawing.Point(767, 8);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(86, 35);
            this.btnFilters.TabIndex = 23;
            this.btnFilters.Text = "Filters";
            this.btnFilters.UseVisualStyleBackColor = true;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // MergeLayers
            // 
            this.MergeLayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.MergeLayers.FlatAppearance.BorderSize = 0;
            this.MergeLayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MergeLayers.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MergeLayers.ForeColor = System.Drawing.Color.White;
            this.MergeLayers.Location = new System.Drawing.Point(939, 49);
            this.MergeLayers.Name = "MergeLayers";
            this.MergeLayers.Size = new System.Drawing.Size(109, 35);
            this.MergeLayers.TabIndex = 24;
            this.MergeLayers.Text = "Merge Layers";
            this.MergeLayers.UseVisualStyleBackColor = true;
            this.MergeLayers.Click += new System.EventHandler(this.btnMergeLayers_Click);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnAddLayer.FlatAppearance.BorderSize = 0;
            this.btnAddLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLayer.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddLayer.ForeColor = System.Drawing.Color.White;
            this.btnAddLayer.Location = new System.Drawing.Point(859, 8);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(97, 35);
            this.btnAddLayer.TabIndex = 25;
            this.btnAddLayer.Text = "Add Layer";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.btnAddLayer_Click);
            // 
            // btnSwitchLayer
            // 
            this.btnSwitchLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnSwitchLayer.FlatAppearance.BorderSize = 0;
            this.btnSwitchLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchLayer.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSwitchLayer.ForeColor = System.Drawing.Color.White;
            this.btnSwitchLayer.Location = new System.Drawing.Point(1055, 49);
            this.btnSwitchLayer.Name = "btnSwitchLayer";
            this.btnSwitchLayer.Size = new System.Drawing.Size(86, 35);
            this.btnSwitchLayer.TabIndex = 26;
            this.btnSwitchLayer.Text = "Switch";
            this.btnSwitchLayer.UseVisualStyleBackColor = true;
            this.btnSwitchLayer.Click += new System.EventHandler(this.btnSwitchLayer_Click);
            // 
            // btnDeleteLayer
            // 
            this.btnDeleteLayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(190)))), ((int)(((byte)(227)))));
            this.btnDeleteLayer.FlatAppearance.BorderSize = 0;
            this.btnDeleteLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLayer.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteLayer.ForeColor = System.Drawing.Color.White;
            this.btnDeleteLayer.Location = new System.Drawing.Point(962, 6);
            this.btnDeleteLayer.Name = "btnDeleteLayer";
            this.btnDeleteLayer.Size = new System.Drawing.Size(86, 35);
            this.btnDeleteLayer.TabIndex = 27;
            this.btnDeleteLayer.Text = "Delete";
            this.btnDeleteLayer.UseVisualStyleBackColor = true;
            this.btnDeleteLayer.Click += new System.EventHandler(this.btnDeleteLayer_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-40, -40);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 128);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // FormImagePro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 665);
            this.Controls.Add(this.btnDeleteLayer);
            this.Controls.Add(this.btnSwitchLayer);
            this.Controls.Add(this.btnAddLayer);
            this.Controls.Add(this.MergeLayers);
            this.Controls.Add(this.btnFilters);
            this.Controls.Add(this.btnEraser);
            this.Controls.Add(this.btnBrush);
            this.Controls.Add(this.btnBrushColor);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.tooExit);
            this.Controls.Add(this.btnClouse);
            this.Controls.Add(this.lstLayers);
            this.Controls.Add(this.brushSizeSelector);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.pictureBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormImagePro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FromImagePro";
            this.Load += new System.EventHandler(this.FromImagePro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown brushSizeSelector;
        private System.Windows.Forms.ListBox lstLayers;
        private System.Windows.Forms.Button btnClouse;
        private System.Windows.Forms.Button tooExit;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnBrushColor;
        private System.Windows.Forms.Button btnBrush;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Button btnFilters;
        private System.Windows.Forms.Button MergeLayers;
        private System.Windows.Forms.Button btnAddLayer;
        private System.Windows.Forms.Button btnSwitchLayer;
        private System.Windows.Forms.Button btnDeleteLayer;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}