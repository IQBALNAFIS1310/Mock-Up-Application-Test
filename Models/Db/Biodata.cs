namespace bodata_calon_karyawan.Models.Db
{
    public class Biodata
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string PosisiDilamar { get; set; }

        public string Nama { get; set; }

        public string NoKtp { get; set; }

        public string TempatLahir { get; set; }

        public DateTime? TanggalLahir { get; set; }

        public string JenisKelamin { get; set; }

        public string Agama { get; set; }

        public string GolonganDarah { get; set; }

        public string Status { get; set; }

        public string AlamatKtp { get; set; }

        public string AlamatTinggal { get; set; }

        public string Email { get; set; }

        public string NoTelp { get; set; }

        public string KontakDarurat { get; set; }

        public string Skill { get; set; }

        public bool BersediaDitempatkan { get; set; }

        public decimal? GajiDiharapkan { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Pendidikan> PendidikanList { get; set; }

        public ICollection<Pelatihan> PelatihanList { get; set; }

        public ICollection<Pekerjaan> PekerjaanList { get; set; }
    }
}
