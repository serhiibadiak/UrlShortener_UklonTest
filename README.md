# UrlShortener_UklonTest
API обрабатывает принимает запрос по адрессу https://localhost:44330/api/urlshortener
Передача ссылки для сокращения в GET запросе вызыввает обработчик запроса, ищет ссылку в коллекции, Если она есть, то возвращает ее короткую версию и добавляет новую дату ее использования методом Put. Если в коллекции ссылки нет, генерируем для нее короткое значение и добавляем в базу.

Если приделать БД к проекту то я бы сделал Бд из двух таблиц. 
1 - таблица с сылками. столбцы Url_id, Url, ShortUrl.
2 - Таблица с датами кликов по ссылке. столбцы Url_id, ClickDate
Создание таблицы описал тут: http://sqlfiddle.com/#!17/928f3/36
Чтобы достать статистику использовать запросы
Сколько кликов было по ссылке URL1
SELECT Url, count FROM URLs
INNER JOIN (SELECT Url_id, COUNT (ClickDate) FROM URLsClicks
GROUP BY Url_id) AS Clicks ON URLs.Url_id = Clicks.Url_id
WHERE Url = 'URL1';

Сколько кликов было по ссылке URL3 за сегодня:
SELECT Url, COUNT(Url) FROM URLs
INNER JOIN (SELECT Url_id, ClickDate FROM URLsClicks
WHERE ClickDate = CURRENT_DATE) AS Clicks ON URLs.Url_id = Clicks.Url_id
GROUP BY Url 
HAVING Url = 'URL3';

Сколько кликов было по ссылке URL1 за неделю
SELECT Url, COUNT(Url) FROM URLs
INNER JOIN (SELECT Url_id, ClickDate FROM URLsClicks
WHERE ClickDate > CURRENT_DATE-7) AS Clicks ON URLs.Url_id = Clicks.Url_id
GROUP BY Url  
HAVING Url = 'URL1';

Сколько кликов было по ссылке URL1 за месяц
SELECT Url, COUNT(Url) FROM URLs
INNER JOIN (SELECT Url_id, ClickDate FROM URLsClicks
WHERE ClickDate > CURRENT_DATE-31) AS Clicks ON URLs.Url_id = Clicks.Url_id
GROUP BY Url  
HAVING Url = 'URL1';
