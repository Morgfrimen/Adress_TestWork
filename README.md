# Adress_TestWork
В случае проблем со сборкой проекта, решением может  быть редактирование файла global.json. В нём указывается версия SDK, отвечаемая за сборку. 
Узнать свою версию можно следующим образом:
1) В PowerShell перейти в папку с проектом
2) Выполнить комманду: dotnet version 

Если на экране не появится предупреждения с тем, что выставленной версии нет - можно пробовать собрать сборку, иначе выберете версию из списка, представленного в консоле.
Сборка расчитана на NET 5.0 и выше.
