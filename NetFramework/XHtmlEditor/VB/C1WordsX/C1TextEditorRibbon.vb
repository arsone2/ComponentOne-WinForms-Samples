Imports System.IO
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text
Imports System.Windows.Forms
Imports C1.Win.C1Ribbon
Imports C1.Win.C1SpellChecker
Imports C1.Win.C1Editor

Imports Resources = C1Words.Resources
Imports Settings = C1Words.Properties.Settings

Namespace C1WordsX
	''' <summary>
	''' Extends C1Ribbon to provide a Word-style ribbon for a text editor.
	''' </summary>
	<LicenseProvider(GetType(LicenseProvider))> _
	Public Class C1TextEditorRibbon
		Inherits C1.Win.C1Ribbon.C1Ribbon
		'------------------------------------------------------------
		#Region "** events"

		Public Event EditorTextChanged As EventHandler

		#End Region

		'------------------------------------------------------------
		#Region "** fields"

		Private _hasChanges As Boolean
		' document has changes (needs to be saved)
		Private _fileName As String
		' current file name
		Private _mru As RecentDocumentList
		' recent document list
		Private _editor As C1RibbonEditorXhtml
		' editor
		Private _parent As Form
		' parent form (to update caption)
		Private _dirtyUI As Boolean
		' UI needs updating
		Private _updatingUI As Boolean
		' UI is being updated
		Private _spellChecker As C1SpellChecker
		' spell-checker
		#End Region

		'------------------------------------------------------------
		#Region "** create/dispose"

		' populate the ribbon
		Public Sub New()
			' create spell checker
			_spellChecker = New C1SpellChecker()

			' configure tooltips
			Me.ToolTipSettings.MaximumWidth = 240

			' initialize ribbon
			InitTabs()
			InitQat()
			InitApplicationMenu()

			' apply settings
			Dim settings__1 As Settings = Settings.[Default]
			Qat.BelowRibbon = settings__1.QatBelowRibbon
			VisualStyle = settings__1.VisualStyle
			ShowErrors = settings__1.ShowErrors
			Dictionary = settings__1.Dictionary

			' update UI when app is idle
			AddHandler Application.Idle, AddressOf Application_Idle
		End Sub

		' update UI when selected tab changes
		Protected Overloads Overrides Sub OnTabIndexChanged(e As EventArgs)
			_dirtyUI = True
		End Sub

		' hook up parent form events
		Protected Overloads Overrides Sub OnParentChanged(e As EventArgs)
			' unhook previous if any
			If _parent IsNot Nothing Then
				RemoveHandler _parent.FormClosing, AddressOf _parent_FormClosing
			End If

			' hook new if any
			_parent = TryCast(TopLevelControl, Form)
			If _parent IsNot Nothing Then
				AddHandler _parent.FormClosing, AddressOf _parent_FormClosing
			End If

			' fire event as usual
			MyBase.OnParentChanged(e)
		End Sub

		' update UI when app is idle
		Private Sub Application_Idle(sender As Object, e As EventArgs)
			If _dirtyUI Then
				UpdateUI()
			End If
		End Sub

		' handle form closing
		Private Sub _parent_FormClosing(sender As Object, e As FormClosingEventArgs)
			' check that we're not discarding any changes
			If Not OKToDiscardChanges() Then
				e.Cancel = True
			End If

			' save settings (even when canceled closing, just to be safe...)
			Dim settings__1 As Settings = Settings.[Default]
			settings__1.QatBelowRibbon = Qat.BelowRibbon
			settings__1.VisualStyle = Me.VisualStyle
			settings__1.RecentDocuments = _mru.RecentDocuments
			settings__1.ShowErrors = ShowErrors
			settings__1.Dictionary = Dictionary
			settings__1.Save()
		End Sub

		#End Region

		'------------------------------------------------------------
		#Region "** disable ribbon element serialization"

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows Property ApplicationMenuHolder() As RibbonApplicationMenu
			Get
				Return MyBase.ApplicationMenuHolder
			End Get
			Set
				MyBase.ApplicationMenuHolder = value
			End Set
        End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property ApplicationMenu() As RibbonApplicationMenu
			Get
				Return MyBase.ApplicationMenu
			End Get
        End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows Property ConfigToolBarHolder() As RibbonConfigToolBar
			Get
				Return MyBase.ConfigToolBarHolder
			End Get
			Set
				MyBase.ConfigToolBarHolder = value
			End Set
        End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property ConfigToolBar() As RibbonConfigToolBar
			Get
				Return MyBase.ConfigToolBar
			End Get
        End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows Property QatHolder() As RibbonQat
			Get
				Return MyBase.QatHolder
			End Get
			Set
				MyBase.QatHolder = value
			End Set
        End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Qat() As RibbonQat
			Get
				Return MyBase.Qat
			End Get
		End Property

		#End Region

		'------------------------------------------------------------
		#Region "** object model"

        Public Property C1Editor() As C1Editor
            Get
                If Editor Is Nothing Then
                    Return Nothing
                Else
                    Return Editor.Editor
                End If
            End Get
            Set(ByVal value As C1Editor)
                Editor = New C1RibbonEditorXhtml(value)
            End Set
        End Property

		<Browsable(False)> _
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Property Editor() As C1RibbonEditorXhtml
			Get
				Return _editor
			End Get
			Set
				AttachEventHandlers(False)
				_editor = value
				AttachEventHandlers(True)
				Me.Enabled = Editor IsNot Nothing
				If Editor IsNot Nothing Then
					Editor.Clear()
					UpdateUndoRedoState()
				End If
				_dirtyUI = True
			End Set
		End Property

		<Browsable(False)> _
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property SpellChecker() As C1SpellChecker
			Get
				Return _spellChecker
			End Get
		End Property

		<Browsable(False)> _
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Property HasChanges() As Boolean
			Get
				Return _hasChanges
			End Get
			Set
				If _hasChanges <> value Then
					_hasChanges = value
					UpdateAppCaption()
				End If
			End Set
		End Property

		<Browsable(False)> _
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Property FileName() As String
			Get
				Return _fileName
			End Get
			Set
				If _fileName <> value Then
					_fileName = value
					_mru.AddDocument(FileName)
					UpdateAppCaption()
				End If
			End Set
		End Property

		<Browsable(False)> _
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Property ShowErrors() As Boolean
			Get
				Return DirectCast(GetItemByID("ShowErrors"), RibbonToggleButton).Pressed
			End Get
			Set
				DirectCast(GetItemByID("ShowErrors"), RibbonToggleButton).Pressed = value
			End Set
		End Property

		<Browsable(False)> _
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Property Dictionary() As String
			Get
				Return Path.GetFileName(_spellChecker.MainDictionary.FileName)
			End Get
			Set
				_spellChecker.MainDictionary.FileName = value
			End Set
		End Property

		#End Region

		'------------------------------------------------------------
		#Region "** handle check spelling"

		Friend Sub SpellCheck()
			If _editor Is Nothing Then
				Return
			End If

			Dim webBrowser As Object = Nothing
			Dim errors As Integer
			If (InlineAssignHelper(webBrowser, _editor.GetWebBrowser2())) IsNot Nothing Then
				errors = _spellChecker.CheckControl(DirectCast(_editor.Editor, Control), webBrowser, False, Nothing)
			Else
				Return
			End If

            Dim msg As String
            If errors < 0 Then
                msg = Resources.SpellingCanceled_msg
            Else
                msg = String.Format(Resources.SpellingComplete_msg, errors)
            End If
            MessageBox.Show(msg, Resources.SpellingComplete_caption)
        End Sub

		Friend Sub SetActiveSpellChecking(spellChecking As Boolean)
			If _editor Is Nothing Then
				Return
			End If

			Dim webBrowser As Object = Nothing
			If (InlineAssignHelper(webBrowser, _editor.GetWebBrowser2())) IsNot Nothing Then
				_spellChecker.SetActiveSpellChecking(DirectCast(_editor.Editor, Control), webBrowser, spellChecking)
			End If
		End Sub

		Friend Sub SetSpellingLanguage()
			Using dlg As SetLanguage = New SetLanguage(_spellChecker)
                dlg.ShowDialog()
            End Using
		End Sub

		#End Region

		'------------------------------------------------------------
		#Region "** editor event handlers"

		' add/remove editor event handlers 
		Private Sub AttachEventHandlers(attach As Boolean)
			If Editor IsNot Nothing Then
				If attach Then
					AddHandler Editor.Editor.DocumentChanged, AddressOf Editor_TextChanged
					AddHandler Editor.Editor.SelectionChanged, AddressOf Editor_SelectionChanged

					' support file drag/drop
					Dim ctl As Control = TryCast(Editor.Editor, Control)
					If ctl IsNot Nothing Then
						AddHandler ctl.DragEnter, AddressOf ctl_DragEnter
						AddHandler ctl.DragDrop, AddressOf ctl_DragDrop
					End If

					' connect spell-checker
					If ShowErrors Then
						SetActiveSpellChecking(True)
					End If
				Else
					RemoveHandler Editor.Editor.DocumentChanged, AddressOf Editor_TextChanged
					RemoveHandler Editor.Editor.SelectionChanged, AddressOf Editor_SelectionChanged

					' disconnect spell checker
					SetActiveSpellChecking(False)
				End If
			End If
		End Sub

		' update UI when the editor content changes
		Private Sub Editor_TextChanged(sender As Object, e As EventArgs)
			HasChanges = True
			UpdateUndoRedoState()
			RaiseEvent EditorTextChanged(Me, EventArgs.Empty)
		End Sub

		' update UI when the current selection changes
		Private Sub Editor_SelectionChanged(sender As Object, e As EventArgs)
			_dirtyUI = True
		End Sub

		' file drop
        Private Sub ctl_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
            If Not String.IsNullOrEmpty(GetDroppedFileName(e.Data)) Then
                e.Effect = DragDropEffects.Copy
                Return
            End If
        End Sub
		Private Sub ctl_DragDrop(sender As Object, e As DragEventArgs)
			Dim fileName As String = GetDroppedFileName(e.Data)
			If Not String.IsNullOrEmpty(fileName) Then
				OpenDocument(fileName)
				e.Effect = DragDropEffects.None
			End If
		End Sub
		#End Region

		'------------------------------------------------------------
		#Region "** command dispatcher"

		' forward ribbon events to the appropriate C1XHtmlRibbonTab.
		Protected Overloads Overrides Sub OnRibbonEvent(e As RibbonEventArgs)
			Dim item As RibbonItem = TryCast(e.Item, RibbonItem)
			If item IsNot Nothing Then

				' handle clicks on non-tab items
				If e.EventType = RibbonEventType.Click Then
					' handle application menu and Qat items
					If item.Tab Is Nothing Then
						Select Case item.ID
							Case "New"
								NewDocument()
								Return
							Case "Open", "OpenQat"
								OpenDocument()
								Return
							Case "Save", "SaveQat"
								SaveDocument()
								Return
							Case "SaveAs"
								SaveDocumentAs()
								Exit Select
							Case "Print"
								PrintDocument(True, False)
								Exit Select
							Case "PrintPreview"
								PrintDocument(False, True)
								Exit Select
							Case "QuickPrint"
								PrintDocument(False, False)
								Exit Select
							Case "ExportPdf"
								ExportDocument()
								Exit Select
							Case "Exit"
								[Exit]()
								Exit Select
							Case "Undo"
								Undo()
								Exit Select
							Case "Redo"
								Redo()
								Exit Select
							Case Else
                                Exit Select
						End Select

						' handle clicks on mru items
						Dim doc As RecentDocumentItem = TryCast(item, RecentDocumentItem)
						If doc IsNot Nothing Then
							OpenDocument(doc.FileName)
						End If
                    End If
                ElseIf e.EventType = RibbonEventType.DropDown Then

                    Select Case item.ID
                        Case "Undo", "Redo"
                            Dim isUndo As Boolean = StrComp(item.ID, "Undo", CompareMethod.Text) = 0
                            Dim sb As RibbonSplitButton = DirectCast(item, RibbonSplitButton)
                            sb.Items.ClearAndDisposeItems()
                            Dim actionList As String()
                            If isUndo Then
                                actionList = _editor.Editor.History.UndoList
                            Else
                                actionList = _editor.Editor.History.RedoList
                            End If

                            Dim actionIndex As Integer = 0
                            For Each action As String In actionList
                                Dim rb As RibbonButton = New RibbonButton(action)
                                rb.Tag = actionIndex
                                If isUndo Then
                                    AddHandler rb.Click, AddressOf UndoClick
                                Else
                                    AddHandler rb.Click, AddressOf RedoClick
                                End If
                                sb.Items.Add(rb)
                                actionIndex = actionIndex + 1
                            Next
                            Exit Select
                        Case Else
                            Exit Select
                    End Select

                End If

				' delegate to tab elements
				If Not _updatingUI Then
					Dim tab As C1TextEditorRibbonTab = TryCast(item.Tab, C1TextEditorRibbonTab)
					If tab IsNot Nothing Then
						tab.HandleItemEvent(e)
					End If
				End If

				' exit when double-clicking the app menu
				If item.Equals(Me.ApplicationMenu) AndAlso e.EventType = RibbonEventType.DoubleClick Then
					[Exit]()
				End If
			End If

			' fire event as usual
			MyBase.OnRibbonEvent(e)
        End Sub

        Private Sub UndoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim rb As RibbonButton = TryCast(sender, RibbonButton)
            If rb IsNot Nothing Then
                Dim index As Integer = DirectCast(rb.Tag, Integer)
                _editor.Editor.History.Undo(index + 1)
            End If
        End Sub

        Private Sub RedoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim rb As RibbonButton = TryCast(sender, RibbonButton)
            If rb IsNot Nothing Then
                Dim index As Integer = DirectCast(rb.Tag, Integer)
                _editor.Editor.History.Redo(index + 1)
            End If
        End Sub

		#End Region

		'------------------------------------------------------------
		#Region "** non-tab event handlers (main menu/Qat)"

		Private Function NewDocument() As Boolean
			If Not OKToDiscardChanges() Then
				Return False
			End If

			' start new document
			Editor.Clear()
			FileName = String.Empty
			HasChanges = False
			UpdateUndoRedoState()
			Return True
		End Function
		Private Function OpenDocument() As Boolean
			If Not OKToDiscardChanges() Then
				Return False
			End If

			' get file name
			Using dlg As OpenFileDialog = New OpenFileDialog()
				Editor.CustomizeFileDialog(dlg)
				If dlg.ShowDialog() = DialogResult.OK Then
					Return OpenDocument(dlg.FileName)
				End If
			End Using

			' canceled
			Return False
		End Function
		Private Function OpenDocument(fileName__1 As String) As Boolean
			If Not OKToDiscardChanges() Then
				Return False
			End If

			Try
				If Editor.Load(fileName__1) Then
					FileName = fileName__1
					HasChanges = False
					Return True
				End If
			Catch x As Exception
				MessageBox.Show(x.Message, Application.ProductName)
			End Try

			' failed to load, remove from mru
			_mru.RemoveDocument(fileName__1)
			Return False
		End Function
		Private Function SaveDocument() As Boolean
			' no file name? defer to SaveAs to prompt
			If String.IsNullOrEmpty(FileName) Then
				Return SaveDocumentAs()
			End If

			' save current file
			Try
				If Editor.Save(FileName) Then
					HasChanges = False
					Return True
				End If
			Catch x As Exception
				MessageBox.Show(x.Message, Application.ProductName)
			End Try

			' failed to save...
			Return False
		End Function
		Private Function PrintDocument(selectPrinter As Boolean, showPreview As Boolean) As Boolean
			If Not showPreview Then
				Editor.Print(selectPrinter)
			Else
				Editor.PrintPreview()
			End If
			Return True
		End Function
		Private Function ExportDocument() As Boolean
			' get pdf file name
			Using dlg As SaveFileDialog = New SaveFileDialog()
				dlg.Filter = "Portable Document File (*.pdf)|*.pdf"
				If dlg.ShowDialog() = DialogResult.OK Then
					' create preview document
					Dim doc As PrintDocument = Editor.PrintDocument
					Dim pc As PrintController = doc.PrintController
					Dim pcpv As PreviewPrintController = New PreviewPrintController()
					doc.PrintController = pcpv
					doc.Print()
					doc.PrintController = pc

					' create pdf document
					Using pdf As C1.C1Pdf.C1PdfDocument = New C1.C1Pdf.C1PdfDocument()
						' add pages to pdf document
						Dim firstPage As Boolean = True
						For Each page As PreviewPageInfo In pcpv.GetPreviewPageInfo()
							pdf.PageSize = New SizeF(page.PhysicalSize.Width * 0.72F, page.PhysicalSize.Height * 0.72F)
							If Not firstPage Then
								pdf.NewPage()
							End If
							pdf.DrawImage(page.Image, pdf.PageRectangle)
							firstPage = False
						Next

						' save pdf file
						Try
							pdf.Save(dlg.FileName)
							Dim msg As String = String.Format(Resources.ExportPdf_msg, Path.GetFileName(dlg.FileName))
							Dim dr As DialogResult = MessageBox.Show(Me, msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
							If dr = DialogResult.Yes Then
								Process.Start(dlg.FileName)
							End If
							Return True
						Catch x As Exception
							Dim msg As String = x.Message
							MessageBox.Show(Me, msg, Application.ProductName)
							Return False
						End Try
					End Using
				End If
			End Using

			' failed
			Return False
		End Function
		Private Function SaveDocumentAs() As Boolean
			' get file name
			Using dlg As SaveFileDialog = New SaveFileDialog()
				Editor.CustomizeFileDialog(dlg)
				If dlg.ShowDialog() = DialogResult.OK Then
					FileName = dlg.FileName
					Return SaveDocument()
				End If
			End Using

			' failed...
			Return False
		End Function
		Private Sub [Exit]()
			If Not OKToDiscardChanges() Then
				Return
			End If

			' done with application
			Application.[Exit]()
		End Sub
		Private Sub Undo()
			Editor.Undo()
		End Sub
		Private Sub Redo()
			Editor.Redo()
		End Sub

		#End Region

		'------------------------------------------------------------
		#Region "** implementation"

		' initialize tabs
		Private Sub InitTabs()
			Tabs.Clear()
			Tabs.Add(New HomeTab())
			Tabs.Add(New InsertTab())
            Tabs.Add(New ReviewTab())
			Tabs.Add(New ViewTab())

			For Each tab As C1TextEditorRibbonTab In Tabs
				tab.InitTab()
			Next
		End Sub

		' initialize main menu
		Private Sub InitApplicationMenu()
			' initialize menu
			Dim menu As RibbonApplicationMenu = Me.ApplicationMenu
			menu.DropDownWidth = 370
			menu.LargeImage = Resources.Symbol_large

			' left menu items
			Dim items As RibbonItemCollection = menu.LeftPaneItems
			items.ClearAndDisposeItems()
			items.Add(CreateButton("New"))
			items.Add(CreateButton("Open"))
			items.Add(CreateButton("Save"))
			items.Add(CreateButton("SaveAs"))
			items.Add(New RibbonSeparator())
            items.Add(CreateSplitButton("Print", CreateHeaderLabel("PreviewAndPrint"), CreateButton("Print"), CreateButton("QuickPrint"), CreateButton("PrintPreview")))
			items.Add(CreateButton("ExportPdf"))

			' right menu items
			_mru = New RecentDocumentList(Me)

			' bottom menu items
			items = menu.BottomPaneItems
			items.ClearAndDisposeItems()
			Dim btnExit As RibbonButton = CreateButton("Exit")
			items.Add(btnExit)
		End Sub

		' initialize quick access toolbar
		Private Sub InitQat()
			' populate QAT (use ItemLinks instead of Items)
			Dim items As RibbonQatLinkCollection = Qat.ItemLinks
			items.Clear()
            items.Add(CreateSplitButton("Undo"))
            items.Add(CreateSplitButton("Redo"))
			items.Add(CreateButton("SaveQat", "Save"))

			' copy QAT items to the hot item list (to allow customization)
			Dim hot As RibbonQatLinkCollection = Qat.HotItemLinks
			hot.Clear()
			For Each item As Component In Qat.ItemLinks
				hot.Add(item)
			Next

			' add more items to hot item list
			hot.Add(CreateButton("OpenQat", "Open"))
		End Sub

		' delegate element creation to C1XHtmlRibbonTab
		Private Shared Function CreateHeader(id As String) As RibbonListItem
			Return C1TextEditorRibbonTab.CreateHeader(id)
        End Function

        Private Shared Function CreateHeaderLabel(ByVal id As String) As RibbonLabel
            Return C1TextEditorRibbonTab.CreateHeaderLabel(id)
        End Function

        Private Shared Function CreateButton(ByVal id As String) As RibbonButton
            Return C1TextEditorRibbonTab.CreateButton(id)
        End Function

		Private Shared Function CreateButton(id As String, imageId As String) As RibbonButton
			Return C1TextEditorRibbonTab.CreateButton(id, imageId)
        End Function

		Private Shared Function CreateSplitButton(id As String, ParamArray items As Object()) As RibbonSplitButton
			Return C1TextEditorRibbonTab.CreateSplitButton(id, items)
		End Function

		' check whether it's OK to discard any current changes
		Private Function OKToDiscardChanges() As Boolean
			' no changes? ok to discard (nothing)
			If Not HasChanges Then
				Return True
			End If

			' prompt user
            Dim docName As String
            If String.IsNullOrEmpty(FileName) Then
                docName = "Document"
            Else
                docName = Path.GetFileName(FileName)
            End If
            Dim msg As String = String.Format(Resources.SaveChanges_msg, docName)
            Dim dr As DialogResult = MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            Select Case dr
                Case DialogResult.Yes
                    Return SaveDocument()
                Case DialogResult.No
                    HasChanges = False
                    ' don't ask again...
                    Return True
            End Select

            ' not OK to discard...
            Return False
        End Function

		' show current document name and modified state in form caption.
		Private Sub UpdateAppCaption()
			Dim ctl As Control = TopLevelControl
			If TypeOf ctl Is Form Then
				Dim sb As New StringBuilder()
				If Not String.IsNullOrEmpty(FileName) Then
                    sb.AppendFormat("{0}{1} - ", Util.IIFS(HasChanges, "* ", String.Empty), Path.GetFileName(FileName))
                End If
                sb.Append(Application.ProductName)
                ctl.Text = sb.ToString()
            End If
            UpdateUI()
		End Sub

		' update UI when the selection changes
		Private Sub UpdateUI()
			' start updating
			_updatingUI = True

			' update selected tab
            Dim tab As C1TextEditorRibbonTab = TryCast(Me.SelectedTab, C1TextEditorRibbonTab)
            If (tab IsNot Nothing) Then
                tab.UpdateUI()
            End If


            ' done updating
            _updatingUI = False
            _dirtyUI = False
        End Sub

		' update Undo and Redo buttons state
		Private Sub UpdateUndoRedoState()
			EnableItem("Undo", Editor.CanUndo)
			EnableItem("Redo", Editor.CanRedo)
		End Sub

		' enable/disable items based on their ID
		Private Sub EnableItem(id As String, enable As Boolean)
			Dim item As RibbonItem = DirectCast(GetItemByID(id), RibbonItem)
			item.Enabled = enable
		End Sub

		' get name of rtf file being dropped
		Private Function GetDroppedFileName(data As IDataObject) As String
			If data.GetDataPresent(DataFormats.FileDrop, False) Then
				Dim files As String() = DirectCast(data.GetData(DataFormats.FileDrop), String())
				If files IsNot Nothing AndAlso files.Length = 1 Then
					Return files(0)
				End If
			End If
			Return Nothing
		End Function
		Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function

		#End Region
	End Class
End Namespace
