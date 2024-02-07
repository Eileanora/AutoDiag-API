// using IntelligentDiagnostics.BL.Dtos.CarSystemsDTOs;
// using IntelligentDiagnostics.DAL.Repositories.SystemRepository;
// using IntelligentDiagnostics.DAL.Repositories.UserRepository;
//
// namespace IntelligentDiagnostics.BL.Manager.CarSystemManager;
//
// public class CarSystemManager : ICarSystemManager
// {
//     private readonly ICarSystemRepository _carSystemRepository;
//     private readonly IUserRepository _userRepository;
//     public CarSystemManager(ICarSystemRepository carSystemRepository)
//     {
//         _carSystemRepository = carSystemRepository;
//     }
//     
//     public async Task<IEnumerable<CarSystemDto>> GetAllAsync()
//     {
//         var systems = await _carSystemRepository.GetAllAsync();
//         
//     }
//
//     public async Task<CarSystemDtoWithSensors> GetById();
//     {
//         throw new NotImplementedException();
//     }
// }
