<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_TableManagement
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblTitle = New Label()
        pnlTableGrid = New Panel()
        btnRefresh = New Button()
        lblStatusInfo = New Label()
        pnlControls = New Panel()
        btnSetReserved = New Button()
        btnSetOccupied = New Button()
        btnSetVacant = New Button()
        lblSelectedTable = New Label()
        pnlTableInfo = New Panel()
        lblLastUpdated = New Label()
        lblTableStatus = New Label()
        lblTableNumber = New Label()
        pnlControls.SuspendLayout()
        pnlTableInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblTitle.Location = New Point(150, 97)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(306, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Table Management"
        ' 
        ' pnlTableGrid
        ' 
         pnlTableGrid.AutoScroll = True
         pnlTableGrid.BackColor = Color.White
         pnlTableGrid.BorderStyle = BorderStyle.FixedSingle
         pnlTableGrid.Location = New Point(150, 157)
         pnlTableGrid.Name = "pnlTableGrid"
         pnlTableGrid.Size = New Size(1000, 600)
         pnlTableGrid.TabIndex = 1
         pnlTableGrid.AutoScrollMargin = New Size(10, 10)
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(150, 777)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(120, 40)
        btnRefresh.TabIndex = 2
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' lblStatusInfo
        ' 
        lblStatusInfo.AutoSize = True
        lblStatusInfo.Font = New Font("Segoe UI", 10F)
        lblStatusInfo.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblStatusInfo.Location = New Point(290, 787)
        lblStatusInfo.Name = "lblStatusInfo"
        lblStatusInfo.Size = New Size(213, 19)
        lblStatusInfo.TabIndex = 3
        lblStatusInfo.Text = "Click on a table to manage status"
        ' 
        ' pnlControls
        ' 
        pnlControls.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        pnlControls.BorderStyle = BorderStyle.FixedSingle
        pnlControls.Controls.Add(btnSetReserved)
        pnlControls.Controls.Add(btnSetOccupied)
        pnlControls.Controls.Add(btnSetVacant)
        pnlControls.Location = New Point(1170, 182)
        pnlControls.Name = "pnlControls"
        pnlControls.Size = New Size(200, 162)
        pnlControls.TabIndex = 4
        ' 
        ' btnSetReserved
        ' 
        btnSetReserved.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        btnSetReserved.FlatAppearance.BorderSize = 0
        btnSetReserved.FlatStyle = FlatStyle.Flat
        btnSetReserved.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnSetReserved.ForeColor = Color.White
        btnSetReserved.Location = New Point(10, 100)
        btnSetReserved.Name = "btnSetReserved"
        btnSetReserved.Size = New Size(180, 35)
        btnSetReserved.TabIndex = 2
        btnSetReserved.Text = "Set Reserved"
        btnSetReserved.UseVisualStyleBackColor = False
        ' 
        ' btnSetOccupied
        ' 
        btnSetOccupied.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnSetOccupied.FlatAppearance.BorderSize = 0
        btnSetOccupied.FlatStyle = FlatStyle.Flat
        btnSetOccupied.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnSetOccupied.ForeColor = Color.White
        btnSetOccupied.Location = New Point(10, 55)
        btnSetOccupied.Name = "btnSetOccupied"
        btnSetOccupied.Size = New Size(180, 35)
        btnSetOccupied.TabIndex = 1
        btnSetOccupied.Text = "Set Occupied"
        btnSetOccupied.UseVisualStyleBackColor = False
        ' 
        ' btnSetVacant
        ' 
        btnSetVacant.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSetVacant.FlatAppearance.BorderSize = 0
        btnSetVacant.FlatStyle = FlatStyle.Flat
        btnSetVacant.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnSetVacant.ForeColor = Color.White
        btnSetVacant.Location = New Point(10, 10)
        btnSetVacant.Name = "btnSetVacant"
        btnSetVacant.Size = New Size(180, 35)
        btnSetVacant.TabIndex = 0
        btnSetVacant.Text = "Set Vacant"
        btnSetVacant.UseVisualStyleBackColor = False
        ' 
        ' lblSelectedTable
        ' 
        lblSelectedTable.AutoSize = True
        lblSelectedTable.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblSelectedTable.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblSelectedTable.Location = New Point(1170, 377)
        lblSelectedTable.Name = "lblSelectedTable"
        lblSelectedTable.Size = New Size(124, 21)
        lblSelectedTable.TabIndex = 5
        lblSelectedTable.Text = "Selected Table:"
        ' 
        ' pnlTableInfo
        ' 
        pnlTableInfo.BackColor = Color.White
        pnlTableInfo.BorderStyle = BorderStyle.FixedSingle
        pnlTableInfo.Controls.Add(lblLastUpdated)
        pnlTableInfo.Controls.Add(lblTableStatus)
        pnlTableInfo.Controls.Add(lblTableNumber)
        pnlTableInfo.Location = New Point(1170, 407)
        pnlTableInfo.Name = "pnlTableInfo"
        pnlTableInfo.Size = New Size(200, 150)
        pnlTableInfo.TabIndex = 6
        ' 
        ' lblLastUpdated
        ' 
        lblLastUpdated.AutoSize = True
        lblLastUpdated.Font = New Font("Segoe UI", 9F)
        lblLastUpdated.ForeColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        lblLastUpdated.Location = New Point(10, 80)
        lblLastUpdated.Name = "lblLastUpdated"
        lblLastUpdated.Size = New Size(79, 15)
        lblLastUpdated.TabIndex = 2
        lblLastUpdated.Text = "Last Updated:"
        ' 
        ' lblTableStatus
        ' 
        lblTableStatus.AutoSize = True
        lblTableStatus.Font = New Font("Segoe UI", 12F)
        lblTableStatus.ForeColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        lblTableStatus.Location = New Point(10, 45)
        lblTableStatus.Name = "lblTableStatus"
        lblTableStatus.Size = New Size(56, 21)
        lblTableStatus.TabIndex = 1
        lblTableStatus.Text = "Vacant"
        ' 
        ' lblTableNumber
        ' 
        lblTableNumber.AutoSize = True
        lblTableNumber.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTableNumber.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTableNumber.Location = New Point(10, 10)
        lblTableNumber.Name = "lblTableNumber"
        lblTableNumber.Size = New Size(74, 25)
        lblTableNumber.TabIndex = 0
        lblTableNumber.Text = "Table #"
        ' 
        ' UC_TableManagement
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(250))
        Controls.Add(pnlTableInfo)
        Controls.Add(lblSelectedTable)
        Controls.Add(pnlControls)
        Controls.Add(lblStatusInfo)
        Controls.Add(btnRefresh)
        Controls.Add(pnlTableGrid)
        Controls.Add(lblTitle)
        Name = "UC_TableManagement"
        Size = New Size(1670, 1020)
        pnlControls.ResumeLayout(False)
        pnlTableInfo.ResumeLayout(False)
        pnlTableInfo.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlTableGrid As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblStatusInfo As Label
    Friend WithEvents pnlControls As Panel
    Friend WithEvents btnSetVacant As Button
    Friend WithEvents btnSetOccupied As Button
    Friend WithEvents btnSetReserved As Button
    Friend WithEvents lblSelectedTable As Label
    Friend WithEvents pnlTableInfo As Panel
    Friend WithEvents lblTableNumber As Label
    Friend WithEvents lblTableStatus As Label
    Friend WithEvents lblLastUpdated As Label

End Class
