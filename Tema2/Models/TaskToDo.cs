using SQLite;

namespace Tema2.Models;

[Table("TaskToDo")]
public class TaskToDo
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    private string content { get; set; }
    public string Content
    {
        get
        {
            return content;
        }
        set
        {
            content = value;
        }
    }
}

