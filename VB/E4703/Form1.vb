Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Design
Imports System.ComponentModel.Design
Imports E4703.nwindDataSetTableAdapters
Imports System.Reflection

Namespace E4703
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim tool As New ReportDesignTool(New XtraReport2())
			' Handle the DesignMdiController.DesignPanelLoaded event
			AddHandler tool.DesignForm.DesignMdiController.DesignPanelLoaded, AddressOf DesignMdiController_DesignPanelLoaded
			' Show End-User Report Designer
			tool.ShowDesigner()
		End Sub

		Private Sub DesignMdiController_DesignPanelLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)
			' Get access to an instanse of the IToolboxService interface
			Dim ts As IToolboxService = CType(e.DesignerHost.GetService(GetType(IToolboxService)), IToolboxService)
			' Get access to the collection of the toolbox items
			Dim collection As ToolboxItemCollection = ts.GetToolboxItems()
			If collection.Count <> 0 Then
				' Change name of the report control
				collection(0).DisplayName = "Report Label"
			End If

			Dim host As IDesignerHost = e.DesignerHost

			Dim ds As New nwindDataSet()
			' Search DataSet component
			For Each comp As IComponent In host.Container.Components
				ds = TryCast(comp, nwindDataSet)
				If (Not Object.Equals(ds, Nothing)) Then
					' Delete data source from designer host
					host.Container.Remove(ds)
					Exit For
				End If
			Next comp
			' In this place you can define your own report data source
			host.Container.Add(ds, "ReportDataSource")

			Dim adapter As New CategoriesTableAdapter()
			' Search TableAdapter component
			For Each comp As IComponent In host.Container.Components
				adapter = TryCast(comp, CategoriesTableAdapter)
				If (Not Object.Equals(adapter, Nothing)) Then
					' Delete table adapter from designer host
					host.Container.Remove(adapter)
					Exit For
				End If
			Next comp
			' In this place you can define your own report table adapter
			host.Container.Add(adapter, "ReportTableAdapter")
		End Sub
	End Class
End Namespace
