using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Drawing.Design;
using System.ComponentModel.Design;
using E4703.nwindDataSetTableAdapters;
using System.Reflection;

namespace E4703
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDesignTool tool = new ReportDesignTool(new XtraReport2());
            // Handle the DesignMdiController.DesignPanelLoaded event
            tool.DesignForm.DesignMdiController.DesignPanelLoaded += new DevExpress.XtraReports.UserDesigner.DesignerLoadedEventHandler(DesignMdiController_DesignPanelLoaded);
            // Show End-User Report Designer
            tool.ShowDesigner();
        }

        void DesignMdiController_DesignPanelLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            // Get access to an instanse of the IToolboxService interface
            IToolboxService ts = (IToolboxService)e.DesignerHost.GetService(typeof(IToolboxService));
            // Get access to the collection of the toolbox items
            ToolboxItemCollection collection = ts.GetToolboxItems();
            foreach(ToolboxItem item in collection)
            {
                if(item.DisplayName == "Label")
                // Change name of the report control
                    collection[0].DisplayName = "Report Label";
            }

            IDesignerHost host = e.DesignerHost;

            nwindDataSet ds = new nwindDataSet();
            // Search DataSet component
            foreach (IComponent comp in host.Container.Components)
            {
                ds = comp as nwindDataSet;            
                if (!Object.Equals(ds, null)) {
                    // Delete data source from designer host
                    host.Container.Remove(ds);
                    break;
                }
            }
            // In this place you can define your own report data source
            host.Container.Add(ds, "ReportDataSource");

            CategoriesTableAdapter adapter = new CategoriesTableAdapter();
            // Search TableAdapter component
            foreach (IComponent comp in host.Container.Components) {                
                adapter = comp as CategoriesTableAdapter;                
                if (!Object.Equals(adapter, null))
                {
                    // Delete table adapter from designer host
                    host.Container.Remove(adapter);
                    break;
                }
            }
            // In this place you can define your own report table adapter
            host.Container.Add(adapter, "ReportTableAdapter");
        }
    }
}
