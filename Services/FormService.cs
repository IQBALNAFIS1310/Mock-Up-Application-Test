using bodata_calon_karyawan.Interface.ViewModels;
using bodata_calon_karyawan.Models.Data;
using bodata_calon_karyawan.Models.Db;
using bodata_calon_karyawan.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bodata_calon_karyawan.Services
{
    public class FormService : IFormService
    {
        private readonly ApplicationDbContext _context;

        public FormService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BiodataFormVM?> GetFormAsync(Guid userId)
        {
            var biodata = await _context.Biodata
                .Include(x => x.PendidikanList)
                .Include(x => x.PelatihanList)
                .Include(x => x.PekerjaanList)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (biodata == null)
                return null;

            return new BiodataFormVM
            {
                Biodata = biodata,
                PendidikanList = biodata.PendidikanList.ToList(),
                PelatihanList = biodata.PelatihanList.ToList(),
                PekerjaanList = biodata.PekerjaanList.ToList()
            };
        }

        public async Task<bool> HasBiodataAsync(Guid userId)
        {
            return await _context.Biodata
                .AnyAsync(x => x.UserId == userId);
        }

        public async Task SaveAsync(BiodataFormVM vm, Guid userId)
        {
            // User hanya boleh membuat biodata satu kali
            if (await HasBiodataAsync(userId))
            {
                throw new Exception("Biodata sudah pernah dibuat.");
            }

            vm.Biodata.Id = Guid.NewGuid();
            vm.Biodata.UserId = userId;

            if (vm.Biodata.TanggalLahir.HasValue)
            {
                vm.Biodata.TanggalLahir = DateTime.SpecifyKind(
                    vm.Biodata.TanggalLahir.Value,
                    DateTimeKind.Unspecified);
            }

            _context.Biodata.Add(vm.Biodata);

            foreach (var item in vm.PendidikanList)
            {
                if (string.IsNullOrWhiteSpace(item.Jenjang) &&
                    string.IsNullOrWhiteSpace(item.NamaInstitusi) &&
                    string.IsNullOrWhiteSpace(item.Jurusan) &&
                    item.TahunLulus == 0 &&
                    (item.Ipk == null || item.Ipk == 0))
                {
                    continue;
                }

                item.Id = Guid.NewGuid();
                item.BiodataId = vm.Biodata.Id;

                _context.Pendidikan.Add(item);
            }

            foreach (var item in vm.PelatihanList)
            {
                if (string.IsNullOrWhiteSpace(item.NamaKursus) &&
                    item.Tahun == 0)
                {
                    continue;
                }

                item.Id = Guid.NewGuid();
                item.BiodataId = vm.Biodata.Id;

                _context.Pelatihan.Add(item);
            }

            foreach (var item in vm.PekerjaanList)
            {
                if (string.IsNullOrWhiteSpace(item.NamaPerusahaan) &&
                    string.IsNullOrWhiteSpace(item.PosisiTerakhir) &&
                    (item.PendapatanTerakhir == null || item.PendapatanTerakhir == 0) &&
                    item.Tahun == 0)
                {
                    continue;
                }

                item.Id = Guid.NewGuid();
                item.BiodataId = vm.Biodata.Id;

                _context.Pekerjaan.Add(item);
            }

            await _context.SaveChangesAsync();
        }
    }
}