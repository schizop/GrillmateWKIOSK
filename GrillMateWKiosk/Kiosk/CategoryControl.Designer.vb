<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoryControl
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
        btnCategory = New Button()
        SuspendLayout()
        ' 
        ' btnCategory
        ' 
        btnCategory.BackColor = Color.White
        btnCategory.Dock = DockStyle.Fill
        btnCategory.FlatAppearance.BorderColor = Color.LightGray
        btnCategory.FlatAppearance.BorderSize = 1
        btnCategory.FlatStyle = FlatStyle.Flat
        btnCategory.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCategory.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        btnCategory.Location = New Point(0, 0)
        btnCategory.Name = "btnCategory"
        btnCategory.Size = New Size(140, 50)
        btnCategory.TabIndex = 0
        btnCategory.Text = "Category"
        btnCategory.UseVisualStyleBackColor = False
        ' 
        ' CategoryControl
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(btnCategory)
        Margin = New Padding(5)
        Name = "CategoryControl"
        Size = New Size(140, 50)
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnCategory As Button

End Class
