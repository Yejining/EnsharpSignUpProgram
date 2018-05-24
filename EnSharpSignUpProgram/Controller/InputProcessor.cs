using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

using EnSharpSignUpProgram.Data;

namespace EnSharpSignUpProgram.Controller
{
    class InputProcessor
    {
        /// <summary>
        /// 사용자의 이름을 입력받는 메소드입니다.
        /// </summary>
        /// <param name="textBox">입력 TextBox</param>
        /// <param name="label">안내문구를 띄울 Label</param>
        public void UserName(TextBox textBox, Label label)
        {
            if (textBox.Text.Length > 5)
            {
                ApplyLimitAndSetCursorEndOfText(textBox);
                Warn(label, Constant.NAME_ERROR);
            }
            else if (!IsKorean(textBox.Text, Constant.INPUT))
            {
                Warn(label, Constant.NAME_ERROR);
            }
            else
            {
                label.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void UserID(TextBox textBox, Label label)
        {
            if (textBox.Text.Length > 20)
            {
                ApplyLimitAndSetCursorEndOfText(textBox);
                Warn(label, Constant.ID_ERROR);
            }
            else if (!IsEnglishOrNumber(textBox.Text))
            {
                Warn(label, Constant.ID_ERROR);
            }
            else
            {
                label.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        /// <summary>
        /// 사용자가 입력한 이름이 유효한지 검사하는 메소드입니다.
        /// </summary>
        /// <param name="textBox">이름 TextBox</param>
        /// <returns>입력 이름 유효 여부</returns>
        public bool IsValidName(TextBox textBox)
        {
            if (textBox.Text.Length < 3 || textBox.Text.Length > 5)
                return false;
            else if (!IsKorean(textBox.Text, Constant.CHECK))
                return false;
            else
                return true;
        }

        public bool IsValidID(TextBox textBox)
        {
            if (textBox.Text.Length < 6 || textBox.Text.Length > 20)
                return false;
            else if (!IsEnglishOrNumber(textBox.Text))
                return false;
            else
                return true;
        }

        /// <summary>
        /// TextBox의 맨 마지막 글자를 지우고 커서를 맞추는 메소드입니다.
        /// </summary>
        /// <param name="textBox">입력 TextBox</param>
        public void ApplyLimitAndSetCursorEndOfText(TextBox textBox)
        {
            textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
        }

        /// <summary>
        /// 사용자가 올바르지 않은 입력을 할 경우 안내사항을 띄우는 메소드입니다.
        /// </summary>
        /// <param name="label">안내문구를 띄울 Label</param>
        /// <param name="message">안내사항</param>
        public void Warn(Label label, string message)
        {
            label.Visibility = System.Windows.Visibility.Visible;
            label.Foreground = new SolidColorBrush(Constant.WARNING_COLOR);
            label.Content = message;
        }

        /// <summary>
        /// 인자로 전달된 문자열이 모두 한국어인지 검사하는 메소드입니다.
        /// </summary>
        /// <param name="word">문자열</param>
        /// <returns>한국어 여부</returns>
        public bool IsKorean(string word, int mode)
        {
            string pattern = "";

            if (mode == Constant.INPUT) pattern = Constant.KOREAN_PATTERN_INPUT;
            else if (mode == Constant.CHECK) pattern = Constant.KOREAN_PATTERN;

            return IsMatch(word, pattern);
        }

        public bool IsEnglishOrNumber(string word)
        {
            return IsMatch(word, Constant.ENGLISH_NUMBER_PARRERN);
        }

        public bool IsMatch(string word, string pattern)
        {
            foreach (char letter in word)
                if (!System.Text.RegularExpressions.Regex.IsMatch(letter.ToString(), pattern))
                    return false;

            return true;
        }
    }
}
