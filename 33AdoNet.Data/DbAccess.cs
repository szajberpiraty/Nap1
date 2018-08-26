using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33AdoNet.Data
{
    public class DbAccess
    {
        private const string connectionString = "Server=.\\sqlexpress;Database=SchoolContext0;Trusted_Connection=True;"; 
        public List<Teachers> GetTeachers()
        {
            var teachers = new List<Teachers>();

            var ds = new DataSet();

            using (var con=new SqlConnection(connectionString))
            {
                using (var cmd=new SqlCommand("select Id,FirstName,LastName,ClassCode,Subject_Id from Teachers",con))
                {
                    using (var da=new SqlDataAdapter(cmd))
                    {
                        
                        da.Fill(ds,"Teachers");
                    }
                }
            }
            foreach (DataRow row in ds.Tables["Teachers"].Rows)
            {
                var teacher = new Teachers()
                {
                    Id = row.Field<int>("Id")
                    ,FirstName=row.Field<string>("FirstName")
                    ,LastName = row.Field<string>("LastName")
                    ,ClassCode = row.Field<string>("ClassCode")
                    ,Subject_Id= row.Field<int>("Subject_Id")
                };
                teachers.Add(teacher);
            }
            return teachers;
        }

        public int DeleteTeacher(int id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                //Nem szabad nekiállni stringeket építeni, mert SQL injection-ra ad lehetőséget
                using (var cmd = new SqlCommand("DELETE FROM Teacher WHERE Id=@Id", con))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value =id;

                    //az érintett sorok számával tér vissza
                    var affectedRows = cmd.ExecuteNonQuery();

                    return affectedRows;
                }
            }
        }

        public Teachers ReadTeacher(int id) //Teachers-el tér vissza
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                //Nem szabad nekiállni stringeket építeni, mert SQL injection-ra ad lehetőséget
                using (var cmd = new SqlCommand("SELECT FirstName,LastName,ClassCode,Subject_Id FROM Teachers WHERE ID=@Id", con))
                {
                    var param = cmd.CreateParameter();
                    param.DbType = DbType.Int32;
                    param.Direction = ParameterDirection.Input;
                    param.ParameterName = "@Id";
                    param.Value = id;

                    //Hozzáadjuk a parancshoz
                    cmd.Parameters.Add(param);

                    //Végrehajtjuk a parancsot és nyitunk egy readert
                    var reader = cmd.ExecuteReader();

                    //Itt is 0-val térünk vissza, ha nincs sor
                    if (!reader.Read())
                    {//ravaszul visszatérünk null-al
                        return null;
                    }

                    var teacher = new Teachers()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id"))
                        ,FirstName= reader.GetString(reader.GetOrdinal("FirstName"))
                        ,LastName = reader.GetString(reader.GetOrdinal("LastName"))
                        ,ClassCode = reader.GetString(reader.GetOrdinal("ClassCode"))
                        ,Subject_Id = reader.GetInt32(reader.GetOrdinal("Subject_Id"))
                    };
                    return teacher;
                }
            }
        }

        public int CreateTeacher(Teachers teacher)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                //Nem szabad nekiállni stringeket építeni, mert SQL injection-ra ad lehetőséget
                using (var cmd = new SqlCommand("INSERT Teachers(FirstName,LastName,ClassCode,Subject_Id) VALUES (@FirstName,@LastName,@ClassCode,@Subject_Id);SELECT SCOPE_IDENTITY() AS ID", con))
                {
                    //String-ből hozta létre a táblát a CodeFirst, ezért ez az adatbázisban NVarChar(max) típus lett
                    //ezt a max értéket a -1-el adjuk meg
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, -1).Value = teacher.FirstName;

                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, -1).Value = teacher.LastName;
                    cmd.Parameters.Add("@ClassCode", SqlDbType.NVarChar, -1).Value = teacher.ClassCode;
                    cmd.Parameters.Add("@Subject_Id", SqlDbType.Int).Value = teacher.Subject_Id;


                    //Lefuttatjuk a parancsot és nyitunk egy reader-t az azonosító betöltéséhez
                    var reader = cmd.ExecuteReader();
                    //Ráállunk a köv. sorra, ami az első sor lesz.
                    //
                    if (!reader.Read())
                    {//Ha nem sikerül, akkor 0 értékkel jelezzük, ami nem megengedett érték az Identity mezőben
                        return 0;
                    }
                    //Egy oszlopos a visszaadott rekordhalmaz, az első oszlop a 0-s indexű
                    var id = (int)reader.GetDecimal(0); //int-re castoljuk az értéket

                    return id;

                }
            }
        }
    }
}
