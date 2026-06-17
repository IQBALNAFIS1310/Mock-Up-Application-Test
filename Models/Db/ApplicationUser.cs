namespace bodata_calon_karyawan.Models.Db
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } = "User";

        public ICollection<Biodata> Biodatas { get; set; }
    }
}
