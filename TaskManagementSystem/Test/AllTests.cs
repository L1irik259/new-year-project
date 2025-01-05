using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;
using Xunit;
using Task = TaskManagementSystem.Models.MyTask;

namespace Test.Tests;

public class Test1
{
    [Fact]
    public void Check_Creature()
    {
        DateTime specificDate = new DateTime(2015, 7, 20, 18, 30, 25);
        Task task = (Task)new TaskBuilder().WithTime(specificDate).WithName("Math").WithComment("sdf").WithTimeWhenRemind(specificDate);

        // Act

        Assert.Equal("Math", task.Name);
    }
}