﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4016
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System


'This class was auto-generated by the StronglyTypedResourceBuilder
'class via a tool like ResGen or Visual Studio.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
'''<summary>
'''  A strongly-typed resource class, for looking up localized strings, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Friend Class Resources
    
    Private Shared resourceMan As Global.System.Resources.ResourceManager
    
    Private Shared resourceCulture As Global.System.Globalization.CultureInfo
    
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
    Friend Sub New()
        MyBase.New
    End Sub
    
    '''<summary>
    '''  Returns the cached ResourceManager instance used by this class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SyntaxHighlight.Resources", GetType(Resources).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property
    
    '''<summary>
    '''  Overrides the current thread's CurrentUICulture property for all
    '''  resource lookups using this strongly typed resource class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to abstract
    '''as
    '''base
    '''bool
    '''break
    '''byte
    '''case
    '''catch
    '''char
    '''checked
    '''class
    '''const
    '''continue
    '''decimal
    '''default
    '''delegate
    '''do
    '''double
    '''else
    '''enum
    '''event
    '''explicit
    '''extern
    '''false
    '''finally
    '''fixed
    '''float
    '''for
    '''foreach
    '''goto
    '''if
    '''implicit
    '''in
    '''int
    '''interface
    '''internal
    '''is
    '''lock
    '''long
    '''namespace
    '''new
    '''null
    '''object
    '''operator
    '''out
    '''override
    '''params
    '''private
    '''protected
    '''public
    '''readonly
    '''ref
    '''return
    '''sbyte
    '''sealed
    '''short
    '''sizeof
    '''stackalloc
    '''static
    '''string
    '''struct
    '''switch
    '''this
    '''throw
    '''true
    '''try
    '''typeof
    '''uint
    '''ulong
    '''u [rest of string was truncated]&quot;;.
    '''</summary>
    Friend Shared ReadOnly Property reservedWords() As String
        Get
            Return ResourceManager.GetString("reservedWords", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;
    '''&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot; &gt;
    '''&lt;head&gt;
    '''    &lt;title&gt;Untitled Page&lt;/title&gt;
    '''    &lt;style type=&quot;text/css&quot;&gt;
    '''        
    '''        body { font-family: Courier New; }
    '''        p { margin: 0px; }
    '''        .comment { color: green; }
    '''        .string { color: red; }
    '''        .resWord { color: blue; font-weight:bold; }
    '''        .type { color: teal; font-weight:bold; }
    '''        
    '''    &lt;/st [rest of string was truncated]&quot;;.
    '''</summary>
    Friend Shared ReadOnly Property Syntax() As String
        Get
            Return ResourceManager.GetString("Syntax", resourceCulture)
        End Get
    End Property
End Class
