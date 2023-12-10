using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Cursovoi_parse_csv_10_12_2023
{
    // в классе создать методы которые принимают список
    // и сохраняют в базу данных
    // строка соединения находится в appconfig-нифига 10-12-2023 22:38 воскресенье
    public class AddToDataBase
    {
        public void metodAddDB(string listStrings) {
            string connetionString = null;
            string sql = null;

            // строка для соединения с базой данных
            connetionString = @"Data Source = fishman\SQLEXPRESS;
                                                Initial Catalog = mytest_db;
                                                Integrated Security = SSPI;
                                                TrustServerCertificate = True";

            // запрос на вставку в таблицу данных двух столбцов
            sql = "insert into Main_t ([First_f], [Last_f]) values(@first,@last)";
            // разбиваем полученный список на подстроки, разделитель перенос строки

            // разделитель по строкам для заполнения списка
            string[] separator = { "\n","\r" };
            // добавляем данные в список 
            string[] stringFile = listStrings.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            // список для записи подстроки из строки, разделение по точке с запятой
            string[] list;

            // Начинаем соединение и создаём запрос на вставку строк
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                  // открываем соединение 
                    cnn.Open();
                    // зазбиваем строку из списка на подстроки
                    foreach (string str in stringFile)
                    {
                        // разделяем строку на подстроки по ";"
                        string[] separatore = { ";" };
                        list = (str.Split(separatore, StringSplitOptions.RemoveEmptyEntries));
                        // выполняем команду, записываем строки в базу данных
                        using (SqlCommand cmd = new SqlCommand(sql, cnn))
                        {

                            // получение и установка параметров для передачи в sql запрос
                            cmd.Parameters.Add("@first", SqlDbType.NVarChar).Value = list[7];
                            cmd.Parameters.Add("@last", SqlDbType.NVarChar).Value = list[8];

                            // Let's ask the db to execute the query
                            // Давайте попросим базу данных выполнить запрос
                            int rowsAdded = cmd.ExecuteNonQuery();
                            if (rowsAdded > 0)
                            { }
                                //MessageBox.Show("Row inserted!!");
                            else
                                // Well this should never really happen
                                // Что ж, на самом деле этого никогда не должно было случиться
                                MessageBox.Show("No row inserted");

                        }
                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    // Мы должны где-то зарегистрировать ошибку,
                    // для этого примера давайте просто покажем сообщение
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }

        }
    }
}