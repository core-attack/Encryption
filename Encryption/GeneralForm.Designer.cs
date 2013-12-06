namespace Encryption
{
    partial class GeneralForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonEnc = new System.Windows.Forms.Button();
            this.buttonDec = new System.Windows.Forms.Button();
            this.comboBoxEncType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ключToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сгенерироватьКлючToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьКлючToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxKey = new System.Windows.Forms.ToolStripTextBox();
            this.показатьКвадратВиженераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьКодыСимволовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьЗамененныйКлючомТекстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.проверитьРассеиваниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.зашифроватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расшифроватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNew = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.textBoxL = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxW = new System.Windows.Forms.ComboBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.показатьРезультатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEnc
            // 
            this.buttonEnc.Location = new System.Drawing.Point(6, 41);
            this.buttonEnc.Name = "buttonEnc";
            this.buttonEnc.Size = new System.Drawing.Size(119, 35);
            this.buttonEnc.TabIndex = 2;
            this.buttonEnc.Text = "Зашифровать";
            this.toolTip1.SetToolTip(this.buttonEnc, "Будьте внимательны! Будет зашифровано всё содержимое окна редактирования!");
            this.buttonEnc.UseVisualStyleBackColor = true;
            this.buttonEnc.Click += new System.EventHandler(this.buttonEnc_Click);
            // 
            // buttonDec
            // 
            this.buttonDec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDec.Location = new System.Drawing.Point(255, 41);
            this.buttonDec.Name = "buttonDec";
            this.buttonDec.Size = new System.Drawing.Size(122, 35);
            this.buttonDec.TabIndex = 4;
            this.buttonDec.Text = "Расшифровать";
            this.toolTip1.SetToolTip(this.buttonDec, "Будьте внимательны! Будет дешифровано всё содержимое окна редактирования!");
            this.buttonDec.UseVisualStyleBackColor = true;
            this.buttonDec.Click += new System.EventHandler(this.buttonDec_Click);
            // 
            // comboBoxEncType
            // 
            this.comboBoxEncType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEncType.FormattingEnabled = true;
            this.comboBoxEncType.Location = new System.Drawing.Point(195, 6);
            this.comboBoxEncType.Name = "comboBoxEncType";
            this.comboBoxEncType.Size = new System.Drawing.Size(182, 29);
            this.comboBoxEncType.TabIndex = 5;
            this.comboBoxEncType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEncType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите тип шифрования";
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox.Location = new System.Drawing.Point(0, 82);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(378, 343);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "Коля долго не мог понять, почему у него НИЧЕГО не получается";
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ключToolStripMenuItem,
            this.сгенерироватьКлючToolStripMenuItem,
            this.изменитьКлючToolStripMenuItem,
            this.показатьКвадратВиженераToolStripMenuItem,
            this.показатьЗамененныйКлючомТекстToolStripMenuItem,
            this.toolStripMenuItemLog,
            this.toolStripMenuItem1,
            this.проверитьРассеиваниеToolStripMenuItem,
            this.показатьРезультатыToolStripMenuItem,
            this.toolStripMenuItem2,
            this.зашифроватьToolStripMenuItem,
            this.расшифроватьToolStripMenuItem,
            this.тестToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(343, 280);
            this.toolTip1.SetToolTip(this.contextMenuStrip1, "Будет зашифрован только выделенный текст");
            // 
            // ключToolStripMenuItem
            // 
            this.ключToolStripMenuItem.Name = "ключToolStripMenuItem";
            this.ключToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.ключToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.ключToolStripMenuItem.Text = "Ключ";
            this.ключToolStripMenuItem.Click += new System.EventHandler(this.ключToolStripMenuItem_Click);
            // 
            // сгенерироватьКлючToolStripMenuItem
            // 
            this.сгенерироватьКлючToolStripMenuItem.Name = "сгенерироватьКлючToolStripMenuItem";
            this.сгенерироватьКлючToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.сгенерироватьКлючToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.сгенерироватьКлючToolStripMenuItem.Text = "Сгенерировать ключ";
            this.сгенерироватьКлючToolStripMenuItem.Click += new System.EventHandler(this.сгенерироватьКлючToolStripMenuItem_Click);
            // 
            // изменитьКлючToolStripMenuItem
            // 
            this.изменитьКлючToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxKey});
            this.изменитьКлючToolStripMenuItem.Name = "изменитьКлючToolStripMenuItem";
            this.изменитьКлючToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.изменитьКлючToolStripMenuItem.Text = "Изменить ключ";
            this.изменитьКлючToolStripMenuItem.DropDownClosed += new System.EventHandler(this.изменитьКлючToolStripMenuItem_DropDownClosed);
            this.изменитьКлючToolStripMenuItem.DropDownOpened += new System.EventHandler(this.изменитьКлючToolStripMenuItem_DropDownOpened);
            // 
            // toolStripTextBoxKey
            // 
            this.toolStripTextBoxKey.Name = "toolStripTextBoxKey";
            this.toolStripTextBoxKey.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxKey.ToolTipText = "Значение ключа";
            // 
            // показатьКвадратВиженераToolStripMenuItem
            // 
            this.показатьКвадратВиженераToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьКодыСимволовToolStripMenuItem});
            this.показатьКвадратВиженераToolStripMenuItem.Name = "показатьКвадратВиженераToolStripMenuItem";
            this.показатьКвадратВиженераToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.показатьКвадратВиженераToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.показатьКвадратВиженераToolStripMenuItem.Text = "Показать квадрат Виженера";
            this.показатьКвадратВиженераToolStripMenuItem.Click += new System.EventHandler(this.показатьКвадратВиженераToolStripMenuItem_Click);
            // 
            // показатьКодыСимволовToolStripMenuItem
            // 
            this.показатьКодыСимволовToolStripMenuItem.Name = "показатьКодыСимволовToolStripMenuItem";
            this.показатьКодыСимволовToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.показатьКодыСимволовToolStripMenuItem.Text = "Показать коды символов";
            this.показатьКодыСимволовToolStripMenuItem.Click += new System.EventHandler(this.показатьКодыСимволовToolStripMenuItem_Click);
            // 
            // показатьЗамененныйКлючомТекстToolStripMenuItem
            // 
            this.показатьЗамененныйКлючомТекстToolStripMenuItem.Name = "показатьЗамененныйКлючомТекстToolStripMenuItem";
            this.показатьЗамененныйКлючомТекстToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.показатьЗамененныйКлючомТекстToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.показатьЗамененныйКлючомТекстToolStripMenuItem.Text = "Показать данные текущего шифрования";
            this.показатьЗамененныйКлючомТекстToolStripMenuItem.Click += new System.EventHandler(this.показатьЗамененныйКлючомТекстToolStripMenuItem_Click);
            // 
            // toolStripMenuItemLog
            // 
            this.toolStripMenuItemLog.Name = "toolStripMenuItemLog";
            this.toolStripMenuItemLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItemLog.Size = new System.Drawing.Size(342, 22);
            this.toolStripMenuItemLog.Text = "Показать лог";
            this.toolStripMenuItemLog.Click += new System.EventHandler(this.toolStripMenuItemLog_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(339, 6);
            // 
            // проверитьРассеиваниеToolStripMenuItem
            // 
            this.проверитьРассеиваниеToolStripMenuItem.Name = "проверитьРассеиваниеToolStripMenuItem";
            this.проверитьРассеиваниеToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.проверитьРассеиваниеToolStripMenuItem.Text = "Проверить рассеивание и перемешивание";
            this.проверитьРассеиваниеToolStripMenuItem.Click += new System.EventHandler(this.проверитьРассеиваниеToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(339, 6);
            // 
            // зашифроватьToolStripMenuItem
            // 
            this.зашифроватьToolStripMenuItem.Name = "зашифроватьToolStripMenuItem";
            this.зашифроватьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.зашифроватьToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.зашифроватьToolStripMenuItem.Text = "Зашифровать";
            this.зашифроватьToolStripMenuItem.Click += new System.EventHandler(this.зашифроватьToolStripMenuItem_Click);
            // 
            // расшифроватьToolStripMenuItem
            // 
            this.расшифроватьToolStripMenuItem.Name = "расшифроватьToolStripMenuItem";
            this.расшифроватьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.расшифроватьToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.расшифроватьToolStripMenuItem.Text = "Расшифровать";
            this.расшифроватьToolStripMenuItem.ToolTipText = "Будет расшифрован только выделенный текст";
            this.расшифроватьToolStripMenuItem.Click += new System.EventHandler(this.расшифроватьToolStripMenuItem_Click);
            // 
            // тестToolStripMenuItem
            // 
            this.тестToolStripMenuItem.Name = "тестToolStripMenuItem";
            this.тестToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.тестToolStripMenuItem.Text = "Тест";
            this.тестToolStripMenuItem.Click += new System.EventHandler(this.тестToolStripMenuItem_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(131, 41);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(119, 35);
            this.buttonNew.TabIndex = 3;
            this.buttonNew.Text = "Новый шифр";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // textBoxR
            // 
            this.textBoxR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxR.Location = new System.Drawing.Point(196, 386);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(26, 29);
            this.textBoxR.TabIndex = 13;
            this.textBoxR.Text = "16";
            this.toolTip1.SetToolTip(this.textBoxR, "Количество раундов шифрования");
            // 
            // textBoxL
            // 
            this.textBoxL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxL.Location = new System.Drawing.Point(260, 386);
            this.textBoxL.Name = "textBoxL";
            this.textBoxL.Size = new System.Drawing.Size(26, 29);
            this.textBoxL.TabIndex = 14;
            this.textBoxL.Text = "32";
            this.toolTip1.SetToolTip(this.textBoxL, "Длина криптоключа в байтах");
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(20, 279);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(20, 314);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(347, 29);
            this.textBox2.TabIndex = 7;
            this.textBox2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(20, 349);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(347, 29);
            this.textBox3.TabIndex = 8;
            this.textBox3.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(292, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 248);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(107, 25);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "+ mod 2^32";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(131, 248);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(71, 25);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "replace";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(209, 248);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(70, 25);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "<<< 11";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(285, 248);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(82, 25);
            this.checkBox4.TabIndex = 12;
            this.checkBox4.Text = "+ mod 2";
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox4.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(163, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "R=";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(228, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "L=";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(84, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "W=";
            // 
            // comboBoxW
            // 
            this.comboBoxW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxW.FormattingEnabled = true;
            this.comboBoxW.Location = new System.Drawing.Point(120, 386);
            this.comboBoxW.Name = "comboBoxW";
            this.comboBoxW.Size = new System.Drawing.Size(47, 29);
            this.comboBoxW.TabIndex = 19;
            this.comboBoxW.Text = "32";
            this.comboBoxW.SelectedIndexChanged += new System.EventHandler(this.comboBoxW_SelectedIndexChanged);
            this.comboBoxW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxW_KeyPress);
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(254, 318);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(38, 25);
            this.checkBox5.TabIndex = 22;
            this.checkBox5.Text = "3";
            this.checkBox5.UseVisualStyleBackColor = false;
            this.checkBox5.Visible = false;
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(177, 318);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(38, 25);
            this.checkBox6.TabIndex = 21;
            this.checkBox6.Text = "2";
            this.checkBox6.UseVisualStyleBackColor = false;
            this.checkBox6.Visible = false;
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Location = new System.Drawing.Point(88, 318);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(38, 25);
            this.checkBox7.TabIndex = 20;
            this.checkBox7.Text = "1";
            this.checkBox7.UseVisualStyleBackColor = false;
            this.checkBox7.Visible = false;
            // 
            // показатьРезультатыToolStripMenuItem
            // 
            this.показатьРезультатыToolStripMenuItem.Name = "показатьРезультатыToolStripMenuItem";
            this.показатьРезультатыToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.показатьРезультатыToolStripMenuItem.Text = "Показать результаты";
            this.показатьРезультатыToolStripMenuItem.Click += new System.EventHandler(this.показатьРезультатыToolStripMenuItem_Click);
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 423);
            this.Controls.Add(this.comboBoxW);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxL);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.textBoxR);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEncType);
            this.Controls.Add(this.buttonDec);
            this.Controls.Add(this.buttonEnc);
            this.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GeneralForm";
            this.ShowIcon = false;
            this.Text = "Шифрование";
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.GeneralForm_InputLanguageChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEnc;
        private System.Windows.Forms.Button buttonDec;
        private System.Windows.Forms.ComboBox comboBoxEncType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ключToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сгенерироватьКлючToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьКлючToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxKey;
        private System.Windows.Forms.ToolStripMenuItem показатьКвадратВиженераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьЗамененныйКлючомТекстToolStripMenuItem;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem расшифроватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зашифроватьToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.ToolStripMenuItem показатьКодыСимволовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLog;
        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.TextBox textBoxL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxW;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.ToolStripMenuItem тестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проверитьРассеиваниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem показатьРезультатыToolStripMenuItem;
    }
}

