<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiptPreviewControl
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
        txtReceiptPreview = New TextBox()
        SuspendLayout()
        ' 
        ' txtReceiptPreview
        ' 
        txtReceiptPreview.Dock = DockStyle.Fill
        txtReceiptPreview.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtReceiptPreview.Location = New Point(0, 0)
        txtReceiptPreview.Multiline = True
        txtReceiptPreview.Name = "txtReceiptPreview"
        txtReceiptPreview.ReadOnly = True
        txtReceiptPreview.ScrollBars = ScrollBars.Vertical
        txtReceiptPreview.Size = New Size(400, 300)
        txtReceiptPreview.TabIndex = 0
        ' 
        ' ReceiptPreviewControl
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(txtReceiptPreview)
        Name = "ReceiptPreviewControl"
        Size = New Size(400, 300)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtReceiptPreview As TextBox

End Class
