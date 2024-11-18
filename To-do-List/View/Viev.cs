using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_do_List.ViewModel;

namespace To_do_List.View;

internal class Viev
{
    public async Task Show()
    {
        while (true)
        {
            Console.Clear();

            VievModel vievModel = new VievModel();
            Console.WriteLine("To-Do-List 'Bazuzba.DB");

            Console.WriteLine(" ");

            Console.WriteLine("1: Добавить новое задание !");
            Console.WriteLine("2: Изменить статус задания !");
            Console.WriteLine("3: Посмотреть задания !");
            Console.WriteLine("4: Удалить все задачи !");

            Console.WriteLine(" ");

            if (int.TryParse(Console.ReadLine(), out int val))
            {
                switch (val)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Добавьте новое задание !");
                            string tasck = Console.ReadLine();

                            Console.WriteLine("Укажите срок выполнения (В днях)!");
                            if (int.TryParse(Console.ReadLine(), out int day))
                            {
                                if (!string.IsNullOrWhiteSpace(tasck))
                                {
                                    await vievModel.AddTask(tasck, DateTime.Now, DateTime.Now.AddDays(day), false);
                                    Console.WriteLine("Новое задание успешно добавлено");
                                }
                                else
                                {
                                    Console.WriteLine("Введены пустые значения");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Введены некорректные значения !");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите задание для изменения его статуса!");
                            await vievModel.ShowTasksAndUpdateStatus();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Все ваши задачи !");
                            Console.WriteLine(" ");

                            var size = await vievModel.GetAllTasck();

                            foreach (var c in size)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine($"Задача:{c.Task}. Дата начала выполнения: {c.dateTime}. Дата окончания выполнения: {c.DueDate}. Состояние задачи: {c.IsCompleted}.");
                                Console.WriteLine(" ");
                            }
                            Console.ReadKey();
                            break;

                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("удаляю все задачи");

                            await vievModel.RemoveAllTasck();

                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Введите число, которое указано в начале параметров !");
            }
        }
    }
}
