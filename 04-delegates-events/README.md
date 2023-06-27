# ДЗ 4. Делегаты и события.

Реализовать класс FileSystemWatcher, отслеживающий изменения в указанной папке на диске и уведомляющий об этом путём генерации события Change.

Типы изменений, о который нужно уведомлять:
- добавлен файл (файлы) и/или папка (папки)
- отредактирован файл(ы)
- удалён файл (файлы) и/или папка (папки)

Алгоритм слежения за изменениями в папке:
1. При появлении первого подписчика на событие Change - запускаем таймер (System.Threading.Timer или System.Timers.Timer)
2. На каждое срабатывание таймера проверяем все файлы в указанной папке (`System.IO.Directory.GetFiles()`): какие появились, какие пропали, какие изменились с прошлого срабатывания.
3. Если есть хоть какие-то изменения, то генерируем событие Changed, в аргументы которого передаём ифнормацию об изменениях: текущее время и все произошедшие изменения (массив изменений), где каждое из изменений содержит путь к файлу/папке и характер изменений: добавлен, отредактирован, либо удалён
4. При отписке последнего подписчика останавливаем таймер

---

# Выполнено

Задание выполнено согласно требований.

Для уведомлений используется инкапсулированный класс Notify в основном классе FileSystemWatcher
Notify включает в себя два поля:
- тип уведомления
    ``` C#
    public Notify(ChangesTypeDef typeOfChange, string relativePath) {
        TimeOfChanges = DateTime.Now;
        TypeOfChange = typeOfChange;
        RelativePath = relativePath;
    }
    ```
- путь к файлу
- время уведомления типа DateTime

также перегружен оператор ToString для удобства вывода данных уведомлений в терминал при помощи System.Console.WriteLine()

В конструкторе класса FileSystemWatcher без параметров перегружен конструктор с одним параметром - период анализа (таймера) сбора информации о файлах в указанной директории path, можно задать собственное время соответственно передав его конструктору

Согласно задания таймер при подписке хотя бы одного подписчика запускается, а при отсутствии подписчиков если был включен - останавливается
```C#
        FilesChanged? change; 
        public event FilesChanged? Change{ 
            add{
                change += value;
                if (!timer.Enabled) timer.Start();
            }
            remove{
                if(change != null) {
                    change -= value;
                    if (change == null && timer.Enabled) timer.Stop();
                }
            }
        }
```

Основная задача выполняется при срабатывании события таймера
```C#
            timer.Elapsed += TimerWent!;
```
, на которое подписывается экземпляр класса во время выполнения конструктора
```C#
        public FileSystemWatcher(double CheckedInterval) { //here need path, init dictionary to files
            if (CheckedInterval < 0)
                CheckedInterval = Math.Abs(CheckedInterval);
            timer.Interval = CheckedInterval;
            timer.Stop();
            timer.Elapsed += TimerWent!;
            //init filesdict Dictionary
            var files_now = System.IO.Directory.GetFileSystemEntries(path, "", SearchOption.AllDirectories);
            foreach (var file in files_now) 
                filesdict.Add(file, new FileInfo(file));
        }
```

Вся информация о файлах собирается в словаре на протяжении работы экземпляра класса при присутствии хотя бы одного подписчика

## Демонстрация
Демонстрация работы программы реализована в проекте 04-delegates-events.FileSystemWatcher.Prog

Демонстрация ориентирована более на беглое тестирование основных реализаций алгоритма, т.е. происходит следующим образом:
- подписываемся на события и передаём статический метод, выводящий уведомления Notify при помощи Console.WriteLine()
- добавляем файл
- изменяем данные в файле
- еще раз изменяем данные в файле
- удаляем файл
Все уведомления при этом выводятся в терминале 
```bash
X:~/assignments-csharp/04-delegates-events$  /.vscode/extensions/ms-dotnettools.csharp-2.0.238-linux-x64/.debugger/vsdbg --interpreter=vscode --connection=/tmp/CoreFxPipe_vsdbg-ui-7e5263a566c54fac9c2ffdb6667d897c 
File ./~/tests/test1dir/file.txt is ADDED at ...
File ./~/tests/test1dir/file.txt is CHANGED at ...
File ./~/tests/test1dir/file.txt is CHANGED at ...
File ./~/tests/test1dir/file.txt is DELETED at ...
```
затем отписываемся от событий и производим теже самые операции, которые уже не отображаются в терминале

после этого опять подписываемся на события и перепроверяем, что всё работает корректно, но уже просто добавляем и удаляем файл
```bash
File ./~/tests/test1dir/file.txt is ADDED at ...
File ./~/tests/test1dir/file.txt is DELETED at ...
```