using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }
                
        public int UserId { get; set; }
                
        public int AnswerId { get; set; }
                
        public bool IsSelected { get; set; }
                
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
                
        [ForeignKey("AnswerId")]
        public virtual Answer Answer { get; set; }
    }
}
