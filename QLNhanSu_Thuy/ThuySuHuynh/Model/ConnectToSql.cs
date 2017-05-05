using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Model
{
    class ConnectToSql
    {
        #region availible
        /// <summary>
        /// Đây là các thuộc tính của lớp connection
        /// </summary>
        private SqlConnection conn;
        private string error;
        #endregion


        #region Contruction
        /// <summary>
        /// Đây là hàm contructor của class sqlconnect
        /// </summary>
        public ConnectToSql()
        {
            conn = new SqlConnection("server=.\\SQLEXPRESS;database=QuanLyNhanSu ;User ID=sa;password=123456");
        }
        #endregion


        #region method
        /// <summary>
        /// Hàm trả lỗi
        /// </summary>
        public string Erro
        {
            get { return error; }
            set { error = value; }
        }
        /// <summary>
        /// Hàm mở kết nối
        /// </summary>
        public void OpenConnect()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
        /// <summary>
        /// Hàm đóng kết nối
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
        /// <summary>
        /// Hàm lấy ra chuỗi kết nối
        /// </summary>
        public SqlConnection strConn
        {
            get { return conn; }
        }
        #endregion
    }
}
