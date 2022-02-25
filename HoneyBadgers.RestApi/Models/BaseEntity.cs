using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyBadgers.RestApi.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
