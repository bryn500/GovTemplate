using DfESurveyTool.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DfESurveyTool.Data.Models
{
    public class MyModel
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; private set; }

        public MyModelStatusId MyModelStatusId { get; private set; }
        public MyModelStatus Status { get; private set; }

        public DateTimeOffset LastUpdated { get; private set; }

        public MyModel()
        {
            ModelChanged();
        }

        public MyModel(string name, MyModelStatusId status) : this()
        {
            Name = name;
            MyModelStatusId = status;
        }

        public void ProcessMyModel(MyModelStatusId status)
        {
            MyModelStatusId = status;
            ModelChanged();
        }

        private void ModelChanged()
        {
            LastUpdated = DateTimeOffset.Now;
        }
    }
}
