using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NavisworkSmartDesignReview
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // DB 연결 문자열을 가져옵니다.
            string connString = ConfigurationManager.ConnectionStrings["YourDbConnectionString"].ToString();

            // SQL 연결을 설정합니다.
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // 연결을 엽니다.
                conn.Open();

                // SQL 쿼리를 설정합니다.
                string query = "SELECT * FROM [Sample].[dbo].[Sheet1$]"; // YourTable에는 실제 테이블 이름을 입력합니다.

                // SQL 명령을 생성합니다.
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // DataAdapter와 DataTable을 사용해 데이터를 가져옵니다.
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // DataGrid에 데이터를 표시합니다.
                    DataGrid.ItemsSource = dt.DefaultView;
                }
            }
        }
    }
}
