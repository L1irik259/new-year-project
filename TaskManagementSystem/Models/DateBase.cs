using Npgsql;

namespace TaskManagementSystem.Models;

public class DateBase
{
    private static NpgsqlConnection? npgsqlConnection { get; set; } = null;

    private DateBase()
    {
        npgsqlConnection = new NpgsqlConnection($"Host=localhost;Port=5432;Database=isdb;Username=user;Password=test123");
    }

    public static DateBase GetInstance()
    {
        if (npgsqlConnection is null)
        {
            DateBase dataBase = new DateBase();
            return dataBase;
        }
        else
        {
            throw new ArgumentException("You have been created database.");
        }
    }

    public void OpenConnection()
    {
        if (npgsqlConnection is not null)
        {
            if (npgsqlConnection.State == System.Data.ConnectionState.Closed)
            {
                npgsqlConnection.Open();
            }
        }
        else
        {
            throw new ArgumentException("You didn't create database.");
        }
    }

    public void CloseConnection()
    {
        if (npgsqlConnection is not null){
            if (npgsqlConnection.State == System.Data.ConnectionState.Open)
            {
                npgsqlConnection.Close();
            }
        }
        else
        {
            throw new ArgumentException("You didn't create database.");
        }
    }

    public void AddTask(MyTask task)
    {
        OpenConnection();

        const string insertQuery = "INSERT INTO tasks (id, taskstatus, time, name, comment, timewhenremind) VALUES (@id, @taskstatus, @time, @name, @comment, @timewhenremind)";

        using var command = new NpgsqlCommand(insertQuery, npgsqlConnection);
        command.Parameters.AddWithValue("@id", task.Id);
        command.Parameters.AddWithValue("@taskstatus", task.TaskStatus);
        command.Parameters.AddWithValue("@time", task.Time);
        command.Parameters.AddWithValue("@name", task.Name);
        command.Parameters.AddWithValue("@comment", task.Comment);
        command.Parameters.AddWithValue("@timewhenremind", task.TimeWhenRemind);

        command.ExecuteNonQuery();
        CloseConnection();
    }
}