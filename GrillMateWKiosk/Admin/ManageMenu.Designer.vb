<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageMenu
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        txtboxCategoryID = New TextBox()
        Label6 = New Label()
        chkboxStatus = New CheckBox()
        txtboxDescript = New TextBox()
        Label5 = New Label()
        DataGridView1 = New DataGridView()
        btnDelete = New Button()
        btnUpdate = New Button()
        btnAdd = New Button()
        txtboxPrice = New TextBox()
        txtboxProdName = New TextBox()
        txtboxProdID = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        btnClear = New Button()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btnClear)
        Panel1.Controls.Add(txtboxCategoryID)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(chkboxStatus)
        Panel1.Controls.Add(txtboxDescript)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(DataGridView1)
        Panel1.Controls.Add(btnDelete)
        Panel1.Controls.Add(btnUpdate)
        Panel1.Controls.Add(btnAdd)
        Panel1.Controls.Add(txtboxPrice)
        Panel1.Controls.Add(txtboxProdName)
        Panel1.Controls.Add(txtboxProdID)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(8, 48)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1288, 692)
        Panel1.TabIndex = 0
        ' 
        ' txtboxCategoryID
        ' 
        txtboxCategoryID.Location = New Point(135, 328)
        txtboxCategoryID.Name = "txtboxCategoryID"
        txtboxCategoryID.Size = New Size(145, 23)
        txtboxCategoryID.TabIndex = 16
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        Label6.Location = New Point(20, 331)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(95, 20)
        Label6.TabIndex = 15
        Label6.Text = "Category ID:"
        ' 
        ' chkboxStatus
        ' 
        chkboxStatus.AutoSize = True
        chkboxStatus.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        chkboxStatus.Location = New Point(93, 412)
        chkboxStatus.Margin = New Padding(2)
        chkboxStatus.Name = "chkboxStatus"
        chkboxStatus.Size = New Size(93, 24)
        chkboxStatus.TabIndex = 14
        chkboxStatus.Text = "Available"
        chkboxStatus.UseVisualStyleBackColor = True
        ' 
        ' txtboxDescript
        ' 
        txtboxDescript.Location = New Point(135, 191)
        txtboxDescript.Margin = New Padding(2)
        txtboxDescript.Name = "txtboxDescript"
        txtboxDescript.Size = New Size(145, 23)
        txtboxDescript.TabIndex = 13
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        Label5.Location = New Point(20, 192)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(95, 20)
        Label5.TabIndex = 12
        Label5.Text = "Description: "
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.BackgroundColor = SystemColors.ButtonFace
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 13.0F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 11.0F)
        DataGridViewCellStyle2.ForeColor = SystemColors.ActiveCaptionText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.Control
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        DataGridView1.Location = New Point(312, 38)
        DataGridView1.Margin = New Padding(2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(927, 474)
        DataGridView1.TabIndex = 11
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(74, 479)
        btnDelete.Margin = New Padding(2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(61, 33)
        btnDelete.TabIndex = 10
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(152, 436)
        btnUpdate.Margin = New Padding(2)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(61, 33)
        btnUpdate.TabIndex = 9
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(74, 436)
        btnAdd.Margin = New Padding(2)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(61, 33)
        btnAdd.TabIndex = 8
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' txtboxPrice
        ' 
        txtboxPrice.Location = New Point(135, 260)
        txtboxPrice.Margin = New Padding(2)
        txtboxPrice.Name = "txtboxPrice"
        txtboxPrice.Size = New Size(145, 23)
        txtboxPrice.TabIndex = 6
        ' 
        ' txtboxProdName
        ' 
        txtboxProdName.Location = New Point(134, 126)
        txtboxProdName.Margin = New Padding(2)
        txtboxProdName.Name = "txtboxProdName"
        txtboxProdName.Size = New Size(145, 23)
        txtboxProdName.TabIndex = 5
        ' 
        ' txtboxProdID
        ' 
        txtboxProdID.Location = New Point(134, 66)
        txtboxProdID.Margin = New Padding(2)
        txtboxProdID.Name = "txtboxProdID"
        txtboxProdID.Size = New Size(145, 23)
        txtboxProdID.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        Label3.Location = New Point(20, 261)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(105, 20)
        Label3.TabIndex = 2
        Label3.Text = "Product Price:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        Label2.Location = New Point(19, 125)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(112, 20)
        Label2.TabIndex = 1
        Label2.Text = "Product Name:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        Label1.Location = New Point(19, 66)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 20)
        Label1.TabIndex = 0
        Label1.Text = "Product ID:"
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(152, 479)
        btnClear.Margin = New Padding(2)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(61, 33)
        btnClear.TabIndex = 17
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' ManageMenu
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1904, 981)
        Controls.Add(Panel1)
        Margin = New Padding(2)
        Name = "ManageMenu"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ManageMenu"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtboxPrice As TextBox
    Friend WithEvents txtboxProdName As TextBox
    Friend WithEvents txtboxProdID As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtboxDescript As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chkboxStatus As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtboxCategoryID As TextBox
    Friend WithEvents btnClear As Button
End Class
