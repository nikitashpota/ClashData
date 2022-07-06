using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.DocumentParts;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Internal.ApiImplementation;
using Autodesk.Navisworks.Api.Automation;
using Autodesk.Navisworks.Api.Plugins;
using ClashData;


//-----For Navisworks 2019-----//
namespace StartView //Created by Carlo Caparas
{
    [PluginAttribute("StartView.Start",    //Namespace.Starting class of the plugin (where the override function is)
     "CD.CAC",  // Your dev ID (It can be anything up to 7 letters I believe)
     ToolTip = "Export Clash Info to Excel",    //Plugin Tooltip content
     DisplayName = "Export Clash Data")]    //Name of the plugin button.
    [RibbonLayout("AddinRibbon.xaml")]
    [RibbonTab("MODUS BIM")]
    [Command("Clash_Data_Exporter", ToolTip = "Export Clash Detective Data to Excel for Power BI")]

    public class Start : CommandHandlerPlugin
    {
        public override int ExecuteCommand(string name, params string[] parameters)
        {
            var window = UserControlWindow.Get();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(window);
            switch (name)
            {
                case "Clash_Data_Exporter":
                    window.Show();
                    break;
            }

            return 0;
        }
    }
}