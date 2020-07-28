using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v2
{
    public class MessageDTO
    {
        public MessageDTO()
        {
            
        }

        public MessageDTO(params string[] messages)
        {
            Messages = messages;
        }
        
        [Required]
        public IList<string> Messages { get; set; } = new List<string>();

        
    }
}