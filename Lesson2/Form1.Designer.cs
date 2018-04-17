namespace Lesson2
{
    partial class FormStringParser
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxStringExpression = new System.Windows.Forms.TextBox();
            this.calculate = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label_expression = new System.Windows.Forms.Label();
            this.label_result = new System.Windows.Forms.Label();
            this.checkBoxShowTime = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxStringExpression
            // 
            this.textBoxStringExpression.Location = new System.Drawing.Point(12, 109);
            this.textBoxStringExpression.Name = "textBoxStringExpression";
            this.textBoxStringExpression.Size = new System.Drawing.Size(584, 20);
            this.textBoxStringExpression.TabIndex = 0;
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(261, 165);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(75, 23);
            this.calculate.TabIndex = 1;
            this.calculate.Text = "Calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(12, 250);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(584, 20);
            this.textBoxResult.TabIndex = 2;
            // 
            // label_expression
            // 
            this.label_expression.AutoSize = true;
            this.label_expression.Location = new System.Drawing.Point(13, 90);
            this.label_expression.Name = "label_expression";
            this.label_expression.Size = new System.Drawing.Size(58, 13);
            this.label_expression.TabIndex = 3;
            this.label_expression.Text = "Expression";
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(13, 231);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(37, 13);
            this.label_result.TabIndex = 4;
            this.label_result.Text = "Result";
            // 
            // checkBoxShowTime
            // 
            this.checkBoxShowTime.AutoSize = true;
            this.checkBoxShowTime.Location = new System.Drawing.Point(16, 23);
            this.checkBoxShowTime.Name = "checkBoxShowTime";
            this.checkBoxShowTime.Size = new System.Drawing.Size(112, 17);
            this.checkBoxShowTime.TabIndex = 5;
            this.checkBoxShowTime.Text = "Show parsing time";
            this.checkBoxShowTime.UseVisualStyleBackColor = true;
            // 
            // FormStringParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 342);
            this.Controls.Add(this.checkBoxShowTime);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.label_expression);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.textBoxStringExpression);
            this.Name = "FormStringParser";
            this.Text = "String Expressions Parser & Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStringExpression;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label_expression;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.CheckBox checkBoxShowTime;
    }
}

