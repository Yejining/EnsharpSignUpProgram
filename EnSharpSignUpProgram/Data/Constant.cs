using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace EnSharpSignUpProgram.Data
{
    class Constant
    {
        public const string API_URL = "https://dapi.kakao.com/v2/local/search/address.json";
        public const string API_KEY = "30e21f11970e8f74a033ceb22c65d83e";

        public static Color TEXT_COLOR = (Color)ColorConverter.ConvertFromString("#000040");
        public static Color WARNING_COLOR = (Color)ColorConverter.ConvertFromString("#F03C45");
        public static Color PLACEHOLDER_COLOR = (Color)ColorConverter.ConvertFromString("#C3C3C3");

        public const string EMPTY_INPUT_ERROR = "필수항목입니다";
        public const string NAME_ERROR = "이름은 3-5자 한글만 사용 가능합니다.";
        public const string ID_ERROR = "ID는 5-20글자의 영문 소문자, 숫자만 사용 가능합니다.";

        public const string WRONG_LOG_IN = "아이디 또는 비밀번호를 다시 확인하세요.\n등록되지 않은 아이디이거나, 아이디 또는 비밀번호를 잘못 입력하셨습니다.";


        public static int[] INPUT_LIMIT = { 5, 20, 16};

        public const int ID_LIMIT = 20;
        public const int PASSWORD_LIMIT = 16;
        
        public const int NAME = 0;
        public const int ID = 1;
        public const int PASSWORD = 2;

        public const string KOREAN_PATTERN_INPUT = "[ㄱ-ㅎ가-힣]";
        public const string KOREAN_PATTERN = "[가-힣]";
        public const string ENGLISH_NUMBER_PARRERN = "[0-9a-zA-Z]";
        public const int INPUT = 0;
        public const int CHECK = 1;
    }
}
