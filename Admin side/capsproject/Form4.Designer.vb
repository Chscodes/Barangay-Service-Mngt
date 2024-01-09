<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(Me.components)
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.Guna2AnimateWindow1 = New Guna.UI2.WinForms.Guna2AnimateWindow(Me.components)
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.txt_current_pass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_current_uname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblvalUname = New System.Windows.Forms.Label()
        Me.Guna2GradientButton3 = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.txtnewPass2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtnewPass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtuname = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnverify = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2PictureBox2 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.pnlVerifycode = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.Guna2CircleButton1 = New Guna.UI2.WinForms.Guna2CircleButton()
        Me.txtcode6 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtcode5 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtcode4 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtcode3 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtcode2 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtcode1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2GradientButton1 = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2PictureBox3 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.lblsec__ = New System.Windows.Forms.Label()
        Me.btnresend = New System.Windows.Forms.Button()
        Me.time_resend = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVerifycode.SuspendLayout()
        CType(Me.Guna2PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2DragControl1.TargetControl = Me
        Me.Guna2DragControl1.UseTransparentDrag = True
        '
        'Guna2AnimateWindow1
        '
        Me.Guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_SLIDE
        Me.Guna2AnimateWindow1.TargetForm = Me
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2PictureBox1.Image = CType(resources.GetObject("Guna2PictureBox1.Image"), System.Drawing.Image)
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(416, 425)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 1
        Me.Guna2PictureBox1.TabStop = False
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.txt_current_pass)
        Me.Guna2ShadowPanel1.Controls.Add(Me.txt_current_uname)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.lblvalUname)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2GradientButton3)
        Me.Guna2ShadowPanel1.Controls.Add(Me.txtnewPass2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.txtnewPass)
        Me.Guna2ShadowPanel1.Controls.Add(Me.txtuname)
        Me.Guna2ShadowPanel1.Controls.Add(Me.btnverify)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2Separator1)
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(429, 21)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.Guna2ShadowPanel1.ShadowDepth = 90
        Me.Guna2ShadowPanel1.ShadowShift = 3
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(263, 375)
        Me.Guna2ShadowPanel1.TabIndex = 32
        '
        'txt_current_pass
        '
        Me.txt_current_pass.Animated = True
        Me.txt_current_pass.BorderRadius = 8
        Me.txt_current_pass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_current_pass.DefaultText = ""
        Me.txt_current_pass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_current_pass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_current_pass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_current_pass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_current_pass.FillColor = System.Drawing.Color.Gainsboro
        Me.txt_current_pass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_current_pass.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_current_pass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_current_pass.IconLeft = CType(resources.GetObject("txt_current_pass.IconLeft"), System.Drawing.Image)
        Me.txt_current_pass.Location = New System.Drawing.Point(35, 111)
        Me.txt_current_pass.Name = "txt_current_pass"
        Me.txt_current_pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txt_current_pass.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.txt_current_pass.PlaceholderText = "Current Password"
        Me.txt_current_pass.SelectedText = ""
        Me.txt_current_pass.Size = New System.Drawing.Size(205, 32)
        Me.txt_current_pass.TabIndex = 45
        Me.txt_current_pass.UseSystemPasswordChar = True
        '
        'txt_current_uname
        '
        Me.txt_current_uname.Animated = True
        Me.txt_current_uname.BorderRadius = 8
        Me.txt_current_uname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_current_uname.DefaultText = ""
        Me.txt_current_uname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_current_uname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_current_uname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_current_uname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_current_uname.FillColor = System.Drawing.Color.Gainsboro
        Me.txt_current_uname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_current_uname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_current_uname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_current_uname.IconLeft = CType(resources.GetObject("txt_current_uname.IconLeft"), System.Drawing.Image)
        Me.txt_current_uname.Location = New System.Drawing.Point(35, 73)
        Me.txt_current_uname.Name = "txt_current_uname"
        Me.txt_current_uname.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_current_uname.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.txt_current_uname.PlaceholderText = "Current Username"
        Me.txt_current_uname.SelectedText = ""
        Me.txt_current_uname.Size = New System.Drawing.Size(205, 32)
        Me.txt_current_uname.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(3, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 30)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "RESET PASSWORD?"
        '
        'lblvalUname
        '
        Me.lblvalUname.AutoSize = True
        Me.lblvalUname.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvalUname.ForeColor = System.Drawing.Color.Red
        Me.lblvalUname.Location = New System.Drawing.Point(139, 156)
        Me.lblvalUname.Name = "lblvalUname"
        Me.lblvalUname.Size = New System.Drawing.Size(101, 12)
        Me.lblvalUname.TabIndex = 43
        Me.lblvalUname.Text = "Username already taken"
        Me.lblvalUname.Visible = False
        '
        'Guna2GradientButton3
        '
        Me.Guna2GradientButton3.Animated = True
        Me.Guna2GradientButton3.AutoRoundedCorners = True
        Me.Guna2GradientButton3.BorderRadius = 13
        Me.Guna2GradientButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2GradientButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2GradientButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2GradientButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2GradientButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2GradientButton3.FillColor = System.Drawing.Color.Transparent
        Me.Guna2GradientButton3.FillColor2 = System.Drawing.Color.Transparent
        Me.Guna2GradientButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Guna2GradientButton3.ForeColor = System.Drawing.Color.DimGray
        Me.Guna2GradientButton3.HoverState.FillColor = System.Drawing.Color.Transparent
        Me.Guna2GradientButton3.HoverState.FillColor2 = System.Drawing.Color.Transparent
        Me.Guna2GradientButton3.HoverState.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2GradientButton3.HoverState.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.Guna2GradientButton3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Guna2GradientButton3.Location = New System.Drawing.Point(75, 344)
        Me.Guna2GradientButton3.Name = "Guna2GradientButton3"
        Me.Guna2GradientButton3.PressedColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.Guna2GradientButton3.PressedDepth = 50
        Me.Guna2GradientButton3.Size = New System.Drawing.Size(115, 28)
        Me.Guna2GradientButton3.TabIndex = 42
        Me.Guna2GradientButton3.Text = "LOG IN"
        '
        'txtnewPass2
        '
        Me.txtnewPass2.Animated = True
        Me.txtnewPass2.BorderRadius = 8
        Me.txtnewPass2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnewPass2.DefaultText = ""
        Me.txtnewPass2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtnewPass2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtnewPass2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtnewPass2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtnewPass2.FillColor = System.Drawing.Color.Gainsboro
        Me.txtnewPass2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtnewPass2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtnewPass2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtnewPass2.IconLeft = CType(resources.GetObject("txtnewPass2.IconLeft"), System.Drawing.Image)
        Me.txtnewPass2.Location = New System.Drawing.Point(35, 249)
        Me.txtnewPass2.Name = "txtnewPass2"
        Me.txtnewPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtnewPass2.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.txtnewPass2.PlaceholderText = " Re-Type Password"
        Me.txtnewPass2.SelectedText = ""
        Me.txtnewPass2.Size = New System.Drawing.Size(205, 32)
        Me.txtnewPass2.TabIndex = 41
        Me.txtnewPass2.UseSystemPasswordChar = True
        '
        'txtnewPass
        '
        Me.txtnewPass.Animated = True
        Me.txtnewPass.BorderRadius = 8
        Me.txtnewPass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnewPass.DefaultText = ""
        Me.txtnewPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtnewPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtnewPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtnewPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtnewPass.FillColor = System.Drawing.Color.Gainsboro
        Me.txtnewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtnewPass.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtnewPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtnewPass.IconLeft = CType(resources.GetObject("txtnewPass.IconLeft"), System.Drawing.Image)
        Me.txtnewPass.Location = New System.Drawing.Point(35, 211)
        Me.txtnewPass.Name = "txtnewPass"
        Me.txtnewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtnewPass.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.txtnewPass.PlaceholderText = "New Password"
        Me.txtnewPass.SelectedText = ""
        Me.txtnewPass.Size = New System.Drawing.Size(205, 32)
        Me.txtnewPass.TabIndex = 40
        Me.txtnewPass.UseSystemPasswordChar = True
        '
        'txtuname
        '
        Me.txtuname.Animated = True
        Me.txtuname.BorderRadius = 8
        Me.txtuname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtuname.DefaultText = ""
        Me.txtuname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtuname.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtuname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtuname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtuname.FillColor = System.Drawing.Color.Gainsboro
        Me.txtuname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtuname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtuname.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtuname.IconLeft = CType(resources.GetObject("txtuname.IconLeft"), System.Drawing.Image)
        Me.txtuname.Location = New System.Drawing.Point(35, 173)
        Me.txtuname.Name = "txtuname"
        Me.txtuname.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtuname.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.txtuname.PlaceholderText = "New Username"
        Me.txtuname.SelectedText = ""
        Me.txtuname.Size = New System.Drawing.Size(205, 32)
        Me.txtuname.TabIndex = 31
        '
        'btnverify
        '
        Me.btnverify.Animated = True
        Me.btnverify.AutoRoundedCorners = True
        Me.btnverify.BorderRadius = 18
        Me.btnverify.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnverify.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnverify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnverify.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnverify.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnverify.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnverify.FillColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.btnverify.FillColor2 = System.Drawing.Color.OrangeRed
        Me.btnverify.FocusedColor = System.Drawing.Color.White
        Me.btnverify.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnverify.ForeColor = System.Drawing.Color.White
        Me.btnverify.HoverState.FillColor = System.Drawing.Color.OrangeRed
        Me.btnverify.HoverState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.btnverify.HoverState.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnverify.Location = New System.Drawing.Point(35, 300)
        Me.btnverify.Name = "btnverify"
        Me.btnverify.PressedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnverify.Size = New System.Drawing.Size(205, 38)
        Me.btnverify.TabIndex = 33
        Me.btnverify.Text = "Update"
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.Location = New System.Drawing.Point(21, 149)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(230, 20)
        Me.Guna2Separator1.TabIndex = 46
        '
        'Guna2PictureBox2
        '
        Me.Guna2PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox2.Image = CType(resources.GetObject("Guna2PictureBox2.Image"), System.Drawing.Image)
        Me.Guna2PictureBox2.ImageRotate = 0!
        Me.Guna2PictureBox2.Location = New System.Drawing.Point(503, -21)
        Me.Guna2PictureBox2.Name = "Guna2PictureBox2"
        Me.Guna2PictureBox2.Size = New System.Drawing.Size(134, 111)
        Me.Guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox2.TabIndex = 33
        Me.Guna2PictureBox2.TabStop = False
        Me.Guna2PictureBox2.UseTransparentBackground = True
        '
        'pnlVerifycode
        '
        Me.pnlVerifycode.BackColor = System.Drawing.Color.Transparent
        Me.pnlVerifycode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlVerifycode.Controls.Add(Me.lblsec__)
        Me.pnlVerifycode.Controls.Add(Me.btnresend)
        Me.pnlVerifycode.Controls.Add(Me.Guna2CircleButton1)
        Me.pnlVerifycode.Controls.Add(Me.txtcode6)
        Me.pnlVerifycode.Controls.Add(Me.txtcode5)
        Me.pnlVerifycode.Controls.Add(Me.txtcode4)
        Me.pnlVerifycode.Controls.Add(Me.txtcode3)
        Me.pnlVerifycode.Controls.Add(Me.txtcode2)
        Me.pnlVerifycode.Controls.Add(Me.txtcode1)
        Me.pnlVerifycode.Controls.Add(Me.Guna2GradientButton1)
        Me.pnlVerifycode.Controls.Add(Me.Label3)
        Me.pnlVerifycode.Controls.Add(Me.Label2)
        Me.pnlVerifycode.Controls.Add(Me.Guna2PictureBox3)
        Me.pnlVerifycode.FillColor = System.Drawing.Color.White
        Me.pnlVerifycode.Location = New System.Drawing.Point(183, 109)
        Me.pnlVerifycode.Name = "pnlVerifycode"
        Me.pnlVerifycode.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.pnlVerifycode.ShadowDepth = 80
        Me.pnlVerifycode.Size = New System.Drawing.Size(352, 228)
        Me.pnlVerifycode.TabIndex = 36
        Me.pnlVerifycode.Visible = False
        '
        'Guna2CircleButton1
        '
        Me.Guna2CircleButton1.Animated = True
        Me.Guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2CircleButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2CircleButton1.ForeColor = System.Drawing.Color.White
        Me.Guna2CircleButton1.IndicateFocus = True
        Me.Guna2CircleButton1.Location = New System.Drawing.Point(3, 6)
        Me.Guna2CircleButton1.Name = "Guna2CircleButton1"
        Me.Guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CircleButton1.Size = New System.Drawing.Size(30, 34)
        Me.Guna2CircleButton1.TabIndex = 58
        Me.Guna2CircleButton1.Text = "X"
        Me.Guna2CircleButton1.UseTransparentBackground = True
        '
        'txtcode6
        '
        Me.txtcode6.Animated = True
        Me.txtcode6.AutoRoundedCorners = True
        Me.txtcode6.BorderRadius = 15
        Me.txtcode6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcode6.DefaultText = ""
        Me.txtcode6.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtcode6.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtcode6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode6.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode6.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtcode6.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode6.Location = New System.Drawing.Point(255, 97)
        Me.txtcode6.MaxLength = 1
        Me.txtcode6.Name = "txtcode6"
        Me.txtcode6.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtcode6.PlaceholderText = ""
        Me.txtcode6.SelectedText = ""
        Me.txtcode6.Size = New System.Drawing.Size(33, 43)
        Me.txtcode6.TabIndex = 57
        Me.txtcode6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcode5
        '
        Me.txtcode5.Animated = True
        Me.txtcode5.AutoRoundedCorners = True
        Me.txtcode5.BorderRadius = 15
        Me.txtcode5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcode5.DefaultText = ""
        Me.txtcode5.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtcode5.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtcode5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode5.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode5.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtcode5.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode5.Location = New System.Drawing.Point(216, 97)
        Me.txtcode5.MaxLength = 1
        Me.txtcode5.Name = "txtcode5"
        Me.txtcode5.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtcode5.PlaceholderText = ""
        Me.txtcode5.SelectedText = ""
        Me.txtcode5.Size = New System.Drawing.Size(33, 43)
        Me.txtcode5.TabIndex = 56
        Me.txtcode5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcode4
        '
        Me.txtcode4.Animated = True
        Me.txtcode4.AutoRoundedCorners = True
        Me.txtcode4.BorderRadius = 15
        Me.txtcode4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcode4.DefaultText = ""
        Me.txtcode4.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtcode4.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtcode4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode4.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode4.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtcode4.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode4.Location = New System.Drawing.Point(177, 97)
        Me.txtcode4.MaxLength = 1
        Me.txtcode4.Name = "txtcode4"
        Me.txtcode4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtcode4.PlaceholderText = ""
        Me.txtcode4.SelectedText = ""
        Me.txtcode4.Size = New System.Drawing.Size(33, 43)
        Me.txtcode4.TabIndex = 55
        Me.txtcode4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcode3
        '
        Me.txtcode3.Animated = True
        Me.txtcode3.AutoRoundedCorners = True
        Me.txtcode3.BorderRadius = 15
        Me.txtcode3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcode3.DefaultText = ""
        Me.txtcode3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtcode3.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtcode3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtcode3.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode3.Location = New System.Drawing.Point(138, 97)
        Me.txtcode3.MaxLength = 1
        Me.txtcode3.Name = "txtcode3"
        Me.txtcode3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtcode3.PlaceholderText = ""
        Me.txtcode3.SelectedText = ""
        Me.txtcode3.Size = New System.Drawing.Size(33, 43)
        Me.txtcode3.TabIndex = 54
        Me.txtcode3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcode2
        '
        Me.txtcode2.Animated = True
        Me.txtcode2.AutoRoundedCorners = True
        Me.txtcode2.BorderRadius = 15
        Me.txtcode2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcode2.DefaultText = ""
        Me.txtcode2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtcode2.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtcode2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtcode2.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode2.Location = New System.Drawing.Point(99, 97)
        Me.txtcode2.MaxLength = 1
        Me.txtcode2.Name = "txtcode2"
        Me.txtcode2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtcode2.PlaceholderText = ""
        Me.txtcode2.SelectedText = ""
        Me.txtcode2.Size = New System.Drawing.Size(33, 43)
        Me.txtcode2.TabIndex = 53
        Me.txtcode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcode1
        '
        Me.txtcode1.Animated = True
        Me.txtcode1.AutoRoundedCorners = True
        Me.txtcode1.BorderRadius = 15
        Me.txtcode1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcode1.DefaultText = ""
        Me.txtcode1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtcode1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtcode1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtcode1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtcode1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtcode1.Location = New System.Drawing.Point(60, 97)
        Me.txtcode1.MaxLength = 1
        Me.txtcode1.Name = "txtcode1"
        Me.txtcode1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtcode1.PlaceholderText = ""
        Me.txtcode1.SelectedText = ""
        Me.txtcode1.Size = New System.Drawing.Size(33, 43)
        Me.txtcode1.TabIndex = 52
        Me.txtcode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2GradientButton1
        '
        Me.Guna2GradientButton1.Animated = True
        Me.Guna2GradientButton1.AutoRoundedCorners = True
        Me.Guna2GradientButton1.BorderRadius = 13
        Me.Guna2GradientButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.Guna2GradientButton1.FillColor2 = System.Drawing.Color.OrangeRed
        Me.Guna2GradientButton1.FocusedColor = System.Drawing.Color.White
        Me.Guna2GradientButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Guna2GradientButton1.ForeColor = System.Drawing.Color.White
        Me.Guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.OrangeRed
        Me.Guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.Guna2GradientButton1.HoverState.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2GradientButton1.Location = New System.Drawing.Point(68, 185)
        Me.Guna2GradientButton1.Name = "Guna2GradientButton1"
        Me.Guna2GradientButton1.PressedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2GradientButton1.Size = New System.Drawing.Size(205, 28)
        Me.Guna2GradientButton1.TabIndex = 44
        Me.Guna2GradientButton1.Text = "Confirm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(57, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 12)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Please enter the code that you received on your email."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(85, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 30)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Verification Code"
        '
        'Guna2PictureBox3
        '
        Me.Guna2PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox3.Image = CType(resources.GetObject("Guna2PictureBox3.Image"), System.Drawing.Image)
        Me.Guna2PictureBox3.ImageRotate = 0!
        Me.Guna2PictureBox3.Location = New System.Drawing.Point(142, 49)
        Me.Guna2PictureBox3.Name = "Guna2PictureBox3"
        Me.Guna2PictureBox3.Size = New System.Drawing.Size(51, 43)
        Me.Guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox3.TabIndex = 45
        Me.Guna2PictureBox3.TabStop = False
        Me.Guna2PictureBox3.UseTransparentBackground = True
        '
        'lblsec__
        '
        Me.lblsec__.AutoSize = True
        Me.lblsec__.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsec__.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblsec__.Location = New System.Drawing.Point(155, 164)
        Me.lblsec__.Name = "lblsec__"
        Me.lblsec__.Size = New System.Drawing.Size(13, 16)
        Me.lblsec__.TabIndex = 122
        Me.lblsec__.Text = "0"
        Me.lblsec__.Visible = False
        '
        'btnresend
        '
        Me.btnresend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnresend.FlatAppearance.BorderSize = 0
        Me.btnresend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnresend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnresend.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnresend.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnresend.Image = CType(resources.GetObject("btnresend.Image"), System.Drawing.Image)
        Me.btnresend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnresend.Location = New System.Drawing.Point(125, 145)
        Me.btnresend.Name = "btnresend"
        Me.btnresend.Size = New System.Drawing.Size(85, 21)
        Me.btnresend.TabIndex = 121
        Me.btnresend.Text = "Resend Code"
        Me.btnresend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnresend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnresend.UseVisualStyleBackColor = True
        '
        'time_resend
        '
        Me.time_resend.Interval = 1000
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(719, 425)
        Me.Controls.Add(Me.pnlVerifycode)
        Me.Controls.Add(Me.Guna2PictureBox2)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.Controls.Add(Me.Guna2PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form4"
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVerifycode.ResumeLayout(False)
        Me.pnlVerifycode.PerformLayout()
        CType(Me.Guna2PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents Guna2AnimateWindow1 As Guna.UI2.WinForms.Guna2AnimateWindow
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2PictureBox2 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtuname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnverify As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents txtnewPass2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtnewPass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2GradientButton3 As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents lblvalUname As Label
    Friend WithEvents pnlVerifycode As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Guna2PictureBox3 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2GradientButton1 As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcode6 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtcode5 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtcode4 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtcode3 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtcode2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtcode1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txt_current_pass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txt_current_uname As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2CircleButton1 As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents lblsec__ As Label
    Friend WithEvents btnresend As Button
    Friend WithEvents time_resend As Timer
End Class
