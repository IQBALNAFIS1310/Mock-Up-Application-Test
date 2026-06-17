using bodata_calon_karyawan.Models.ViewModels;

namespace bodata_calon_karyawan.Interface.ViewModels
{
    public interface IFormService
    {
        Task<BiodataFormVM?> GetFormAsync(Guid userId);

        Task<bool> HasBiodataAsync(Guid userId);

        Task SaveAsync(BiodataFormVM vm, Guid userId);
    }
}