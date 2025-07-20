using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class TaskItem
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public override string ToString()
    {
        return $"{(IsCompleted ? "[X]" : "[ ]")} {Description}";
    }

    public string ToFileString()
    {
        return $"{IsCompleted}|{Description.Replace("|", "||")}"; 
    }

    public static TaskItem FromFileString(string line)
    {
        var parts = line.Split(new[] { '|' }, 2);
        if (parts.Length == 2 && bool.TryParse(parts[0], out bool isCompleted))
        {
            return new TaskItem
            {
                IsCompleted = isCompleted,
                Description = parts[1].Replace("||", "|")
            };
        }
        return null;
    }
}

class Program
{
    private static readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.txt");
    private static List<TaskItem> _tasks = new List<TaskItem>();

    static void Main()
    {
        LoadTasks();

        while (true)
        {
            Console.Clear();
            DisplayMenu();

            Console.Write("Escolha uma opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
                    Console.WriteLine("Saindo do gerenciador de tarefas. Até mais!");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Por favor, escolha uma opção entre 1 e 5.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("=== GERENCIADOR DE TAREFAS ===");
        Console.WriteLine("1. Listar tarefas");
        Console.WriteLine("2. Adicionar tarefa");
        Console.WriteLine("3. Marcar como concluída");
        Console.WriteLine("4. Remover tarefa");
        Console.WriteLine("5. Sair");
        Console.WriteLine("------------------------------");
    }

    static void AddTask()
    {
        Console.Write("Digite a descrição da nova tarefa: ");
        string description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("A descrição da tarefa não pode ser vazia.");
            return;
        }

        _tasks.Add(new TaskItem { Description = description.Trim(), IsCompleted = false });
        SaveTasks();
        Console.WriteLine($"Tarefa \"{description.Trim()}\" adicionada com sucesso!");
    }

    static void ListTasks()
    {
        Console.WriteLine("\n--- SUAS TAREFAS ---");
        if (!_tasks.Any())
        {
            Console.WriteLine("Nenhuma tarefa encontrada. Que tal adicionar uma?");
            return;
        }

        for (int i = 0; i < _tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_tasks[i]}");
        }
    }

    static void CompleteTask()
    {
        ListTasks();
        if (!_tasks.Any()) return;

        Console.Write("\nDigite o NÚMERO da tarefa para marcar como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int index) && IsValidTaskIndex(index))
        {
            if (_tasks[index - 1].IsCompleted)
            {
                Console.WriteLine("Esta tarefa já está marcada como concluída!");
            }
            else
            {
                _tasks[index - 1].IsCompleted = true;
                SaveTasks();
                Console.WriteLine($"Tarefa \"{_tasks[index - 1].Description}\" marcada como concluída!");
            }
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Por favor, digite um número da lista.");
        }
    }

    static void RemoveTask()
    {
        ListTasks();
        if (!_tasks.Any()) return;

        Console.Write("\nDigite o NÚMERO da tarefa para remover: ");
        if (int.TryParse(Console.ReadLine(), out int index) && IsValidTaskIndex(index))
        {
            string removedDescription = _tasks[index - 1].Description;
            _tasks.RemoveAt(index - 1);
            SaveTasks();
            Console.WriteLine($"Tarefa \"{removedDescription}\" removida com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Por favor, digite um número da lista.");
        }
    }

    static void SaveTasks()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var task in _tasks)
                {
                    writer.WriteLine(task.ToFileString());
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao salvar as tarefas: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro inesperado ao salvar: {ex.Message}");
        }
    }

    static void LoadTasks()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("Arquivo de tarefas não encontrado. Um novo será criado ao salvar.");
            return;
        }

        try
        {
            _tasks.Clear();
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var task = TaskItem.FromFileString(line);
                if (task != null)
                {
                    _tasks.Add(task);
                }
                else
                {
                    Console.WriteLine($"Atenção: Linha inválida no arquivo de tarefas ignorada: '{line}'");
                }
            }
            Console.WriteLine($"Tarefas carregadas com sucesso: {_tasks.Count} tarefas.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao carregar as tarefas: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro inesperado ao carregar: {ex.Message}");
        }
    }

    static bool IsValidTaskIndex(int index)
    {
        return index > 0 && index <= _tasks.Count;
    }
}