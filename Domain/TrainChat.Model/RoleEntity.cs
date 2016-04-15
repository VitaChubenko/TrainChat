namespace TrainChat.Model
{
    public class RoleEntity : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<UserEntity> Users { get; set; }

        //public RoleEntity()
        //{
        //    Users = new List<UserEntity>();
        //}
    }
}
