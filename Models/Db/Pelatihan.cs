namespace bodata_calon_karyawan.Models.Db
{
    public class Pelatihan
    {
        public Guid Id { get; set; }

        public Guid BiodataId { get; set; }

        public string NamaKursus { get; set; }

        public bool Sertifikat { get; set; }

        public int Tahun { get; set; }

        public Biodata Biodata { get; set; }
    }
}
