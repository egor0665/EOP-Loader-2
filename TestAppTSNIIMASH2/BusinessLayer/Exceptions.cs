using System;
/// <summary>Исключение происходящее при отсутствии конфигурационного файла</summary>
class ConfigFileDoesNotExistException : Exception
{
    public ConfigFileDoesNotExistException(string message)
        : base(message) { }
}
/// <summary>Исключение происходящее при наличии некорректных параметров в файле конфигурации</summary>
class IllegalConfigParamException : Exception
{
    public IllegalConfigParamException(string message)
        : base(message) { }
}