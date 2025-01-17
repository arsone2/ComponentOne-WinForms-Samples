﻿Imports System.IO
Imports System.Reflection
Imports C1.LiveLinq
Imports C1.LiveLinq.AdoNet
Imports C1.LiveLinq.LiveViews
Imports System.Configuration
Imports System.Globalization

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' generated automatically
        productsTableAdapter.Fill(nORTHWNDDataSet.Products)
        categoriesTableAdapter.Fill(nORTHWNDDataSet.Categories)

        comboBox1.DataSource = bindingSource1
        comboBox1.DisplayMember = "CategoryName"

        ' Create a live view for Categories.
        ' Each category contains a list with the products of that category. 

        C1.LiveLinq.AdoNet.AdoNetExtensions.AsLive(nORTHWNDDataSet.Categories)

        Dim categoryView =
            From c In nORTHWNDDataSet.Categories.AsLive()
            Group Join p In nORTHWNDDataSet.Products.AsLive()
                On c.CategoryID Equals p.CategoryID Into g = Group
            Select New With
            {
                c.CategoryID,
                c.CategoryName,
                .FK_Products_Categories = g
            }

        ' replace DataSource on the form to use our LiveLinq Query
        bindingSource1.DataSource = categoryView.AsDynamic()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\ComponentOne Samples\Common")
        Dim dbFile As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\ComponentOne Samples\Common", "Northwnd.mdf")
        If Not File.Exists(dbFile) Then
            Throw New Exception("Sample database Northwnd.mdf must be created in the Common folder. Run the CreateSampleDB utility to create the Northwind database")
        End If

        ' make sure both version 11 and version 12 or higher of SQLServer LocalDb are supported
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions")

        If key Is Nothing Then
            Throw New Exception("Microsoft SQL Server LocalDB is not installed.")
        End If

        Dim version As String = "v11.0"

        For Each subKeyName In key.GetSubKeyNames()
            Dim localDBVersion As Double = 0
            If Double.TryParse(subKeyName, NumberStyles.Number, CultureInfo.InvariantCulture, localDBVersion) And localDBVersion >= 12 Then
                version = "MSSQLLocalDB"
                Exit For
            End If
        Next

        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim connStr = config.ConnectionStrings.ConnectionStrings("Traditional.My.MySettings.NORTHWNDConnectionString")
        connStr.ConnectionString = connStr.ConnectionString.Replace("v11.0", version)
        config.Save(ConfigurationSaveMode.Modified, True)
        ConfigurationManager.RefreshSection("connectionStrings")
    End Sub

End Class