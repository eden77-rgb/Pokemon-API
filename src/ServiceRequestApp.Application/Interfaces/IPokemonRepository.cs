using ServiceRequestApp.Domain.Entities;
namespace ServiceRequestApp.Application.Interfaces;
public interface IPokemonRepository
{
    Task<List<Pokemon>>  GetAllAsync();         // R.etrieve (R) from C.R.U.D
    Task<Pokemon?>       GetByIdAsync(int id);  // GUID R.etrieve (R) from C.R.U.D 
    Task<Pokemon>        AddAsync(Pokemon request); // C.reate (C).R.U.D 
    Task<Pokemon?>       UpdateAsync(Pokemon request); //U.pdate(U) C.R.U.D 
    Task<bool>                  DeleteAsync(int id);                 //D.elete(D) C.R.U.D 
}