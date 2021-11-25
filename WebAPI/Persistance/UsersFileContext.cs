using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WebAPI.Models;

namespace FileData{
    public class UsersFileContext
    {
        public IList<User> Users { get; private set; }
        
        private readonly string usersFile = "users.json";

        public UsersFileContext() {
            Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
        }

        private IList<T> ReadData<T>(string s) {
            using (var jsonReader = File.OpenText(s)) {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges() {
            //storing users
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions {
                WriteIndented = true
            });

            using (StreamWriter outputFile = new StreamWriter(usersFile, false)) {
                outputFile.Write(jsonUsers);
            }
        }
    }
}