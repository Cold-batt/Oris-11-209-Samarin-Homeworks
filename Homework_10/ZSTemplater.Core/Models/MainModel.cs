namespace ZSTemplater.Core.Models;

public class MainModel
{
    /// <summary>
    /// Полное Имя
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Баллы
    /// </summary>
    public int Balls { get; set; }
    
    /// <summary>
    /// Список остальных студентов
    /// </summary>
    public List<Student> Students { get; set; }
    
    /// <summary>
    /// Список посещений
    /// </summary>
    public List<Visit> Visits { get; set; }
}