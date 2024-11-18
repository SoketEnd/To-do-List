using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List.Migrations.ModelDB;

internal class Model
{
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Task { get; set; }
    public DateTime dateTime { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }

    public Model(string Task, DateTime dateTime, DateTime? DueDate, bool IsCompleted)
    {
        Id = Guid.NewGuid();
        this.Task = Task;
        this.dateTime = dateTime;
        this.DueDate = DueDate;
        this.IsCompleted = IsCompleted;
    }
    public Model() { }
}
