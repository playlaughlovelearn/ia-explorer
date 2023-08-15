using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Json.Net;
using Newtonsoft.Json;

using System.Security;
using System.Net.Http;
using System.Threading;
using System.Collections;

struct metadataRecordClass
{
	public string identifier;
	public string description;
	public string mediatype;
	public string title;
	public string uploader;
	public string curation;
	public string collection;
	public string backup_location;
	public DateTime? publicDate;
	public DateTime? addedDate;
	public bool hidden;
};


namespace ia_explorer
{
	public partial class mainForm : Form
	{
		public ArchiveCollection ia = null;
		internal HttpClient m_httpClient = new();


		public mainForm()
		{
			InitializeComponent();
			//ThreadPool.SetMaxThreads(64, 64);
		}

		public void RefreshCellStyles()
		{
		}

		public DataGridViewCellStyle GetCellStyle(Color fore, Color back)
		{
			DataGridViewCellStyle retVal = new DataGridViewCellStyle();
			retVal.ForeColor = fore;
			retVal.BackColor = back;

			return retVal;
		}
		 
		private string outputPathRoot { get => Path.TrimEndingDirectorySeparator(textDestinationFolder.Text); }
		private string collectionName { get => textCollectionName.Text; }

		#region download metadata
		Thread backgroundDownloadThread = null;
		private void btnDownloadMetadata_Click(object sender, EventArgs e)
		{
			backgroundDownloadThread = new Thread(x => downloadMetadataThread(x));
			disableSelectionChanged = true;

			timerRefresh.Start();

			backgroundDownloadThread.Start(this);
		}

		private static void downloadMetadataThread(object parameter)
		{
			mainForm appForm = (mainForm)parameter;
			appForm.downloadMetadata();
		}
		  
		private void downloadMetadata()
		{
			ia = new ArchiveCollection();
			ia.DownloadAndLoadCollection(outputPathRoot, collectionName, () => onLoadComplete());
		}

		private void onLoadComplete()
		{
			disableSelectionChanged = false;

			BeginInvoke((Action)(() => {
				progressMain.Maximum = progressMain.Value;
				datagridCollectionMetadata.DataSource = ia.collectionsMetadata;
				gridItems.DataSource = ia.itemsMetadata;
				timerRefresh.Enabled = false;

				updateStyles();
			}));
		}
		#endregion

		private void btnClear_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(
				"Warning, this will clear all files from the output folder.\n\nThis cannot be undone!",
				"Clear Output Folder?",
				MessageBoxButtons.YesNo, 
				MessageBoxIcon.Warning
			);

			if (result == DialogResult.Yes)
			{
				Directory.Delete(outputPathRoot, true);
			}
		}

		private void timerRefresh_Tick(object sender, EventArgs e)
		{
			progressMain.Maximum = ia.itemCount;
			progressMain.Value = ia.itemLoadProgress;
			labelCounter.Text = $"{progressMain.Value} / {progressMain.Maximum}";

			labelCounter.Refresh();
			progressMain.Refresh();
		}

		bool disableSelectionChanged = false;

		DataGridViewCellStyle defaultStyle = null;

		private void updateItemStyles()
		{
			int visibleRowStart = gridItems.Rows.GetFirstRow(DataGridViewElementStates.Visible);
			int visibleRowCount = gridItems.Rows.GetRowCount(DataGridViewElementStates.Visible);

			for (int i = visibleRowStart; i < visibleRowCount + visibleRowStart; ++i)
			{
				DataGridViewRow row = gridItems.Rows[i];
				ItemMetadata itemMetadata = (ItemMetadata) row.DataBoundItem;

				if (itemMetadata.AnyFilesDownloaded())
				{
					row.DefaultCellStyle.BackColor = Color.Green;
					row.DefaultCellStyle.ForeColor = Color.White;
				}
			}
		}

		private void updateDetailStyles()
		{
			for(int i = 0; i < gridDetails.Rows.Count; ++i)
			{
				DataGridViewRow row = gridDetails.Rows[i];
				FileMetadata fileMetadata = (FileMetadata)row.DataBoundItem;

				if (fileMetadata.IsFileDownloaded())
				{
					row.DefaultCellStyle.BackColor = Color.Yellow;
					row.DefaultCellStyle.ForeColor = Color.Black;
				}
			}

			gridDetails.Invalidate();
		}


		private void updateStyles()
		{
			updateItemStyles();
			updateDetailStyles();
		}

		private void gridItems_SelectionChanged(object sender, EventArgs e)
		{
			if (disableSelectionChanged)
				return;

			updateStyles();

			DataGridViewSelectedRowCollection selectedItems = gridItems.SelectedRows;
			List<string> identifiers = new List<string>();

			List<FileMetadata> selectedFiles = new List<FileMetadata>();

			long totalSize = 0;

			for (int i=0; i < selectedItems.Count; ++i)
			{
				var gridRow = selectedItems[i];

				ItemMetadata itemMetadata = (ItemMetadata)gridRow.DataBoundItem;
				identifiers.Add(itemMetadata.identifier);

				string[] includeFilters = textboxIncludeFilters.Text.Split(",", StringSplitOptions.RemoveEmptyEntries);
				string[] excludeFilters = textboxExcludeFilters.Text.Split(",", StringSplitOptions.RemoveEmptyEntries);

				for (int j = 0; j < itemMetadata.files_count; ++j)
				{
					bool include = false;

					foreach (string includeFilter in includeFilters)
						if (itemMetadata.fileItems[j].name.Contains(includeFilter))
							include = true;

					foreach (string excludeFilter in excludeFilters)
						if (itemMetadata.fileItems[j].name.Contains(excludeFilter))
							include = false;

					if (!include)
						continue;

					totalSize += itemMetadata.fileItems[j].size_bytes;	
					selectedFiles.Add(itemMetadata.fileItems[j]);
				}
			}

			textboxSelectionSize.Text = totalSize.ToString() + " (" + (totalSize/1024).ToString() + "kB) " + "(" + (totalSize/1024/1024).ToString() + "MB)";

			gridDetails.DataSource = selectedFiles;
		}

		private async void btnGrabFileMetadata_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < gridDetails.Rows.Count; ++i)
			{
				DataGridViewRow row = gridDetails.Rows[i];
				FileMetadata rowMetadata = (FileMetadata)row.DataBoundItem;
				await rowMetadata.DownloadFile();
			}
		}

		private void gridDetails_SelectionChanged(object sender, EventArgs e)
		{
			gridDetails.ClearSelection();
		}
	}
}
