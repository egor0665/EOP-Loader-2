using System;
using System.Collections.Generic;
using System.IO;

class IERSBusiness
{
    /// <summary>Метод разбора данных из файла</summary>
    internal static List<EopParam> RefactorData(string savePath, string fileName)
    {
        Logger.Log("Debug", "Обработка файла IERS", "Обработка файла запущена");
        try
        {
            string data = LocalWorker.ReadData(savePath, fileName);
            Logger.Log("Debug", "Обработка файла IERS", $"Данные успешно считаны из файла {savePath}\\{fileName}");
            List<EopParam> EopParams = ProcessResult(data);
            return EopParams;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "Обработка файла IERS", $"Ошибка при обработке файла\n {e.Message}");
            throw;
        }
    }
    /// <summary>Метод тестирования</summary>
    internal static void Test(string filePath, string fileName)
    {
        Logger.Log("Debug", "Тестирование IERS", "Тестирование запущено");
        try
        {
            Logger.Log("Debug", "Тестирование IERS", "Тестирование получение данных из файла");
            string data = LocalWorker.ReadData(filePath, fileName);
            Logger.Log("Debug", "Тестирование IERS", $"Данные успешно считаны из файла");
            Logger.Log("Debug", "Тестирование IERS", "Тестирование обработки данных");
            ProcessResult(data);
            Logger.Log("Debug", "Тестирование IERS", "Данные успешно обработаны");
            Logger.Log("Debug", "Тестирование IERS", "Все тесты успешно пройдены");
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "Тестирование", $"Ошибка при тестировании \n{e.Message}");
            return;
        }
    }
    /// <summary>Метод обработки строки данных</summary>
    internal static List<EopParam> ProcessResult(string data)
    {
        try
        {
            List<EopParam> result = DataProcesser.ProcessDataFromStringIERS(data);
            Logger.Log("Debug", "Обработка файла IERS", "Данные успешно обработаны");
            return result;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "Обработка файла IERS", $"Ошибка при обработке файла\n {e.Message}");
            throw;
        }
    }

}