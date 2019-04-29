using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataBase : MonoBehaviour {

    private string sConn, sSqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    int nLastScore = 0;
    string sLastName = "";

    void Start()
    {
        sConn = "URI=file:" + Application.dataPath + "/Plugins/Leaderboards.s3db"; //Path to database.
        if (SceneManager.GetActiveScene().name.Equals("Home game")) {
            string[] Data = Readers();
            Text tRank = GameObject.Find("/TextBoards/Rank").GetComponent<Text>();
            Text tPlayer = GameObject.Find("/TextBoards/Player").GetComponent<Text>();
            Text tScore = GameObject.Find("/TextBoards/Score").GetComponent<Text>();
            tRank.text = Data[0];
            tPlayer.text = Data[1];
            tScore.text = Data[2];
        }
    }

    public bool[] Readers(int nTotalScore) // Use for BackHome
    {
        bool[] bCheck = new bool[2];
        bool bData = true;
        bool bCountOver = true;
        try
        {
            using (dbconn = new SqliteConnection(sConn))
            {
                dbconn.Open(); //Open connection to the database.
                dbcmd = dbconn.CreateCommand();
                sSqlQuery = "SELECT * " + "FROM Leaderboards ORDER BY score DESC ";// table name
                dbcmd.CommandText = sSqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                int nCountPlayer = 1;
                int nScore = 0;
                string sName = "";
                while (reader.Read())
                {
                    nCountPlayer += 1;
                    nScore = reader.GetInt32(0);
                    sName = reader.GetString(1);
                    if (nScore == nTotalScore && sName.Equals(gameManager.sNamePlayer))
                    {
                        bData = false;
                    }

                }

                if (nScore > nTotalScore)
                {
                    bData = false;
                }
                if (nCountPlayer <= 5)
                {
                    bCountOver = false;
                }

                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;

                bCheck[0] = bData;
                bCheck[1] = bCountOver;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        return bCheck;
    }
    
    public string[] Readers() // Use for LeaderboardsScore.cs
    {
        string[] Data = new string[3];
        try
        {
            using (dbconn = new SqliteConnection(sConn))
            {
                dbconn.Open(); //Open connection to the database.
                dbcmd = dbconn.CreateCommand();
                sSqlQuery = "SELECT * " + "FROM Leaderboards ORDER BY score DESC ";// table name ASC
                dbcmd.CommandText = sSqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                string sRank = "";
                string sName = "";
                string sScore = "";
                int nCount = 1;
                while (reader.Read())
                {
                    sRank += nCount + "\n";
                    sScore += reader.GetInt32(0) + "\n";
                    sName += reader.GetString(1) + "\n";
                    nCount += 1;
                }
                Data[0] = sRank;
                Data[1] = sName;
                Data[2] = sScore;

                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
                
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            Data = CreateTable(Data);
        }
        return Data;

    }


    public string[] CreateTable(string[] Data) // Use for LeaderboardsScore.cs
    {
        try
        {
            using (dbconn = new SqliteConnection(sConn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                //"CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";
                //string.Format("insert into Leaderboards values(" + id + ",\"" + name + "\"," + score + ")");
                sSqlQuery = "CREATE TABLE IF NOT EXISTS Leaderboards (score INTEGER, name TEXT)";
                dbcmd.CommandText = sSqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
                dbconn = null;
                dbcmd.Dispose();
                dbcmd = null;

                return Data;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        Insertvalue(8989, "Pupe");
        Insertvalue(1990, "Bee");
        return Readers();
    }


    public void Insertvalue(int nScore, string sName) // Use for all file
    {
        using (dbconn = new SqliteConnection(sConn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            //sqlQuery = string.Format("insert into Usersinfo (Name, Email, Address) values (\"{0}\",\"{1}\",\"{2}\")", name, email, address);// table name
            sSqlQuery = "insert into Leaderboards values(" + nScore + ",\"" + sName + "\")"; // insert into Leaderboards values(8989, "Bee");
            dbcmd.CommandText = sSqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            dbconn = null;
            dbcmd.Dispose();
            dbcmd = null;
        }
    }

    public void Deletvalue() // Use for all file
    {
        using (dbconn = new SqliteConnection(sConn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            //sqlQuery = string.Format("Delete from Usersinfo WHERE ID=\"{0}\"", id);// table name
            sSqlQuery = string.Format("Delete from Leaderboards WHERE score = " + nLastScore + " and name = \"" + sLastName + "\"");
            dbcmd.CommandText = sSqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            dbconn = null;
            dbcmd.Dispose();
            dbcmd = null;
        }
    }
}
