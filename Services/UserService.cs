using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MoneyManager.Models;
using System.Runtime.CompilerServices;
namespace MoneyManager.Services

{
    //to manage user operations such as saving, loading users, and password hashing.
    internal class UserService : IUserService
    {
        private readonly string usersFilePath = Path.Combine(AppContext.BaseDirectory, "UserDetails.json");// Path for storing user details in a JSON file
        // Asynchronously saves a new user by hashing their password before storing
        public async Task SaveUserAsync(User user)
        {
            try
            {
                var users = await LoadUsersAsync();

                // Hash the user's password
                user.Password = HashPassword(user.Password);

                users.Add(user);
                await SaveUsersAsync(users);// Save the updated list of users to the file
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
                throw;
            }
        }
        // Asynchronously loads all users from the JSON file
        public async Task<List<User>> LoadUsersAsync()
        {
            try
            {
                if (!File.Exists(usersFilePath))
                {
                    return new List<User>();
                }

                var json = await File.ReadAllTextAsync(usersFilePath);
                return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON deserialization error: {jsonEx.Message}");
                return new List<User>();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading users: {ioEx.Message}");
                return new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while loading users: {ex.Message}");
                return new List<User>();
            }
        }
        // Private  method to save the list of users to the file
        private async Task SaveUsersAsync(List<User> users)
        {
            try
            {
                var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(usersFilePath, json);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading users: {ioEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while saving users: {ex.Message}");
                throw;
            }
        }
        // Private method to hash the user's password using SHA-256
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
