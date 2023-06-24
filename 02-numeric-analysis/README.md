# Численные методы

Домашнее задание по курсу C#.

[Постановка задачи](./doc)

Указания к выполнению:
- реализуйте метод вычисления интеграла в [NumericAnalysis/IntegralCalculus.cs](./NumericAnalysis/IntegralCalculus.cs)
- Проверяйте корректность запуская unit тесты: `dotnet test` из папки с проектом [NumericAnalysis.Tests](./NumericAnalysis.Tests/)

---

# Выполнено

- реализован класс IntegralCalculus, в котором реализованы два статических метода:
    - публичный 
        ``` C#
        public static double Calculate(Func<double, double> func, double x1, double x2, double precision) 
        ```
        , позволяющий задать интервал интегрирования, а также точность вычисления
    - приватный 
        ```C#
        static double TrapMeth(Func<double, double> func, double x1, double x2, uint segmentsnumb)
        ```
        , реализующий алгоритм численного метода расчёта интеграла по формуле вычисления трапеций. 
    
    В публичном методе используется функция Console.WriteLine для отслеживания промежуточных вычислений при поиске значения интеграла, т.е. exp - точность для текущей итерации вычисления, а также количество интервалов на данной итерации вычисления.
- корректность вычисления проверена при помощи заданного шаблона теста к данному заданию путём вызова команды dotnet test

Вывод результата выполнения команды dotnet test
``` bash
...
  Определение проектов для восстановления...
  Все проекты обновлены для восстановления.
  NumericAnalysis -> /home/kpeq-23/Рабочий стол/assignments-csharp/02-numeric-analysis/NumericAnalysis/bin/Debug/net7.0/NumericAnalysis.dll
  NumericAnalysis.Tests -> /home/kpeq-23/Рабочий стол/assignments-csharp/02-numeric-analysis/NumericAnalysis.Tests/bin/Debug/net7.0/NumericAnalysis.Tests.dll
Тестовый запуск для /home/kpeq-23/Рабочий стол/assignments-csharp/02-numeric-analysis/NumericAnalysis.Tests/bin/Debug/net7.0/NumericAnalysis.Tests.dll (.NETCoreApp,Version=v7.0)
Программа Microsoft (R) Test Execution Command Line Tool версии 17.6.0 (x64)
(с) Корпорация Майкрософт (Microsoft Corporation). Все права защищены.

Запуск выполнения тестов; подождите...
Общее количество тестовых файлов (1), соответствующих указанному шаблону.
Precision exp = 0,9474562500000161, intervals = 2
Precision exp = 45,05197734374998, intervals = 4
Precision exp = 44,75589726562491, intervals = 8
Precision exp = 0,014804003906277785, intervals = 16
Precision exp = 6,098066981505951, intervals = 32
Precision exp = 3,0282355710983495, intervals = 64
Precision exp = 3,064973846624781, intervals = 128
Precision exp = 5,7828140199944755E-05, intervals = 256
Precision exp = 1,5707963267948963, intervals = 2
Precision exp = 0,32532257114214325, intervals = 4
Precision exp = 0,078112704008511, intervals = 8
Precision exp = 0,018967153325232244, intervals = 16
Precision exp = 0,033506102100286705, intervals = 32
Precision exp = 0,010827837919432204, intervals = 64
Precision exp = 0,00030121154416984375, intervals = 128

Пройден!   : не пройдено     0, пройдено     2, пропущено     0, всего     2, длительность 2 ms. - NumericAnalysis.Tests.dll (net7.0)
```