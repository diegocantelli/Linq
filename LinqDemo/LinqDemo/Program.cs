using System;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] countries = { "Brasil", "India", "EUA", "UK" };

            //Obtendo o menor valor de um array
            int result = numbers.Min();

            //Obtendo o menor dentro os valores pares
            result = numbers.Where(x => x % 2 == 0).Min();

            //a -> 0
            //b -> 1
            //faz com que seja concatenado as posições do array até o último elemento
            //O que foi concatenado, na próxima iteração, volta como sendo o valor do primeiro parâmetro.
            //O Primeiro parâmetro funciona como uma variável acumuladora
            //Resultado -> "Brasil, India, EUA, UK" 
            var aggregate = countries.Aggregate((a, b) => a + ", " + b);

            //É possível passar um parâmetro inicial nesta função, ela será usada como o valor inicial da iteração
            //Resultado -> "Chile, Brasil, India, EUA, UK" 
            var aggregateSeed = countries.Aggregate("Chile ", (a, b) => a + ", " + b);

            // Utilizando a função de projeção SELECT para retornar apenas uma parte do objeto ou até mesmo um novo objeto  
            var employeeId = Employee.GetAllEmployees().Select(x => x.EmployeeId);

            // Utilizando a função de projeção SELECT para retornar um objeto anônimo  
            var employeeData = Employee.GetAllEmployees().Select(x => new { Id = x.EmployeeId, Name = x.FirstName });

            // Utilizando a função de projeção SELECT para retornar um objeto anônimo  e efetuando o cálculo do salário mensal
            var employeeMonthlySalary = Employee.GetAllEmployees()
                .Select(x => new { Id = x.EmployeeId, Name = x.FirstName, MonthlySalary = x.AnnualSalary / 12 });

            // Utilizando a função de projeção SelectMany para obter um único IEnumerable com todas as opções da lista
            // habilidades -> Irá retornar um IEnumerable<string> contendo as habilidades de cada empregado numa mesma lista,
            // que antes estavam agrupadas por empregado
            var habilidades = Employee.GetAllEmployees().SelectMany(x => x.Habilidades);

            //Caso haja valores duplicados no retorno e seja necessário filtrar os duplicados para retornar apenas uma
            // ocorrência, pode se usar o operador Distinct
            var habilidadesDistinct = Employee.GetAllEmployees().SelectMany(x => x.Habilidades).Distinct();

            // Retornando um objeto com base nos dados do objeto original e com base em cada habilidade que foi extraída
            // no SelectMany
            // Para cada habilidade que um operário possuir, será criada uma nova instância desse objeto
            //(empregado, habilidade) -> empregado: objeto original, habilidade: habilidades extraídas via SelectMany
            var habilidadesDistinct2 = Employee.GetAllEmployees().SelectMany(x => x.Habilidades, (empregado, habilidade) =>
                new { EmpregadoNome = empregado.FirstName, Competencia = habilidade }
            ).Distinct();

            foreach (var item in habilidadesDistinct2)
            {
                Console.WriteLine(item.EmpregadoNome + " " + item.Competencia );
            }
            Console.Read();
        }
    }
}
