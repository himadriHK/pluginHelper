using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;

namespace PluginHelper
{
	public partial class TemplateSelector : Form
	{
		public TemplateSelector()
		{
			InitializeComponent();
		}

		public string SelectedTemplatePath;
		private string networkPath;
		private string localPath;
		public TemplateSelector(string networkTemplateCollectionPath, string localTemplateCollectionPath) : this()
		{
			networkPath = networkTemplateCollectionPath;
			localPath = localTemplateCollectionPath;
			cmbTemplateSelect.DataSource = new BindingSource(BuildTemplateListFromLocal(), null);
			cmbTemplateSelect.DisplayMember = "Key";
			cmbTemplateSelect.ValueMember = "Value";
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			SelectedTemplatePath = (string)cmbTemplateSelect.SelectedValue;
			Close();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			SyncFileSystem(networkPath,localPath);
			cmbTemplateSelect.DataSource = new BindingSource(BuildTemplateListFromLocal(), null);
			cmbTemplateSelect.DisplayMember = "Key";
			cmbTemplateSelect.ValueMember = "Value";
		}

		private void SyncFileSystem(
			string sourcePath, string destinationPath)
		{
			FileSyncProvider sourceProvider = null;
			FileSyncProvider destinationProvider = null;
			FileSyncScopeFilter filter = new FileSyncScopeFilter();
			filter.FileNameIncludes.Add("*.zip");
			FileSyncOptions options = FileSyncOptions.None;
			try
			{
				sourceProvider = new FileSyncProvider(
					sourcePath, filter, options);
				destinationProvider = new FileSyncProvider(
					destinationPath, filter, options);

				SyncOrchestrator agent = new SyncOrchestrator();
				agent.LocalProvider = sourceProvider;
				agent.RemoteProvider = destinationProvider;
				agent.Direction = SyncDirectionOrder.Upload; 

				agent.Synchronize();
			}
			finally
			{
				if (sourceProvider != null) sourceProvider.Dispose();
				if (destinationProvider != null) destinationProvider.Dispose();
			}
		}

		private Dictionary<string, string> BuildTemplateListFromLocal()
		{
			Dictionary<string,string> templateDictionary = new Dictionary<string, string>();
			if (Directory.Exists(localPath))
			{
				foreach (var file in Directory.GetFiles(localPath,"*.zip"))
				{
					templateDictionary.Add(Path.GetFileName(file),file);
				}

				
			}

			return templateDictionary;
		}
	}
}
