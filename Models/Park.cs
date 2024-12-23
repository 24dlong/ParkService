
using HotChocolate;
using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;
using ParkService.Data;

namespace ParkService.Models
{
    public class Park
    {
        [ID]
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        
        [ReferenceResolver]
        public static Park? ResolveReference(
            int id,
            IParkRepository parkRepository
        )
        {
            return parkRepository.GetPark(id);
        }
    }
}