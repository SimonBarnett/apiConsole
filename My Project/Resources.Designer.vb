﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("apiConsole.Resources", GetType(Resources).Assembly)
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
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to USE [master]
        '''GO
        '''
        '''/****** Object:  Login [NT AUTHORITY\Network Service]    Script Date: 06/05/2019 11:09:56 ******/
        '''CREATE LOGIN [NT AUTHORITY\Network Service] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
        '''GO
        '''
        '''ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT AUTHORITY\Network Service]
        '''GO
        '''
        '''ALTER SERVER ROLE [securityadmin] ADD MEMBER [NT AUTHORITY\Network Service]
        '''GO
        '''
        '''ALTER SERVER ROLE [serveradmin] ADD MEMBER [NT AUTHORITY\Network Service]
        '''GO
        '''
        '''ALTER SERVER ROLE [setupa [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property addLogin() As String
            Get
                Return ResourceManager.GetString("addLogin", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property API_Feed_item() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("API_Feed_item", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property API_Feed_project() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("API_Feed_project", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property API_Handler_item() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("API_Handler_item", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property API_Handler_Project() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("API_Handler_Project", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Imports PriPROC6.Interface.oData
        '''Imports System.Reflection
        '''
        '''&apos;&apos;&apos; &lt;summary&gt;
        '''&apos;&apos;&apos;
        '''&apos;&apos;&apos; This code was generated by the Schema Utility.
        '''&apos;&apos;&apos;
        '''&apos;&apos;&apos; Form: #FORM# as List(Of row#FORM#)
        '''&apos;&apos;&apos; Date: #DATE#
        '''&apos;&apos;&apos;
        '''&apos;&apos;&apos; &lt;/summary&gt;
        '''&lt;oFormClass(&quot;row#FORM#&quot;#NAV#)&gt;
        '''Public Class #FORM# : Inherits oForm
        '''
        '''    &apos;&apos;&apos; &lt;summary&gt;
        '''    &apos;&apos;&apos; #FORM# Constructor method.
        '''    &apos;&apos;&apos; &lt;/summary&gt;
        '''	&apos;&apos;&apos; &lt;param name=&quot;Sender&quot;&gt;The Assembly.GetExecutingAssembly of your project&lt;/param&gt;
        '''    &apos;&apos;&apos; &lt;param name=&quot;Parent&quot;&gt;Optional: Parent oRow of this fo [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property txtForm() As String
            Get
                Return ResourceManager.GetString("txtForm", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to     
        '''	&apos;&apos;&apos; &lt;summary&gt;
        '''    &apos;&apos;&apos; Get / Set the &quot;#TITLE#&quot; Value of #FORMNAME#.
        '''    &apos;&apos;&apos; &lt;/summary&gt;
        '''    &apos;&apos;&apos; &lt;returns&gt;#RETURNTYPE#&lt;/returns&gt;	
        '''    &lt;oDataColumn(&quot;#TITLE#&quot;#DIRECTIVES#)&gt;
        '''    Public Property #PROPERTYNAME# As #RETURNTYPE#
        '''        Get
        '''            Return getProperty()
        '''        End Get
        '''        Set(value As #RETURNTYPE#)
        '''            setProperty(value)
        '''        End Set
        '''    End Property
        '''.
        '''</summary>
        Friend ReadOnly Property txtProperty() As String
            Get
                Return ResourceManager.GetString("txtProperty", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to     
        '''	&apos;&apos;&apos; &lt;summary&gt;
        '''    &apos;&apos;&apos; Get the Read Only &quot;#TITLE#&quot; Value of #FORMNAME#.
        '''    &apos;&apos;&apos; &lt;/summary&gt;
        '''    &apos;&apos;&apos; &lt;returns&gt;#RETURNTYPE#&lt;/returns&gt;	
        '''    &lt;oDataColumn(&quot;#TITLE#&quot;#DIRECTIVES#)&gt;
        '''    Public Readonly Property #PROPERTYNAME# As #RETURNTYPE#
        '''        Get
        '''            Return getProperty()
        '''        End Get
        '''
        '''    End Property
        '''.
        '''</summary>
        Friend ReadOnly Property txtPropertyReadOnly() As String
            Get
                Return ResourceManager.GetString("txtPropertyReadOnly", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''&apos;&apos;&apos; &lt;summary&gt;
        '''&apos;&apos;&apos; Defines rows in the #FORM# form.
        '''&apos;&apos;&apos; &lt;/summary&gt;
        '''&lt;oRowClass(&quot;#FORM#&quot;, &quot;serial#FORM#&quot;)&gt;
        '''Public Class row#FORM# : Inherits oRow
        '''
        '''    &apos;&apos;&apos; &lt;summary&gt;
        '''    &apos;&apos;&apos; row#FORM# Constructor method.
        '''    &apos;&apos;&apos; &lt;/summary&gt;
        '''    &apos;&apos;&apos; &lt;param name=&quot;Parent&quot;&gt;Parent oForm of this row&lt;/param&gt;
        '''    Sub New(Parent As oForm)
        '''        MyBase.New(Parent)
        '''
        '''    End Sub
        '''#SUBFORMS#
        '''#PROPERTIES#
        '''
        '''End Class
        '''.
        '''</summary>
        Friend ReadOnly Property txtRow() As String
            Get
                Return ResourceManager.GetString("txtRow", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''&apos;&apos;&apos; &lt;summary&gt;
        '''&apos;&apos;&apos; A nullable version of row#FORM#.
        '''&apos;&apos;&apos;
        '''&apos;&apos;&apos; This is used to deserialise JSON data
        '''&apos;&apos;&apos; and should not be instantiated directly.
        '''&apos;&apos;&apos; &lt;/summary&gt;
        '''Public Class serial#FORM# 
        '''
        '''#PROPERTIES#
        '''
        '''End Class.
        '''</summary>
        Friend ReadOnly Property txtSerial() As String
            Get
                Return ResourceManager.GetString("txtSerial", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to     Public Property #PROPERTYNAME# As #RETURNTYPE#
        '''.
        '''</summary>
        Friend ReadOnly Property txtSerialProp() As String
            Get
                Return ResourceManager.GetString("txtSerialProp", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to     
        '''	&apos;&apos;&apos; &lt;summary&gt;
        '''    &apos;&apos;&apos; Get/set the #FORMNAME# subform.
        '''    &apos;&apos;&apos; &lt;/summary&gt;
        '''    &apos;&apos;&apos; &lt;returns&gt;#FORMNAME#&lt;/returns&gt;
        '''	Public Property #FORMNAME# As #FORMNAME#
        '''        Get
        '''            Return MyBase.SubForms(&quot;#FORMNAME#&quot;)
        '''        End Get
        '''        Set(value As #FORMNAME#)
        '''            MyBase.SubForms(&quot;#FORMNAME#&quot;) = value
        '''        End Set
        '''    End Property.
        '''</summary>
        Friend ReadOnly Property txtSubForm() As String
            Get
                Return ResourceManager.GetString("txtSubForm", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
