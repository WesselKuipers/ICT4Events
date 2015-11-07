using System;
using System.Collections.Generic;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IMaterialTypeContext : IRepositoryContext<MaterialType>
    {
        List<MaterialType> GetAll();
        MaterialType GetById(object id);
        MaterialType GetByName(string name);
        MaterialType Insert(MaterialType entity);
        bool Update(MaterialType entity);
        bool Delete(MaterialType entity);
        }
}