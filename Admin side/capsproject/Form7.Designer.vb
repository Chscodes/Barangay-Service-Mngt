<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form7
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(Me.components)
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2AnimateWindow1 = New Guna.UI2.WinForms.Guna2AnimateWindow(Me.components)
        Me.dgv_docs = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2VSeparator2 = New Guna.UI2.WinForms.Guna2VSeparator()
        Me.Guna2VSeparator1 = New Guna.UI2.WinForms.Guna2VSeparator()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.lbl_avail = New System.Windows.Forms.Label()
        Me.tg_avail = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdocDesc = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdocname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtdocPrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnsave = New Guna.UI2.WinForms.Guna2Button()
        Me.btn_edit = New Guna.UI2.WinForms.Guna2Button()
        Me.btnupdate = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.dgv_docs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2ShadowForm1
        '
        Me.Guna2ShadowForm1.TargetForm = Me
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 20
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2AnimateWindow1
        '
        Me.Guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_SLIDE
        Me.Guna2AnimateWindow1.TargetForm = Me
        '
        'dgv_docs
        '
        Me.dgv_docs.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(183, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgv_docs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_docs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv_docs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv_docs.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.dgv_docs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_docs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_docs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_docs.ColumnHeadersHeight = 37
        Me.dgv_docs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(207, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(95, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_docs.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_docs.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgv_docs.EnableHeadersVisualStyles = False
        Me.dgv_docs.GridColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgv_docs.Location = New System.Drawing.Point(0, 0)
        Me.dgv_docs.Name = "dgv_docs"
        Me.dgv_docs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_docs.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_docs.RowHeadersVisible = False
        Me.dgv_docs.RowTemplate.Height = 26
        Me.dgv_docs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_docs.Size = New System.Drawing.Size(541, 538)
        Me.dgv_docs.TabIndex = 1
        Me.dgv_docs.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.SunFlower
        Me.dgv_docs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dgv_docs.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_docs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Gray
        Me.dgv_docs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgv_docs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgv_docs.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.dgv_docs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgv_docs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.dgv_docs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised
        Me.dgv_docs.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgv_docs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgv_docs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_docs.ThemeStyle.HeaderStyle.Height = 37
        Me.dgv_docs.ThemeStyle.ReadOnly = False
        Me.dgv_docs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.dgv_docs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv_docs.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_docs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv_docs.ThemeStyle.RowsStyle.Height = 26
        Me.dgv_docs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.dgv_docs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(698, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 37)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Documents Information"
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Separator1.Location = New System.Drawing.Point(540, 31)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(606, 25)
        Me.Guna2Separator1.TabIndex = 38
        Me.Guna2Separator1.UseTransparentBackground = True
        '
        'Guna2VSeparator2
        '
        Me.Guna2VSeparator2.Location = New System.Drawing.Point(648, 57)
        Me.Guna2VSeparator2.Name = "Guna2VSeparator2"
        Me.Guna2VSeparator2.Size = New System.Drawing.Size(8, 17)
        Me.Guna2VSeparator2.TabIndex = 349
        '
        'Guna2VSeparator1
        '
        Me.Guna2VSeparator1.Location = New System.Drawing.Point(547, 56)
        Me.Guna2VSeparator1.Name = "Guna2VSeparator1"
        Me.Guna2VSeparator1.Size = New System.Drawing.Size(8, 17)
        Me.Guna2VSeparator1.TabIndex = 348
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.lbl_avail)
        Me.Guna2ShadowPanel1.Controls.Add(Me.tg_avail)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label4)
        Me.Guna2ShadowPanel1.Controls.Add(Me.txtdocPrice)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.txtdocDesc)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label3)
        Me.Guna2ShadowPanel1.Controls.Add(Me.txtdocname)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.SystemColors.Control
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(547, 85)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2ShadowPanel1.ShadowShift = 10
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(588, 453)
        Me.Guna2ShadowPanel1.TabIndex = 353
        '
        'lbl_avail
        '
        Me.lbl_avail.AutoSize = True
        Me.lbl_avail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_avail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbl_avail.Font = New System.Drawing.Font("Copperplate Gothic Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_avail.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_avail.Location = New System.Drawing.Point(436, 26)
        Me.lbl_avail.Name = "lbl_avail"
        Me.lbl_avail.Size = New System.Drawing.Size(101, 18)
        Me.lbl_avail.TabIndex = 372
        Me.lbl_avail.Text = "AVAILABLE"
        Me.lbl_avail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tg_avail
        '
        Me.tg_avail.Checked = True
        Me.tg_avail.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tg_avail.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.tg_avail.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.tg_avail.CheckedState.InnerColor = System.Drawing.Color.White
        Me.tg_avail.Location = New System.Drawing.Point(395, 25)
        Me.tg_avail.Name = "tg_avail"
        Me.tg_avail.Size = New System.Drawing.Size(35, 20)
        Me.tg_avail.TabIndex = 354
        Me.tg_avail.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.tg_avail.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.tg_avail.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.tg_avail.UncheckedState.InnerColor = System.Drawing.Color.White
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(16, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 29)
        Me.Label4.TabIndex = 371
        Me.Label4.Text = "Document Price:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(15, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 29)
        Me.Label2.TabIndex = 369
        Me.Label2.Text = "Document Description:"
        '
        'txtdocDesc
        '
        Me.txtdocDesc.Animated = True
        Me.txtdocDesc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.txtdocDesc.BorderRadius = 8
        Me.txtdocDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdocDesc.DefaultText = ""
        Me.txtdocDesc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtdocDesc.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtdocDesc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtdocDesc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtdocDesc.FillColor = System.Drawing.SystemColors.Control
        Me.txtdocDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtdocDesc.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdocDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtdocDesc.Location = New System.Drawing.Point(67, 235)
        Me.txtdocDesc.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtdocDesc.Multiline = True
        Me.txtdocDesc.Name = "txtdocDesc"
        Me.txtdocDesc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtdocDesc.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.txtdocDesc.PlaceholderText = ""
        Me.txtdocDesc.SelectedText = ""
        Me.txtdocDesc.Size = New System.Drawing.Size(344, 147)
        Me.txtdocDesc.TabIndex = 368
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(16, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 29)
        Me.Label3.TabIndex = 367
        Me.Label3.Text = "Document Name:"
        '
        'txtdocname
        '
        Me.txtdocname.Animated = True
        Me.txtdocname.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.txtdocname.BorderRadius = 8
        Me.txtdocname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdocname.DefaultText = ""
        Me.txtdocname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtdocname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtdocname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtdocname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtdocname.FillColor = System.Drawing.SystemColors.Control
        Me.txtdocname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtdocname.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdocname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtdocname.Location = New System.Drawing.Point(67, 58)
        Me.txtdocname.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtdocname.Name = "txtdocname"
        Me.txtdocname.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtdocname.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.txtdocname.PlaceholderText = ""
        Me.txtdocname.SelectedText = ""
        Me.txtdocname.Size = New System.Drawing.Size(420, 41)
        Me.txtdocname.TabIndex = 366
        '
        'txtdocPrice
        '
        Me.txtdocPrice.Animated = True
        Me.txtdocPrice.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.txtdocPrice.BorderRadius = 8
        Me.txtdocPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdocPrice.DefaultText = ""
        Me.txtdocPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtdocPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtdocPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtdocPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtdocPrice.FillColor = System.Drawing.SystemColors.Control
        Me.txtdocPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtdocPrice.Font = New System.Drawing.Font("Copperplate Gothic Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdocPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtdocPrice.IconLeft = CType(resources.GetObject("txtdocPrice.IconLeft"), System.Drawing.Image)
        Me.txtdocPrice.Location = New System.Drawing.Point(65, 152)
        Me.txtdocPrice.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtdocPrice.MaxLength = 6
        Me.txtdocPrice.Name = "txtdocPrice"
        Me.txtdocPrice.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtdocPrice.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.txtdocPrice.PlaceholderText = ""
        Me.txtdocPrice.SelectedText = ""
        Me.txtdocPrice.Size = New System.Drawing.Size(215, 41)
        Me.txtdocPrice.TabIndex = 370
        '
        'btnClear
        '
        Me.btnClear.Animated = True
        Me.btnClear.AutoRoundedCorners = True
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.BorderColor = System.Drawing.Color.Transparent
        Me.btnClear.BorderRadius = 14
        Me.btnClear.BorderThickness = 1
        Me.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClear.FillColor = System.Drawing.Color.Transparent
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnClear.HoverState.BorderColor = System.Drawing.Color.Gold
        Me.btnClear.HoverState.FillColor = System.Drawing.Color.Transparent
        Me.btnClear.HoverState.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.HoverState.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageSize = New System.Drawing.Size(15, 15)
        Me.btnClear.Location = New System.Drawing.Point(671, 49)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.PressedColor = System.Drawing.Color.Lime
        Me.btnClear.Size = New System.Drawing.Size(70, 30)
        Me.btnClear.TabIndex = 352
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseTransparentBackground = True
        Me.btnClear.Visible = False
        '
        'btnsave
        '
        Me.btnsave.Animated = True
        Me.btnsave.AutoRoundedCorners = True
        Me.btnsave.BackColor = System.Drawing.Color.Transparent
        Me.btnsave.BorderColor = System.Drawing.Color.Transparent
        Me.btnsave.BorderRadius = 14
        Me.btnsave.BorderThickness = 1
        Me.btnsave.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnsave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnsave.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnsave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnsave.FillColor = System.Drawing.Color.Transparent
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnsave.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnsave.HoverState.BorderColor = System.Drawing.Color.Lime
        Me.btnsave.HoverState.FillColor = System.Drawing.Color.Transparent
        Me.btnsave.HoverState.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.HoverState.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageSize = New System.Drawing.Size(15, 15)
        Me.btnsave.Location = New System.Drawing.Point(572, 49)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(70, 30)
        Me.btnsave.TabIndex = 347
        Me.btnsave.Text = "Save"
        Me.btnsave.UseTransparentBackground = True
        '
        'btn_edit
        '
        Me.btn_edit.Animated = True
        Me.btn_edit.AutoRoundedCorners = True
        Me.btn_edit.BackColor = System.Drawing.Color.Transparent
        Me.btn_edit.BorderColor = System.Drawing.Color.Transparent
        Me.btn_edit.BorderRadius = 14
        Me.btn_edit.BorderThickness = 1
        Me.btn_edit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_edit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_edit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_edit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_edit.FillColor = System.Drawing.Color.Transparent
        Me.btn_edit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_edit.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btn_edit.HoverState.BorderColor = System.Drawing.Color.Gold
        Me.btn_edit.HoverState.FillColor = System.Drawing.Color.Transparent
        Me.btn_edit.HoverState.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_edit.HoverState.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btn_edit.Image = CType(resources.GetObject("btn_edit.Image"), System.Drawing.Image)
        Me.btn_edit.ImageSize = New System.Drawing.Size(15, 15)
        Me.btn_edit.Location = New System.Drawing.Point(572, 49)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.PressedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_edit.Size = New System.Drawing.Size(70, 30)
        Me.btn_edit.TabIndex = 351
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseTransparentBackground = True
        Me.btn_edit.Visible = False
        '
        'btnupdate
        '
        Me.btnupdate.Animated = True
        Me.btnupdate.AutoRoundedCorners = True
        Me.btnupdate.BackColor = System.Drawing.Color.Transparent
        Me.btnupdate.BorderColor = System.Drawing.Color.Transparent
        Me.btnupdate.BorderRadius = 14
        Me.btnupdate.BorderThickness = 1
        Me.btnupdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnupdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnupdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnupdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnupdate.FillColor = System.Drawing.Color.Transparent
        Me.btnupdate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnupdate.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnupdate.HoverState.BorderColor = System.Drawing.Color.Gold
        Me.btnupdate.HoverState.FillColor = System.Drawing.Color.Transparent
        Me.btnupdate.HoverState.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.HoverState.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnupdate.Image = CType(resources.GetObject("btnupdate.Image"), System.Drawing.Image)
        Me.btnupdate.ImageSize = New System.Drawing.Size(15, 15)
        Me.btnupdate.Location = New System.Drawing.Point(572, 49)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.PressedColor = System.Drawing.Color.Lime
        Me.btnupdate.Size = New System.Drawing.Size(70, 30)
        Me.btnupdate.TabIndex = 350
        Me.btnupdate.Text = "Save"
        Me.btnupdate.UseTransparentBackground = True
        Me.btnupdate.Visible = False
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 538)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Guna2VSeparator2)
        Me.Controls.Add(Me.Guna2VSeparator1)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.Guna2Separator1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_docs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form7"
        Me.Text = "Form7"
        CType(Me.dgv_docs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2AnimateWindow1 As Guna.UI2.WinForms.Guna2AnimateWindow
    Friend WithEvents dgv_docs As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents btnClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2VSeparator2 As Guna.UI2.WinForms.Guna2VSeparator
    Friend WithEvents Guna2VSeparator1 As Guna.UI2.WinForms.Guna2VSeparator
    Friend WithEvents btnsave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btn_edit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnupdate As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents lbl_avail As Label
    Friend WithEvents tg_avail As Guna.UI2.WinForms.Guna2ToggleSwitch
    Friend WithEvents Label4 As Label
    Friend WithEvents txtdocPrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtdocname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtdocDesc As Guna.UI2.WinForms.Guna2TextBox
End Class
