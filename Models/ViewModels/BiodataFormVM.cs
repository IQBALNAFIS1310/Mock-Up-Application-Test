using bodata_calon_karyawan.Models.Db;

namespace bodata_calon_karyawan.Models.ViewModels
{
    public class BiodataFormVM
    {
        public Biodata Biodata { get; set; } = new();

        public List<Pendidikan> PendidikanList { get; set; } = new();

        public List<Pelatihan> PelatihanList { get; set; } = new();

        public List<Pekerjaan> PekerjaanList { get; set; } = new();
    }
}