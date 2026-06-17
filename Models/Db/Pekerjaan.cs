namespace bodata_calon_karyawan.Models.Db
{
    public class Pekerjaan
    {
        public Guid Id { get; set; }

        public Guid BiodataId { get; set; }

        public string NamaPerusahaan { get; set; }

        public string PosisiTerakhir { get; set; }

        public decimal? PendapatanTerakhir { get; set; }

        public int Tahun { get; set; }

        public Biodata Biodata { get; set; }
    }
}
