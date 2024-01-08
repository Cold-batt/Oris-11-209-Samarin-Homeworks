namespace DotGame;

partial class GameWindow
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
        ButtonLogin = new Button();
        NameInput = new TextBox();
        Users = new ListBox();
        label1 = new Label();
        SuspendLayout();
        // 
        // ButtonLogin
        // 
        ButtonLogin.Location = new Point(487, 337);
        ButtonLogin.Margin = new Padding(4, 5, 4, 5);
        ButtonLogin.Name = "ButtonLogin";
        ButtonLogin.Size = new Size(107, 38);
        ButtonLogin.TabIndex = 0;
        ButtonLogin.Text = "Войти";
        ButtonLogin.UseVisualStyleBackColor = true;
        ButtonLogin.Click += Login;
        // 
        // NameInput
        // 
        NameInput.Location = new Point(449, 268);
        NameInput.Margin = new Padding(4, 5, 4, 5);
        NameInput.Name = "NameInput";
        NameInput.Size = new Size(180, 31);
        NameInput.TabIndex = 2;
        // 
        // Users
        // 
        Users.FormattingEnabled = true;
        Users.ItemHeight = 25;
        Users.Location = new Point(953, 30);
        Users.Margin = new Padding(4, 5, 4, 5);
        Users.Name = "Users";
        Users.Size = new Size(170, 479);
        Users.TabIndex = 3;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(133, 88);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(0, 25);
        label1.TabIndex = 4;
        // 
        // GameWindow
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1169, 558);
        Controls.Add(label1);
        Controls.Add(Users);
        Controls.Add(NameInput);
        Controls.Add(ButtonLogin);
        Name = "GameWindow";
        Text = "Игра в точку";
        MouseDown += GameWindow_MouseDown;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button ButtonLogin;
    private TextBox NameInput;
    private ListBox Users;
    private Label label1;
}