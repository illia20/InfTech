using System.IO;
using System.Text.Json;

namespace DBMS.Core
{
    class FileLoader
    {
        private readonly string dbFilesExtension = "tdb";

        public void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public bool SaveDatabaseOnDrive(string pathToTheDriveDirectory, Database database)
        {
            if (!Directory.Exists(pathToTheDriveDirectory))
            {
                Directory.CreateDirectory(pathToTheDriveDirectory);
            }
            var options = new JsonSerializerOptions { WriteIndented = true };

            string fileName = $"{database.GetName()}.{dbFilesExtension}";
            string jsonString = JsonSerializer.Serialize(database, options);
            File.WriteAllText($"{pathToTheDriveDirectory}{fileName}", jsonString);
            return true;
        }

        public Database LoadDatabaseFromDrive(string path, string databaseName)
        {
            string fileName = $"{databaseName}.{dbFilesExtension}";
            string jsonString = File.ReadAllText($"{path}{fileName}");
            Database databaseFromDrive = JsonSerializer.Deserialize<Database>(jsonString);
            return databaseFromDrive;
        }
    }
}
