using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace EnSharpSignUpProgram.Data
{
    class Database
    {
        static MySqlConnection connect;
        static MySqlCommand command;
        static MySqlDataReader reader;

        /// <summary>
        /// MySQL에 연결합니다.
        /// </summary>
        public static void ConnectToMySQL()
        {
            String databaseConnect;

            databaseConnect = "Server=Localhost;Database=ensharp_sign_up;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);

            connect.Open();
        }

        /// <summary>
        /// MySQL과의 연결을 종료합니다.
        /// </summary>
        public static void CloseConnectMySQL()
        {
            connect.Close();
        }

        /// <summary>
        /// sql 쿼리문을 실행시킵니다.
        /// </summary>
        /// <param name="sql"></param>
        public static void MakeCommand(string sql)
        {
            command = new MySqlCommand(sql.ToString(), connect);
            reader = command.ExecuteReader();
            reader.Close();
        }

        /// <summary>
        /// sql 쿼리문을 실행 후 데이터베이스에서 읽은 값을 반환해주는 메소드입니다.
        /// </summary>
        /// <param name="sql">쿼리문</param>
        /// <param name="searchCategory">컬럼</param>
        /// <returns></returns>
        public static List<string> MakeCommand(string sql, string column)
        {
            List<string> result = new List<string>();

            command = new MySqlCommand(sql.ToString(), connect);
            reader = command.ExecuteReader();

            while (reader.Read()) result.Add(reader[column].ToString());

            reader.Close();

            return result;
        }

        /// <summary>
        /// 테이블 안에서 일정 조건을 만족하는 데이터의 갯수를 반환하는 메소드입니다.
        /// </summary>
        /// <param name="tableName">테이블명</param>
        /// <param name="conditionalExpression">검색 조건</param>
        /// <returns>데이터 갯수</returns>
        public static int GetCountFromDatabase(string tableName, string conditionalExpression)
        {
            string sql = "SELECT count(*) FROM " + tableName + conditionalExpression + ";";

            return Int32.Parse(MakeCommand(sql, "count(*)")[0]);
        }

        /// <summary>
        /// 데이터베이스에서 일정 조건을 만족하는 column값을 선택해 가져오는 메소드입니다.
        /// </summary>
        /// <param name="column">컬럼명</param>
        /// <param name="tableName">테이블명</param>
        /// <param name="conditionalExpression">조건식</param>
        /// <returns>테이블에서 선택한 컬럼 내용</returns>
        public static List<string> SelectFromDatabase(string column, string tableName, string conditionalExpression)
        {
            List<string> data = new List<string>();
            string sql = "SELECT " + column + " FROM " + tableName + conditionalExpression + ";";

            return MakeCommand(sql, column);
        }

        /// <summary>
        /// 테이블에서 조건문을 만족시키는 데이터를 삭제하는 메소드입니다.
        /// </summary>
        /// <param name="tableName">테이블명</param>
        /// <param name="conditionalExpression">조건문</param>
        public static void DeleteFromDatabase(string tableName, string conditionalExpression)
        {
            string sql = "DELETE FROM " + tableName + conditionalExpression + ";";

            MakeCommand(sql);
        }

        /// <summary>
        /// 테이블에 데이터를 삽입하는 메소드입니다.
        /// </summary>
        /// <param name="table">테이블명</param>
        /// <param name="columns">삽입할 데이터 변수명</param>
        /// <param name="values">삽입할 데이터 내용</param>
        public static void InsertIntoDatabase(string table, string columns, string values)
        {
            string sql = "INSERT INTO " + table + " " + columns + " VALUES " + values + ";";

            MakeCommand(sql);
        }

        /// <summary>
        /// 테이블 내에서 조건을 만족하는 데이터를 업데이트하는 메소드입니다.
        /// </summary>
        /// <param name="table">테이블명</param>
        /// <param name="column">컬럼명</param>
        /// <param name="data">업데이트할 데이터</param>
        /// <param name="conditionalExpression">조건문</param>
        public static void UpdateToDatabase(string table, string column, string data, string conditionalExpression)
        {
            string sql = "UPDATE " + table + " SET " + column + "=" + data + conditionalExpression + ";";

            MakeCommand(sql);
        }
    }
}
