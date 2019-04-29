//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//using Mono.Data.Sqlite;
//using System.Data;
//using System;

//public class MenuDatabase : MonoBehaviour {

//	private string conn, sqlQuery;
//    IDbConnection dbconn;
//    IDbCommand dbcmd;

//    // Use this for initialization
//    void Start () {
//        conn = "URI=file:" + Application.dataPath + "/DB/TableData.s3db"; //Path to database.
//        //Deletvalue(6);
//        //insertvalue("ahmedm", "ahmedm@gmail.com", "sss"); 
//        //Updatevalue("a", "w@gamil.com", "1st", 1);
//        insertvalue(4,"jannis",25);
//        readers();
//        Debug.Log("=======================");
//        Deletvalue(4);
//        Updatevalue(3, "pun",14);
//        readers();
//    }

//    private void insertvalue(int id, string name, int score)
//    {
//        using (dbconn = new SqliteConnection(conn))
//        {
//            dbconn.Open(); //Open connection to the database.
//            dbcmd = dbconn.CreateCommand();
//            //sqlQuery = string.Format("insert into Usersinfo (Name, Email, Address) values (\"{0}\",\"{1}\",\"{2}\")", name, email, address);// table name
//            sqlQuery = string.Format("insert into TableTest values("+id+",\""+name+"\","+score+")");
//            dbcmd.CommandText = sqlQuery;
//            dbcmd.ExecuteScalar();
//            dbconn.Close();
//        }
//    }
//    private void Deletvalue(int id)
//    {
//        using (dbconn = new SqliteConnection(conn))
//        {
//            dbconn.Open(); //Open connection to the database.
//            dbcmd = dbconn.CreateCommand();
//            //sqlQuery = string.Format("Delete from Usersinfo WHERE ID=\"{0}\"", id);// table name
//            sqlQuery = string.Format("Delete from TableTest WHERE id = " + id);
//            dbcmd.CommandText = sqlQuery;
//            dbcmd.ExecuteScalar();
//            dbconn.Close();
//        }
//    }


//    private void Updatevalue(int id,string name,int score)
//    {
//        using (dbconn = new SqliteConnection(conn))
//        {

//            dbconn.Open(); //Open connection to the database.
//            dbcmd = dbconn.CreateCommand();
//            //sqlQuery = string.Format("UPDATE Usersinfo set Name=\"{0}\", Email=\"{1}\", Address=\"{2}\" WHERE ID=\"{3}\" ", name, email, address, id);// table name
//            sqlQuery = string.Format("UPDATE TableTest set id = "+id+",name = \""+name+"\",score = "+score+" WHERE id = "+id);
//            dbcmd.CommandText = sqlQuery;
//            dbcmd.ExecuteScalar();
//            dbconn.Close();
//        }
//    }


//    private void readers()
//    {
//        using (dbconn = new SqliteConnection(conn))
//        {
//            dbconn.Open(); //Open connection to the database.
//            dbcmd = dbconn.CreateCommand();
//            sqlQuery = "SELECT * " + "FROM TableTest";// table name
//            dbcmd.CommandText = sqlQuery;
//            IDataReader reader = dbcmd.ExecuteReader();
//            while (reader.Read())
//            {
//                int id = reader.GetInt32(0);
//                string name = reader.GetString(1);
//                int score = reader.GetInt32(2);

//                Debug.Log("ID = " + id + " Name = " + name + " Score = "+ score);
//            }
//            reader.Close();
//            reader = null;
//            dbcmd.Dispose();
//            dbcmd = null;
//            dbconn.Close();
//            dbconn = null;
//        }
//    }
	
//	// Update is called once per frame
//	void Update () {
		
//	}
//}
