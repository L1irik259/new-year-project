using TaskManagementSystem.Interfaces;

namespace TaskManagementSystem.Models;

public class TaskBuilder : IMyTaskBuilder
{
    private MyTask NowTask { get; set; } = new MyTask();
    private int GlobalTaskId = 1;

    public IMyTaskBuilder WithId()
    {
        NowTask.Id = GlobalTaskId++;
        return this;
    }

    public IMyTaskBuilder WithTaskStatus(int _taskStatus)
    {
        NowTask.TaskStatus = _taskStatus;
        return this;
    }

    public IMyTaskBuilder WithTime(DateTime _date)
    {
        NowTask.Time = _date;
        return this;
    }

    public IMyTaskBuilder WithName(string _name)
    {
        NowTask.Name = _name;
        return this;
    }

    public IMyTaskBuilder WithComment(string _name)
    {
        NowTask.Comment = _name;
        return this;
    }

    public IMyTaskBuilder WithTimeWhenRemind(DateTime _timeWhenRemind)
    {
        NowTask.TimeWhenRemind = _timeWhenRemind;
        return this;
    }

    public MyTask GetResult()
    {
        return NowTask;
    }
}