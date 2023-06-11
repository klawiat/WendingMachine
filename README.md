# WendingMachine
Тестовое задание на позицию .net разработчика
## Описание проекта
Проект состоит из 2-х приложений. В папке "backend" лежат 4 проекта:
- Data - слой доменных объектов
- Infrastructure - отвечает за взаимодействие с внешними сервисами
- Application - отвечает за логику и транспортировку данных

В папке "frontend" лежит проект blazor webassenbly. Он является оберткой для api и позволяет взаимодействовать с бд.
## Возможности 
- Просмотр, создание и редактирование монет
- Просмотр, создание, редактирование и удаление напитков 
- Просмотр и редактирование машин
- Раздельный доступ для пользователей и администраторов
## Настройка и запуск
Оба проекта можно запустить из visual studio
Первым должен быть запущен проект из папки backend 
По пути "backend\WendingMachine.Api\appsettings.json" исправить строку на вашу
``` sh
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(local);Initial Catalog=WendingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
  }
```
Также настроить порты на более подходящие для вас.
Автоматическая документация swagger доступна по ссылке "https:localhost:(ваш порт)/swagger"

Настройка второго проекта заключается в изменении строки в файле по пути "frontend\WendingMachine.Web\Client\Program.cs"
``` csharp
    BaseAddress = new Uri("(Тут должен быть вставлен адрес запущенного backend проекта)")
```

## Необязательные требования
- Реализован функционал подсчета монет нужного номинала для сдачи
