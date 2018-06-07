﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RpgTowerDefense
{
    class Database
    {
        SQLiteConnection sqlite2 = new SQLiteConnection("Data Source=C:\\TowerDefence\\TowerDefence.db");
        List<string> score;

        public List<string> Score { get => score; set => score = value; }

        #region ReadFrom
        public List<string> ReadHighScore(string select)
        {
            //Read highscore from database
            sqlite2.Open();
            string sql = select;
            //"select * from users" +
            //"order by score desc"
            Score = new List<string>();

            SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
            SQLiteDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                string a = "" + reader.GetString(1) + "    " + reader.GetInt32(2) + "";
                Score.Add(a);
            }

            sqlite2.Close();
            return Score;
        }
        #endregion



        #region AdMethods
        public void SaveGame()
        {
            sqlite2.Open();


            string AddDatabase = "CREATE TABLE IF NOT EXISTS account (rowID INT, user VARCHAR(20), pass VARCHAR(20))";
            
            SQLiteCommand command = new SQLiteCommand(AddDatabase, sqlite2);
            command.ExecuteNonQuery();


            sqlite2.Close();
        }

        public void AddHighScore(string user, int Score)
        {
            //Adder HighScores til databasen
            sqlite2.Open();
            
            string txtSqlQuery = "INSERT INTO HighScore Values (null,'"+ user +"'," + Score + ", date('now'))";
            
            SQLiteCommand command = new SQLiteCommand(txtSqlQuery, sqlite2);
            command.ExecuteNonQuery();
            sqlite2.Close();
        }

        public void AddAnalyse(int indkomstPrLevel, int totalInkomst, int loseLvl, int totalTårnePlaceret)
        {
            //Adder Analysen til databasen
            sqlite2.Open();
            string txtSqlQuery = "INSERT INTO Analyse Values(null," + indkomstPrLevel+","+totalInkomst+","+loseLvl+","+totalTårnePlaceret+")";




            SQLiteCommand command = new SQLiteCommand(txtSqlQuery, sqlite2);
            command.ExecuteNonQuery();
            sqlite2.Close();
        }
        #endregion


        #region CreateTables
        public void CreateTables()
        {
            //Highscore tables created

            sqlite2.Open();
            string CreateTableHighscore = "CREATE TABLE IF NOT EXISTS HighScore" +
                "(ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                "" + "user" + " varchar(50)," +
                "" + "score" + " INTEGER," +
                "DateTime DATETIME NOT NULL DEFAULT (datetime(CURRENT_TIMESTAMP, 'localtime')))";
            
            SQLiteCommand commandHighscore = new SQLiteCommand(CreateTableHighscore, sqlite2);
            commandHighscore.ExecuteNonQuery();

            //Analyse tables created

            string CreateTableAnalyse = "CREATE TABLE IF NOT EXISTS Analyse" +
                "('ID' INTEGER PRIMARY KEY AUTOINCREMENT," +
                "" + "Income per round" + " INTEGER," +
                "'" + "Total Income" + "' INTEGER," +
                "'" + "Lose Lvl" + "' INTEGER," +
                "'" + "Total turrets placed" + "' INTEGER)";
            
            SQLiteCommand commandAnalyse = new SQLiteCommand(CreateTableAnalyse, sqlite2);
            commandAnalyse.ExecuteNonQuery();







            sqlite2.Close();
        }
        #endregion
    }
}