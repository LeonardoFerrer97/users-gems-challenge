using System;
namespace User_gems_challenge_interface_repository.Infraestruture
{
    public interface IIDentityInspector<TEntity> where TEntity : class
    {
        string GetColumnsIdentityForType();
    }
}
