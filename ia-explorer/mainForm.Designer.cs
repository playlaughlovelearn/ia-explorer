
namespace ia_explorer
{
	partial class mainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textDestinationFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textCollectionName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnDownloadMetadata = new System.Windows.Forms.Button();
			this.progressMain = new System.Windows.Forms.ProgressBar();
			this.btnClear = new System.Windows.Forms.Button();
			this.datagridCollectionMetadata = new System.Windows.Forms.DataGridView();
			this.btnGrabFileMetadata = new System.Windows.Forms.Button();
			this.timerRefresh = new System.Windows.Forms.Timer(this.components);
			this.labelCounter = new System.Windows.Forms.Label();
			this.gridItems = new System.Windows.Forms.DataGridView();
			this.gridDetails = new System.Windows.Forms.DataGridView();
			this.btnLoadFromDisk = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.textboxIncludeFilters = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textboxExcludeFilters = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textboxSelectionSize = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.datagridCollectionMetadata)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
			this.SuspendLayout();
			// 
			// textDestinationFolder
			// 
			this.textDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textDestinationFolder.Location = new System.Drawing.Point(12, 25);
			this.textDestinationFolder.Name = "textDestinationFolder";
			this.textDestinationFolder.Size = new System.Drawing.Size(1560, 23);
			this.textDestinationFolder.TabIndex = 2;
			this.textDestinationFolder.Text = "L:\\bluesky\\internet-archive";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(93, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 15);
			this.label1.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "Destination Folder";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 53);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 15);
			this.label4.TabIndex = 9;
			this.label4.Text = "Collection Name";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(93, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(0, 15);
			this.label5.TabIndex = 8;
			// 
			// textCollectionName
			// 
			this.textCollectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textCollectionName.Location = new System.Drawing.Point(12, 71);
			this.textCollectionName.Name = "textCollectionName";
			this.textCollectionName.Size = new System.Drawing.Size(529, 23);
			this.textCollectionName.TabIndex = 7;
			this.textCollectionName.Text = "windowsdesktopthemes";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 105);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(87, 15);
			this.label6.TabIndex = 11;
			this.label6.Text = "Available Items";
			// 
			// btnDownloadMetadata
			// 
			this.btnDownloadMetadata.Location = new System.Drawing.Point(105, 97);
			this.btnDownloadMetadata.Name = "btnDownloadMetadata";
			this.btnDownloadMetadata.Size = new System.Drawing.Size(140, 23);
			this.btnDownloadMetadata.TabIndex = 15;
			this.btnDownloadMetadata.Text = "Download Metadata";
			this.btnDownloadMetadata.UseVisualStyleBackColor = true;
			this.btnDownloadMetadata.Click += new System.EventHandler(this.btnDownloadMetadata_Click);
			// 
			// progressMain
			// 
			this.progressMain.Location = new System.Drawing.Point(1009, 97);
			this.progressMain.Name = "progressMain";
			this.progressMain.Size = new System.Drawing.Size(563, 23);
			this.progressMain.TabIndex = 21;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(867, 97);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(136, 23);
			this.btnClear.TabIndex = 23;
			this.btnClear.Text = "Clear Output Folder";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// datagridCollectionMetadata
			// 
			this.datagridCollectionMetadata.AllowUserToAddRows = false;
			this.datagridCollectionMetadata.AllowUserToDeleteRows = false;
			this.datagridCollectionMetadata.AllowUserToOrderColumns = true;
			this.datagridCollectionMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.datagridCollectionMetadata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.datagridCollectionMetadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.datagridCollectionMetadata.Location = new System.Drawing.Point(11, 153);
			this.datagridCollectionMetadata.Name = "datagridCollectionMetadata";
			this.datagridCollectionMetadata.RowTemplate.Height = 25;
			this.datagridCollectionMetadata.Size = new System.Drawing.Size(1559, 62);
			this.datagridCollectionMetadata.TabIndex = 25;
			// 
			// btnGrabFileMetadata
			// 
			this.btnGrabFileMetadata.Location = new System.Drawing.Point(401, 97);
			this.btnGrabFileMetadata.Name = "btnGrabFileMetadata";
			this.btnGrabFileMetadata.Size = new System.Drawing.Size(121, 23);
			this.btnGrabFileMetadata.TabIndex = 28;
			this.btnGrabFileMetadata.Text = "Grab Files";
			this.btnGrabFileMetadata.UseVisualStyleBackColor = true;
			this.btnGrabFileMetadata.Click += new System.EventHandler(this.btnGrabFileMetadata_Click);
			// 
			// timerRefresh
			// 
			this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
			// 
			// labelCounter
			// 
			this.labelCounter.Location = new System.Drawing.Point(528, 97);
			this.labelCounter.Name = "labelCounter";
			this.labelCounter.Size = new System.Drawing.Size(333, 23);
			this.labelCounter.TabIndex = 30;
			this.labelCounter.Text = "Counter";
			this.labelCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gridItems
			// 
			this.gridItems.AllowUserToAddRows = false;
			this.gridItems.AllowUserToDeleteRows = false;
			this.gridItems.AllowUserToOrderColumns = true;
			this.gridItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridItems.Location = new System.Drawing.Point(14, 221);
			this.gridItems.Name = "gridItems";
			this.gridItems.RowTemplate.Height = 25;
			this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridItems.Size = new System.Drawing.Size(369, 628);
			this.gridItems.TabIndex = 32;
			this.gridItems.SelectionChanged += new System.EventHandler(this.gridItems_SelectionChanged);
			// 
			// gridDetails
			// 
			this.gridDetails.AllowUserToAddRows = false;
			this.gridDetails.AllowUserToDeleteRows = false;
			this.gridDetails.AllowUserToOrderColumns = true;
			this.gridDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridDetails.Location = new System.Drawing.Point(389, 221);
			this.gridDetails.MultiSelect = false;
			this.gridDetails.Name = "gridDetails";
			this.gridDetails.ReadOnly = true;
			this.gridDetails.RowTemplate.Height = 25;
			this.gridDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridDetails.Size = new System.Drawing.Size(1181, 628);
			this.gridDetails.TabIndex = 34;
			this.gridDetails.SelectionChanged += new System.EventHandler(this.gridDetails_SelectionChanged);
			// 
			// btnLoadFromDisk
			// 
			this.btnLoadFromDisk.Location = new System.Drawing.Point(251, 96);
			this.btnLoadFromDisk.Name = "btnLoadFromDisk";
			this.btnLoadFromDisk.Size = new System.Drawing.Size(144, 23);
			this.btnLoadFromDisk.TabIndex = 27;
			this.btnLoadFromDisk.Text = "Load From Disk";
			this.btnLoadFromDisk.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(549, 51);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(153, 15);
			this.label7.TabIndex = 37;
			this.label7.Text = "Include Filters (applied first)";
			// 
			// textboxIncludeFilters
			// 
			this.textboxIncludeFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textboxIncludeFilters.Location = new System.Drawing.Point(549, 69);
			this.textboxIncludeFilters.Name = "textboxIncludeFilters";
			this.textboxIncludeFilters.Size = new System.Drawing.Size(436, 23);
			this.textboxIncludeFilters.TabIndex = 36;
			this.textboxIncludeFilters.Text = "jpg,zip";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(994, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(149, 15);
			this.label2.TabIndex = 40;
			this.label2.Text = "Exclude Filters (applied last";
			// 
			// textboxExcludeFilters
			// 
			this.textboxExcludeFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textboxExcludeFilters.Location = new System.Drawing.Point(994, 68);
			this.textboxExcludeFilters.Name = "textboxExcludeFilters";
			this.textboxExcludeFilters.Size = new System.Drawing.Size(436, 23);
			this.textboxExcludeFilters.TabIndex = 39;
			this.textboxExcludeFilters.Text = "thumb";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label8.Location = new System.Drawing.Point(11, 124);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(173, 22);
			this.label8.TabIndex = 43;
			this.label8.Text = "Size of Selected (bytes)";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textboxSelectionSize
			// 
			this.textboxSelectionSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textboxSelectionSize.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textboxSelectionSize.Location = new System.Drawing.Point(190, 124);
			this.textboxSelectionSize.Name = "textboxSelectionSize";
			this.textboxSelectionSize.Size = new System.Drawing.Size(687, 22);
			this.textboxSelectionSize.TabIndex = 42;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1584, 861);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textboxSelectionSize);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textboxExcludeFilters);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textboxIncludeFilters);
			this.Controls.Add(this.gridDetails);
			this.Controls.Add(this.gridItems);
			this.Controls.Add(this.labelCounter);
			this.Controls.Add(this.btnGrabFileMetadata);
			this.Controls.Add(this.datagridCollectionMetadata);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.progressMain);
			this.Controls.Add(this.btnDownloadMetadata);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textCollectionName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textDestinationFolder);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.IsMdiContainer = true;
			this.Name = "mainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AAAAAAAAAHHH version 0.0 not even alpha";
			((System.ComponentModel.ISupportInitialize)(this.datagridCollectionMetadata)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TreeView tvEnumeratedItems;
		private System.Windows.Forms.TextBox textDestinationFolder;
		private System.Windows.Forms.Button btnDownloadMetadata;
		private System.Windows.Forms.TextBox txtCollectionURL;
		private System.Windows.Forms.TextBox textCollectionName;
		private System.Windows.Forms.ProgressBar progressMain;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridView datagridCollectionMetadata;
		private System.Windows.Forms.Button btnGrabFileMetadata;
		private System.Windows.Forms.Timer timerRefresh;
		private System.Windows.Forms.Label labelCounter;
		private System.Windows.Forms.DataGridViewTextBoxColumn identifier;
		private System.Windows.Forms.DataGridView gridItems;
		private System.Windows.Forms.DataGridView gridDetails;
		private System.Windows.Forms.Button btnLoadFromDisk;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textboxIncludeFilters;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Ex;
		private System.Windows.Forms.TextBox textboxExcludeFilters;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textboxSelectionSize;
	}
}

