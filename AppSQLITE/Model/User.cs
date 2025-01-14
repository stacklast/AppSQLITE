using SQLite;
namespace AppSQLITE.Model
{
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20), Unique]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }
    }
}
