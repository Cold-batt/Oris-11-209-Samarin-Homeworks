namespace ZSTemplater.Core;


public static class Program
{
    public static void Main(string[] args)
    {
        var template = """Здравствуйте, @{fullname}. """ + 
                       """Ваша успеваемость на @if(balls >30 ) @then{ хорошем} @else{плохом} уровне. """ + 
                       """Ваш средний балл @{balls}. """ + 
                       """Меньше чем у студентов: @for(student in students) {@{student.surname} @{student.name}}.""" + 
                       """ Вы @if(visits< 10) @then{отчислены} @else{получите автомат}” как студенты """ + 
                       """ @for(student in students) """ + 
                       """{@if(visits< 10) @then{@{student.surname} @{student.name}}. @else{@{student.surname} @{student.name}}.}""";
        var a = new Parser(template);
        a.Parse(template);
    }
}