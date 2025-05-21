using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace new_app.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; private set; }

        public void SetPassword(string password)
        {
            PasswordHash = HashPassword(password);
        }

        private static string HashPassword(string password)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(password, GenerateSalt(), 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = rfc2898.GetBytes(32);
                return Convert.ToBase64String(hash);
            }
        }

        private static byte[] GenerateSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);
                return salt;
            }
        }
    }
}