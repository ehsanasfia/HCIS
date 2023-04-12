Imports System.Linq

Public Class UserPermissionsController


    Private LocalDataset As New DS
    Public UID As Integer, AppID As Integer, CreationUID As Integer
    Private tblApplicationsTableAdapter As New DSTableAdapters.tblApplicationsTableAdapter
    Private tblObjectsTableAdapter As New DSTableAdapters.tblObjectsTableAdapter
    Private tblPermissionsTableAdapter As New DSTableAdapters.tblPermissionsTableAdapter
    Private tblRolebasedObjectPermissionsTableAdapter As New DSTableAdapters.tblRolebasedObjectPermissionsTableAdapter
    Private tblRolesTableAdapter As New DSTableAdapters.tblRolesTableAdapter
    Private tblUserbasedObjectPermissionsTableAdapter As New DSTableAdapters.tblUserbasedObjectPermissionsTableAdapter
    Private tblUsersTableAdapter As New DSTableAdapters.tblUsersTableAdapter
    Private tblObjectTypesTableAdapter As New DSTableAdapters.tblObjectTypesTableAdapter

    Public Sub New(ByVal UserName As String)
        'objType = obj.GetType.ToString
        Me.New(UserName, (New ApplicationServices.ApplicationBase).Info.AssemblyName)
    End Sub

    Public Sub New(ByVal UserName As String, ByVal ApplicationName As String)
        'objType = obj.GetType.ToString
        UserName = Replace(UserName, "ي", "ی")
        UserName = UserName.ToLower
        Try
            tblApplicationsTableAdapter.FillByAppName(LocalDataset.tblApplications, ApplicationName)
            If LocalDataset.tblApplications.Rows.Count <= 0 Then
                Dim newRow As DS.tblApplicationsRow = LocalDataset.tblApplications.NewRow
                newRow("ApplicationName") = ApplicationName
                LocalDataset.tblApplications.AddtblApplicationsRow(newRow)
                tblApplicationsTableAdapter.Update(LocalDataset.tblApplications)
            End If
            AppID = LocalDataset.tblApplications.First.Item("ApplicationID")
            tblObjectsTableAdapter.FillByAppID(LocalDataset.tblObjects, AppID)
            If UserName = "administrator" Then
                tblUsersTableAdapter.FillByUserName(LocalDataset.tblUsers, UserName)
                UID = LocalDataset.tblUsers.First.Item("UserID")
                tblUserbasedObjectPermissionsTableAdapter.FillForAdmin(LocalDataset.tblUserbasedObjectPermissions, UID, ApplicationName)
            Else
                tblUsersTableAdapter.FillByUserName_ApplicationName(LocalDataset.tblUsers, UserName, ApplicationName)
                UID = LocalDataset.tblUsers.First.Item("UserID")
                tblUserbasedObjectPermissionsTableAdapter.FillByUserID(LocalDataset.tblUserbasedObjectPermissions, UID)
            End If

            tblPermissionsTableAdapter.Fill(LocalDataset.tblPermissions)
            tblRolebasedObjectPermissionsTableAdapter.Fill(LocalDataset.tblRolebasedObjectPermissions)
            tblRolesTableAdapter.Fill(LocalDataset.tblRoles)
            tblObjectTypesTableAdapter.Fill(LocalDataset.tblObjectTypes)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetNavBarPermissions(ByRef navBar As DevExpress.XtraNavBar.NavBarControl, containerClass As String)
        Dim tmpMnu = CreateMenuFromNavBar(navBar)
        GetMenuPermissions(tmpMnu, containerClass)

        For Each group As DevExpress.XtraNavBar.NavBarGroup In navBar.Groups
            Dim rootmnu = tmpMnu.Items.OfType(Of ToolStripMenuItem)().Single(Function(c) c.Name = group.Name)
            group.Visible = rootmnu.Enabled


            For Each item As DevExpress.XtraNavBar.NavBarItemLink In group.ItemLinks
                Dim mnulist = rootmnu.DropDownItems.OfType(Of ToolStripMenuItem)().Where(Function(c) c.Name = item.Item.Name)
                For Each mnu In mnulist
                    item.Item.Enabled = mnu.Enabled
                    item.Visible = mnu.Enabled
                Next
            Next
        Next


    End Sub

    Public Sub GetRibbonPermissions(ByRef ribbon As DevExpress.XtraBars.Ribbon.RibbonControl, containerClass As String)
        Dim tmpMnu = CreateMenuFromRibbon(ribbon)
        GetMenuPermissions(tmpMnu, containerClass)

        If ribbon.PageCategories.Count > 0 Then
            For Each pageCategory As DevExpress.XtraBars.Ribbon.RibbonPageCategory In ribbon.PageCategories
                Dim rootmnu = tmpMnu.Items.OfType(Of ToolStripMenuItem)().Single(Function(c) c.Name = pageCategory.Name)
                pageCategory.Visible = rootmnu.Enabled

                For Each page As DevExpress.XtraBars.Ribbon.RibbonPage In pageCategory.Pages
                    Dim mnu = rootmnu.DropDownItems.OfType(Of ToolStripMenuItem)().Single(Function(c) c.Name = page.Name)
                    page.Visible = mnu.Enabled


                    For Each group As DevExpress.XtraBars.Ribbon.RibbonPageGroup In page.Groups
                        Dim submenu = mnu.DropDownItems.OfType(Of ToolStripMenuItem)().Single(Function(c) c.Name = group.Name)
                        group.Visible = submenu.Enabled


                        For Each item As DevExpress.XtraBars.BarButtonItemLink In group.ItemLinks.OfType(Of DevExpress.XtraBars.BarButtonItemLink)()
                            If submenu.DropDownItems.OfType(Of ToolStripMenuItem).Single(Function(c) c.Name = item.Item.Name).Enabled Then
                                item.Item.Enabled = True
                                item.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                            Else
                                item.Item.Enabled = False
                                item.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                            End If

                        Next
                    Next
                Next
            Next
        Else
            For Each page As DevExpress.XtraBars.Ribbon.RibbonPage In ribbon.Pages
                Dim mnu = tmpMnu.Items.OfType(Of ToolStripMenuItem)().Single(Function(c) c.Name = page.Name)
                page.Visible = mnu.Enabled


                For Each group As DevExpress.XtraBars.Ribbon.RibbonPageGroup In page.Groups
                    Dim submenu = mnu.DropDownItems.OfType(Of ToolStripMenuItem)().Single(Function(c) c.Name = group.Name)
                    group.Visible = submenu.Enabled

                    For Each item In group.ItemLinks.OfType(Of DevExpress.XtraBars.BarButtonItemLink)()
                        If submenu.DropDownItems.OfType(Of ToolStripMenuItem).Single(Function(c) c.Name = item.Item.Name).Enabled Then
                            item.Item.Enabled = True
                            item.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                        Else
                            item.Item.Enabled = False
                            item.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        End If

                    Next
                Next
            Next

        End If


    End Sub

    Public Sub GetMenuPermissions(ByRef mnu As MenuStrip, ByVal containerClass As String, Optional ByVal checkSetting As Boolean = False)
        Dim flag As Boolean = False
        Dim tempMenu As ToolStripMenuItem
        Dim currentObjPermission As DS.tblUserbasedObjectPermissionsRow()
        Dim OID As Integer
        For Each tempMenu In mnu.Items
            If tempMenu.GetType.ToString Like "*SystemMenuItem" Or tempMenu.GetType.ToString Like "*ControlBoxMenuItem" Then
                tempMenu.Visible = IIf(checkSetting, False, True)
                Continue For
            End If
            If tempMenu.DropDownItems.Count > 0 Then
                flag = GetMenuPermissions(tempMenu, containerClass, checkSetting)
            End If
            If LocalDataset.tblObjects.Select("ObjectName = '" + tempMenu.Name + "' AND ContainerClass = '" + containerClass + "'").Count > 0 Then
                OID = LocalDataset.tblObjects.Select("ObjectName = '" + tempMenu.Name + "' AND ContainerClass = '" + containerClass + "'").First.Item("ObjectID")
                currentObjPermission = LocalDataset.tblUserbasedObjectPermissions.Select("ObjectID = " + OID.ToString)
                If currentObjPermission.Count > 0 Then
                    If checkSetting Then
                        tempMenu.Visible = True
                        tempMenu.CheckOnClick = True
                        tempMenu.Checked = CBool(currentObjPermission.First.Item("PermissionID"))
                    Else
                        tempMenu.Visible = CBool(currentObjPermission.First.Item("PermissionID"))
                        tempMenu.Enabled = CBool(currentObjPermission.First.Item("PermissionID"))
                    End If
                Else
                    If checkSetting Then
                        tempMenu.Visible = True
                        tempMenu.CheckOnClick = True
                        tempMenu.Checked = False
                    Else
                        tempMenu.Visible = False
                        tempMenu.Enabled = False
                    End If
                End If
            Else
                If checkSetting Then
                    tempMenu.Visible = True
                    tempMenu.CheckOnClick = True
                    tempMenu.Checked = False
                Else
                    tempMenu.Visible = False
                    tempMenu.Enabled = False
                End If
            End If
            If flag Then
                If checkSetting Then
                    tempMenu.Visible = True
                    tempMenu.CheckOnClick = True
                    tempMenu.Checked = False
                Else
                    tempMenu.Visible = True
                    tempMenu.Enabled = True
                End If
            End If
        Next
    End Sub

    Private Function GetMenuPermissions(ByRef subMenu As ToolStripMenuItem, ByVal containerClass As String, Optional ByVal checkSetting As Boolean = False) As Boolean
        Dim lowerFlag As Boolean = False, upperFlag As Boolean = False
        Dim tempMenu As ToolStripMenuItem
        Dim currentObjPermission As DS.tblUserbasedObjectPermissionsRow()
        Dim OID As Integer
        For Each tempMenu In subMenu.DropDownItems
            lowerFlag = False
            If tempMenu.DropDownItems.Count > 0 Then
                lowerFlag = GetMenuPermissions(tempMenu, containerClass, checkSetting)
            End If
            If LocalDataset.tblObjects.Select("ObjectName = '" + tempMenu.Name + "' AND ContainerClass = '" + containerClass + "'").Count > 0 Then
                OID = LocalDataset.tblObjects.Select("ObjectName = '" + tempMenu.Name + "' AND ContainerClass = '" + containerClass + "'").First.Item("ObjectID")
                currentObjPermission = LocalDataset.tblUserbasedObjectPermissions.Select("ObjectID = " + OID.ToString)
                If currentObjPermission.Count > 0 Then
                    If checkSetting Then
                        tempMenu.Visible = True
                        tempMenu.CheckOnClick = True
                        tempMenu.Checked = CBool(currentObjPermission.First.Item("PermissionID"))
                    Else
                        tempMenu.Visible = CBool(currentObjPermission.First.Item("PermissionID"))
                        tempMenu.Enabled = CBool(currentObjPermission.First.Item("PermissionID"))
                        If Not upperFlag Then upperFlag = CBool(currentObjPermission.First.Item("PermissionID"))
                    End If
                Else
                    If checkSetting Then
                        tempMenu.Visible = True
                        tempMenu.CheckOnClick = True
                        tempMenu.Checked = False
                    Else
                        tempMenu.Visible = False
                        tempMenu.Enabled = False
                    End If
                End If
            Else
                If checkSetting Then
                    tempMenu.Visible = True
                    tempMenu.CheckOnClick = True
                    tempMenu.Checked = False
                Else
                    tempMenu.Visible = False
                    tempMenu.Enabled = False
                End If
            End If
            If lowerFlag Then
                If checkSetting Then
                    tempMenu.Visible = True
                    tempMenu.CheckOnClick = True
                    tempMenu.Checked = False
                Else
                    tempMenu.Visible = True
                    tempMenu.Enabled = True
                End If
            End If
        Next
        Return upperFlag
    End Function

    Public Sub SetMenuPermissions(ByVal mnu As MenuStrip, ByVal containerClass As String)
        Dim flag As Boolean = False
        Dim OID As Integer
        Dim tempMenu As ToolStripMenuItem
        Dim currentObjPermission As DS.tblUserbasedObjectPermissionsRow()
        Dim row As DS.tblUserbasedObjectPermissionsRow
        Try
            For Each tempMenu In mnu.Items
                flag = False
                If tempMenu.DropDownItems.Count > 0 Then
                    flag = SetMenuPermissions(tempMenu, containerClass)
                End If
                OID = LocalDataset.tblObjects.Select("ObjectName = '" + tempMenu.Name + "' AND ContainerClass = '" + containerClass + "'").First.Item("ObjectID")
                currentObjPermission = LocalDataset.tblUserbasedObjectPermissions.Select("ObjectID = " + OID.ToString)
                If currentObjPermission.Count > 0 Then
                    For Each row In currentObjPermission
                        row.PermissionID = IIf(tempMenu.Checked Or flag, 1, 0)
                        If Not flag AndAlso tempMenu.DropDownItems.Count > 0 Then
                            row.PermissionID = 0
                            tempMenu.Checked = False
                        End If
                    Next
                Else
                    row = LocalDataset.tblUserbasedObjectPermissions.NewRow()
                    row.ObjectID = OID
                    'row.ApplicationID = AppID
                    row.UserID = UID
                    row.PermissionID = IIf(tempMenu.Checked Or flag, 1, 0)
                    LocalDataset.tblUserbasedObjectPermissions.AddtblUserbasedObjectPermissionsRow(row)
                End If
            Next
            tblUserbasedObjectPermissionsTableAdapter.Update(LocalDataset.tblUserbasedObjectPermissions)
            'LocalDataset.tblUserbasedObjectPermissions.Clear()
            'tblUserbasedObjectPermissionsTableAdapter.Fill(LocalDataset.tblUserbasedObjectPermissions)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function SetMenuPermissions(ByVal mnu As ToolStripMenuItem, ByVal containerClass As String) As Boolean
        Dim lowerFlag As Boolean = False, upperFlag As Boolean = False
        Dim OID As Integer
        Dim tempMenu As ToolStripMenuItem
        Dim currentObjPermission As DS.tblUserbasedObjectPermissionsRow()
        Dim row As DS.tblUserbasedObjectPermissionsRow
        Try
            For Each tempMenu In mnu.DropDownItems
                lowerFlag = False
                If tempMenu.DropDownItems.Count > 0 Then
                    lowerFlag = SetMenuPermissions(tempMenu, containerClass)
                End If
                OID = LocalDataset.tblObjects.Select("ObjectName = '" + tempMenu.Name + "' AND ContainerClass = '" + containerClass + "'").First.Item("ObjectID")
                currentObjPermission = LocalDataset.tblUserbasedObjectPermissions.Select("ObjectID = " + OID.ToString)
                If currentObjPermission.Count > 0 Then
                    For Each row In currentObjPermission
                        row.PermissionID = IIf(tempMenu.Checked Or lowerFlag, 1, 0)
                        If Not lowerFlag AndAlso tempMenu.DropDownItems.Count > 0 Then
                            row.PermissionID = 0
                            tempMenu.Checked = False
                        End If
                    Next
                Else
                    row = LocalDataset.tblUserbasedObjectPermissions.NewRow()
                    row.ObjectID = OID
                    'row.ApplicationID = AppID
                    row.UserID = UID
                    row.PermissionID = IIf(tempMenu.Checked Or lowerFlag, 1, 0)
                    LocalDataset.tblUserbasedObjectPermissions.AddtblUserbasedObjectPermissionsRow(row)
                End If
                If Not upperFlag Then upperFlag = IIf(tempMenu.Checked Or lowerFlag, True, False)
            Next
            Return upperFlag
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Sub AddMenu(ByVal mnuStrip As MenuStrip, ByVal containerClass As String)
        Dim mnu As ToolStripMenuItem
        Dim newRow As DS.tblObjectsRow
        Try
            For Each mnu In mnuStrip.Items
                If Not (mnu.GetType.ToString Like "*SystemMenuItem" Or mnu.GetType.ToString Like "*ControlBoxMenuItem") Then
                    If mnu.DropDownItems.Count > 0 Then
                        AddSubMenus(mnu, containerClass)
                    End If
                    newRow = LocalDataset.tblObjects.NewRow()
                    newRow.ObjectName = mnu.Name
                    newRow.AppID = AppID
                    Dim objectType As String = mnu.GetType.ToString
                    If LocalDataset.tblObjectTypes.Select("TypeName = '" + mnu.GetType.ToString + "'").Count = 0 Then
                        Dim newObjectRow As DS.tblObjectTypesRow = LocalDataset.tblObjectTypes.NewRow
                        newObjectRow.TypeName = objectType
                        LocalDataset.tblObjectTypes.AddtblObjectTypesRow(newObjectRow)
                        tblObjectTypesTableAdapter.Update(LocalDataset.tblObjectTypes)
                    End If
                    newRow.ObjectTypeID = LocalDataset.tblObjectTypes.Select("TypeName = '" + mnu.GetType.ToString + "'").First.Item("TypeID")
                    newRow.ContainerClass = containerClass
                    If LocalDataset.tblObjects.Select("ObjectTypeID = " + newRow.ObjectTypeID.ToString + " AND ObjectName = '" + newRow.ObjectName.ToString + "' AND ContainerClass = '" + newRow.ContainerClass + "' AND AppID ='" + newRow.AppID.ToString + "'").Count <= 0 Then
                        LocalDataset.tblObjects.AddtblObjectsRow(newRow)
                    Else : newRow.Delete()
                    End If
                End If
            Next
            tblObjectsTableAdapter.Update(LocalDataset.tblObjects)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AddSubMenus(ByVal menu As ToolStripMenuItem, ByVal containerClass As String)
        Dim mnu As ToolStripMenuItem
        Dim newRow As DS.tblObjectsRow
        Try
            For Each mnu In menu.DropDownItems
                If mnu.DropDownItems.Count > 0 Then
                    AddSubMenus(mnu, containerClass)
                End If
                newRow = LocalDataset.tblObjects.NewRow()
                newRow.ObjectName = mnu.Name
                newRow.AppID = AppID
                newRow.ObjectTypeID = LocalDataset.tblObjectTypes.Select("TypeName = '" + mnu.GetType.ToString + "'").First.Item("TypeID")
                newRow.ContainerClass = containerClass
                If LocalDataset.tblObjects.Select("ObjectTypeID = " + newRow.ObjectTypeID.ToString + " AND ObjectName = '" + newRow.ObjectName.ToString + "' AND ContainerClass = '" + newRow.ContainerClass + "' AND AppID ='" + newRow.AppID.ToString + "'").Count <= 0 Then
                    LocalDataset.tblObjects.AddtblObjectsRow(newRow)
                Else : newRow.Delete()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub CopyDropDownItems(ByVal SourceMenu As MenuStrip, ByRef DestinationMenu As MenuStrip, Optional ByVal checkOnClick As Boolean = False)
        Dim mnu As ToolStripMenuItem
        For Each mnu In SourceMenu.Items
            If mnu.GetType.ToString Like "*SystemMenuItem" Or mnu.GetType.ToString Like "*ControlBoxMenuItem" Then
                Continue For
            End If
            Dim tmpmnu As New ToolStripMenuItem
            tmpmnu.Name = mnu.Name
            tmpmnu.Text = mnu.Text
            tmpmnu.Image = mnu.Image
            If mnu.DropDownItems.Count > 0 Then
                CopyDropDownItems(mnu, tmpmnu, True)
            End If
            tmpmnu.CheckOnClick = True
            DestinationMenu.Items.Add(tmpmnu)
        Next
    End Sub

    Private Sub CopyDropDownItems(ByVal mnuSource As ToolStripMenuItem, ByRef mnuDestination As ToolStripMenuItem, Optional ByVal checkOnClick As Boolean = False)
        Dim menuItem, tmpmenu As ToolStripMenuItem
        For Each menuItem In mnuSource.DropDownItems
            tmpmenu = New ToolStripMenuItem()
            tmpmenu.Text = menuItem.Text
            tmpmenu.Name = menuItem.Name
            tmpmenu.Image = menuItem.Image
            If menuItem.DropDownItems.Count > 0 Then
                CopyDropDownItems(menuItem, tmpmenu)
            End If
            If checkOnClick Then
                tmpmenu.CheckOnClick = True
            End If
            mnuDestination.DropDownItems.Add(tmpmenu)
        Next
    End Sub

End Class
