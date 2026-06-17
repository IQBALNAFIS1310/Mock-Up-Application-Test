using bodata_calon_karyawan.Models.ViewModels;

namespace bodata_calon_karyawan.Interface
{
    public interface IAdminService
    {
        Task<List<BiodataFormVM>> GetAllAsync();

        Task<BiodataFormVM?> GetByIdAsync(Guid id);

        Task UpdateAsync(BiodataFormVM vm);

        Task DeleteAsync(Guid id);
    }
}