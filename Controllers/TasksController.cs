using pr45savichev.Context;
using pr45savichev.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace pr45savichev.Controllers
{
    [Route("api/TasksController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TasksController : Controller
    {
        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <remarks>Данный метод получает список задач, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]

        public ActionResult List()
        {
            try
            {
                IEnumerable<Tasks> Tasks = new TaskContext().Tasks;
                return Json(Tasks);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <remarks>Данный метод получает задачу, находящуюся в базе данных</remarks>
        /// <response code="200">Задача успешно получена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                Tasks Task = new TaskContext().Tasks.Where(x => x.Id == Id).First();
                return Json(Task);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод добавления задачи
        /// </summary>
        /// <param name="task">Данные о задачи</param>
        /// <returns>Статус выполнения запроса</returns>
        /// <remarks>Данный метод добавляет задачу в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Tasks task)
        {
            try
            {
                TaskContext tasksContext = new TaskContext();
                tasksContext.Tasks.Add(task);
                tasksContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
