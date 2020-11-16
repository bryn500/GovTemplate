using DfESurveyTool.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DfESurveyTool.Data.Models
{
    public class MyModelStatus
    {
        [Key]
        public MyModelStatusId Id { get; private set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; private set; }

        public virtual List<MyModel> MyModels { get; set; }

        public MyModelStatus()
        {
        }

        public MyModelStatus(MyModelStatusId status)
        {
            Id = status;
            Name = status.ToString();
        }
    }
}
