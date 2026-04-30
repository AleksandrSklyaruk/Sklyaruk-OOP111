using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Helper
{
    internal class Validator
    {
        /// <summary>
        /// Проверяет, что все поля TextBox заполнены.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        /// <param name="textBoxes">Поля для проверки.</param>
        /// <returns>
        /// Возвращает true, если все поля заполнены;
        /// иначе false.
        /// </returns>
        internal static bool AreTextBoxesFilled(
            string errorMessage,
            params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox == null)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show(
                        errorMessage,
                        "Ошибка ввода",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBox.Focus();

                    return false;
                }
            }

            return true;
        }
    }
}
