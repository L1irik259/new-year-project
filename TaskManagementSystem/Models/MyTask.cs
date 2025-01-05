using TaskManagementSystem.Interfaces;

namespace TaskManagementSystem.Models;

public class MyTask : IMyTask 
{
    public int Id { get; set; }

    /// <summary>
    /// Статус задачи, определяющий текущее состояние выполнения.
    /// </summary>
    /// <remarks>
    /// Возможные значения:
    /// <list type="number">
    /// <item>
    /// <description>1 - Задача в работе.</description>
    /// </item>
    /// <item>
    /// <description>2 - Задача завершилась.</description>
    /// </item>
    /// <item>
    /// <description>3 - Задача ожидает выполнения.</description>
    /// </item>
    /// </list>
    /// </remarks>
    public int TaskStatus { get; set; }

    public DateTime Time { get; set; }

    public string? Name { get; set; } = null;

    public string? Comment { get; set; } = null;

    public DateTime? TimeWhenRemind { get; set; }
}