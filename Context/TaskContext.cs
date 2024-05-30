using System;
using pr45savichev.Model;
using Microsoft.EntityFrameworkCore;

namespace pr45savichev.Context
{
    public class TaskContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Tasks> Tasks { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public TaskContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=Base44;uid=root;pwd=", new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
