using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_PROJECT.UI
{
    internal class FormStyling
    {
        public static Color PrimaryColor = Color.FromArgb(0, 122, 204);
        public static Color SecondaryColor = Color.FromArgb(45, 45, 48);
        public static Color BackgroundColor = Color.FromArgb(240, 240, 240);
        public static Font HeaderFont = new Font("Segoe UI", 16, FontStyle.Bold);
        public static Font NormalFont = new Font("Segoe UI", 10);

        public static void ApplyStyles(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = NormalFont;

            foreach (Control control in form.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = PrimaryColor;
                    button.ForeColor = Color.White;
                    button.Font = new Font(NormalFont.FontFamily, 10, FontStyle.Bold);
                    button.Padding = new Padding(10, 5, 10, 5);
                }
                else if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = NormalFont;
                }
                else if (control is Label label)
                {
                    label.ForeColor = SecondaryColor;
                }
            }
        }
    }
}
