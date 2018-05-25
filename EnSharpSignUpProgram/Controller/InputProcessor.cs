using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

using EnSharpSignUpProgram.Data;

namespace EnSharpSignUpProgram.Controller
{
    class InputProcessor
    {
        public void LogInProcess(object sender, KeyEventArgs e, TextBox textBox, int limit)
        {
            if (textBox.Tag.ToString() == "비밀번호")
            {
                textBox.Text = new string('*', textBox.Text.Length);
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
            }

            if (textBox.Text.Length > limit)
            {
                ApplyLimitAndSetCursorEndOfText(textBox);
            }
        }

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
        public bool IsValidName(TextBox textBox, Label label)
        {
            if (textBox.Text.Length < 3 || textBox.Text.Length > 5)
            {
                Warn(label, Constant.ID_ERROR);
                return false;
            }
            else if (!IsKorean(textBox.Text, Constant.CHECK))
            {
                Warn(label, Constant.ID_ERROR);
                return false;
            }
            else
            {
                label.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }
        }

        public bool IsValidID(TextBox textBox, Label label)
        {
            if (textBox.Text.Length < 6 || textBox.Text.Length > 20)
            {
                Warn(label, Constant.ID_ERROR);
                return false;
            }
            else if (!IsEnglishOrNumber(textBox.Text))
            {
                Warn(label, Constant.ID_ERROR);
                return false;
            }
            else if (Database.GetCountFromDatabase("member", $" WHERE id=\"{textBox.Text}\"") != 0)
            {
                Warn(label, "이미 사용중이거나 탈퇴한 아이디입니다.");
                return false;
            }
            else
            {
                label.Visibility = System.Windows.Visibility.Hidden;
                return true;
            }
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
