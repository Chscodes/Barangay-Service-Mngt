<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(Me.components)
        Me.Guna2AnimateWindow1 = New Guna.UI2.WinForms.Guna2AnimateWindow(Me.components)
        Me.dgv_docu = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.txtsearch = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.res_report = New Guna.UI2.WinForms.Guna2Button()
        Me.sum_report = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.dtp_to = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.dtp_from = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.BtnShow = New Guna.UI2.WinForms.Guna2Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.print_Doc_report = New System.Drawing.Printing.PrintDocument()
        Me.print_preview_report = New System.Windows.Forms.PrintPreviewDialog()
        Me.bg_reports = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.cmb_doc = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.print_prev_ALLREQ = New System.Windows.Forms.PrintPreviewDialog()
        Me.print_doc_ALLREQ = New System.Drawing.Printing.PrintDocument()
        Me.dgv_res_req = New Guna.UI2.WinForms.Guna2DataGridView()
        CType(Me.dgv_docu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GroupBox1.SuspendLayout()
        CType(Me.bg_reports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_res_req, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2ShadowForm1
        '
        Me.Guna2ShadowForm1.TargetForm = Me
        '
        'Guna2AnimateWindow1
        '
        Me.Guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_SLIDE
        Me.Guna2AnimateWindow1.TargetForm = Me
        '
        'dgv_docu
        '
        Me.dgv_docu.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(183, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgv_docu.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_docu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv_docu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv_docu.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.dgv_docu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_docu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_docu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_docu.ColumnHeadersHeight = 37
        Me.dgv_docu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(207, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(95, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_docu.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_docu.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgv_docu.EnableHeadersVisualStyles = False
        Me.dgv_docu.GridColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgv_docu.Location = New System.Drawing.Point(0, 0)
        Me.dgv_docu.Name = "dgv_docu"
        Me.dgv_docu.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_docu.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_docu.RowHeadersVisible = False
        Me.dgv_docu.RowTemplate.Height = 26
        Me.dgv_docu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_docu.Size = New System.Drawing.Size(689, 577)
        Me.dgv_docu.TabIndex = 1
        Me.dgv_docu.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.SunFlower
        Me.dgv_docu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dgv_docu.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_docu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Gray
        Me.dgv_docu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgv_docu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgv_docu.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.dgv_docu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgv_docu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.dgv_docu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised
        Me.dgv_docu.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgv_docu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgv_docu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_docu.ThemeStyle.HeaderStyle.Height = 37
        Me.dgv_docu.ThemeStyle.ReadOnly = False
        Me.dgv_docu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.dgv_docu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv_docu.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_docu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv_docu.ThemeStyle.RowsStyle.Height = 26
        Me.dgv_docu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.dgv_docu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'txtsearch
        '
        Me.txtsearch.Animated = True
        Me.txtsearch.AutoRoundedCorners = True
        Me.txtsearch.BorderColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.txtsearch.BorderRadius = 15
        Me.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtsearch.DefaultText = ""
        Me.txtsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtsearch.FillColor = System.Drawing.SystemColors.Control
        Me.txtsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtsearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtsearch.IconLeft = CType(resources.GetObject("txtsearch.IconLeft"), System.Drawing.Image)
        Me.txtsearch.Location = New System.Drawing.Point(693, 59)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtsearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.txtsearch.PlaceholderText = "Search..."
        Me.txtsearch.SelectedText = ""
        Me.txtsearch.Size = New System.Drawing.Size(444, 32)
        Me.txtsearch.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(815, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 37)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Summary Report"
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Separator1.Location = New System.Drawing.Point(693, 38)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(453, 25)
        Me.Guna2Separator1.TabIndex = 43
        Me.Guna2Separator1.UseTransparentBackground = True
        '
        'res_report
        '
        Me.res_report.Animated = True
        Me.res_report.AutoRoundedCorners = True
        Me.res_report.BackColor = System.Drawing.Color.Transparent
        Me.res_report.BorderRadius = 22
        Me.res_report.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.res_report.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.res_report.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.res_report.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.res_report.FillColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.res_report.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.res_report.ForeColor = System.Drawing.Color.White
        Me.res_report.Location = New System.Drawing.Point(739, 519)
        Me.res_report.Name = "res_report"
        Me.res_report.Size = New System.Drawing.Size(361, 46)
        Me.res_report.TabIndex = 45
        Me.res_report.Text = "Generate Requests"
        Me.res_report.UseTransparentBackground = True
        '
        'sum_report
        '
        Me.sum_report.Animated = True
        Me.sum_report.AutoRoundedCorners = True
        Me.sum_report.BackColor = System.Drawing.Color.Transparent
        Me.sum_report.BorderRadius = 22
        Me.sum_report.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.sum_report.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.sum_report.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.sum_report.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.sum_report.FillColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.sum_report.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.sum_report.ForeColor = System.Drawing.Color.White
        Me.sum_report.Location = New System.Drawing.Point(739, 453)
        Me.sum_report.Name = "sum_report"
        Me.sum_report.Size = New System.Drawing.Size(361, 46)
        Me.sum_report.TabIndex = 379
        Me.sum_report.Text = "Generate Summary Report"
        Me.sum_report.UseTransparentBackground = True
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.Controls.Add(Me.dtp_to)
        Me.Guna2GroupBox1.Controls.Add(Me.dtp_from)
        Me.Guna2GroupBox1.Controls.Add(Me.BtnShow)
        Me.Guna2GroupBox1.Controls.Add(Me.Label5)
        Me.Guna2GroupBox1.Controls.Add(Me.Label4)
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(699, 171)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(447, 276)
        Me.Guna2GroupBox1.TabIndex = 385
        Me.Guna2GroupBox1.Text = "Advance Date Filter: "
        '
        'dtp_to
        '
        Me.dtp_to.Animated = True
        Me.dtp_to.BackColor = System.Drawing.Color.Transparent
        Me.dtp_to.BorderRadius = 5
        Me.dtp_to.Checked = True
        Me.dtp_to.CustomFormat = "yyyy-MM-dd"
        Me.dtp_to.FillColor = System.Drawing.Color.White
        Me.dtp_to.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_to.Location = New System.Drawing.Point(59, 155)
        Me.dtp_to.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_to.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_to.Name = "dtp_to"
        Me.dtp_to.Size = New System.Drawing.Size(320, 52)
        Me.dtp_to.TabIndex = 391
        Me.dtp_to.UseTransparentBackground = True
        Me.dtp_to.Value = New Date(2022, 12, 18, 0, 0, 0, 0)
        '
        'dtp_from
        '
        Me.dtp_from.Animated = True
        Me.dtp_from.BackColor = System.Drawing.Color.Transparent
        Me.dtp_from.BorderRadius = 5
        Me.dtp_from.Checked = True
        Me.dtp_from.CustomFormat = "yyyy-MM-dd"
        Me.dtp_from.FillColor = System.Drawing.Color.White
        Me.dtp_from.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_from.Location = New System.Drawing.Point(59, 76)
        Me.dtp_from.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_from.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_from.Name = "dtp_from"
        Me.dtp_from.Size = New System.Drawing.Size(320, 52)
        Me.dtp_from.TabIndex = 390
        Me.dtp_from.UseTransparentBackground = True
        Me.dtp_from.Value = New Date(2022, 12, 7, 0, 0, 0, 0)
        '
        'BtnShow
        '
        Me.BtnShow.Animated = True
        Me.BtnShow.AutoRoundedCorners = True
        Me.BtnShow.BackColor = System.Drawing.Color.Transparent
        Me.BtnShow.BorderRadius = 22
        Me.BtnShow.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnShow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnShow.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnShow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnShow.FillColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtnShow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnShow.ForeColor = System.Drawing.Color.White
        Me.BtnShow.Location = New System.Drawing.Point(150, 213)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(154, 46)
        Me.BtnShow.TabIndex = 389
        Me.BtnShow.Text = "Show"
        Me.BtnShow.UseTransparentBackground = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(2, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 19)
        Me.Label5.TabIndex = 388
        Me.Label5.Text = "To: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(2, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 19)
        Me.Label4.TabIndex = 387
        Me.Label4.Text = "From: "
        '
        'print_Doc_report
        '
        '
        'print_preview_report
        '
        Me.print_preview_report.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.print_preview_report.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.print_preview_report.ClientSize = New System.Drawing.Size(400, 300)
        Me.print_preview_report.Document = Me.print_Doc_report
        Me.print_preview_report.Enabled = True
        Me.print_preview_report.Icon = CType(resources.GetObject("print_preview_report.Icon"), System.Drawing.Icon)
        Me.print_preview_report.Name = "PrintPreviewDialog1"
        Me.print_preview_report.Visible = False
        '
        'bg_reports
        '
        Me.bg_reports.Image = CType(resources.GetObject("bg_reports.Image"), System.Drawing.Image)
        Me.bg_reports.ImageRotate = 0!
        Me.bg_reports.Location = New System.Drawing.Point(380, -45)
        Me.bg_reports.Name = "bg_reports"
        Me.bg_reports.Size = New System.Drawing.Size(38, 41)
        Me.bg_reports.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.bg_reports.TabIndex = 392
        Me.bg_reports.TabStop = False
        '
        'cmb_doc
        '
        Me.cmb_doc.BackColor = System.Drawing.Color.Transparent
        Me.cmb_doc.BorderRadius = 5
        Me.cmb_doc.BorderThickness = 2
        Me.cmb_doc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_doc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_doc.FillColor = System.Drawing.SystemColors.Control
        Me.cmb_doc.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmb_doc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmb_doc.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmb_doc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmb_doc.ItemHeight = 30
        Me.cmb_doc.Items.AddRange(New Object() {"ALL"})
        Me.cmb_doc.Location = New System.Drawing.Point(705, 129)
        Me.cmb_doc.Name = "cmb_doc"
        Me.cmb_doc.Size = New System.Drawing.Size(195, 36)
        Me.cmb_doc.TabIndex = 393
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(701, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 19)
        Me.Label2.TabIndex = 394
        Me.Label2.Text = "Select Document:"
        '
        'print_prev_ALLREQ
        '
        Me.print_prev_ALLREQ.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.print_prev_ALLREQ.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.print_prev_ALLREQ.ClientSize = New System.Drawing.Size(400, 300)
        Me.print_prev_ALLREQ.Document = Me.print_doc_ALLREQ
        Me.print_prev_ALLREQ.Enabled = True
        Me.print_prev_ALLREQ.Icon = CType(resources.GetObject("print_prev_ALLREQ.Icon"), System.Drawing.Icon)
        Me.print_prev_ALLREQ.Name = "PrintPreviewDialog1"
        Me.print_prev_ALLREQ.Visible = False
        '
        'print_doc_ALLREQ
        '
        '
        'dgv_res_req
        '
        Me.dgv_res_req.AllowUserToAddRows = False
        Me.dgv_res_req.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(183, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgv_res_req.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_res_req.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_res_req.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv_res_req.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgv_res_req.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_res_req.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_res_req.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_res_req.ColumnHeadersHeight = 37
        Me.dgv_res_req.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(207, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(95, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_res_req.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_res_req.EnableHeadersVisualStyles = False
        Me.dgv_res_req.GridColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgv_res_req.Location = New System.Drawing.Point(155, 0)
        Me.dgv_res_req.Name = "dgv_res_req"
        Me.dgv_res_req.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_res_req.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_res_req.RowHeadersVisible = False
        Me.dgv_res_req.RowTemplate.Height = 26
        Me.dgv_res_req.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_res_req.Size = New System.Drawing.Size(831, 780)
        Me.dgv_res_req.TabIndex = 395
        Me.dgv_res_req.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.SunFlower
        Me.dgv_res_req.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dgv_res_req.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_res_req.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Gray
        Me.dgv_res_req.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgv_res_req.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgv_res_req.ThemeStyle.BackColor = System.Drawing.SystemColors.Control
        Me.dgv_res_req.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgv_res_req.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.dgv_res_req.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised
        Me.dgv_res_req.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.dgv_res_req.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgv_res_req.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_res_req.ThemeStyle.HeaderStyle.Height = 37
        Me.dgv_res_req.ThemeStyle.ReadOnly = False
        Me.dgv_res_req.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.dgv_res_req.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv_res_req.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_res_req.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv_res_req.ThemeStyle.RowsStyle.Height = 26
        Me.dgv_res_req.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.dgv_res_req.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgv_res_req.Visible = False
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 577)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_doc)
        Me.Controls.Add(Me.bg_reports)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.Controls.Add(Me.sum_report)
        Me.Controls.Add(Me.res_report)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.dgv_docu)
        Me.Controls.Add(Me.Guna2Separator1)
        Me.Controls.Add(Me.dgv_res_req)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form8"
        Me.Text = "Form8"
        CType(Me.dgv_docu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GroupBox1.ResumeLayout(False)
        Me.Guna2GroupBox1.PerformLayout()
        CType(Me.bg_reports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_res_req, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Guna2AnimateWindow1 As Guna.UI2.WinForms.Guna2AnimateWindow
    Friend WithEvents dgv_docu As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents txtsearch As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents res_report As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents sum_report As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents BtnShow As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtp_to As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents dtp_from As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents print_Doc_report As Printing.PrintDocument
    Friend WithEvents print_preview_report As PrintPreviewDialog
    Friend WithEvents bg_reports As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmb_doc As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents print_prev_ALLREQ As PrintPreviewDialog
    Friend WithEvents print_doc_ALLREQ As Printing.PrintDocument
    Friend WithEvents dgv_res_req As Guna.UI2.WinForms.Guna2DataGridView
End Class
