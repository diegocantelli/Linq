using System;
using System.Collections;
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

            //Ordenando os empregados pelo nome de forma ascendente 
            var orderedAscEmployees = Employee.GetAllEmployees().OrderBy(x => x.FirstName);

            //Ordenando os empregados pelo nome de forma descendente 
            var orderedDescEmployees = Employee.GetAllEmployees().OrderByDescending(x => x.FirstName);

            //Ordenando os empregados pelo nome e pelo sobrenome
            //Quando se deseja ordenar utilizando 2 parâmetros, é necessário utilizar os operadores ThenBy ou ThenByDescending
            var orderedThenByEmployees = Employee.GetAllEmployees().OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            // Take -> Irá retornar os n primeiros itens de uma lista
            var employeesTake = Employee.GetAllEmployees().Take(2);

            // Skip -> Irá pular os n primeiros itens de uma lista
            var employeesSkip = Employee.GetAllEmployees().Skip(1).Take(2);

            // TakeWhile -> Irá retornar todos os itens da lista que satisfaçam a condição passada por parâmetro
            var employeesTakeWhile = Employee.GetAllEmployees().TakeWhile(x => x.AnnualSalary > 10000);

            // SkipWhile -> Irá pular todos os itens da lista que satisfaçam a condição passada por parâmetro
            var employeesSkipWhile = Employee.GetAllEmployees().SkipWhile(x => x.AnnualSalary < 10000);

            // Execução tardia -> É referente ao momento em que a instrução é de fato executada.
            // Neste momento existe n empregados na lista
            // mesmo se inserirmos outro empregado na lista após a definição da instrução LINQ, este empregado será
            // retornado na lista
            // Operadores de execução tardia -> Select, Where, Take, Skip...
            var execucaoTardia = from emp in Employee.GetAllEmployees()
                                 select emp;

            // Para forçarmos que a instrução LINQ seja executada na hora, temos que convertê-la para lista(ToList)
            // Assim não irá incluir no resultado empregados que foram incluídos após a definição da instrução LINQ 
            // Operadores de execução imediata -> Count, Average, Min, Max, ToList...
            var execucaoImediata = (from emp in Employee.GetAllEmployees()
                                    select emp).ToList();

            int[] numeros = { 1, 2, 3 };

            //ToList() -> Converte uma sequeência em uma lista
            // Este operador não utiliza execução tardia
            var numerosList = numeros.ToList();


            var empregadosList = Employee.GetAllEmployees().ToList();

            // ToDictionary -> Converte os itens de uma sequência em um dicionário
            // Os valores das chaves(1 parâmetro) devem ser únicas
            // Este não é um operador de execução tardia
            var empregadosDict = empregadosList.ToDictionary(x => x.EmployeeId, x => x.FirstName);

            // ToLookup -> é uma lista de dicionários. Irá agrupar todos os itens com base no parâmetro informado
            var empregadosLookup = Employee.GetAllEmployees().ToLookup(x => x.Gender);


            ArrayList list = new ArrayList();
            list.Add(1); list.Add(2); list.Add(3);

            // Cast<T> -> Para cada item contido na coleção ele tentará fazer a conversão para o tipo genérico especificado
            // caso alguns dos itens falhe na conversão, será lançada uma exceção.
            // Este operador trabalha com execução tardia
            var intlist = list.Cast<int>();


            ArrayList list2 = new ArrayList();
            list2.Add(1); list2.Add(2); list2.Add(3);
            list2.Add("ABC");

            // OfType<T> -> irá retornar apenas os itens do mesmo tipo especificado no parâmetro genérico
            var intListOfType = list2.OfType<int>();

            // GroupBy(x => x.Gender) -> irá agrupar os empregados por gênero
            var empGroupByGender = Employee.GetAllEmployees().GroupBy(x => x.Gender);

            // Para cada gênero que foi agrupado
            foreach (var emp in empGroupByGender)
            {
                // irá exibir apenas a qtd dos que possuem pelo menos 1 habilidade
                // emp.Key -> irá conter a chave que foi usada no agrupamento
                // emp -> irá conter a lista dos elementos que foram agrupados, neste caso irá conter uma lista de empregados
                Console.WriteLine(emp.Key + " " + emp.Count(x => x.Habilidades.Count > 0));
            }

            var empGroupByGenderSqlLike = from employees in Employee.GetAllEmployees()
                                              // agrupa os empregados por gênero e joga esse resultado na variável empGroupByGenderSlq
                                          group employees by employees.Gender into empGroupByGenderSlq
                                          // orderna pela chave, que nesse caso será por gênero
                                          orderby empGroupByGenderSlq.Key
                                          select new
                                          {
                                              Key = empGroupByGenderSlq.Key,
                                              Employees = empGroupByGenderSlq.OrderBy(x => x.FirstName)
                                          };


            foreach (var empLkp in empregadosLookup)
            {
                // empLkp.Key -> Será a chave que foi usada para realizar o agrupamento, no caso a prop Gender
                Console.WriteLine("Empregados do gênero " + empLkp.Key );

                // empregadosLookup[empLkp.Key] -> irá retornar os empregados que fazem parte da chave atual, que no caso
                // será o gênero
                foreach (var emp in empregadosLookup[empLkp.Key])
                {
                    Console.WriteLine(emp.FirstName + "" + emp.LastName);
                }
            }


            var employeeGroupByMultKeys = Employee.GetAllEmployees()
                .GroupBy(x => new { x.Gender, x.AnnualSalary })
                //como foram usadas duas chaves na agregação, a propriedade Key irá conter estas duas propriedades: Gender e AnnualSalary
                .OrderBy(x => x.Key.Gender).ThenBy(x => x.Key.AnnualSalary)
                .Select(x => new
                {
                    Gender = x.Key.Gender,
                    AnnualSalary = x.Key.AnnualSalary,
                    Employee = x.OrderBy(emp => emp.FirstName)
                });

            int[] numerosOperators = { };
            // DefaultIfEmpty() -> Irá retornar uma lista com o valor padrão do tipo específico da lista
            // caso a lista original esteja vazia
            // Neste exemplo irá retornar zero
            // DefaultIfEmpty(100) -> é possível especificar o valor padrão que deverá ser retornado
            var numsDefaultIfEmpty = numerosOperators.DefaultIfEmpty();

            var empDepGroupJoin = Department.GetAllDepartments()
                // Department.GetAllDepartments() -> especifica qual dataset será usado no join com o dataset de empregados
                .GroupJoin(Employee.GetAllEmployees(),
                dep => dep.Id,
                emp => emp.DepartmentId,
                // A ordem desses parâmetros obedece a mesma ordem do join GetAllEmployees() -> GetAllDepartments()
                (departments, employees) => new
                {
                    Department = departments,
                    Employee = employees
                });

            foreach (var department in empDepGroupJoin)
            {
                Console.WriteLine(department.Department.Nome);

                foreach (var emp in department.Employee)
                {
                    Console.WriteLine(emp.FirstName);
                }
            }


            // inner join
            var empDepInnerJoin = Employee.GetAllEmployees()
                .Join(Department.GetAllDepartments(),
                e => e.DepartmentId,
                d => d.Id,
                (employee, department) => new
                {
                    EmployeeName = employee.FirstName,
                    DepartmentName = department.Nome
                });

            foreach (var item in empDepInnerJoin)
            {
                Console.WriteLine(item.EmployeeName + "\t" + item.DepartmentName);
            }

            Console.Read();
        }
    }
}
