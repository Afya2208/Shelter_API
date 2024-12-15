using WebApplication2.Entities.shorts;

namespace WebApplication2.Entities
{
    public partial class TakingAnimal
    {
        public TakingAnimal()
        {
        }
        public TakingAnimal(TakingAnimalShort @short)
        {
            DateOfTaking = @short.DateOfTaking;
            ClientId = @short.ClientId;
            AnimalId = @short.AnimalId;
        }
    }
}
