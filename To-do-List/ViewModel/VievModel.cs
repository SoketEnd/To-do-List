using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using To_do_List.Migrations.Migration;
using To_do_List.Migrations.ModelDB;

namespace To_do_List.ViewModel;

internal class VievModel
{
    public async Task AddTask(string task, DateTime dateTime, DateTime? DueData, bool isCompleted = false)
    {
        using (AppDBContext app = new())
        {

            var newTask = new Model
            {
                Task = task,
                dateTime = dateTime,
                DueDate = DueData,
                IsCompleted = isCompleted
            };


            await app.Models.AddAsync(newTask);
            await app.SaveChangesAsync();
        }
    }

    public async Task ShowTasksAndUpdateStatus()
    {
        using (AppDBContext app = new())
        {
            var tasck = await app.Models.ToListAsync();

            if (tasck.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }

            Console.WriteLine("Список задач! ");
            for (int i = 0; i < tasck.Count; i++)
            {
                var c = tasck[i];
                Console.WriteLine(" ");
                Console.WriteLine($"№{i + 1}: Задача: {c.Task}. " +
                    $"Дата начала выполнения: {c.dateTime}. " +
                    $"Дата окончания выполнения: {c.DueDate}. " +
                    $"Состояние задачи: {c.IsCompleted}.");
                Console.WriteLine(" ");
            }

            Console.WriteLine("\nВведите номер задачи, чтобы изменить её статус (или нажмите Enter для выхода):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int taskNumber) && taskNumber > 0 && taskNumber <= tasck.Count)
            {
                var selectedTask = tasck[taskNumber - 1];

                if (selectedTask.IsCompleted)
                {
                    Console.WriteLine("Данная задача уже выполнена");
                }else
                {
                    selectedTask.IsCompleted = true;
                    app.Models.Update(selectedTask);
                    await app.SaveChangesAsync();
                    Console.WriteLine($"Статус задачи \"{selectedTask.Task}\" успешно изменён на \"Выполнено\".");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод данных");
            }


        }
    }

    public async Task<List<Model>> GetAllTasck()
    {
        using (AppDBContext App = new())
        {
            return await App.Models.ToListAsync();
        }
    }
    public async Task RemoveAllTasck()
    {
        using (AppDBContext App = new())
        {
            var ApiZd = await App.Models.ToListAsync();
            App.Models.RemoveRange(ApiZd);
            await App.SaveChangesAsync();
        }
    }
}
