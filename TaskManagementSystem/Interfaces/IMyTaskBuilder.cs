using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interfaces;

public interface IMyTaskBuilder
{
    IMyTaskBuilder WithId();

    IMyTaskBuilder WithTaskStatus(int _taskStatus);

    IMyTaskBuilder WithTime(DateTime _time);

    IMyTaskBuilder WithName(string _name);

    IMyTaskBuilder WithComment(string _comment);

    IMyTaskBuilder WithTimeWhenRemind(DateTime _timeWhenRemind);

    public Models.MyTask GetResult();
}