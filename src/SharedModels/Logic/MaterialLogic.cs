using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;

namespace SharedModels.Logic
{
    public class MaterialLogic
    {
        private readonly IMaterialContext _contextMaterial;
        private readonly IMaterialTypeContext _contextMaterialType;
        private readonly IGuestContext _contextGuest;


        public MaterialLogic()
        {
            _contextGuest = new GuestOracleContext();
            _contextMaterial = new MaterialOracleContext();
            _contextMaterialType = new MaterialTypeOracleContext();
        }
    }
}