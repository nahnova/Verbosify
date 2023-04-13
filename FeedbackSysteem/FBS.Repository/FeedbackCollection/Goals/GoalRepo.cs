﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FBS.DataAccess;

namespace FBS.Repository
{

    public class GoalRepo

    {
        private FeedbackCollectionDBDataAccess iDB { get; set; }

        public GoalRepo()

        {
            this.iDB = new FeedbackCollectionDBDataAccess();
        }
        public List<Goal> goals = new List<Goal>();


        //Add Goal
        public void AddGoal(int id, int studentId, string priority, string goal, string time)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string sql = "INSERT INTO Goal (id,studentID,priority,goal,time) VALUES(@id,@studentID,@priority,@goal,@time)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@studentID", studentId);
                    cmd.Parameters.AddWithValue("@priority", priority);
                    cmd.Parameters.AddWithValue("@goal", goal);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.Dispose(); }
        }

        /*==========Get the list of goals from the database==========*/
        public void GetGoalsFromDatabase()
        {
            goals.Clear();

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cnn.ConnectionString = connectionString;
                    cnn.Open();
                    cmd.Connection = cnn;
                    cmd.CommandText = "SELECT id,studentID,priority,goal,time FROM Goal ORDER BY id";
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            goals.Add(new Goal(
                            Int32.Parse(dataReader[0].ToString()),  // set the ID property of the Goal object to the first value in the dataReader array, converted to an integer
                            Int32.Parse(dataReader[1].ToString()),  // set the CategoryID property of the Goal object to the second value in the dataReader array, converted to an integer
                            dataReader[2].ToString(),               // set the Description property of the Goal object to the third value in the dataReader array, as a string
                            dataReader[3].ToString(),               // set the CompletionDate property of the Goal object to the fourth value in the dataReader array, as a string
                            dataReader[4].ToString()                // set the Completed property of the Goal object to the fifth value in the dataReader array, as a string, which will be converted to a boolean value later
                            ));
                        }
                    }
                }
            }
        }

        /*==========Get a single goal from the database==========*/
        public Goal GetSingleGoalByID(int id)
        {
            Goal goal = new Goal(0, 0, "", "", "");

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cnn.ConnectionString = connectionString;
                    cnn.Open();
                    cmd.Connection = cnn;
                    cmd.CommandText = "SELECT id,studentID,priority,goal,time FROM Goal WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            goal.ID = Int32.Parse(dataReader[0].ToString());
                            goal.studentID = Int32.Parse(dataReader[1].ToString());
                            goal.priority = dataReader[2].ToString();
                            goal.goal = dataReader[3].ToString();
                            goal.time = dataReader[4].ToString();
                        }
                    }
                }
            }
            return goal;
        }

        //Delete Goal
        public void DeleteGoal(int id)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string sql = "DELETE Goal WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { connection.Dispose(); }
        }

        // Update Goal
        public void UpdateGoal(int id, int studentId, string priority, string goal, string time)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string sql = "UPDATE Goal SET id = @id,studentID= @studentID,priority = @priority,goal= @goal,time = @time WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@studentID", studentId);
                    cmd.Parameters.AddWithValue("@priority", priority);
                    cmd.Parameters.AddWithValue("@goal", goal);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { connection.Dispose(); }
        }
    }
}
