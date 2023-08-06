namespace YaChitay.Entities.Dto
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Photo { get; set; }

        public PhotoDto(int id, string photo) {
            Id = id;
            Photo = photo;
        }
    }
}
