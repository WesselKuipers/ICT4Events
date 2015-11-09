using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Models;

namespace ICT4EventsTests.Data
{
    public class MaterialMemoryContext : IMaterialContext
    {
        private List<Material> _materials = new List<Material>(); 

        public List<Material> GetAll()
        {
            return _materials;
        }

        public Material GetById(object id)
        {
            return _materials.FirstOrDefault(m => m.ID == (int) id);
        }

        public Material Insert(Material entity)
        {
            if (GetById(entity.ID) != null) return null;

            var id = _materials.Max(e => e.ID);
            var material = new Material(id, entity.Name, entity.EventID, entity.TypeID);
            _materials.Add(material);

            return material;
        }

        public bool Update(Material entity)
        {
            var material = _materials.FirstOrDefault(e => e.ID == entity.ID);
            if (material == null) return false;

            _materials.Remove(material);
            _materials.Add(entity);
            return true;
        }

        public bool Delete(Material entity)
        {
            var material = _materials.FirstOrDefault(e => e.ID == entity.ID);
            if (material == null) return false;

            _materials.Remove(material);
            return true;
        }

        public List<Material> GetAllByEvent(Event ev)
        {
            return _materials.Where(m => m.EventID == ev.ID).ToList();
        }

        public List<Material> GetAllByEventAndNonReserved(Event ev)
        {
            throw new NotImplementedException();
        }

        public List<Material> GetReservedMaterialsByGuest(Guest guest)
        {
            throw new NotImplementedException();
        }

        public List<Material> GetAllReservedMaterials(Event ev)
        {
            throw new NotImplementedException();
        }

        public Material AddReservation(Material material, int guestID, DateTime startDate, DateTime endDate)
        {
            material.GuestID = guestID;
            material.StartDate = startDate;
            material.EndDate = endDate;

            return material;
        }

        public bool UpdateReservation(Material material, DateTime startDate, DateTime endDate)
        {
            if (material.GuestID == 0) return false;

            material.StartDate = startDate;
            material.EndDate = endDate;

            return true;
        }

        public bool RemoveReservation(Material material)
        {
            throw new NotImplementedException();
            //material.GuestID = null;
            //material.StartDate = null;
            //material.EndDate = null;
            //return material;
        }
    }
}
