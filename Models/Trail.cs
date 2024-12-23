using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;
using ParkService.Data;

namespace ParkService.Models
{
    public class Trail
    {
        [ID]
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Park Park { get; set; }
        // miles
        public required double Length { get; set; }
        
        [ReferenceResolver]
        public static Trail? ResolveReference(
            int id,
            IParkRepository parkRepository
        )
        {
            return parkRepository.GetTrail(id);
        }
    }
}