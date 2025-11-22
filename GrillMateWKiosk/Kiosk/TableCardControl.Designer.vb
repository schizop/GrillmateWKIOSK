<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TableCardControl
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
        btnTable = New Button()
        SuspendLayout()
        ' 
        ' btnTable
        ' 
        btnTable.Dock = DockStyle.Fill
        btnTable.FlatAppearance.BorderSize = 2
        btnTable.FlatStyle = FlatStyle.Flat
        btnTable.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnTable.Location = New Point(0, 0)
        btnTable.Name = "btnTable"
        btnTable.Size = New Size(300, 200)
        btnTable.TabIndex = 0
        btnTable.Text = "TABLE"
        btnTable.UseVisualStyleBackColor = False
        ' 
        ' TableCardControl
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(btnTable)
        Name = "TableCardControl"
        Size = New Size(300, 200)
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnTable As Button

End Class
