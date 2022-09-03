using System;
/// <summary>���������� ������������ ��� ���������� ����������������� �����</summary>
class ConfigFileDoesNotExistException : Exception
{
    public ConfigFileDoesNotExistException(string message)
        : base(message) { }
}
/// <summary>���������� ������������ ��� ������� ������������ ���������� � ����� ������������</summary>
class IllegalConfigParamException : Exception
{
    public IllegalConfigParamException(string message)
        : base(message) { }
}