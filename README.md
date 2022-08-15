# EWSS Tool C#

![bnr-git-ewssbanner](https://user-images.githubusercontent.com/31628014/179772956-ea1972aa-4ff8-44d6-8bcb-63b83c567c00.png)

## О EWSS Tool
**EWSS** _(Easy Windows Server Setup Tool)_ — утилита для быстрой и удобной стартовой конфигурации и/или отладки ОС семейства Windows Server. Задачей проекта было написание «подручной» утилиты с возможностью изменять системные параметры не используя стандартный интерфейс ОС. Избавление от PS, BAT консолей и создание информативного интерфейса.


![image](https://user-images.githubusercontent.com/31628014/183946613-eb792a0b-76a5-46de-ac52-1fe19bf53e7d.png)


## Зависимости EWSS Tool C#

- [**.NET 6 Desktop Runtime**](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) и выше
- **PowerShell 5** и выше

## Функционал кнопок быстрого доступа


Быстрый доступ необходим, когда у вас есть нестандартная задача, которую сложно уместить в функционал «одной кнопки». Важно понимать, что требования к конкретной ОС возникают в соответствии с задачей и условиями. Так, например, чтобы отредактировать параметры быстродействия ОС, в случае ограниченности в ресурсах, вам необходимо открыть соответствующие параметры. Чтобы их открыть приходится пройти по достаточно долгому пути из окошек. С EWSS это можно сделать одной кнопкой на панели быстрого доступа.


## Активатор EWSS Tool 🌐

⚠️ _Для работы требуется стабильное Интернет-подключение_ 🌐

Функционал активатора ОС использует KMS средства, что накладывает ограничения на использования в ОС с версиями `Eval`. Для их активации необходима конвертация ОС в `Retail`, как это осуществить будет [здесь](https://docs.microsoft.com/en-us/answers/questions/219734/how-to-convert-windows-server-2019-datacenter-eval.html).

Для активации используется общий ключ продукта LTSC и LTSB версий ОС с [официального сайта Microsoft](https://docs.microsoft.com/en-us/windows-server/get-started/kms-client-activation-keys#windows-server-ltscltsb-versions). 

Активация не подразумевает использование виртуального сетевого адаптера и эмуляции KMS сервера. KMS сервера используемые для активации являются свободным ресурсом и ответственность за их предназначение лежит на их владельцах.

⚠️ _В этой версии EWSS Tool список поддерживаемых ОС сокращен до часто используемых. Версии 2008 и 2012 удалены. Добавлены GVLK ключи пользовательских ОС вплоть до Windows 7._

### Тестирование EWSS 🔑 Активатора в ОС
| Отметка               | Статус                    |
|:---------------------:|---------------------------|
| :white_check_mark:    | Протестировано и работает |
| :black_square_button: | Тестирование не проводили |
| :x:                   | Не работает               |

#### Серверные ОС

  - **2022**
    - :black_square_button: Windows Server 2022 Standart
    - :black_square_button: Windows Server 2022 Datacenter
  - **2019**
    - :black_square_button: Windows Server 2019 Datacenter
    - :black_square_button: Windows Server 2019 Standard
    - :black_square_button: Windows Server 2019 Essentials
  - **2016**
    - :black_square_button: Windows Server 2016 Datacenter
    - :white_check_mark: Windows Server 2016 Standard
    - :black_square_button: Windows Server 2016 Essentials
  - **2012 R2**
    - :white_check_mark: Windows Server 2012 R2 Standard
    - :white_check_mark: Windows Server 2012 R2 Datacenter
    - :black_square_button: Windows Server 2012 R2 Essentials

#### Пользовательские ОС

  - **Windows 11**
    - :black_square_button: Windows 11 Pro
    - :black_square_button: Windows 11 Pro N
    - :black_square_button: Windows 11 Pro для рабочих станций
    - :black_square_button: Windows 11 Pro для рабочих станций N
    - :black_square_button: Windows 11 Pro для образовательных учреждений
    - :black_square_button: Windows 11 Pro для образовательных учреждений N
    - :black_square_button: Windows 11 для образовательных учреждений
    - :black_square_button: Windows 11 для образовательных учреждений N
    - :black_square_button: Windows 11 Корпоративная
    - :black_square_button: Windows 11 Корпоративная N
    - :black_square_button: Windows 11 Корпоративная G
    - :black_square_button: Windows 11 Корпоративная G N
  - **Windows 10**
    - :black_square_button: Windows 10 Pro
    - :black_square_button: Windows 10 Pro N
    - :black_square_button: Windows 10 Pro для рабочих станций
    - :black_square_button: Windows 10 Pro для рабочих станций N
    - :black_square_button: Windows 10 Pro для образовательных учреждений
    - :black_square_button: Windows 10 Pro для образовательных учреждений N
    - :black_square_button: Windows 10 для образовательных учреждений
    - :black_square_button: Windows 10 для образовательных учреждений N
    - :black_square_button: Windows 10 Корпоративная
    - :black_square_button: Windows 10 Корпоративная N
    - :black_square_button: Windows 10 Корпоративная G
    - :black_square_button: Windows 10 Корпоративная G N
  - **Windows 10 LTSC 2021 и 2019**
    - :black_square_button: Windows 10 Корпоративная LTSC 2021
    - :black_square_button: Windows 10 Корпоративная LTSC 2019
    - :black_square_button: Windows 10 Корпоративная N LTSC 2021
    - :black_square_button: Windows 10 Корпоративная N LTSC 2019
  - **Windows 10 2016**
    - :black_square_button: Windows 10 Корпоративная LTSB 2016
    - :black_square_button: Windows 10 Корпоративная N LTSB 2016
  - **Windows 10 2015**
    - :black_square_button: Windows 10 Корпоративная 2015 с долгосрочным обслуживанием
    - :black_square_button: Windows 10 Корпоративная 2015 с долгосрочным обслуживанием N
    
 
