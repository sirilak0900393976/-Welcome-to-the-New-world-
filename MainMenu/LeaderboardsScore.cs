using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class LeaderboardsScore : MonoBehaviour {

    //Type Database
    private string sConn, sSqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;

    //Type Text Show
    Text tRank;
    Text tPlayer;
    Text tScore;

    //TextMesh tTryCatch;

    // Use this for initialization
    void Start () {

        //Get GameObject Text
        tRank = GameObject.Find("/TextBoards/Rank").GetComponent<Text>();
        tPlayer = GameObject.Find("/TextBoards/Player").GetComponent<Text>();
        tScore = GameObject.Find("/TextBoards/Score").GetComponent<Text>();
        sConn = "URI=file:" + Application.dataPath + "/Plugins/Leaderboards.s3db"; //Path to database.
        Readers();

    }

    //=============================================================
    //Function Database

    private void Readers()
    {
        try {
            using (dbconn = new SqliteConnection(sConn))
            {
                dbconn.Open(); //Open connection to the database.
                dbcmd = dbconn.CreateCommand();
                sSqlQuery = "SELECT * " + "FROM Leaderboards ORDER BY score DESC ";// table name
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
                tRank.text = sRank;
                tPlayer.text = sName;
                tScore.text = sScore;

                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();
                dbconn = null;
            }
        }
        catch (Exception ex) {
            Debug.Log(ex.ToString());
            CreateTable();
        }
        
    }

    private void Insertvalue(int nScore, string sName)
    {
        using (dbconn = new SqliteConnection(sConn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            //sqlQuery = string.Format("insert into Usersinfo (Name, Email, Address) values (\"{0}\",\"{1}\",\"{2}\")", name, email, address);// table name
            sSqlQuery = "insert into Leaderboards values("+nScore+",\""+sName+"\")"; // insert into Leaderboards values(8989, "Bee");
            dbcmd.CommandText = sSqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            dbconn = null;
            dbcmd.Dispose();
            dbcmd = null;
        }
    }

    private void CreateTable()
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
            }
        } catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        Insertvalue( 8989, "Pupe");
        Insertvalue( 1990, "Bee");
        Readers();
    }
}
