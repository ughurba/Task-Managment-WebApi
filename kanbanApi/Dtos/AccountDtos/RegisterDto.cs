namespace kanbanApi.Dtos.AccountDtos
{
    public class RegisterDto
    {
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public bool isCreateCompany { get; set; }
        public string CompanySecretCode { get; set; }
    }
}
