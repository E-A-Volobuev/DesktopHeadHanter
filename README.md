# DesktopHeadHanter

## Краткое описание проекта

Для выбора вакансии необходимо указать интересующие параметры:

![Alt-текст](https://github.com/E-A-Volobuev/DesktopHeadHanter/blob/master/%D0%B3%D0%BB%D0%B0%D0%B2%D0%BD%D0%BE%D0%B5%20%D0%BE%D0%BA%D0%BD%D0%BE.png?raw=true)

![Alt-текст](https://github.com/E-A-Volobuev/DesktopHeadHanter/blob/master/%D0%B2%D1%8B%D0%BF%D0%B0%D0%B4%D0%B0%D1%8E%D1%89%D0%B8%D0%B5%20%D1%81%D0%BF%D0%B8%D1%81%D0%BA%D0%B8.png?raw=true)

В новом окне будут представлены актуальные вакансии по Вашему запросу:

![Alt-текст](https://github.com/E-A-Volobuev/DesktopHeadHanter/blob/master/%D1%80%D0%B5%D0%B7%D1%83%D0%BB%D1%8C%D1%82%D0%B0%D1%82%20%D0%BF%D0%BE%D0%B8%D1%81%D0%BA%D0%B0.png?raw=true)

По каждой вакансии можно узнать детали, кликнув по ней:

![Alt-текст](https://github.com/E-A-Volobuev/DesktopHeadHanter/blob/master/%D0%B4%D0%B5%D1%82%D0%B0%D0%BB%D0%B8%20%D0%B2%D0%B0%D0%BA%D0%B0%D0%BD%D1%81%D0%B8%D0%B8.png?raw=true)


По приложенной (в правом нижнем углу) ссылке можно перейти к вакансии на хх ру:

![Alt-текст](https://github.com/E-A-Volobuev/DesktopHeadHanter/blob/master/%D0%B2%D0%B0%D0%BA%D0%B0%D0%BD%D1%81%D0%B8%D1%8F%20%D0%BD%D0%B0%20%D1%85%D1%85%20%D1%80%D1%83.png?raw=true)

## Структура приложения

Проект основан на WindowsForm.
В проекте представлены классы, описывающие вакансию (Vacancy), специализацию (Spezialization),
детали вакансии(ViewVacancy) и географическое положение (Countries,Areas,Sities).
Получение и отправка данных в формате json происходит средствами HttpWebRequest/HttpWebResponse и api.hh.ru
