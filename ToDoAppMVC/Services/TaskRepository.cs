using Dapper;
using Microsoft.Data.SqlClient;
using ToDoAppMVC.Entities;
using ToDoAppMVC.Models;

namespace ToDoAppMVC.Services
{
    public interface ITaskRepository
    {
        void Add(CreateTaskViewModel task);
        Task<IEnumerable<Task>> GetAllTasks();
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly string ConnectionString;
        public TaskRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultDatabase");
        }
        public void Add(CreateTaskViewModel task)
        {
            using var connection = new SqlConnection(ConnectionString);
            var id = connection.QuerySingle<int>(
                $@"INSERT INTO Task (Title, Description) VALUES ('{task.Title}', '{task.Description}');" +
                $@"SELECT SCOPE_IDENTITY()");
        }
        public Task<IEnumerable<Task>> GetAllTasks()
        {
            throw new NotImplementedException();
        }
    }
}
