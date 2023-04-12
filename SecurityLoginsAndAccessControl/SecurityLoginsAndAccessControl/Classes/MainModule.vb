
Module MainModule


    Friend Function CreateMenuFromRibbon(ribbon As DevExpress.XtraBars.Ribbon.RibbonControl) As MenuStrip
        Dim tmpMnu As New MenuStrip
        If ribbon.PageCategories.Count > 0 Then
            For Each pageCategory As DevExpress.XtraBars.Ribbon.RibbonPageCategory In ribbon.PageCategories
                Dim rootmnu = New ToolStripMenuItem() With {.Name = pageCategory.Name, .Text = pageCategory.Text}
                For Each page As DevExpress.XtraBars.Ribbon.RibbonPage In pageCategory.Pages
                    Dim mnu = New ToolStripMenuItem() With {.Name = page.Name, .Text = page.Text}
                    For Each group As DevExpress.XtraBars.Ribbon.RibbonPageGroup In page.Groups
                        Dim submenu = New ToolStripMenuItem() With {.Name = group.Name, .Text = group.Text}
                        For Each item As DevExpress.XtraBars.BarButtonItemLink In group.ItemLinks
                            Dim imnu = New ToolStripMenuItem() With {.Name = item.Item.Name, .Text = item.Item.Caption}
                            submenu.DropDownItems.Add(imnu)
                        Next
                        mnu.DropDownItems.Add(submenu)
                    Next
                    rootmnu.DropDownItems.Add(mnu)
                Next
                tmpMnu.Items.Add(rootmnu)
            Next
        Else
            For Each page As DevExpress.XtraBars.Ribbon.RibbonPage In ribbon.Pages
                Dim mnu = New ToolStripMenuItem() With {.Name = page.Name, .Text = page.Text}
                For Each group As DevExpress.XtraBars.Ribbon.RibbonPageGroup In page.Groups
                    Dim submenu = New ToolStripMenuItem() With {.Name = group.Name, .Text = group.Text}
                    For Each item As DevExpress.XtraBars.BarButtonItemLink In group.ItemLinks.OfType(Of DevExpress.XtraBars.BarButtonItemLink)()
                        Dim imnu = New ToolStripMenuItem() With {.Name = item.Item.Name, .Text = item.Item.Caption}
                        submenu.DropDownItems.Add(imnu)
                    Next
                    mnu.DropDownItems.Add(submenu)
                Next
                tmpMnu.Items.Add(mnu)
            Next
        End If
        Return tmpMnu
    End Function


    Friend Function CreateMenuFromNavBar(navBar As DevExpress.XtraNavBar.NavBarControl) As MenuStrip
        Dim tmpMnu As New MenuStrip

        For Each group As DevExpress.XtraNavBar.NavBarGroup In navBar.Groups
            Dim rootmnu As New ToolStripMenuItem() With {.Name = group.Name, .Text = group.Caption}
            'Dim grpitems = From d As DevExpress.XtraNavBar.NavBarItemLink In group.ItemLinks
            '          Select d.Item Distinct

            For Each item As DevExpress.XtraNavBar.NavBarItemLink In group.ItemLinks
                Dim mnu As New ToolStripMenuItem() With {.Name = item.Item.Name, .Text = item.Item.Caption}
                rootmnu.DropDownItems.Add(mnu)
            Next
            tmpMnu.Items.Add(rootmnu)
        Next

        Return tmpMnu
    End Function


End Module
