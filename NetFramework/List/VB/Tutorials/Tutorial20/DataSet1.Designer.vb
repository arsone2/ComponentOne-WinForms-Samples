﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version:2.0.41115.19
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System


<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.ComponentModel.ToolboxItem(true),  _
 System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema"),  _
 System.Xml.Serialization.XmlRootAttribute("DataSet1")>  _
Partial Public Class DataSet1
    Inherits System.Data.DataSet
    
    Private tableComposer As ComposerDataTable
    
    Public Sub New()
        MyBase.New
        Me.BeginInit
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler MyBase.Relations.CollectionChanged, schemaChangedHandler
        Me.EndInit
    End Sub
    
    Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context)
        If (Me.IsBinarySerialized(info, context) = true) Then
            Me.InitVars(false)
            Dim schemaChangedHandler1 As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
            AddHandler Me.Tables.CollectionChanged, schemaChangedHandler1
            AddHandler Me.Relations.CollectionChanged, schemaChangedHandler1
            Return
        End If
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(String)),String)
        If (Not (strSchema) Is Nothing) Then
            Dim ds As System.Data.DataSet = New System.Data.DataSet
            ds.ReadXmlSchema(New System.Xml.XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("Composer")) Is Nothing) Then
                MyBase.Tables.Add(New ComposerDataTable(ds.Tables("Composer")))
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
            Me.BeginInit
            Me.InitClass
            Me.EndInit
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property Composer() As ComposerDataTable
        Get
            Return Me.tableComposer
        End Get
    End Property
    
    <System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Tables() As System.Data.DataTableCollection
        Get
            Return MyBase.Tables
        End Get
    End Property
    
    <System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Relations() As System.Data.DataRelationCollection
        Get
            Return MyBase.Relations
        End Get
    End Property
    
    <System.ComponentModel.DefaultValueAttribute(true)>  _
    Public Shadows Property EnforceConstraints() As Boolean
        Get
            Return MyBase.EnforceConstraints
        End Get
        Set
            MyBase.EnforceConstraints = value
        End Set
    End Property
    
    Public Overrides Function Clone() As System.Data.DataSet
        Dim cln As DataSet1 = CType(MyBase.Clone,DataSet1)
        cln.InitVars
        Return cln
    End Function
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As System.Xml.XmlReader)
        Me.Reset
        Dim ds As System.Data.DataSet = New System.Data.DataSet
        ds.ReadXml(reader)
        If (Not (ds.Tables("Composer")) Is Nothing) Then
            MyBase.Tables.Add(New ComposerDataTable(ds.Tables("Composer")))
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
        Me.WriteXmlSchema(New System.Xml.XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New System.Xml.XmlTextReader(stream), Nothing)
    End Function
    
    Friend Overloads Sub InitVars()
        Me.InitVars(true)
    End Sub
    
    Friend Overloads Sub InitVars(ByVal initTable As Boolean)
        Me.tableComposer = CType(MyBase.Tables("Composer"),ComposerDataTable)
        If (initTable = true) Then
            If (Not (Me.tableComposer) Is Nothing) Then
                Me.tableComposer.InitVars
            End If
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "DataSet1"
        Me.Prefix = ""
        Me.Namespace = "http://www.tempuri.org/DataSet1.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableComposer = New ComposerDataTable
        MyBase.Tables.Add(Me.tableComposer)
    End Sub
    
    Private Function ShouldSerializeComposer() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Shared Function GetTypedDataSetSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
        Dim ds As DataSet1 = New DataSet1
        Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
        xs.Add(ds.GetSchemaSerializable)
        Dim any As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Return type
    End Function
    
    Public Delegate Sub ComposerRowChangeEventHandler(ByVal sender As Object, ByVal e As ComposerRowChangeEvent)
    
    <System.Serializable(),  _
     System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class ComposerDataTable
        Inherits System.Data.DataTable
        Implements System.Collections.IEnumerable
        
        Private columnBirth As System.Data.DataColumn
        
        Private columnCountry As System.Data.DataColumn
        
        Private columnDeath As System.Data.DataColumn
        
        Private columnFirst As System.Data.DataColumn
        
        Private columnLast As System.Data.DataColumn
        
        Public Sub New()
            MyBase.New
            Me.TableName = "Composer"
            Me.BeginInit
            Me.InitClass
            Me.EndInit
        End Sub
        
        Friend Sub New(ByVal table As System.Data.DataTable)
            MyBase.New
            Me.TableName = table.TableName
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
        End Sub
        
        Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
            Me.InitVars
        End Sub
        
        Public ReadOnly Property BirthColumn() As System.Data.DataColumn
            Get
                Return Me.columnBirth
            End Get
        End Property
        
        Public ReadOnly Property CountryColumn() As System.Data.DataColumn
            Get
                Return Me.columnCountry
            End Get
        End Property
        
        Public ReadOnly Property DeathColumn() As System.Data.DataColumn
            Get
                Return Me.columnDeath
            End Get
        End Property
        
        Public ReadOnly Property FirstColumn() As System.Data.DataColumn
            Get
                Return Me.columnFirst
            End Get
        End Property
        
        Public ReadOnly Property LastColumn() As System.Data.DataColumn
            Get
                Return Me.columnLast
            End Get
        End Property
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count() As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As ComposerRow
            Get
                Return CType(Me.Rows(index),ComposerRow)
            End Get
        End Property
        
        Public Event ComposerRowChanged As ComposerRowChangeEventHandler
        
        Public Event ComposerRowChanging As ComposerRowChangeEventHandler
        
        Public Event ComposerRowDeleted As ComposerRowChangeEventHandler
        
        Public Event ComposerRowDeleting As ComposerRowChangeEventHandler
        
        Public Overloads Sub AddComposerRow(ByVal row As ComposerRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddComposerRow(ByVal Birth As Date, ByVal Country As String, ByVal Death As Date, ByVal First As String, ByVal Last As String) As ComposerRow
            Dim rowComposerRow As ComposerRow = CType(Me.NewRow,ComposerRow)
            rowComposerRow.ItemArray = New Object() {Birth, Country, Death, First, Last}
            Me.Rows.Add(rowComposerRow)
            Return rowComposerRow
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As System.Data.DataTable
            Dim cln As ComposerDataTable = CType(MyBase.Clone,ComposerDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As System.Data.DataTable
            Return New ComposerDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnBirth = MyBase.Columns("Birth")
            Me.columnCountry = MyBase.Columns("Country")
            Me.columnDeath = MyBase.Columns("Death")
            Me.columnFirst = MyBase.Columns("First")
            Me.columnLast = MyBase.Columns("Last")
        End Sub
        
        Private Sub InitClass()
            Me.columnBirth = New System.Data.DataColumn("Birth", GetType(Date), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnBirth)
            Me.columnCountry = New System.Data.DataColumn("Country", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnCountry)
            Me.columnDeath = New System.Data.DataColumn("Death", GetType(Date), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnDeath)
            Me.columnFirst = New System.Data.DataColumn("First", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnFirst)
            Me.columnLast = New System.Data.DataColumn("Last", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnLast)
            Me.Locale = New System.Globalization.CultureInfo("en-US")
        End Sub
        
        Public Function NewComposerRow() As ComposerRow
            Return CType(Me.NewRow,ComposerRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New ComposerRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(ComposerRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.ComposerRowChangedEvent) Is Nothing) Then
                RaiseEvent ComposerRowChanged(Me, New ComposerRowChangeEvent(CType(e.Row,ComposerRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.ComposerRowChangingEvent) Is Nothing) Then
                RaiseEvent ComposerRowChanging(Me, New ComposerRowChangeEvent(CType(e.Row,ComposerRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.ComposerRowDeletedEvent) Is Nothing) Then
                RaiseEvent ComposerRowDeleted(Me, New ComposerRowChangeEvent(CType(e.Row,ComposerRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.ComposerRowDeletingEvent) Is Nothing) Then
                RaiseEvent ComposerRowDeleting(Me, New ComposerRowChangeEvent(CType(e.Row,ComposerRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveComposerRow(ByVal row As ComposerRow)
            Me.Rows.Remove(row)
        End Sub
        
        Public Shared Function GetTypedTableSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
            Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
            Dim ds As DataSet1 = New DataSet1
            xs.Add(ds.GetSchemaSerializable)
            Dim any1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
            any1.Namespace = "http://www.w3.org/2001/XMLSchema"
            any1.MinOccurs = New Decimal(0)
            any1.MaxOccurs = Decimal.MaxValue
            any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any1)
            Dim any2 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
            any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
            any2.MinOccurs = New Decimal(1)
            any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any2)
            Dim attribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute
            attribute1.Name = "namespace"
            attribute1.FixedValue = ds.Namespace
            type.Attributes.Add(attribute1)
            Dim attribute2 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute
            attribute2.Name = "tableTypeName"
            attribute2.FixedValue = "ComposerDataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Return type
        End Function
    End Class
    
    Partial Public Class ComposerRow
        Inherits System.Data.DataRow
        
        Private tableComposer As ComposerDataTable
        
        Friend Sub New(ByVal rb As System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableComposer = CType(Me.Table,ComposerDataTable)
        End Sub
        
        Public Property Birth() As Date
            Get
                Try 
                    Return CType(Me(Me.tableComposer.BirthColumn),Date)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("StrongTyping_CannotAccessDBNull for column Birth", e)
                End Try
            End Get
            Set
                Me(Me.tableComposer.BirthColumn) = value
            End Set
        End Property
        
        Public Property Country() As String
            Get
                Try 
                    Return CType(Me(Me.tableComposer.CountryColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("StrongTyping_CannotAccessDBNull for column Country", e)
                End Try
            End Get
            Set
                Me(Me.tableComposer.CountryColumn) = value
            End Set
        End Property
        
        Public Property Death() As Date
            Get
                Try 
                    Return CType(Me(Me.tableComposer.DeathColumn),Date)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("StrongTyping_CannotAccessDBNull for column Death", e)
                End Try
            End Get
            Set
                Me(Me.tableComposer.DeathColumn) = value
            End Set
        End Property
        
        Public Property First() As String
            Get
                Try 
                    Return CType(Me(Me.tableComposer.FirstColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("StrongTyping_CannotAccessDBNull for column First", e)
                End Try
            End Get
            Set
                Me(Me.tableComposer.FirstColumn) = value
            End Set
        End Property
        
        Public Property Last() As String
            Get
                Try 
                    Return CType(Me(Me.tableComposer.LastColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("StrongTyping_CannotAccessDBNull for column Last", e)
                End Try
            End Get
            Set
                Me(Me.tableComposer.LastColumn) = value
            End Set
        End Property
        
        Public Function IsBirthNull() As Boolean
            Return Me.IsNull(Me.tableComposer.BirthColumn)
        End Function
        
        Public Sub SetBirthNull()
            Me(Me.tableComposer.BirthColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsCountryNull() As Boolean
            Return Me.IsNull(Me.tableComposer.CountryColumn)
        End Function
        
        Public Sub SetCountryNull()
            Me(Me.tableComposer.CountryColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsDeathNull() As Boolean
            Return Me.IsNull(Me.tableComposer.DeathColumn)
        End Function
        
        Public Sub SetDeathNull()
            Me(Me.tableComposer.DeathColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsFirstNull() As Boolean
            Return Me.IsNull(Me.tableComposer.FirstColumn)
        End Function
        
        Public Sub SetFirstNull()
            Me(Me.tableComposer.FirstColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsLastNull() As Boolean
            Return Me.IsNull(Me.tableComposer.LastColumn)
        End Function
        
        Public Sub SetLastNull()
            Me(Me.tableComposer.LastColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    Public Class ComposerRowChangeEvent
        Inherits System.EventArgs
        
        Private eventRow As ComposerRow
        
        Private eventAction As System.Data.DataRowAction
        
        Public Sub New(ByVal row As ComposerRow, ByVal action As System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row() As ComposerRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        Public ReadOnly Property Action() As System.Data.DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
