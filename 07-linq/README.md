# ДЗ 7. LINQ.

**Задание**

Реализуйте следующие методы расширения (extension methods) для IEnumerable<T> по аналогии с тем, как реализованы методы LINQ:
- `TakeOdd()` - возвращает последовательность, содержащую нечётные по порядку элементы исходной  
- `TakeEven()` - возвращает последовательность, содержащую чётные по порядку элементы исходной
- `TakeNegative()` - возвращает последовательность, содержащую отрицательные элементы исходной
- `TakePositive()` - возвращает последовательность, содержащую отрицательные элементы исходной
- `SmoothByMovingAverage(int width)` - сглаживает элементы числовой последовательности алгоритмом скользящего среднего заданной ширины. Значение элемента последовательности-результата равно среднему арифметическому значений исходной последовательности в окрестности (width) этого элемента.

---

# Выполнено

Методы реализованы, для проверки методов реализовано несколько тестов используя тип int