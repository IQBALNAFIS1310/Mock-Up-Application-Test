namespace bodata_calon_karyawan.Models.Db
{
    public class Pendidikan
    {
        public Guid Id { get; set; }

        public Guid BiodataId { get; set; }

        public string Jenjang { get; set; }

        public string NamaInstitusi { get; set; }

        public string Jurusan { get; set; }

        public int TahunLulus { get; set; }

        public decimal? Ipk { get; set; }

        public Biodata Biodata { get; set; }
    }
}
