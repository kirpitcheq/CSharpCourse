В случае использования generic IEnumerable<T>, который требует реализованый итератор для контейнера IEnumerator<T> важно реализовывать строго в соответствии с названиями интерфейсов (подключив соответствующие using или использовать полное имя типа)
ПРИМЕР:
        IEnumerator IEnumerable.GetEnumerator() => first!;
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => first!;
Также сигнатура должна очень точно совпадать с требованиями контракта интерфейса (т.е. в этом случае даже важно использовать без public)

Очень плохо ведёт себя при этом IntelliCode и плохо подсказывает начинающему.