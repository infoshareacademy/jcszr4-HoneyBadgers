using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.Logic
{
    public static class FileDataReader
    {
        private const string UsersFilePath = "Resources/users.json";

        private const string MoviesFilePath = "Resources/movies.json";

        public static List<Movie> LoadMovies()
        {
            return LoadData<Movie>(MoviesFilePath);
        }

        private static List<T> LoadData<T>(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException(nameof(filePath));

            try
            {
                var fileText = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(fileText);
            }
            catch (Exception e)
            {
                throw new Exception($"An error has occurred while reading Users records. Ex: {e.Message}");
            }
        }
    }
}
