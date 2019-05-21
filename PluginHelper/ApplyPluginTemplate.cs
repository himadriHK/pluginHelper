using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace PluginHelper
{
	/// <summary>
	/// Command handler
	/// </summary>
	internal sealed class ApplyPluginTemplate
	{
		/// <summary>
		/// Command ID.
		/// </summary>
		public const int CommandId = 0x0100;

		/// <summary>
		/// Command menu group (command set GUID).
		/// </summary>
		public static readonly Guid CommandSet = new Guid("02208204-ab80-4eed-9e75-d4d219242725");

		/// <summary>
		/// VS Package that provides this command, not null.
		/// </summary>
		private readonly AsyncPackage package;

		/// <summary>
		/// Initializes a new instance of the <see cref="ApplyPluginTemplate"/> class.
		/// Adds our command handlers for menu (commands must exist in the command table file)
		/// </summary>
		/// <param name="package">Owner package, not null.</param>
		/// <param name="commandService">Command service to add command to, not null.</param>
		private ApplyPluginTemplate(AsyncPackage package, OleMenuCommandService commandService)
		{
			this.package = package ?? throw new ArgumentNullException(nameof(package));
			commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

			var menuCommandID = new CommandID(CommandSet, CommandId);
			var menuItem = new MenuCommand(this.Execute, menuCommandID);
			commandService.AddCommand(menuItem);
		}

		/// <summary>
		/// Gets the instance of the command.
		/// </summary>
		public static ApplyPluginTemplate Instance
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the service provider from the owner package.
		/// </summary>
		private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
		{
			get
			{
				return this.package;
			}
		}

		/// <summary>
		/// Initializes the singleton instance of the command.
		/// </summary>
		/// <param name="package">Owner package, not null.</param>
		public static async Task InitializeAsync(AsyncPackage package)
		{
			// Switch to the main thread - the call to AddCommand in ApplyPluginTemplate's constructor requires
			// the UI thread.
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

			OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
			Instance = new ApplyPluginTemplate(package, commandService);
		}

		/// <summary>
		/// This function is the callback used to execute the command when the menu item is clicked.
		/// See the constructor to see how the menu item is associated with this function using
		/// OleMenuCommandService service and MenuCommand class.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event args.</param>
		private async void Execute(object sender, EventArgs e)
		{
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
			DTE2 dte2 = (EnvDTE80.DTE2) ServiceProvider.GetServiceAsync(typeof(SDTE)).Result;
			string selectedFolder = dte2.SelectedItems.Count > 0 ? dte2.SelectedItems.Item(1).Name : "NewProject";
			//string destFolderName = Microsoft.VisualBasic.Interaction.InputBox("Enter Path", "Project Path",Path.Combine(Path.GetDirectoryName(dte2.Solution.FileName), selectedFolder));
			string localPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				"PluginHelper");
			Directory.CreateDirectory(localPath);
			TemplateSelector ts= new TemplateSelector(pluginHelper.Default.NetworkPathForTemplateCollection,localPath);
			ts.ShowDialog();
			
			//Microsoft.VisualBasic.Interaction.MsgBox(destFolderName, MsgBoxStyle.DefaultButton1, "path");
		}

		private void UpdateTemplates()
		{
			
		}
	}
}
