# ДЗ 3. Структуры.

## Задание
Разработать и протестировать структуры Meter и Inch для работы с метрической и дюймовой системами измерения длины.

## Требования
Для каждой структуры требуется определить:
- арифметические операторы `+`, `-`, `*`, `/`
- унарные `+` и `-`
- операторы сравнения `==`, `!=`, `>`, `<`, `>=`, `<=`
- операторы явного и неявного приведения типа
- методы ToString, GetHashCode и Equals

Бинарные операторы требуется перегрузить так, чтобы можно было их применять к операндам:
- метры-метры и дюймы-дюймы
- метры-дюймы и дюймы-метры
- метры-T, T-метры и дюймы-T, T-дюймы (где T - это тип, который вы выбрали для хранения значения в структурах Meter и Inch)

Операторы явного и неявного примедения типа требуется перегрузить, чтобы можно было получать:
- метры из T и дюймы из Т, где T - это тип, который вы выбрали для хранения значения в структурах Meter и Inch
- метры из дюймов и дюймы из метров

"Протестировать" в постановке означает один из двух вариантов, на ваш выбор:
1. Написать код для демонстрации работы 
2. Покрыть код unit-тестами (предпочтительно)

---

---

---

## Выполнено 
Выполнены все требования реализации структур и всех перечисленных в требованиях определений операторов, за исключением взаимного определения бинарных операторов Inch и Metre структур. При определении например 
```C#
    public static Inch operator+(Inch A, Meter B) => new (A.Value + METER_TO_INCH * B.Value);
```
, а также
```C#
    public static Metre operator +(Inch A, Metre B) => new (INCH_TO_METRE * A.Value + B.Value); 
```
компилятор выдаёт ошибку, которая была определена на этапе написания тестов к структурам
```bash
~/assignments-csharp/03-structs/Structs.Lib/Inch.cs(51,46): error CS0246: Не удалось найти тип или имя пространства имен "Meter" (возможно, отсутствует директива using или ссылка на сборку). [~/assignments-csharp/03-structs/Structs.Lib/Structs.Lib.csproj]
```
Решено оставить код, но дополнительно снабдить участок кода макросами
``` C#
#if INCH_OPS
        /* inch-meter bin ops */
        public static Inch operator-(Inch A, Meter B) => new (A.Value - METER_TO_INCH * B.Value);
        public static Inch operator*(Inch A, Meter B) => new (A.Value * METER_TO_INCH * B.Value);
        public static Inch operator/(Inch A, Meter B) => new (A.Value / METER_TO_INCH * B.Value);

         /* meter-inch bin ops */
        public static Inch operator+(Meter A, Inch B) => new (METER_TO_INCH * A.Value + B.Value);
        public static Inch operator-(Meter A, Inch B) => new (METER_TO_INCH * A.Value - B.Value);
        public static Inch operator*(Meter A, Inch B) => new (METER_TO_INCH * A.Value * B.Value);
        public static Inch operator/(Meter A, Inch B) => new (METER_TO_INCH * A.Value / B.Value);
#endif
```

Также по описанной выше причине нет возможности без явного преобразования протестировать участок кода
``` C#
        public delegate Inch InchFuncInchMetre(Inch inch, Metre metre);
        public static Inch InchAddMetreForward(Inch inch, Metre metre) => (Inch)(inch + metre);
        public static Inch InchAddMetreReverse(Inch inch, Metre metre) => (Inch)(metre + inch);
        public static Inch InchSubMetreForward(Inch inch, Metre metre) => (Inch)(inch - metre);
        public static Inch InchSubMetreReverse(Inch inch, Metre metre) => (Inch)(metre - inch);
        public static Inch InchMulMetreForward(Inch inch, Metre metre) => (Inch)(inch * metre);
        public static Inch InchMulMetreReverse(Inch inch, Metre metre) => (Inch)(metre * inch);
        public static Inch InchDivMetreForward(Inch inch, Metre metre) => (Inch)(inch / metre);
        public static Inch InchDivMetreReverse(Inch inch, Metre metre) => (Inch)(metre / inch);

```
(делегат в коде носит информационный осведомительный характер об тестируемых ниже его описания функциях)

Произвольно была выбрана перегрузка оператора умножения для Inch в целях демонстрации
```C#
        public delegate Metre MetreFuncMetreInch(Metre metre, Inch inch);
        public static Metre MetreAddInchForward(Metre metre, Inch inch) => metre + inch;
        public static Metre MetreAddInchReverse(Metre metre, Inch inch) => inch + metre;
        public static Metre MetreSubInchForward(Metre metre, Inch inch) => metre - inch;
        public static Metre MetreSubInchReverse(Metre metre, Inch inch) => inch - metre;
        public static Metre MetreMulInchForward(Metre metre, Inch inch) => metre * inch;
        public static Metre MetreMulInchReverse(Metre metre, Inch inch) => (Metre)(inch * metre);
        public static Metre MetreDivInchForward(Metre metre, Inch inch) => metre / inch; 
        public static Metre MetreDivInchReverse(Metre metre, Inch inch) => inch / metre;
```

--- 
Далее был обнаружен еще один нюанс при написании тестов:
1 дюйм * 1 метр
1 дюйм * 39... дюйм = 39... дюйм => переводить в 1 метр 
0.0254 метр * 1 метр = 0.0254 метра => переводить в дюйм = 1дюйм

но если хотим получить дюйм, то сначала переводим метр в дюймы и умножаем, аналогично с метрами, но в таком случае требуется однозначное определение операторов умножения для каждого из типов структур. Такая же ситуация и с делением. А в случае простых арифметических операций первичный перевод не критичен.

В связи с этим тестирование именно операторов умножения не реализовано, но в коде закоментировано

```C#
        public static IEnumerable<object[]> MetreBinMetreInchEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)MetreAddInchForward, new Metre(1.0254M) };
            yield return new object[] { 1M, 1M, (object)MetreAddInchReverse, new Metre(1.0254M) };
            yield return new object[] { 1M, 1M, (object)MetreSubInchForward, new Metre(0.9746M) };
            yield return new object[] { 1M, 1M, (object)MetreSubInchReverse, new Metre(-0.9746M) };
            yield return new object[] { 1M, 1M, (object)MetreMulInchForward, new Metre(0.0254M) };
            // yield return new object[] { 1M, 1M, (object)MetreMulInchReverse, new Metre() };
            // yield return new object[] { 1M, 1M, (object)MetreDivInchForward, new Metre() }; //how use many ops overloads?
            // yield return new object[] { 1M, 1M, (object)MetreDivInchReverse, new Metre() };
        }
```
Точно также и в классе тестирования структуры InchTests

---

## Структура тестов
Тесты произведены при помощи XUnit

Категории тестов разделены при помощи разделителей коментариями
```C#
        //-----------------------------------------------------------------------------------
```

Была использована возможность использования подстановки набора данных при помощи атрибутов, например

```C#
        [Theory, MemberData(nameof(InchBinInchMetreEnumerable))]
```

А также сами наборы данных вынесены отдельно в методы класса тестирования возвращающие IEnumerable<object[]>, например

```C#
        public static IEnumerable<object[]> InchBinInchMetreEnumerable()
        {   
            yield return new object[] { 1M, 1M, (object)InchAddMetreForward, new Inch(40.370078740157480314960629921M) };
            yield return new object[] { 1M, 1M, (object)InchAddMetreReverse, new Inch(40.370078740157480314960629921M) };
            ...
```

В некоторых случаях использовалась другая возможность XUnit для задания набора тестов при помощи атрибута, в примере

```C#
        [Theory]
        [InlineData(1, -1)]
        [InlineData(-1, 1)]
        [InlineData(3, -3)]
        [InlineData(-3, 3)]
        public void InchUnarMinus(decimal toinch, decimal expected)
        ...
```

Однако данную возможность нельзя использовать везде, исходя из запрета указания константного литерала M для чисел типа 'decimal', т.к. возникает ошибка, например если использовать

```C#
        [Theory]
        [InlineData(1, -1M)]
```

, то возникает следующая ошибка

```bash
~/assignments-csharp/03-structs/Structs.Tests/InchTests.cs(177,24): error CS0182: Аргументом атрибута должно быть константное выражение, выражение typeof или выражение создания массива того же типа, что и параметр атрибута. [~/assignments-csharp/03-structs/Structs.Tests/Structs.Tests.csproj]
```

А если использовать без контекстного литерала M, то происходит неявное преобразование из double в decimal с потерей точности, что не приемлемо для проверки точного результата типа decimal, поэтому и используются наборы возвращающие IEnumerable<object[]>

---

Тесты сформированы двумя способами для читаемости
В первом случае при использовании наборов данных возвращающих IEnumerable<object[]>:
- Описаны определения тестируемых функций
- Описаны наборы данных IEnumerable<object[]>, в которых используются статические методы описанные выше
- описан метод самого тестирования, использующий тот или иной набор данных, с соответствующей сигнатурой к набору получаемых данных

Во втором случае, когда не требуется точность передачи данных и допустимо неявное преобразование из double в decimal:
- Описаны передаваемые данные через атрибут [InlineData]
- Описан тестируемый метод с соответствующей сигнатурой для приёма данных через атрибут

---

Отчёт об успешном выполнении тестов

```bash
...:~/assignments-csharp/03-structs$ dotnet test
  Определение проектов для восстановления...
  Все проекты обновлены для восстановления.
  Structs.Lib -> /home/kpeq-23/Рабочий стол/assignments-csharp/03-structs/Structs.Lib/bin/Debug/net7.0/Structs.Lib.dll
  Structs.Tests -> /home/kpeq-23/Рабочий стол/assignments-csharp/03-structs/Structs.Tests/bin/Debug/net7.0/Structs.Tests.dll
Тестовый запуск для /home/kpeq-23/Рабочий стол/assignments-csharp/03-structs/Structs.Tests/bin/Debug/net7.0/Structs.Tests.dll (.NETCoreApp,Version=v7.0)
Программа Microsoft (R) Test Execution Command Line Tool версии 17.6.0 (x64)
(с) Корпорация Майкрософт (Microsoft Corporation). Все права защищены.

Запуск выполнения тестов; подождите...
Общее количество тестовых файлов (1), соответствующих указанному шаблону.

Пройден!   : не пройдено     0, пройдено    82, пропущено     0, всего    82, длительность 44 ms. - Structs.Tests.dll (net7.0)
```