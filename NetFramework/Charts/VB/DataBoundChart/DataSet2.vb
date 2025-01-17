﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.0.3705.288
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Xml


<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Diagnostics.DebuggerStepThrough(),  _
 System.ComponentModel.ToolboxItem(true)>  _
Public Class DataSet2
    Inherits DataSet
    
    Private tableCategories As CategoriesDataTable
    
    Public Sub New()
        MyBase.New
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(System.String)),String)
        If (Not (strSchema) Is Nothing) Then
            Dim ds As DataSet = New DataSet
            ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("Categories")) Is Nothing) Then
                Me.Tables.Add(New CategoriesDataTable(ds.Tables("Categories")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.InitClass
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property Categories As CategoriesDataTable
        Get
            Return Me.tableCategories
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As DataSet2 = CType(MyBase.Clone,DataSet2)
        cln.InitVars
        Return cln
    End Function
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
        Me.Reset
        Dim ds As DataSet = New DataSet
        ds.ReadXml(reader)
        If (Not (ds.Tables("Categories")) Is Nothing) Then
            Me.Tables.Add(New CategoriesDataTable(ds.Tables("Categories")))
        End If
        Me.DataSetName = ds.DataSetName
        Me.Prefix = ds.Prefix
        Me.Namespace = ds.Namespace
        Me.Locale = ds.Locale
        Me.CaseSensitive = ds.CaseSensitive
        Me.EnforceConstraints = ds.EnforceConstraints
        Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
        Me.InitVars
    End Sub
    
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
    End Function
    
    Friend Sub InitVars()
        Me.tableCategories = CType(Me.Tables("Categories"),CategoriesDataTable)
        If (Not (Me.tableCategories) Is Nothing) Then
            Me.tableCategories.InitVars
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "DataSet2"
        Me.Prefix = ""
        Me.Namespace = "http://www.tempuri.org/DataSet2.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableCategories = New CategoriesDataTable
        Me.Tables.Add(Me.tableCategories)
    End Sub
    
    Private Function ShouldSerializeCategories() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub CategoriesRowChangeEventHandler(ByVal sender As Object, ByVal e As CategoriesRowChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class CategoriesDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnCategoryName As DataColumn
        
        Private columnCategoryID As DataColumn
        
        Friend Sub New()
            MyBase.New("Categories")
            Me.InitClass
        End Sub
        
        Friend Sub New(ByVal table As DataTable)
            MyBase.New(table.TableName)
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
            Me.DisplayExpression = table.DisplayExpression
        End Sub
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Friend ReadOnly Property CategoryNameColumn As DataColumn
            Get
                Return Me.columnCategoryName
            End Get
        End Property
        
        Friend ReadOnly Property CategoryIDColumn As DataColumn
            Get
                Return Me.columnCategoryID
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As CategoriesRow
            Get
                Return CType(Me.Rows(index),CategoriesRow)
            End Get
        End Property
        
        Public Event CategoriesRowChanged As CategoriesRowChangeEventHandler
        
        Public Event CategoriesRowChanging As CategoriesRowChangeEventHandler
        
        Public Event CategoriesRowDeleted As CategoriesRowChangeEventHandler
        
        Public Event CategoriesRowDeleting As CategoriesRowChangeEventHandler
        
        Public Overloads Sub AddCategoriesRow(ByVal row As CategoriesRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddCategoriesRow(ByVal CategoryName As String, ByVal CategoryID As Integer) As CategoriesRow
            Dim rowCategoriesRow As CategoriesRow = CType(Me.NewRow,CategoriesRow)
            rowCategoriesRow.ItemArray = New Object() {CategoryName, CategoryID}
            Me.Rows.Add(rowCategoriesRow)
            Return rowCategoriesRow
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As CategoriesDataTable = CType(MyBase.Clone,CategoriesDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New CategoriesDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnCategoryName = Me.Columns("CategoryName")
            Me.columnCategoryID = Me.Columns("CategoryID")
        End Sub
        
        Private Sub InitClass()
            Me.columnCategoryName = New DataColumn("CategoryName", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnCategoryName)
            Me.columnCategoryID = New DataColumn("CategoryID", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnCategoryID)
        End Sub
        
        Public Function NewCategoriesRow() As CategoriesRow
            Return CType(Me.NewRow,CategoriesRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New CategoriesRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(CategoriesRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.CategoriesRowChangedEvent) Is Nothing) Then
                RaiseEvent CategoriesRowChanged(Me, New CategoriesRowChangeEvent(CType(e.Row,CategoriesRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.CategoriesRowChangingEvent) Is Nothing) Then
                RaiseEvent CategoriesRowChanging(Me, New CategoriesRowChangeEvent(CType(e.Row,CategoriesRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.CategoriesRowDeletedEvent) Is Nothing) Then
                RaiseEvent CategoriesRowDeleted(Me, New CategoriesRowChangeEvent(CType(e.Row,CategoriesRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.CategoriesRowDeletingEvent) Is Nothing) Then
                RaiseEvent CategoriesRowDeleting(Me, New CategoriesRowChangeEvent(CType(e.Row,CategoriesRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveCategoriesRow(ByVal row As CategoriesRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class CategoriesRow
        Inherits DataRow
        
        Private tableCategories As CategoriesDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableCategories = CType(Me.Table,CategoriesDataTable)
        End Sub
        
        Public Property CategoryName As String
            Get
                Try 
                    Return CType(Me(Me.tableCategories.CategoryNameColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableCategories.CategoryNameColumn) = value
            End Set
        End Property
        
        Public Property CategoryID As Integer
            Get
                Try 
                    Return CType(Me(Me.tableCategories.CategoryIDColumn),Integer)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableCategories.CategoryIDColumn) = value
            End Set
        End Property
        
        Public Function IsCategoryNameNull() As Boolean
            Return Me.IsNull(Me.tableCategories.CategoryNameColumn)
        End Function
        
        Public Sub SetCategoryNameNull()
            Me(Me.tableCategories.CategoryNameColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsCategoryIDNull() As Boolean
            Return Me.IsNull(Me.tableCategories.CategoryIDColumn)
        End Function
        
        Public Sub SetCategoryIDNull()
            Me(Me.tableCategories.CategoryIDColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class CategoriesRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As CategoriesRow
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As CategoriesRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As CategoriesRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        Public ReadOnly Property Action As DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
