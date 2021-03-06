﻿Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace Solution161.Web
    Partial Public Class Solution161AspNetApplication
        Inherits WebApplication

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection, True)
        End Sub
        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As Solution161.Module.Solution161Module
        Private module4 As Solution161.Module.Web.Solution161AspNetModule
        Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
        Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
        Private sqlConnection1 As System.Data.SqlClient.SqlConnection
        Private securityComplex1 As DevExpress.ExpressApp.Security.SecurityComplex
        Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
        Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Solution161AspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            Else
                Throw New InvalidOperationException("The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & ControlChars.CrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & ControlChars.CrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & ControlChars.CrLf & "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " & "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/")
            End If
#End If
        End Sub

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New Solution161.Module.Solution161Module()
            Me.module4 = New Solution161.Module.Web.Solution161AspNetModule()
            Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
            Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
            Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
            Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
            Me.securityComplex1 = New DevExpress.ExpressApp.Security.SecurityComplex()
            Me.authenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' module5
            ' 
            Me.module5.AllowValidationDetailsAccess = True
            ' 
            ' sqlConnection1
            ' 
            Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=Solution161;Integrated Security=SSPI;Pooling=" & "false"
            Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
            ' 
            ' securityComplex1
            ' 
            Me.securityComplex1.Authentication = Me.authenticationStandard1
            Me.securityComplex1.IsGrantedForNonExistentPermission = False
            Me.securityComplex1.RoleType = GetType(DevExpress.Persistent.BaseImpl.Role)
            Me.securityComplex1.UserType = GetType(DevExpress.Persistent.BaseImpl.User)
            ' 
            ' authenticationStandard1
            ' 
            Me.authenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
            ' 
            ' Solution161AspNetApplication
            ' 
            Me.ApplicationName = "Solution161"
            Me.Connection = Me.sqlConnection1
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module6)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module4)
            Me.Modules.Add(Me.module5)
            Me.Modules.Add(Me.securityModule1)
            Me.Security = Me.securityComplex1
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
