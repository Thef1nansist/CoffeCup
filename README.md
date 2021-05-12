Что ещё нужно сделать: Статистику для пользователей, статистику для кофейнь, напитки , которые пользователь активировал, карту с кофейнями
Сделано: Авторизация для пользователей, авторизация для кофейнь, добавление кофейнь и меню к ним, рейтинг популярный кофейнь, вывод всех доступных кофейнь, которые уже есть в приложении, избранные кофейни, то есть те, которые пользователь добавил в кладку избранные, вкладка с  информацией о самом приложении, активация купона

"# CoffeCup" 
Курсовой проект(в дальнейшем может быть свой стартап);
Тема Desctop Application для скидок на кофее;
Приложение написано на C#, + использованы такие технологии как
1. WPF(MVVM - архитектруный паттерн проектирования) - Windows Presentation Foundation (WPF) — аналог WinForms, система для построения клиентских приложений Windows с визуально привлекательными возможностями взаимодействия с пользователем.
2. Web Api - это программный интерфейс, состоящий из одной или нескольких общедоступных конечных точек для определенной системы сообщений запрос-ответ, обычно выраженной в JSON или XML.
3. EF CORE - представляет собой объектно-ориентированную, легковесную и расширяемую технологию от компании Microsoft для доступа к данным.
4. JWT -  это открытый стандарт (RFC 7519) для создания токенов доступа, основанный на формате JSON. Как правило, используется для передачи данных для аутентификации в клиент-серверных приложениях. Токены создаются сервером, подписываются секретным ключом и передаются клиенту, который в дальнейшем использует данный токен для подтверждения своей личности.
5. Sqlite - база данных, просто в использовании и переносима на другие устройства;
6. DI - это шаблон проектирования, используемый для реализации IoC. Он позволяет создавать зависимые объекты вне класса и предоставляет эти объекты классу различными способами. Используя DI, мы перемещаем создание и привязку зависимых объектов за пределы класса, который от них зависит.
7. Identity - Identity представляет встроенную в ASP.NET систему аутентификации и авторизации. Данная система позволяет пользователям создавать учетные записи, аутентифицироваться, управлять учетными записями.
Архитектура приложения разбита на 4 части
1. Это сама wpf часть(desctoppapp)
2. Это server web api;
3. Это Infrastructure - для взаимодействия с базой данных;
4. BusinessLogic - для работы с самими данными;
Из-за того, что я хочу вдальнейшем этот проект развивать, я сделал так, чтобы вместо wpf части, можно было подключить любую другую технологию и не нужно было бы переписывать весь код заново, в дальнейшем планирую на xamarin написать что-то похожее, но с большим функционалом под пользователя.
