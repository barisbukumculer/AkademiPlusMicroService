namespace AkademiPlusMicroService.WebUI.DTOs.RegisterDTOs
{
	public class CreateRegisterDTO
	{
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
