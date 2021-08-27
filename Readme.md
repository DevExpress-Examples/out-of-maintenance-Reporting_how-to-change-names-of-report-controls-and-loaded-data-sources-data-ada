<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128598900/11.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4703)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/E4703/Form1.cs) (VB: [Form1.vb](./VB/E4703/Form1.vb))**
<!-- default file list end -->
# How to change names of report controls and loaded data sources (data adapters) in the End-User Report Designer


<p>The main idea to accomplish this task is handle the <a href="http://documentation.devexpress.com/#XtraReports/DevExpressXtraReportsUserDesignerXRDesignMdiController_DesignPanelLoadedtopic"><u>XRDesignMdiController.DesignPanelLoaded</u></a><u> </u>event and get access to the designer host to change the name of the report data source and table adapter. Then, it is necessary to use an instance of the IToolboxService interface to change the name of report controls.</p>

<br/>


