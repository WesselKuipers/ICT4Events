using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace ICT4EventsTests.Data
{
    public class MaterialTypeMemoryContext : IMaterialTypeContext
    {
        private List<MaterialType> _materialTypes = new List<MaterialType>();

        public List<MaterialType> GetAll()
        {
            return _materialTypes;
        }

        public MaterialType GetById(object id)
        {
            return _materialTypes.FirstOrDefault(m => m.ID == (int) id);
        }

        public MaterialType Insert(MaterialType entity)
        {
            if (GetById(entity.ID) != null) return null;

            var id = _materialTypes.Max(e => e.ID);
            var materialType = new MaterialType(id, entity.Name);
            _materialTypes.Add(materialType);

            return materialType;
        }

        public bool Update(MaterialType entity)
        {
            var materialType = _materialTypes.FirstOrDefault(e => e.ID == entity.ID);
            if (materialType == null) return false;

            _materialTypes.Remove(materialType);
            _materialTypes.Add(entity);
            return true;
        }

        public bool Delete(MaterialType entity)
        {
            var materialType = _materialTypes.FirstOrDefault(e => e.ID == entity.ID);
            if (materialType == null) return false;

            _materialTypes.Remove(materialType);
            return true;
        }
    }
}
