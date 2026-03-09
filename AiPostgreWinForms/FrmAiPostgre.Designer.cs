namespace AiPostgreWinForms
{
    partial class FrmAiPostgre
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAiPostgre));
            btn_keysettings = new Button();
            btn_showquery = new Button();
            btn_send = new Button();
            tb_userrequest = new TextBox();
            tb_aiquery = new TextBox();
            dgv_airesult = new DataGridView();
            lbl_title = new Label();
            btn_dbsettings = new Button();
            pcbx_icon = new PictureBox();
            il_showimages = new ImageList(components);
            gb_key = new GroupBox();
            gb_LLM = new GroupBox();
            lblLlmModel = new Label();
            txtLlmModel = new TextBox();
            lblLLM = new Label();
            txt_LlmUrl = new TextBox();
            gb_Gemini = new GroupBox();
            lbl_key = new Label();
            tx_apikey = new TextBox();
            ckbx_remember = new CheckBox();
            ckbx_showApi = new CheckBox();
            rdbtn_LLM = new RadioButton();
            rdbtn_Gemini = new RadioButton();
            btn_keyback = new Button();
            btn_saveapi = new Button();
            gb_database = new GroupBox();
            btn_dbback = new Button();
            lbl_validatedb = new Label();
            chbx_dbpass = new CheckBox();
            btn_savedb = new Button();
            txt_pass = new TextBox();
            lbl_pass = new Label();
            txt_user = new TextBox();
            lbl_user = new Label();
            txt_db = new TextBox();
            lbl_db = new Label();
            tx_ip = new TextBox();
            lbl_ip = new Label();
            tt_hover = new ToolTip(components);
            Btn_Copy = new Button();
            btn_mapdb = new Button();
            btn_tweak = new Button();
            btn_deletemap = new Button();
            btn_selectmap = new Button();
            btn_map = new Button();
            btn_backmap = new Button();
            gb_loading = new GroupBox();
            pb_loading = new ProgressBar();
            lbl_loadstatus = new Label();
            pcbx_loadinggif = new PictureBox();
            gb_map = new GroupBox();
            lbl_mapprogress = new Label();
            lv_maps = new ListView();
            pcbx_background = new PictureBox();
            il_selectimages = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)dgv_airesult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbx_icon).BeginInit();
            gb_key.SuspendLayout();
            gb_LLM.SuspendLayout();
            gb_Gemini.SuspendLayout();
            gb_database.SuspendLayout();
            gb_loading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbx_loadinggif).BeginInit();
            gb_map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbx_background).BeginInit();
            SuspendLayout();
            // 
            // btn_keysettings
            // 
            btn_keysettings.BackgroundImage = (Image)resources.GetObject("btn_keysettings.BackgroundImage");
            btn_keysettings.BackgroundImageLayout = ImageLayout.Zoom;
            btn_keysettings.FlatAppearance.BorderSize = 0;
            btn_keysettings.FlatStyle = FlatStyle.Flat;
            btn_keysettings.Location = new Point(547, 67);
            btn_keysettings.Name = "btn_keysettings";
            btn_keysettings.Size = new Size(50, 50);
            btn_keysettings.TabIndex = 2;
            tt_hover.SetToolTip(btn_keysettings, "AI Settings");
            btn_keysettings.UseVisualStyleBackColor = true;
            btn_keysettings.Click += btn_keysettings_Click;
            // 
            // btn_showquery
            // 
            btn_showquery.BackgroundImage = (Image)resources.GetObject("btn_showquery.BackgroundImage");
            btn_showquery.BackgroundImageLayout = ImageLayout.Zoom;
            btn_showquery.FlatAppearance.BorderSize = 0;
            btn_showquery.FlatStyle = FlatStyle.Flat;
            btn_showquery.Location = new Point(547, 123);
            btn_showquery.Name = "btn_showquery";
            btn_showquery.Size = new Size(50, 50);
            btn_showquery.TabIndex = 3;
            tt_hover.SetToolTip(btn_showquery, "Show the generated query");
            btn_showquery.UseVisualStyleBackColor = true;
            btn_showquery.Click += btn_showquery_Click;
            // 
            // btn_send
            // 
            btn_send.BackgroundImage = (Image)resources.GetObject("btn_send.BackgroundImage");
            btn_send.BackgroundImageLayout = ImageLayout.Zoom;
            btn_send.Location = new Point(492, 334);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(50, 23);
            btn_send.TabIndex = 4;
            tt_hover.SetToolTip(btn_send, "Send Request");
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // tb_userrequest
            // 
            tb_userrequest.ForeColor = Color.Gray;
            tb_userrequest.Location = new Point(12, 336);
            tb_userrequest.Name = "tb_userrequest";
            tb_userrequest.Size = new Size(474, 23);
            tb_userrequest.TabIndex = 5;
            tb_userrequest.Text = "Request...";
            tb_userrequest.Enter += tb_userrequest_Enter;
            tb_userrequest.KeyDown += tb_userrequest_KeyDown;
            tb_userrequest.Leave += tb_userrequest_Leave;
            // 
            // tb_aiquery
            // 
            tb_aiquery.Location = new Point(12, 307);
            tb_aiquery.Name = "tb_aiquery";
            tb_aiquery.Size = new Size(446, 23);
            tb_aiquery.TabIndex = 6;
            tb_aiquery.Visible = false;
            tb_aiquery.KeyDown += tb_aiquery_KeyDown;
            // 
            // dgv_airesult
            // 
            dgv_airesult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_airesult.Location = new Point(12, 51);
            dgv_airesult.Name = "dgv_airesult";
            dgv_airesult.RowHeadersWidth = 62;
            dgv_airesult.Size = new Size(530, 250);
            dgv_airesult.TabIndex = 7;
            dgv_airesult.CellMouseDown += dgv_airesult_CellMouseDown;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Arial", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_title.Location = new Point(230, 15);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(147, 28);
            lbl_title.TabIndex = 9;
            lbl_title.Text = "LangToSQL";
            // 
            // btn_dbsettings
            // 
            btn_dbsettings.BackgroundImage = (Image)resources.GetObject("btn_dbsettings.BackgroundImage");
            btn_dbsettings.BackgroundImageLayout = ImageLayout.Zoom;
            btn_dbsettings.FlatAppearance.BorderSize = 0;
            btn_dbsettings.FlatStyle = FlatStyle.Flat;
            btn_dbsettings.Location = new Point(547, 179);
            btn_dbsettings.Name = "btn_dbsettings";
            btn_dbsettings.Size = new Size(50, 50);
            btn_dbsettings.TabIndex = 11;
            tt_hover.SetToolTip(btn_dbsettings, "Postgre's Server Settings");
            btn_dbsettings.UseVisualStyleBackColor = true;
            btn_dbsettings.Click += btn_dbsettings_Click;
            // 
            // pcbx_icon
            // 
            pcbx_icon.Image = (Image)resources.GetObject("pcbx_icon.Image");
            pcbx_icon.Location = new Point(191, 1);
            pcbx_icon.Name = "pcbx_icon";
            pcbx_icon.Size = new Size(43, 47);
            pcbx_icon.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbx_icon.TabIndex = 14;
            pcbx_icon.TabStop = false;
            // 
            // il_showimages
            // 
            il_showimages.ColorDepth = ColorDepth.Depth32Bit;
            il_showimages.ImageStream = (ImageListStreamer)resources.GetObject("il_showimages.ImageStream");
            il_showimages.TransparentColor = Color.Transparent;
            il_showimages.Images.SetKeyName(0, "show.png");
            il_showimages.Images.SetKeyName(1, "hide.png");
            il_showimages.Images.SetKeyName(2, "select.png");
            il_showimages.Images.SetKeyName(3, "unselect.png");
            // 
            // gb_key
            // 
            gb_key.Controls.Add(gb_LLM);
            gb_key.Controls.Add(gb_Gemini);
            gb_key.Controls.Add(rdbtn_LLM);
            gb_key.Controls.Add(rdbtn_Gemini);
            gb_key.Controls.Add(btn_keyback);
            gb_key.Controls.Add(btn_saveapi);
            gb_key.Location = new Point(138, 27);
            gb_key.Name = "gb_key";
            gb_key.Size = new Size(338, 330);
            gb_key.TabIndex = 15;
            gb_key.TabStop = false;
            gb_key.Text = "AI Settings";
            gb_key.Visible = false;
            // 
            // gb_LLM
            // 
            gb_LLM.Controls.Add(lblLlmModel);
            gb_LLM.Controls.Add(txtLlmModel);
            gb_LLM.Controls.Add(lblLLM);
            gb_LLM.Controls.Add(txt_LlmUrl);
            gb_LLM.Enabled = false;
            gb_LLM.Location = new Point(6, 162);
            gb_LLM.Name = "gb_LLM";
            gb_LLM.Size = new Size(326, 122);
            gb_LLM.TabIndex = 12;
            gb_LLM.TabStop = false;
            // 
            // lblLlmModel
            // 
            lblLlmModel.AutoSize = true;
            lblLlmModel.Location = new Point(6, 64);
            lblLlmModel.Name = "lblLlmModel";
            lblLlmModel.Size = new Size(77, 15);
            lblLlmModel.TabIndex = 11;
            lblLlmModel.Text = "Model name:";
            // 
            // txtLlmModel
            // 
            txtLlmModel.Location = new Point(9, 84);
            txtLlmModel.Name = "txtLlmModel";
            txtLlmModel.Size = new Size(311, 23);
            txtLlmModel.TabIndex = 12;
            // 
            // lblLLM
            // 
            lblLLM.AutoSize = true;
            lblLLM.Location = new Point(6, 16);
            lblLLM.Name = "lblLLM";
            lblLLM.Size = new Size(92, 15);
            lblLLM.TabIndex = 9;
            lblLLM.Text = "LLM Server URL:";
            // 
            // txt_LlmUrl
            // 
            txt_LlmUrl.Location = new Point(9, 34);
            txt_LlmUrl.Name = "txt_LlmUrl";
            txt_LlmUrl.Size = new Size(311, 23);
            txt_LlmUrl.TabIndex = 10;
            // 
            // gb_Gemini
            // 
            gb_Gemini.Controls.Add(lbl_key);
            gb_Gemini.Controls.Add(tx_apikey);
            gb_Gemini.Controls.Add(ckbx_remember);
            gb_Gemini.Controls.Add(ckbx_showApi);
            gb_Gemini.Location = new Point(6, 37);
            gb_Gemini.Name = "gb_Gemini";
            gb_Gemini.Size = new Size(326, 94);
            gb_Gemini.TabIndex = 11;
            gb_Gemini.TabStop = false;
            // 
            // lbl_key
            // 
            lbl_key.AutoSize = true;
            lbl_key.Location = new Point(6, 16);
            lbl_key.Name = "lbl_key";
            lbl_key.Size = new Size(98, 15);
            lbl_key.TabIndex = 2;
            lbl_key.Text = "Gemini's API key:";
            // 
            // tx_apikey
            // 
            tx_apikey.Location = new Point(9, 34);
            tx_apikey.Name = "tx_apikey";
            tx_apikey.PasswordChar = '*';
            tx_apikey.Size = new Size(311, 23);
            tx_apikey.TabIndex = 0;
            // 
            // ckbx_remember
            // 
            ckbx_remember.AutoSize = true;
            ckbx_remember.Location = new Point(9, 66);
            ckbx_remember.Name = "ckbx_remember";
            ckbx_remember.Size = new Size(147, 19);
            ckbx_remember.TabIndex = 3;
            ckbx_remember.Text = "Remember the API Key";
            tt_hover.SetToolTip(ckbx_remember, "The API Key will be stored and loaded at the start");
            ckbx_remember.UseVisualStyleBackColor = true;
            ckbx_remember.Click += ckbx_remember_CheckedChanged;
            // 
            // ckbx_showApi
            // 
            ckbx_showApi.AutoSize = true;
            ckbx_showApi.Location = new Point(222, 65);
            ckbx_showApi.Name = "ckbx_showApi";
            ckbx_showApi.Size = new Size(98, 19);
            ckbx_showApi.TabIndex = 4;
            ckbx_showApi.Text = "Show API Key";
            ckbx_showApi.UseVisualStyleBackColor = true;
            ckbx_showApi.Click += ckbx_showApi_Click;
            // 
            // rdbtn_LLM
            // 
            rdbtn_LLM.AutoSize = true;
            rdbtn_LLM.Location = new Point(6, 137);
            rdbtn_LLM.Name = "rdbtn_LLM";
            rdbtn_LLM.Size = new Size(70, 19);
            rdbtn_LLM.TabIndex = 8;
            rdbtn_LLM.Text = "Use LLM";
            rdbtn_LLM.UseVisualStyleBackColor = true;
            // 
            // rdbtn_Gemini
            // 
            rdbtn_Gemini.AutoSize = true;
            rdbtn_Gemini.Checked = true;
            rdbtn_Gemini.Location = new Point(6, 16);
            rdbtn_Gemini.Name = "rdbtn_Gemini";
            rdbtn_Gemini.Size = new Size(106, 19);
            rdbtn_Gemini.TabIndex = 7;
            rdbtn_Gemini.TabStop = true;
            rdbtn_Gemini.Text = "Use Gemini API";
            rdbtn_Gemini.UseVisualStyleBackColor = true;
            rdbtn_Gemini.CheckedChanged += rdbtn_Gemini_CheckedChanged;
            // 
            // btn_keyback
            // 
            btn_keyback.BackgroundImage = (Image)resources.GetObject("btn_keyback.BackgroundImage");
            btn_keyback.BackgroundImageLayout = ImageLayout.Zoom;
            btn_keyback.Location = new Point(12, 302);
            btn_keyback.Margin = new Padding(2);
            btn_keyback.Name = "btn_keyback";
            btn_keyback.Size = new Size(50, 23);
            btn_keyback.TabIndex = 6;
            tt_hover.SetToolTip(btn_keyback, "Back");
            btn_keyback.UseVisualStyleBackColor = true;
            btn_keyback.Click += btn_keyback_Click;
            // 
            // btn_saveapi
            // 
            btn_saveapi.BackgroundImage = (Image)resources.GetObject("btn_saveapi.BackgroundImage");
            btn_saveapi.BackgroundImageLayout = ImageLayout.Zoom;
            btn_saveapi.Location = new Point(268, 301);
            btn_saveapi.Name = "btn_saveapi";
            btn_saveapi.Size = new Size(50, 23);
            btn_saveapi.TabIndex = 5;
            tt_hover.SetToolTip(btn_saveapi, "Save");
            btn_saveapi.UseVisualStyleBackColor = true;
            btn_saveapi.Click += btn_saveapi_Click;
            // 
            // gb_database
            // 
            gb_database.Controls.Add(btn_dbback);
            gb_database.Controls.Add(lbl_validatedb);
            gb_database.Controls.Add(chbx_dbpass);
            gb_database.Controls.Add(btn_savedb);
            gb_database.Controls.Add(txt_pass);
            gb_database.Controls.Add(lbl_pass);
            gb_database.Controls.Add(txt_user);
            gb_database.Controls.Add(lbl_user);
            gb_database.Controls.Add(txt_db);
            gb_database.Controls.Add(lbl_db);
            gb_database.Controls.Add(tx_ip);
            gb_database.Controls.Add(lbl_ip);
            gb_database.Location = new Point(196, 54);
            gb_database.Name = "gb_database";
            gb_database.Size = new Size(225, 244);
            gb_database.TabIndex = 16;
            gb_database.TabStop = false;
            gb_database.Text = "Postgre's Server Settings";
            gb_database.Visible = false;
            // 
            // btn_dbback
            // 
            btn_dbback.BackgroundImage = (Image)resources.GetObject("btn_dbback.BackgroundImage");
            btn_dbback.BackgroundImageLayout = ImageLayout.Zoom;
            btn_dbback.Location = new Point(15, 206);
            btn_dbback.Name = "btn_dbback";
            btn_dbback.Size = new Size(55, 23);
            btn_dbback.TabIndex = 11;
            tt_hover.SetToolTip(btn_dbback, "Back");
            btn_dbback.UseVisualStyleBackColor = true;
            btn_dbback.Click += btn_dbback_Click;
            // 
            // lbl_validatedb
            // 
            lbl_validatedb.AutoSize = true;
            lbl_validatedb.ForeColor = Color.Red;
            lbl_validatedb.Location = new Point(6, 226);
            lbl_validatedb.Margin = new Padding(2, 0, 2, 0);
            lbl_validatedb.Name = "lbl_validatedb";
            lbl_validatedb.Size = new Size(0, 15);
            lbl_validatedb.TabIndex = 10;
            // 
            // chbx_dbpass
            // 
            chbx_dbpass.AutoSize = true;
            chbx_dbpass.Location = new Point(141, 172);
            chbx_dbpass.Margin = new Padding(2);
            chbx_dbpass.Name = "chbx_dbpass";
            chbx_dbpass.Size = new Size(55, 19);
            chbx_dbpass.TabIndex = 9;
            chbx_dbpass.Text = "Show";
            chbx_dbpass.UseVisualStyleBackColor = true;
            chbx_dbpass.Click += chbx_dbpass_Click;
            // 
            // btn_savedb
            // 
            btn_savedb.BackgroundImage = (Image)resources.GetObject("btn_savedb.BackgroundImage");
            btn_savedb.BackgroundImageLayout = ImageLayout.Zoom;
            btn_savedb.Location = new Point(153, 206);
            btn_savedb.Name = "btn_savedb";
            btn_savedb.Size = new Size(54, 23);
            btn_savedb.TabIndex = 8;
            tt_hover.SetToolTip(btn_savedb, "Save");
            btn_savedb.UseVisualStyleBackColor = true;
            btn_savedb.Click += btn_savedb_Click;
            // 
            // txt_pass
            // 
            txt_pass.Location = new Point(6, 169);
            txt_pass.Name = "txt_pass";
            txt_pass.PasswordChar = '*';
            txt_pass.Size = new Size(131, 23);
            txt_pass.TabIndex = 7;
            // 
            // lbl_pass
            // 
            lbl_pass.AutoSize = true;
            lbl_pass.Location = new Point(6, 151);
            lbl_pass.Name = "lbl_pass";
            lbl_pass.Size = new Size(60, 15);
            lbl_pass.TabIndex = 6;
            lbl_pass.Text = "Password:";
            // 
            // txt_user
            // 
            txt_user.Location = new Point(6, 125);
            txt_user.Name = "txt_user";
            txt_user.Size = new Size(131, 23);
            txt_user.TabIndex = 5;
            // 
            // lbl_user
            // 
            lbl_user.AutoSize = true;
            lbl_user.Location = new Point(6, 107);
            lbl_user.Name = "lbl_user";
            lbl_user.Size = new Size(33, 15);
            lbl_user.TabIndex = 4;
            lbl_user.Text = "User:";
            // 
            // txt_db
            // 
            txt_db.Location = new Point(6, 81);
            txt_db.Name = "txt_db";
            txt_db.Size = new Size(202, 23);
            txt_db.TabIndex = 3;
            // 
            // lbl_db
            // 
            lbl_db.AutoSize = true;
            lbl_db.Location = new Point(6, 63);
            lbl_db.Name = "lbl_db";
            lbl_db.Size = new Size(58, 15);
            lbl_db.TabIndex = 2;
            lbl_db.Text = "Database:";
            // 
            // tx_ip
            // 
            tx_ip.Location = new Point(6, 37);
            tx_ip.Name = "tx_ip";
            tx_ip.Size = new Size(202, 23);
            tx_ip.TabIndex = 1;
            // 
            // lbl_ip
            // 
            lbl_ip.AutoSize = true;
            lbl_ip.Location = new Point(6, 19);
            lbl_ip.Name = "lbl_ip";
            lbl_ip.Size = new Size(65, 15);
            lbl_ip.TabIndex = 0;
            lbl_ip.Text = "IP Address:";
            // 
            // Btn_Copy
            // 
            Btn_Copy.BackgroundImage = (Image)resources.GetObject("Btn_Copy.BackgroundImage");
            Btn_Copy.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_Copy.Location = new Point(462, 305);
            Btn_Copy.Name = "Btn_Copy";
            Btn_Copy.Size = new Size(24, 23);
            Btn_Copy.TabIndex = 19;
            tt_hover.SetToolTip(Btn_Copy, "Copy the generated query");
            Btn_Copy.UseVisualStyleBackColor = true;
            Btn_Copy.Visible = false;
            Btn_Copy.Click += Btn_Copy_Click;
            // 
            // btn_mapdb
            // 
            btn_mapdb.BackgroundImage = (Image)resources.GetObject("btn_mapdb.BackgroundImage");
            btn_mapdb.BackgroundImageLayout = ImageLayout.Zoom;
            btn_mapdb.FlatAppearance.BorderSize = 0;
            btn_mapdb.FlatStyle = FlatStyle.Flat;
            btn_mapdb.Location = new Point(547, 235);
            btn_mapdb.Name = "btn_mapdb";
            btn_mapdb.Size = new Size(50, 50);
            btn_mapdb.TabIndex = 20;
            tt_hover.SetToolTip(btn_mapdb, "Mapped Databases");
            btn_mapdb.UseVisualStyleBackColor = true;
            btn_mapdb.Click += btn_mapdb_Click;
            // 
            // btn_tweak
            // 
            btn_tweak.BackgroundImage = (Image)resources.GetObject("btn_tweak.BackgroundImage");
            btn_tweak.BackgroundImageLayout = ImageLayout.Zoom;
            btn_tweak.Location = new Point(492, 305);
            btn_tweak.Name = "btn_tweak";
            btn_tweak.Size = new Size(50, 23);
            btn_tweak.TabIndex = 17;
            tt_hover.SetToolTip(btn_tweak, "Run in Server");
            btn_tweak.UseVisualStyleBackColor = true;
            btn_tweak.Visible = false;
            btn_tweak.Click += btn_tweak_Click;
            // 
            // btn_deletemap
            // 
            btn_deletemap.BackgroundImage = (Image)resources.GetObject("btn_deletemap.BackgroundImage");
            btn_deletemap.BackgroundImageLayout = ImageLayout.Zoom;
            btn_deletemap.Location = new Point(304, 103);
            btn_deletemap.Margin = new Padding(2);
            btn_deletemap.Name = "btn_deletemap";
            btn_deletemap.Size = new Size(35, 30);
            btn_deletemap.TabIndex = 5;
            tt_hover.SetToolTip(btn_deletemap, "Delete Map");
            btn_deletemap.UseVisualStyleBackColor = true;
            btn_deletemap.Click += btn_deletemap_Click;
            // 
            // btn_selectmap
            // 
            btn_selectmap.BackgroundImage = (Image)resources.GetObject("btn_selectmap.BackgroundImage");
            btn_selectmap.BackgroundImageLayout = ImageLayout.Zoom;
            btn_selectmap.Location = new Point(304, 68);
            btn_selectmap.Margin = new Padding(2);
            btn_selectmap.Name = "btn_selectmap";
            btn_selectmap.Size = new Size(35, 30);
            btn_selectmap.TabIndex = 3;
            tt_hover.SetToolTip(btn_selectmap, "Select Map");
            btn_selectmap.UseVisualStyleBackColor = true;
            btn_selectmap.Click += btn_selectmap_Click;
            // 
            // btn_map
            // 
            btn_map.BackgroundImage = (Image)resources.GetObject("btn_map.BackgroundImage");
            btn_map.BackgroundImageLayout = ImageLayout.Zoom;
            btn_map.Location = new Point(304, 33);
            btn_map.Margin = new Padding(2);
            btn_map.Name = "btn_map";
            btn_map.Size = new Size(35, 30);
            btn_map.TabIndex = 2;
            tt_hover.SetToolTip(btn_map, "Map current database");
            btn_map.UseVisualStyleBackColor = true;
            btn_map.Click += btn_map_Click;
            // 
            // btn_backmap
            // 
            btn_backmap.BackgroundImage = (Image)resources.GetObject("btn_backmap.BackgroundImage");
            btn_backmap.BackgroundImageLayout = ImageLayout.Zoom;
            btn_backmap.Location = new Point(10, 149);
            btn_backmap.Margin = new Padding(2);
            btn_backmap.Name = "btn_backmap";
            btn_backmap.Size = new Size(56, 20);
            btn_backmap.TabIndex = 0;
            tt_hover.SetToolTip(btn_backmap, "Back");
            btn_backmap.UseVisualStyleBackColor = true;
            btn_backmap.Click += btn_backmap_Click;
            // 
            // gb_loading
            // 
            gb_loading.BackColor = Color.White;
            gb_loading.Controls.Add(pb_loading);
            gb_loading.Controls.Add(lbl_loadstatus);
            gb_loading.Controls.Add(pcbx_loadinggif);
            gb_loading.Location = new Point(0, 0);
            gb_loading.Margin = new Padding(2);
            gb_loading.Name = "gb_loading";
            gb_loading.Padding = new Padding(2);
            gb_loading.Size = new Size(1, 1);
            gb_loading.TabIndex = 18;
            gb_loading.TabStop = false;
            gb_loading.Text = "Loading";
            gb_loading.Visible = false;
            // 
            // pb_loading
            // 
            pb_loading.Location = new Point(0, 375);
            pb_loading.Margin = new Padding(2);
            pb_loading.Name = "pb_loading";
            pb_loading.Size = new Size(617, 18);
            pb_loading.TabIndex = 2;
            // 
            // lbl_loadstatus
            // 
            lbl_loadstatus.AutoSize = true;
            lbl_loadstatus.ForeColor = SystemColors.ControlText;
            lbl_loadstatus.Location = new Point(14, 348);
            lbl_loadstatus.Margin = new Padding(2, 0, 2, 0);
            lbl_loadstatus.Name = "lbl_loadstatus";
            lbl_loadstatus.Size = new Size(59, 15);
            lbl_loadstatus.TabIndex = 1;
            lbl_loadstatus.Text = "Loading...";
            // 
            // pcbx_loadinggif
            // 
            pcbx_loadinggif.BackgroundImageLayout = ImageLayout.Stretch;
            pcbx_loadinggif.Dock = DockStyle.Fill;
            pcbx_loadinggif.Image = (Image)resources.GetObject("pcbx_loadinggif.Image");
            pcbx_loadinggif.Location = new Point(2, 18);
            pcbx_loadinggif.Margin = new Padding(2);
            pcbx_loadinggif.Name = "pcbx_loadinggif";
            pcbx_loadinggif.Size = new Size(0, 0);
            pcbx_loadinggif.SizeMode = PictureBoxSizeMode.Zoom;
            pcbx_loadinggif.TabIndex = 0;
            pcbx_loadinggif.TabStop = false;
            // 
            // gb_map
            // 
            gb_map.Controls.Add(lbl_mapprogress);
            gb_map.Controls.Add(btn_deletemap);
            gb_map.Controls.Add(btn_selectmap);
            gb_map.Controls.Add(btn_map);
            gb_map.Controls.Add(lv_maps);
            gb_map.Controls.Add(btn_backmap);
            gb_map.Location = new Point(136, 90);
            gb_map.Margin = new Padding(2);
            gb_map.Name = "gb_map";
            gb_map.Padding = new Padding(2);
            gb_map.Size = new Size(348, 178);
            gb_map.TabIndex = 21;
            gb_map.TabStop = false;
            gb_map.Text = "Mapped Databases";
            gb_map.Visible = false;
            // 
            // lbl_mapprogress
            // 
            lbl_mapprogress.AutoSize = true;
            lbl_mapprogress.Location = new Point(70, 152);
            lbl_mapprogress.Margin = new Padding(2, 0, 2, 0);
            lbl_mapprogress.Name = "lbl_mapprogress";
            lbl_mapprogress.Size = new Size(0, 15);
            lbl_mapprogress.TabIndex = 6;
            // 
            // lv_maps
            // 
            lv_maps.Location = new Point(10, 22);
            lv_maps.Margin = new Padding(2);
            lv_maps.Name = "lv_maps";
            lv_maps.Size = new Size(290, 125);
            lv_maps.TabIndex = 1;
            lv_maps.UseCompatibleStateImageBehavior = false;
            lv_maps.View = View.SmallIcon;
            lv_maps.SelectedIndexChanged += lv_maps_SelectedIndexChanged;
            // 
            // pcbx_background
            // 
            pcbx_background.BackgroundImage = (Image)resources.GetObject("pcbx_background.BackgroundImage");
            pcbx_background.BackgroundImageLayout = ImageLayout.Stretch;
            pcbx_background.Location = new Point(0, 153);
            pcbx_background.Margin = new Padding(2);
            pcbx_background.Name = "pcbx_background";
            pcbx_background.Size = new Size(280, 240);
            pcbx_background.TabIndex = 22;
            pcbx_background.TabStop = false;
            // 
            // il_selectimages
            // 
            il_selectimages.ColorDepth = ColorDepth.Depth32Bit;
            il_selectimages.ImageStream = (ImageListStreamer)resources.GetObject("il_selectimages.ImageStream");
            il_selectimages.TransparentColor = Color.Transparent;
            il_selectimages.Images.SetKeyName(0, "select.png");
            il_selectimages.Images.SetKeyName(1, "unselect.png");
            // 
            // FrmAiPostgre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 392);
            Controls.Add(gb_map);
            Controls.Add(gb_key);
            Controls.Add(gb_loading);
            Controls.Add(gb_database);
            Controls.Add(pcbx_icon);
            Controls.Add(btn_dbsettings);
            Controls.Add(tb_aiquery);
            Controls.Add(tb_userrequest);
            Controls.Add(btn_send);
            Controls.Add(btn_showquery);
            Controls.Add(btn_keysettings);
            Controls.Add(lbl_title);
            Controls.Add(dgv_airesult);
            Controls.Add(btn_tweak);
            Controls.Add(btn_mapdb);
            Controls.Add(pcbx_background);
            Controls.Add(Btn_Copy);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAiPostgre";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LangToSQL - AI PostgreSQL Assistant";
            FormClosing += FrmAiPostgre_FormClosing;
            Load += FrmAiPostgre_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_airesult).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbx_icon).EndInit();
            gb_key.ResumeLayout(false);
            gb_key.PerformLayout();
            gb_LLM.ResumeLayout(false);
            gb_LLM.PerformLayout();
            gb_Gemini.ResumeLayout(false);
            gb_Gemini.PerformLayout();
            gb_database.ResumeLayout(false);
            gb_database.PerformLayout();
            gb_loading.ResumeLayout(false);
            gb_loading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcbx_loadinggif).EndInit();
            gb_map.ResumeLayout(false);
            gb_map.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcbx_background).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_keysettings;
        private Button btn_showquery;
        private Button btn_send;
        private TextBox tb_userrequest;
        private TextBox tb_aiquery;
        private DataGridView dgv_airesult;
        private Label lbl_title;
        private Button btn_dbsettings;
        private PictureBox pcbx_icon;
        private ImageList il_showimages;
        private GroupBox gb_key;
        private GroupBox gb_database;
        private Button btn_saveapi;
        private CheckBox ckbx_showApi;
        private CheckBox ckbx_remember;
        private Label lbl_key;
        private TextBox tx_apikey;
        private Button btn_savedb;
        private TextBox txt_pass;
        private Label lbl_pass;
        private TextBox txt_user;
        private Label lbl_user;
        private TextBox txt_db;
        private Label lbl_db;
        private TextBox tx_ip;
        private Label lbl_ip;
        private ToolTip tt_hover;
        private CheckBox chbx_dbpass;
        private Button btn_tweak;
        private GroupBox gb_loading;
        private PictureBox pcbx_loadinggif;
        private Label lbl_validatedb;
        private Button btn_dbback;
        private Button btn_keyback;
        private Label lbl_loadstatus;
        private ProgressBar pb_loading;
        private Button Btn_Copy;
        private Button btn_mapdb;
        private GroupBox gb_map;
        private Button btn_backmap;
        private Button btn_selectmap;
        private Button btn_map;
        private ListView lv_maps;
        private Button btn_deletemap;
        private Label lbl_mapprogress;
        private PictureBox pcbx_background;
        private ImageList il_selectimages;
        private RadioButton rdbtn_LLM;
        private RadioButton rdbtn_Gemini;
        private TextBox txt_LlmUrl;
        private Label lblLLM;
        private GroupBox gb_LLM;
        private GroupBox gb_Gemini;
        private Label lblLlmModel;
        private TextBox txtLlmModel;
    }
}
