using System.ComponentModel.DataAnnotations;

namespace EventinoApi.Models.Out
{
    public class OutExternalLoginInfo
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string OIdProviderName { get; set; }
        public string OId { get; set; }
    }
}
