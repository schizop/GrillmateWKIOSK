<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DineInOrTakeout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        btnDineIn = New Button()
        btnTakeout = New Button()
        btnBack = New Button()
        lblTitle = New Label()
        SuspendLayout()
        ' 
        ' btnDineIn
        ' 
        btnDineIn.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnDineIn.FlatAppearance.BorderSize = 0
        btnDineIn.FlatStyle = FlatStyle.Flat
        btnDineIn.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDineIn.ForeColor = Color.White
        btnDineIn.Location = New Point(400, 300)
        btnDineIn.Name = "btnDineIn"
        btnDineIn.Size = New Size(500, 400)
        btnDineIn.TabIndex = 0
        btnDineIn.Text = "🍽️" & vbCrLf & vbCrLf & "DINE-IN"
        btnDineIn.UseVisualStyleBackColor = False
        ' 
        ' btnTakeout
        ' 
        btnTakeout.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnTakeout.FlatAppearance.BorderSize = 0
        btnTakeout.FlatStyle = FlatStyle.Flat
        btnTakeout.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnTakeout.ForeColor = Color.White
        btnTakeout.Location = New Point(1000, 300)
        btnTakeout.Name = "btnTakeout"
        btnTakeout.Size = New Size(500, 400)
        btnTakeout.TabIndex = 1
        btnTakeout.Text = ChrW(55358) & ChrW(56673) & vbCrLf & vbCrLf & "TAKEOUT"
        btnTakeout.UseVisualStyleBackColor = False
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
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(1904, 35)
        btnBack.TabIndex = 2
        btnBack.Text = "← BACK TO LOGIN"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' lblTitle
        ' 
        lblTitle.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 35)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1904, 90)
        lblTitle.TabIndex = 3
        lblTitle.Text = "SELECT ORDER TYPE"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' DineInOrTakeout
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        ClientSize = New Size(1904, 1041)
        Controls.Add(btnDineIn)
        Controls.Add(btnTakeout)
        Controls.Add(lblTitle)
        Controls.Add(btnBack)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "DineInOrTakeout"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GrillMate - Order Type Selection"
        ResumeLayout(False)

    End Sub

    Friend WithEvents btnDineIn As Button
    Friend WithEvents btnTakeout As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblTitle As Label
End Class
