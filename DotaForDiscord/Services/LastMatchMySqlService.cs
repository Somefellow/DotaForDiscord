using DotaForDiscord.Exceptions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DotaForDiscord.Services
{
    internal class LastMatchMySqlService : ILastMatchService
    {
        // CREATE TABLE `lastmatch` ( `id` INT NOT NULL , `matchid` BIGINT NOT NULL , `name` VARCHAR(100) , PRIMARY KEY (`id`)) ENGINE = InnoDB;
        private readonly string connectionString;

        public LastMatchMySqlService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long GetLastMatch(int id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT `matchid` FROM `lastmatch` WHERE `id`=@id", connection);
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                return reader.GetInt64(0);
            }
            else
            {
                throw new NotTrackedException(id);
            }
        }

        public int[] GetTrackedIds()
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT `id` FROM `lastmatch`", connection);
            using var reader = command.ExecuteReader();
            var ids = new List<int>();

            while (reader.Read())
            {
                ids.Add(reader.GetInt32(0));
            }

            return ids.ToArray();
        }

        public void SetLastMatch(int id, long lastMatchId)
        {
            var lastMatch = GetLastMatch(id);

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("UPDATE `lastmatch` SET `matchid`=@lastMatchId WHERE `id`=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@lastMatchId", lastMatchId);

            command.ExecuteNonQuery();
        }

        public void TrackId(int id)
        {
            var lastMatch = GetLastMatch(id);

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("INSERT INTO `lastmatch`(`id`, `matchid`) VALUES (@id,0)", connection);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public void SetName(int id, string name)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("UPDATE `lastmatch` SET `name`=@name WHERE `id`=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);

            command.ExecuteNonQuery();
        }
    }
}