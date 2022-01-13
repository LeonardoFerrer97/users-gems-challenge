using System;
namespace User_gems_challenge_interface_repository.Infraestruture
{
    public interface IPartsQryGenerator<TEntity> where TEntity : class
    {
        string GenerateSelect();
        string GenerateSelect(object fieldsFilter);
        string GeneratePartInsert(string identityField = null);
        string GenerateDelete(object parameters);
        string GenerateUpdate(object pks);
    }
}
