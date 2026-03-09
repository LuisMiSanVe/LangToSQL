using AiPostgreWinForms.Properties;
using Newtonsoft.Json;
using Npgsql;
using RestSharp;
using System.Data;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace AiPostgreWinForms
{
    public partial class FrmAiPostgre : Form
    {
        // Gemini API Data
        public static string endpoint = "https://generativelanguage.googleapis.com"; // Resource
        public static string uri = "/v1beta/models/gemini-2.5-flash:generateContent?key="; // Model URI
        public static string apikey = ""; // API Key

        // Database Data
        public static string database = "";
        public static string json = "";

        // Encryption Data
        public static string key = "";
        public static string iv = "";

        // Other Data
        public static string currentmap = "";
        public static string currentai = "";

        public FrmAiPostgre()
        {
            InitializeComponent();
        }

        private void FrmAiPostgre_Load(object sender, EventArgs e)
        {
            // Creates the Encrytion Keys
            if (GetMotherboardSerialNumber() != "")
            {
                key = GetMotherboardSerialNumber().Remove(6, GetMotherboardSerialNumber().Length - 6) + "SpecificSystemBasedEncrypt"; // Must be 32 bytes for AES-256
                iv = GetMotherboardSerialNumber().Remove(6, GetMotherboardSerialNumber().Length - 6) + "SpecSysEnc"; // Must be 16 bytes for AES
            }
            else
            {
                MessageBox.Show("Because of the System Data wasn't gathered, which is necessary to the encryption method, to prevent further error and securuty breaches, all program's data will be erased.", "Encryption method fail response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (File.Exists("apisettings.conf"))
                    File.Delete("apisettings.conf");
                if (File.Exists("dbsettings.conf"))
                    File.Delete("dbsettings.conf");
                if (File.Exists("aisettings.conf"))
                    File.Delete("aisettings.conf");
                if (Directory.Exists("MappedDB"))
                    Directory.Delete("MappedDB");
            }

            // Load saved API Key if remembered is checked
            if (File.Exists("apisettings.conf"))
            {
                ckbx_remember.Checked = true;
                tx_apikey.Text = Decrypt(File.ReadAllText("apisettings.conf"));
                apikey = tx_apikey.Text;
            }

            // Load latest saved DB settings
            if (File.Exists("dbsettings.conf"))
            {
                string dbsettings = Decrypt(File.ReadAllText("dbsettings.conf"));
                if (dbsettings != "")
                {
                    string[] settings = dbsettings.Split(';');
                    tx_ip.Text = settings[0].Substring(settings[0].IndexOf("=") + 1);
                    txt_db.Text = settings[3].Substring(settings[3].IndexOf("=") + 1);
                    txt_user.Text = settings[1].Substring(settings[1].IndexOf("=") + 1);
                    txt_pass.Text = settings[2].Substring(settings[2].IndexOf("=") + 1);
                }
                database = dbsettings;
            }

            // Load the Mapped Databases
            if (Directory.Exists("MappedDB"))
            {
                lv_maps.Items.Clear();
                for (int i = 0; i < Directory.EnumerateFiles("MappedDB").Count(); i++)
                {
                    lv_maps.Items.Add(Directory.GetFiles("MappedDB")[i].Remove(0, 9).Replace(".json", ""));

                    if (currentmap != "")
                        if (lv_maps.Items[i].Text == currentmap)
                        {
                            lv_maps.Items[i].BackColor = Color.FromArgb(255, 86, 240, 255); //56F0FF
                            lv_maps.Items[i].ForeColor = Color.FromArgb(255, 88, 76, 246); //584CF6
                        }
                }
            }

            // Load the current AI selection
            if (File.Exists("aisettings.conf"))
            {
                string aisettings = Decrypt(File.ReadAllText("aisettings.conf"));
                currentai = aisettings.Split('\n')[0];
                txt_LlmUrl.Text = aisettings.Split('\n')[1];
                txtLlmModel.Text = aisettings.Split('\n')[2];

                if (currentai.Equals("LLM"))
                    rdbtn_LLM.Checked = true;
            }
            else
                currentai = "Gemini";
        }

        private void btn_showquery_Click(object sender, EventArgs e)
        {
            if (tb_aiquery.Visible)
            {
                tb_aiquery.Visible = false;
                btn_tweak.Visible = false;
                Btn_Copy.Visible = false;
                btn_showquery.BackgroundImage = il_showimages.Images[0];
                tt_hover.SetToolTip(btn_showquery, "Show the generated query");
            }
            else
            {
                tb_aiquery.Visible = true;
                btn_tweak.Visible = true;
                Btn_Copy.Visible = true;
                btn_showquery.BackgroundImage = il_showimages.Images[1];
                tt_hover.SetToolTip(btn_showquery, "Hide the generated query");
            }
        }

        private void btn_keysettings_Click(object sender, EventArgs e)
        {
            // Displays the selected settings
            gb_key.Visible = true;

            // Disables the functionality of the rest of the program
            btn_dbsettings.Enabled = false;
            btn_showquery.Enabled = false;
            btn_send.Enabled = false;
            tb_aiquery.Enabled = false;
            tb_userrequest.Enabled = false;
            dgv_airesult.Enabled = false;
            btn_tweak.Enabled = false;
            Btn_Copy.Enabled = false;
            btn_mapdb.Enabled = false;
        }

        private void btn_dbsettings_Click(object sender, EventArgs e)
        {
            // Displays the selected settings
            gb_database.Visible = true;

            // Disables the functionality of the rest of the program
            btn_keysettings.Enabled = false;
            btn_showquery.Enabled = false;
            btn_send.Enabled = false;
            tb_aiquery.Enabled = false;
            tb_userrequest.Enabled = false;
            dgv_airesult.Enabled = false;
            btn_tweak.Enabled = false;
            Btn_Copy.Enabled = false;
            btn_mapdb.Enabled = false;
        }

        private void btn_saveapi_Click(object sender, EventArgs e)
        {
            if (rdbtn_Gemini.Checked)
            {
                if (Regex.Match(tx_apikey.Text, "^AIza[0-9A-Za-z_-]{35}$").Success)
                {
                    apikey = tx_apikey.Text;
                    if (ckbx_remember.Checked)
                        File.WriteAllText("apisettings.conf", Encrypt(apikey));
                }
                else
                    MessageBox.Show("The API Key provided doesn't match with a Google API Key.", "API Key doesn't match the format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (currentai.Equals(""))
                currentai = "Gemini";
            File.WriteAllText("aisettings.conf", Encrypt(currentai + "\n" + txt_LlmUrl.Text + "\n" + txtLlmModel.Text));

            gb_key.Visible = false;

            // Enables the functionality of the rest of the program
            btn_dbsettings.Enabled = true;
            btn_showquery.Enabled = true;
            btn_send.Enabled = true;
            tb_aiquery.Enabled = true;
            tb_userrequest.Enabled = true;
            dgv_airesult.Enabled = true;
            btn_tweak.Enabled = true;
            Btn_Copy.Enabled = true;
            btn_mapdb.Enabled = true;
        }

        private void btn_savedb_Click(object sender, EventArgs e)
        {
            if (tx_ip.Text != "" && txt_user.Text != "" && txt_pass.Text != "" && txt_db.Text != "")
            {
                // Saves the value and closes the settings
                database = "Host=" + tx_ip.Text + ";Username=" + txt_user.Text + ";Password=" + txt_pass.Text + ";Database=" + txt_db.Text;
                // Verify the db
                var connection = new NpgsqlConnection(database);
                try
                {
                    // Try to open the connection, if it fails, it displays a message, else, closes the connection and saves
                    connection.Open();
                    connection.Close();

                    File.WriteAllText("dbsettings.conf", Encrypt(database));
                    gb_database.Visible = false;

                    // Enables the functionality of the rest of the program
                    btn_keysettings.Enabled = true;
                    btn_showquery.Enabled = true;
                    btn_send.Enabled = true;
                    tb_aiquery.Enabled = true;
                    tb_userrequest.Enabled = true;
                    dgv_airesult.Enabled = true;
                    btn_tweak.Enabled = true;
                    Btn_Copy.Enabled = true;
                    btn_mapdb.Enabled = true;

                    // Empties the possible mapped database if is not a saved map
                    if (currentmap == "")
                        json = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("The PostgreSQL Server can't be reached, it's possible some of the provided data is wrong.", "Can't connect to PostgeSQL Server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ckbx_remember_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbx_remember.Checked)
                File.Delete("apisettings.conf");
        }

        private void ckbx_showApi_Click(object sender, EventArgs e)
        {
            togglePassword(ckbx_showApi, tx_apikey);
        }

        private void togglePassword(CheckBox chk, TextBox txb)
        {
            if (chk.Checked)
                txb.PasswordChar = '\0';
            else
                txb.PasswordChar = '*';
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {   // You can't use it unless you have something written
                if (tb_userrequest.Text != "" && tb_userrequest.ForeColor != Color.Gray)
                {
                    if (apikey != "")
                    {
                        var thread = new Thread(() =>
                        {
                            // Connects to the database
                            var connection = new NpgsqlConnection(database);

                            if (connection != null && connection.ConnectionString != "")
                            {
                                try
                                {
                                    connection.Open();

                                    pb_loading.Invoke((MethodInvoker)(() =>
                                    {
                                        // Enables the loading screen
                                        gb_loading.Dock = DockStyle.Fill;
                                        gb_loading.Visible = true;
                                        lbl_loadstatus.Text = "Mapping...";
                                        pb_loading.Value = 0; // Restart the bar value 
                                    }));

                                    // If the database is already mapped, it skips the process
                                    if (json == "")
                                    {
                                        // OBTAIN DB
                                        // Get the quantity of tables and columns for the loading bar
                                        var tableQuantity = new NpgsqlCommand("SELECT (" +
                                                                              "SELECT COUNT(*) FROM information_schema.tables " +
                                                                              "WHERE table_type = 'BASE TABLE' AND table_name NOT LIKE 'pg_%' AND table_name NOT LIKE 'sql_%') +" +
                                                                              "(SELECT COUNT(*) FROM information_schema.columns " +
                                                                              "WHERE table_schema NOT LIKE 'pg_%' AND table_name NOT LIKE 'sql_%')", connection).ExecuteReader();
                                        while (tableQuantity.Read())
                                        {
                                            pb_loading.Invoke((MethodInvoker)(() =>
                                            {
                                                pb_loading.Maximum = tableQuantity.GetInt32(0);
                                                lbl_loadstatus.Text = "Mapping... (0/" + pb_loading.Maximum + ")";
                                            }));
                                        }
                                        tableQuantity.Close();
                                        // Tables
                                        var tablesDB = new NpgsqlCommand("SELECT CONCAT(table_schema, '.', table_name) AS full_table_name " +
                                                                         "FROM information_schema.tables WHERE table_type = 'BASE TABLE' AND table_name NOT LIKE 'pg_%' AND table_name NOT LIKE 'sql_%' " +
                                                                         "ORDER BY full_table_name;", connection).ExecuteReader();
                                        // Table           Column(Type)
                                        Dictionary<string, List<string>> tables = new Dictionary<string, List<string>>();

                                        while (tablesDB.Read())
                                        {
                                            if (!tables.ContainsKey(tablesDB.GetString(0)))
                                            {
                                                //         Name                   Columns
                                                tables.Add(tablesDB.GetString(0), null);
                                                // Fills the loading bar
                                                pb_loading.Invoke((MethodInvoker)(() =>
                                                {
                                                    if (pb_loading.Value < pb_loading.Maximum)
                                                    {
                                                        pb_loading.Value++;
                                                        lbl_loadstatus.Text = "Mapping... (" + pb_loading.Value + "/" + pb_loading.Maximum + ")";
                                                    }
                                                }));
                                            }
                                        }
                                        tablesDB.Close();
                                        // Columns
                                        foreach (string tableName in tables.Keys)
                                        {
                                            var columnsDB = new NpgsqlCommand("SELECT c.column_name, c.data_type, CASE WHEN tc.constraint_type = 'PRIMARY KEY' THEN 'PK' WHEN tc.constraint_type = 'FOREIGN KEY' THEN 'FK' ELSE '' END AS key_type " +
                                                                              "FROM information_schema.columns c " +
                                                                              "LEFT JOIN information_schema.key_column_usage kcu ON c.table_schema = kcu.table_schema AND c.table_name = kcu.table_name AND c.column_name = kcu.column_name " +
                                                                              "LEFT JOIN information_schema.table_constraints tc ON kcu.constraint_name = tc.constraint_name AND kcu.table_schema = tc.table_schema AND kcu.table_name = tc.table_name " +
                                                                              "WHERE c.table_schema = '" + tableName.Substring(0, tableName.IndexOf('.')) + "' AND c.table_name = '" + tableName.Remove(0, tableName.IndexOf('.') + 1) + "'" +
                                                                              "ORDER BY c.column_name;", connection).ExecuteReader();

                                            List<string> columns = new List<string>();

                                            while (columnsDB.Read())
                                            {
                                                string columnInfo = columnsDB.GetString(0) + "(" + columnsDB.GetString(1) + ")";
                                                if (!columnsDB.GetString(2).Equals(""))
                                                    columnInfo = columnsDB.GetString(0) + "(" + columnsDB.GetString(1) + ") (" + columnsDB.GetString(2) + ")";

                                                if (!columns.Contains(columnInfo))
                                                {   //      Name(Type)(Key)
                                                    columns.Add(columnInfo);

                                                    tables[tableName] = columns;
                                                    // Fills the loading bar
                                                    pb_loading.Invoke((MethodInvoker)(() =>
                                                    {
                                                        if (pb_loading.Value < pb_loading.Maximum)
                                                        {
                                                            pb_loading.Value++;
                                                            lbl_loadstatus.Text = "Mapping... (" + pb_loading.Value + "/" + pb_loading.Maximum + ")";
                                                        }
                                                    }));
                                                }
                                            }
                                            columnsDB.Close();
                                        }
                                        // Finish the loading bar
                                        pb_loading.Invoke((MethodInvoker)(() =>
                                        {
                                            int difference = pb_loading.Maximum - pb_loading.Value;
                                            pb_loading.Value += difference;
                                            lbl_loadstatus.Text = "Mapping... (" + pb_loading.Maximum + "/" + pb_loading.Maximum + ")";
                                        }));

                                        var opcions = new JsonSerializerOptions
                                        {
                                            WriteIndented = true // JSON format
                                        };

                                        json = System.Text.Json.JsonSerializer.Serialize(tables, opcions);
                                    }
                                    else
                                    {
                                        // Finish the loading bar
                                        pb_loading.Invoke((MethodInvoker)(() =>
                                        {
                                            pb_loading.Value = pb_loading.Maximum;
                                        }));
                                    }
                                    // Creates context to modify AI's behavior
                                    string context = "You're a database assistant, I'll send you requests and you'll return a PostgeSQL query to do my request and if what I request can't be found on the database, tell me, but don't use more words. " +
                                                     "This is the database: " +
                                                     json +
                                                     "\nAnd this is my request: ";

                                    // AI Request
                                    string generatedSql = "";
                                    if (currentai.Equals("Gemini"))
                                    {
                                        var Client = new RestClient(endpoint);
                                        var request = new RestRequest(uri + apikey, Method.Post);
                                        request.AddHeader("Content-Type", "application/json");

                                        var body = new AIRequest();
                                        body.contents = new Content[] { new Content() { parts = new Part[] { new Part() { text = context + tb_userrequest.Text } } } };

                                        var jsonstring = JsonConvert.SerializeObject(body);

                                        request.AddJsonBody(jsonstring);

                                        // Sends the request to the service
                                        lbl_loadstatus.Invoke((MethodInvoker)(() =>
                                        {
                                            lbl_loadstatus.Text = "Generating...";
                                        }));
                                        try
                                        {
                                            var response = Client.Post(request);
                                            var resp = JsonDocument.Parse(response.Content);
                                            // It extracts the AI's response from the 'Text' field                                                                                      and I remove the SQL Code style the AI adds
                                            generatedSql = resp.RootElement.GetProperty("candidates")[0].GetProperty("content").GetProperty("parts")[0].GetProperty("text").GetString().Replace("```sql", "").Replace("```", "").Replace('\n', ' ').Trim();
                                            generatedSql = Regex.Replace(generatedSql, @"\s+", " ");
                                            tb_aiquery.Invoke((MethodInvoker)(() =>
                                            {
                                                tb_aiquery.Text = generatedSql;
                                            }));
                                        }
                                        catch (HttpRequestException ex)
                                        {
                                            MessageBox.Show("The provided Gemini API Key has failed to access the endpoint, make sure the API Key or Service is functional", "API Key failed (" + ex.StatusCode + ")", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            gb_key.Invoke((MethodInvoker)(() =>
                                            {
                                                btn_keysettings_Click(null, null);
                                            }));
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("The provided Gemini API Key has failed to access the endpoint, make sure the API Key or Service is functional", "API Key failed (" + ex.Message + ")", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            gb_key.Invoke((MethodInvoker)(() =>
                                            {
                                                btn_keysettings_Click(null, null);
                                            }));
                                        }
                                    }
                                    else if (currentai.Equals("LLM"))
                                    {
                                        var Client = new RestClient(txt_LlmUrl.Text);
                                        var request = new RestRequest("/v1/chat/completions", Method.Post);
                                        request.AddHeader("Content-Type", "application/json");

                                        var body = new
                                        {
                                            model = txtLlmModel.Text,
                                            messages = new[]
                                            {
                                                new
                                                {
                                                    role = "user",
                                                    content = context + tb_userrequest.Text
                                                }
                                            },
                                            temperature = 0.2,
                                            max_tokens = 512
                                        };

                                        request.AddJsonBody(body);

                                        lbl_loadstatus.Invoke((MethodInvoker)(() =>
                                        {
                                            lbl_loadstatus.Text = "Generating...";
                                        }));

                                        try
                                        {
                                            var response = Client.Post(request);

                                            if (!response.IsSuccessful)
                                                throw new Exception(response.Content ?? response.ErrorMessage);

                                            var resp = JsonDocument.Parse(response.Content);

                                            generatedSql = resp.RootElement
                                                .GetProperty("choices")[0]
                                                .GetProperty("message")
                                                .GetProperty("content")
                                                .GetString()?
                                                .Replace("```sql", "")
                                                .Replace("```", "")
                                                .Replace('\n', ' ')
                                                .Trim();

                                            generatedSql = Regex.Replace(generatedSql ?? "", @"\s+", " ");

                                            tb_aiquery.Invoke((MethodInvoker)(() =>
                                            {
                                                tb_aiquery.Text = generatedSql;
                                            }));
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("LM Studio failed at answering. Ensure LM Studio is running and a model is loaded.\nCheck LM Studio's Server Console, if the call reached the server but didn't process, it's possible that your database is bigger than what your hardware can handle, please try to use Gemini instead.", "LM Studio Error (" + ex.Message + ")", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            gb_key.Invoke((MethodInvoker)(() =>
                                            {
                                                btn_keysettings_Click(null, null);
                                            }));
                                        }
                                    }
                                    // Execute the generated query
                                    // Disables the loading screen
                                    gb_loading.Invoke((MethodInvoker)(() =>
                                    {
                                        gb_loading.Visible = false;
                                        gb_loading.Dock = DockStyle.None;
                                    }));
                                    try
                                    {
                                        if (generatedSql != "")
                                        {
                                            var resultBBDD = new NpgsqlCommand(generatedSql, connection).ExecuteReader();
                                            DataTable dt = new DataTable();
                                            dt.Load(resultBBDD);

                                            // Loads the result in the UI Thread
                                            dgv_airesult.Invoke((MethodInvoker)(() =>
                                            {
                                                dgv_airesult.DataSource = dt;
                                            }));
                                        }

                                        connection.Close();
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("An error was thrown while running the generated query (" + generatedSql + ")", "The query failed to run in the PostgreSQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        if (!btn_tweak.Visible)
                                            btn_showquery.Invoke((MethodInvoker)(() =>
                                            {
                                                btn_showquery_Click(sender, e);
                                            }));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("The configured Database couldn't be reached, please check if the Database can still be connected with this configuration.", "Database can't be reached", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    btn_dbsettings.Invoke((MethodInvoker)(() =>
                                    {
                                        btn_dbsettings_Click(sender, e);
                                    }));
                                }
                            }
                            else
                            {
                                MessageBox.Show("You need to set up a proper Database connection first!", "No Database found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btn_dbsettings.Invoke((MethodInvoker)(() =>
                                {
                                    btn_dbsettings_Click(sender, e);
                                }));
                            }
                        });
                        thread.Start();
                    }
                    else
                    {
                        MessageBox.Show("You need to set up a proper API Key first!", "No API Key found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_keysettings_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error happened while trying to get response of Gemini AI or PostgreSQL Server:\r\n" + ex.Message, "Error while getting response", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chbx_dbpass_Click(object sender, EventArgs e)
        {
            togglePassword(chbx_dbpass, txt_pass);
        }

        private void tb_userrequest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_send_Click(sender, e);
        }

        private void btn_tweak_Click(object sender, EventArgs e)
        {
            if (tb_aiquery.Text != "")
            {
                var connection = new NpgsqlConnection(database);

                if (connection != null && connection.ConnectionString != "")
                {
                    connection.Open();
                    try
                    {
                        var resultBBDD = new NpgsqlCommand(tb_aiquery.Text, connection).ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(resultBBDD);

                        // Loads the result
                        dgv_airesult.DataSource = dt;

                        connection.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error was thrown while running the query (" + tb_aiquery.Text + ")", "The query failed to run in the PostgreSQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You need to set up a proper Database connection first!", "No Database found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_dbsettings_Click(sender, e);
                }
            }
        }

        private void tb_userrequest_Enter(object sender, EventArgs e)
        {
            if (tb_userrequest.ForeColor == Color.Gray)
            {
                tb_userrequest.ForeColor = Color.Black;
                tb_userrequest.Text = "";
            }
        }

        private void tb_userrequest_Leave(object sender, EventArgs e)
        {
            if (tb_userrequest.Text == "")
            {
                tb_userrequest.ForeColor = Color.Gray;
                tb_userrequest.Text = "Request...";
            }
        }

        private void btn_dbback_Click(object sender, EventArgs e)
        {
            gb_database.Visible = false;

            // Enables the functionality of the rest of the program
            btn_keysettings.Enabled = true;
            btn_showquery.Enabled = true;
            btn_send.Enabled = true;
            tb_aiquery.Enabled = true;
            tb_userrequest.Enabled = true;
            dgv_airesult.Enabled = true;
            btn_tweak.Enabled = true;
            Btn_Copy.Enabled = true;
            btn_mapdb.Enabled = true;

            // Discard the changes
            FrmAiPostgre_Load(sender, e);
        }

        private void btn_keyback_Click(object sender, EventArgs e)
        {
            gb_key.Visible = false;

            // Enables the functionality of the rest of the program
            btn_dbsettings.Enabled = true;
            btn_showquery.Enabled = true;
            btn_send.Enabled = true;
            tb_aiquery.Enabled = true;
            tb_userrequest.Enabled = true;
            dgv_airesult.Enabled = true;
            btn_tweak.Enabled = true;
            Btn_Copy.Enabled = true;
            btn_mapdb.Enabled = true;

            // Discard the changes
            FrmAiPostgre_Load(sender, e);
        }

        private void FrmAiPostgre_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the user tries to close the program while it's loading...
            if (gb_loading.Visible == true)
            {   // Checks for verification
                string tokenwaste = "";
                if (lbl_loadstatus.Text.Contains("Generating..."))
                    tokenwaste = "(You'll waste the used Tokens!)";
                var result = MessageBox.Show("The program is in the " + lbl_loadstatus.Text.Remove(lbl_loadstatus.Text.IndexOf("."), lbl_loadstatus.Text.Length - lbl_loadstatus.Text.IndexOf(".")) + " process, you do want to exit? " + tokenwaste, "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void tb_aiquery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_tweak_Click(sender, e);
        }

        // Encryption methods
        static string GetMotherboardSerialNumber()
        {
            return GetWmiProperty("Win32_BaseBoard", "SerialNumber");
        }
        static string GetWmiProperty(string className, string propertyName)
        {
            try
            {
                string result = string.Empty;
                using (ManagementClass managementClass = new ManagementClass(className))
                {
                    foreach (ManagementObject obj in managementClass.GetInstances())
                    {
                        if (obj[propertyName] != null)
                        {
                            result = obj[propertyName].ToString();
                            break;
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The system's data used in the verification couldn't be obtained:\r\n" + ex.Message, "System's data couldn't be obtained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
        public static string Decrypt(string cipherText)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = Encoding.UTF8.GetBytes(iv);

                    using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(cryptoStream))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The configuration file can't be decrypted, the file might be corrupted or it doesn't belong to this device:\r\n" + e.Message, "Encryption Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }

        private void Btn_Copy_Click(object sender, EventArgs e)
        {
            if (tb_aiquery.Text != "")
                Clipboard.SetText(tb_aiquery.Text);
        }

        private void btn_mapdb_Click(object sender, EventArgs e)
        {
            // Displays the selected settings
            gb_map.Visible = true;

            // Disables the functionality of the rest of the program
            btn_dbsettings.Enabled = false;
            btn_keysettings.Enabled = false;
            btn_showquery.Enabled = false;
            btn_send.Enabled = false;
            tb_aiquery.Enabled = false;
            tb_userrequest.Enabled = false;
            dgv_airesult.Enabled = false;
            btn_tweak.Enabled = false;
            Btn_Copy.Enabled = false;
        }

        private void btn_backmap_Click(object sender, EventArgs e)
        {
            gb_map.Visible = false;

            // Enables the functionality of the rest of the program
            btn_dbsettings.Enabled = true;
            btn_keysettings.Enabled = true;
            btn_showquery.Enabled = true;
            btn_send.Enabled = true;
            tb_aiquery.Enabled = true;
            tb_userrequest.Enabled = true;
            dgv_airesult.Enabled = true;
            btn_tweak.Enabled = true;
            Btn_Copy.Enabled = true;
        }

        private void btn_map_Click(object sender, EventArgs e)
        {
            if (!lv_maps.Items.Cast<ListViewItem>().Any(item => item.Text == txt_db.Text))
            {
                gb_map.Enabled = false;

                int maximum = 0;
                int current = 0;

                var thread = new Thread(() =>
                {
                    // Connects to the database
                    var connection = new NpgsqlConnection(database);

                    if (connection != null && connection.ConnectionString != "")
                    {
                        connection.Open();

                        // OBTAIN DB
                        // Get the quantity of tables and columns for the loading bar
                        var tableQuantity = new NpgsqlCommand("SELECT (" +
                                                              "SELECT COUNT(*) FROM information_schema.tables " +
                                                              "WHERE table_type = 'BASE TABLE' AND table_name NOT LIKE 'pg_%' AND table_name NOT LIKE 'sql_%') +" +
                                                              "(SELECT COUNT(*) FROM information_schema.columns " +
                                                              "WHERE table_schema NOT LIKE 'pg_%' AND table_name NOT LIKE 'sql_%')", connection).ExecuteReader();
                        while (tableQuantity.Read())
                        {
                            lbl_mapprogress.Invoke((MethodInvoker)(() =>
                            {
                                maximum = tableQuantity.GetInt32(0);
                                lbl_mapprogress.Text = "(" + current + "/" + maximum + ")";
                            }));
                        }
                        tableQuantity.Close();
                        // Tables
                        var tablesDB = new NpgsqlCommand("SELECT CONCAT(table_schema, '.', table_name) AS full_table_name " +
                                                         "FROM information_schema.tables WHERE table_type = 'BASE TABLE' AND table_name NOT LIKE 'pg_%' AND table_name NOT LIKE 'sql_%' " +
                                                         "ORDER BY full_table_name;", connection).ExecuteReader();
                        // Table           Column(Type)
                        Dictionary<string, List<string>> tables = new Dictionary<string, List<string>>();

                        while (tablesDB.Read())
                        {
                            if (!tables.ContainsKey(tablesDB.GetString(0)))
                            {
                                //         Name                   Columns
                                tables.Add(tablesDB.GetString(0), null);
                                // Fills the loading bar
                                lbl_mapprogress.Invoke((MethodInvoker)(() =>
                                {
                                    if (current < maximum)
                                    {
                                        current++;
                                        lbl_mapprogress.Text = "(" + current + "/" + maximum + ")";
                                    }
                                }));
                            }
                        }
                        tablesDB.Close();
                        // Columns
                        foreach (string tableName in tables.Keys)
                        {
                            var columnsDB = new NpgsqlCommand("SELECT c.column_name, c.data_type, CASE WHEN tc.constraint_type = 'PRIMARY KEY' THEN 'PK' WHEN tc.constraint_type = 'FOREIGN KEY' THEN 'FK' ELSE '' END AS key_type " +
                                                              "FROM information_schema.columns c " +
                                                              "LEFT JOIN information_schema.key_column_usage kcu ON c.table_schema = kcu.table_schema AND c.table_name = kcu.table_name AND c.column_name = kcu.column_name " +
                                                              "LEFT JOIN information_schema.table_constraints tc ON kcu.constraint_name = tc.constraint_name AND kcu.table_schema = tc.table_schema AND kcu.table_name = tc.table_name " +
                                                              "WHERE c.table_schema = '" + tableName.Substring(0, tableName.IndexOf('.')) + "' AND c.table_name = '" + tableName.Remove(0, tableName.IndexOf('.') + 1) + "'" +
                                                              "ORDER BY c.column_name;", connection).ExecuteReader();

                            List<string> columns = new List<string>();

                            while (columnsDB.Read())
                            {
                                string columnInfo = columnsDB.GetString(0) + "(" + columnsDB.GetString(1) + ")";
                                if (!columnsDB.GetString(2).Equals(""))
                                    columnInfo = columnsDB.GetString(0) + "(" + columnsDB.GetString(1) + ") (" + columnsDB.GetString(2) + ")";

                                if (!columns.Contains(columnInfo))
                                {   //      Name(Type)(Key)
                                    columns.Add(columnInfo);

                                    tables[tableName] = columns;
                                    // Fills the loading bar
                                    lbl_mapprogress.Invoke((MethodInvoker)(() =>
                                    {
                                        if (current < maximum)
                                        {
                                            current++;
                                            lbl_mapprogress.Text = "(" + current + "/" + maximum + ")";
                                        }
                                    }));
                                }
                            }
                            columnsDB.Close();
                        }

                        // Fills the loading bar
                        lbl_mapprogress.Invoke((MethodInvoker)(() =>
                        {
                            lbl_mapprogress.Text = "";
                        }));

                        var opcions = new JsonSerializerOptions
                        {
                            WriteIndented = true // JSON format
                        };

                        try
                        {
                            if (!Directory.Exists("MappedDB"))
                                Directory.CreateDirectory("MappedDB");
                            File.WriteAllText("MappedDB\\" + txt_db.Text + ".json", System.Text.Json.JsonSerializer.Serialize(tables, opcions));

                            lv_maps.Invoke((MethodInvoker)(() =>
                            {
                                lv_maps.Items.Add(txt_db.Text);
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The Mapped Database couldn't be saved in your drive, make sure the installation path have the necessary permissions or start the program as Administrator.", "Permissions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    gb_map.Invoke((MethodInvoker)(() =>
                    {
                        gb_map.Enabled = true;
                    }));
                });
                thread.Start();
            }
            else
            {
                MessageBox.Show("That Database is already mapped.", "That map already exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_selectmap_Click(object sender, EventArgs e)
        {
            if (lv_maps.FocusedItem != null)
            {
                if (tt_hover.GetToolTip(btn_selectmap).Equals("Select Map"))
                {
                    json = File.ReadAllText("MappedDB\\" + lv_maps.FocusedItem.Text + ".json");
                    // I change the colors to identify the selected map
                    foreach (ListViewItem item in lv_maps.Items)
                    {
                        item.BackColor = Color.White;
                        item.ForeColor = Color.Black;
                    }
                    lv_maps.FocusedItem.BackColor = Color.FromArgb(255, 86, 240, 255); //56F0FF
                    lv_maps.FocusedItem.ForeColor = Color.FromArgb(255, 88, 76, 246); //584CF6

                    currentmap = lv_maps.FocusedItem.Text;

                    lv_maps.FocusedItem.Selected = false;
                    lv_maps.FocusedItem = null;

                    btn_selectmap.BackgroundImage = il_selectimages.Images[1];
                    tt_hover.SetToolTip(btn_selectmap, "Unselect Map");
                }
                else
                {
                    json = "";
                    // I revert the colors
                    foreach (ListViewItem item in lv_maps.Items)
                    {
                        item.BackColor = Color.White;
                        item.ForeColor = Color.Black;
                    }

                    currentmap = "";

                    lv_maps.FocusedItem.Selected = false;
                    lv_maps.FocusedItem = null;

                    btn_selectmap.BackgroundImage = il_selectimages.Images[0];
                    tt_hover.SetToolTip(btn_selectmap, "Select Map");
                }
            }
        }

        private void btn_deletemap_Click(object sender, EventArgs e)
        {
            if (lv_maps.FocusedItem != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete this Mapped Database?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete("MappedDB\\" + lv_maps.FocusedItem.Text + ".json");
                        json = "";
                        lv_maps.FocusedItem.Remove();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The Mapped Database couldn't be deleted from your drive, make sure the installation path have the necessary permissions or start the program as Administrator.", "Permissions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lv_maps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_maps.FocusedItem != null)
            {
                if (lv_maps.FocusedItem.BackColor == Color.FromArgb(255, 142, 188, 237) &&
                    lv_maps.FocusedItem.ForeColor == Color.FromArgb(255, 182, 13, 216) &&
                    json != "")
                {
                    btn_selectmap.BackgroundImage = il_selectimages.Images[1];
                    tt_hover.SetToolTip(btn_selectmap, "Unselect Map");
                }
                else
                {
                    btn_selectmap.BackgroundImage = il_selectimages.Images[0];
                    tt_hover.SetToolTip(btn_selectmap, "Select Map");
                }
            }
        }

        private void dgv_airesult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    var cell = dgv_airesult[e.ColumnIndex, e.RowIndex];
                    if (cell?.Value != null)
                    {
                        if (!cell.Value.ToString().Equals(""))
                        {
                            Clipboard.SetText(cell.Value.ToString());
                            new ToolTip().Show("Value copied!", this, 3000);
                        }
                    }
                }
            }
        }

        private void rdbtn_Gemini_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_Gemini.Checked)
            {
                gb_Gemini.Enabled = true;
                gb_LLM.Enabled = false;

                currentai = "Gemini";
            }
            else if (rdbtn_LLM.Checked)
            {
                gb_Gemini.Enabled = false;
                gb_LLM.Enabled = true;

                currentai = "LLM";
            }
        }
    }
}
