namespace TaskManagementSystem.Interfaces;

public interface IMyTask
{
    int Id { get; set; }

    int TaskStatus { get; set; }

    DateTime Time { get; set; }

    string? Name { get; set; }

    string? Comment { get; set; }

    DateTime? TimeWhenRemind { get; set; }
}