namespace Books.Data.IdentityViewModels
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public List<RolesViewModel> Roles { get; set; }
    }
}