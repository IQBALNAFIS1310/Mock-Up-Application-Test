using bodata_calon_karyawan.Interface;
using bodata_calon_karyawan.Models.Data;
using bodata_calon_karyawan.Models.Db;
using bodata_calon_karyawan.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bodata_calon_karyawan.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BiodataFormVM>> GetAllAsync()
        {
            return await _context.Biodata
                .Include(x => x.PendidikanList)
                .Select(x => new BiodataFormVM
                {
                    Biodata = x,
                    PendidikanList = x.PendidikanList.ToList()
                })
                .ToListAsync();
        }

        public async Task<BiodataFormVM?> GetByIdAsync(Guid id)
        {
            var biodata = await _context.Biodata
                .Include(x => x.PendidikanList)
                .Include(x => x.PelatihanList)
                .Include(x => x.PekerjaanList)
                .FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task UpdateAsync(BiodataFormVM vm)
        {
            if (vm.Biodata.TanggalLahir.HasValue)
            {
                vm.Biodata.TanggalLahir = DateTime.SpecifyKind(
                    vm.Biodata.TanggalLahir.Value,
                    DateTimeKind.Unspecified);
            }

            _context.Biodata.Update(vm.Biodata);

            var pendidikan = _context.Pendidikan
                .Where(x => x.BiodataId == vm.Biodata.Id);

            var pelatihan = _context.Pelatihan
                .Where(x => x.BiodataId == vm.Biodata.Id);

            var pekerjaan = _context.Pekerjaan
                .Where(x => x.BiodataId == vm.Biodata.Id);

            _context.Pendidikan.RemoveRange(pendidikan);
            _context.Pelatihan.RemoveRange(pelatihan);
            _context.Pekerjaan.RemoveRange(pekerjaan);

            foreach (var item in vm.PendidikanList.Where(x =>
                     !string.IsNullOrWhiteSpace(x.NamaInstitusi)))
            {
                item.Id = Guid.NewGuid();
                item.BiodataId = vm.Biodata.Id;

                _context.Pendidikan.Add(item);
            }

            foreach (var item in vm.PelatihanList.Where(x =>
                     !string.IsNullOrWhiteSpace(x.NamaKursus)))
            {
                item.Id = Guid.NewGuid();
                item.BiodataId = vm.Biodata.Id;

                _context.Pelatihan.Add(item);
            }

            foreach (var item in vm.PekerjaanList.Where(x =>
                     !string.IsNullOrWhiteSpace(x.NamaPerusahaan)))
            {
                item.Id = Guid.NewGuid();
                item.BiodataId = vm.Biodata.Id;

                _context.Pekerjaan.Add(item);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var biodata = await _context.Biodata
                .Include(x => x.PendidikanList)
                .Include(x => x.PelatihanList)
                .Include(x => x.PekerjaanList)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (biodata == null)
                return;

            _context.Pendidikan.RemoveRange(biodata.PendidikanList);
            _context.Pelatihan.RemoveRange(biodata.PelatihanList);
            _context.Pekerjaan.RemoveRange(biodata.PekerjaanList);

            _context.Biodata.Remove(biodata);

            await _context.SaveChangesAsync();
        }
    }
}