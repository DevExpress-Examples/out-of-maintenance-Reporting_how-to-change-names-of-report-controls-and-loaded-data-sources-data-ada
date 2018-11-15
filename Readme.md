<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/E4703/Form1.cs) (VB: [Form1.vb](./VB/E4703/Form1.vb))**
<!-- default file list end -->
# How to change names of report controls and loaded data sources (data adapters) in the End-User Report Designer


<p>The main idea to accomplish this task is handle the <a href="http://documentation.devexpress.com/#XtraReports/DevExpressXtraReportsUserDesignerXRDesignMdiController_DesignPanelLoadedtopic"><u>XRDesignMdiController.DesignPanelLoaded</u></a><u> </u>event and get access to the designer host to change the name of the report data source and table adapter. Then, it is necessary to use an instance of the IToolboxService interface to change the name of report controls.</p>

<br/>


