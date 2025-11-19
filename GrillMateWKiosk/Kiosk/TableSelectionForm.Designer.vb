<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TableSelectionForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlTableGrid = New Panel()
        btnBack = New Button()
        lblTitle = New Label()
        SuspendLayout()
        ' 
        ' pnlTableGrid
        ' 
        pnlTableGrid.AutoScroll = True
        pnlTableGrid.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlTableGrid.Dock = DockStyle.Fill
        pnlTableGrid.Location = New Point(0, 125)
        pnlTableGrid.Margin = New Padding(4, 3, 4, 3)
        pnlTableGrid.Name = "pnlTableGrid"
        pnlTableGrid.Padding = New Padding(23)
        pnlTableGrid.Size = New Size(1904, 916)
        pnlTableGrid.TabIndex = 0
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnBack.Dock = DockStyle.Top
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(0, 0)
        btnBack.Margin = New Padding(4, 3, 4, 3)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(1904, 35)
        btnBack.TabIndex = 1
        btnBack.Text = "← BACK"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' lblTitle
        ' 
        lblTitle.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 35)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1904, 90)
        lblTitle.TabIndex = 2
        lblTitle.Text = "SELECT TABLE"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TableSelectionForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(1904, 1041)
        Controls.Add(pnlTableGrid)
        Controls.Add(lblTitle)
        Controls.Add(btnBack)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        Name = "TableSelectionForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GrillMate - Table Selection"
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTableGrid As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents lblTitle As Label
End Class