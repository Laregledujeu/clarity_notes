﻿using MySql.Data.MySqlClient;
using System;


public static class Database
{
    private static string ip = "83.150.217.50";
    private static string database = "clarity_notes";
    private static string username = "root";
    private static string password = "tAP4kN4SLEpit@";
    private static string port = "3306";

    public static MySqlConnection GetConnection()
    {
        string parameters = $"server={ip};port={port};uid={username};pwd={password};initial catalog={database}"; 
        MySqlConnection mySqlConnection = new MySqlConnection();
        mySqlConnection.ConnectionString = parameters;
        mySqlConnection.Open();
        return mySqlConnection;
    }

    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
    }
}
