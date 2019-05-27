using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace WoozyTune
{
    class Repository : IRepository
    {

        private string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";

        public int FindUser(string login, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("FindUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@login", Value = login });
                command.Parameters.Add(new SqlParameter { ParameterName = "@password", Value = password.GetHashCode() });
                var result = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                command.Parameters.Add(result);
                command.ExecuteNonQuery();

                return (int)result.Value;
            }
        }

        public int CreateUser(string login, string password, int age, string gender, string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("CreateUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@login", Value = login });
                command.Parameters.Add(new SqlParameter { ParameterName = "@password", Value = password.GetHashCode() });
                command.Parameters.Add(new SqlParameter { ParameterName = "@age", Value = age });
                command.Parameters.Add(new SqlParameter { ParameterName = "@gender", Value = gender });
                command.Parameters.Add(new SqlParameter { ParameterName = "@username", Value = username });
                var result = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                command.Parameters.Add(result);

                command.ExecuteNonQuery();

                return (int)result.Value;
            }
        }

        public string GetUsername()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("GetUsername", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = CurrentUser.UserId });
                var result = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.NVarChar, Size = -1, Direction = ParameterDirection.Output};
                command.Parameters.Add(result);
                command.ExecuteNonQuery();

                return (string)result.Value;
            }
        }

        public void UploadTrack(int playlistId, string artist, string title, string path, string imagePath, string genre)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UploadTrack", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@playlistId", Value = playlistId });
                command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = CurrentUser.UserId });
                command.Parameters.Add(new SqlParameter { ParameterName = "@artist", Value = artist });
                command.Parameters.Add(new SqlParameter { ParameterName = "@title", Value = title });
                command.Parameters.Add(new SqlParameter { ParameterName = "@path", Value = path});
                command.Parameters.Add(new SqlParameter { ParameterName = "@imagePath", Value = imagePath });
                command.Parameters.Add(new SqlParameter { ParameterName = "@genre", Value = genre });
                command.ExecuteNonQuery();
            }
        }

        public int UploadPlaylist(string artist, string title, string imagePath, string type, string genre)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UploadPlaylist", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@artist", Value = artist });
                command.Parameters.Add(new SqlParameter { ParameterName = "@title", Value = title });
                command.Parameters.Add(new SqlParameter { ParameterName = "@imagePath", Value = imagePath });
                command.Parameters.Add(new SqlParameter { ParameterName = "@type", Value = type });
                command.Parameters.Add(new SqlParameter { ParameterName = "@genre", Value = genre});
                var result = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                command.Parameters.Add(result);
                command.ExecuteNonQuery();

                return (int)result.Value;
            }

        }

        public void AddHistory(int trackId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("AddHistory", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = CurrentUser.UserId });
                command.Parameters.Add(new SqlParameter { ParameterName = "@trackId", Value = trackId });
                command.ExecuteNonQuery();
            }
        }

        public (int[], string[]) GetUsersToFollow()
        { 
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT [UserId], [Username] FROM UsersData WHERE [UserId] != {CurrentUser.UserId}";
                var command = new SqlCommand(select, connection);
                var reader = command.ExecuteReader();

                var usersId = new List<int>();
                var usernames = new List<string>();
                while (reader.Read())
                {
                    usersId.Add((int)reader.GetValue(0));
                    usernames.Add(reader.GetString(1));
                }

                return (usersId.ToArray(), usernames.ToArray());
            }
        }

        public void AddFollow(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("AddFollow", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@followerId", Value = CurrentUser.UserId });
                command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = userId });
                command.ExecuteNonQuery();
            }
        }

        public void DropFollow(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DropFollow", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@followerId", Value = CurrentUser.UserId });
                command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = userId });
                command.ExecuteNonQuery();
            }
        }

        public int CheckForFollow(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("CheckForFollow", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@followerId", Value = CurrentUser.UserId });
                command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = userId });
                var result = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                command.Parameters.Add(result);
                command.ExecuteNonQuery();

                return (int)result.Value;
            }
        }
    }
}
