using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace TrySigninBlazor.Data
{
    public class ProfileManagement
    {
        public int Id { get; set; }
        public int Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Biography { get; set; }
        public string MissionStatement { get; set; }
        public string Document {  get; set; }
        public byte[] Profile {  get; set; }
    }
}
