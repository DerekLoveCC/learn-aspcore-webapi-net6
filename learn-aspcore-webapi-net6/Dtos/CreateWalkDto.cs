namespace learn_aspcore_webapi_net6.Dtos
{
    public class CreateWalkDto
    {
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
