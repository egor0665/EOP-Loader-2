using System;
using System.Collections.Generic;
using System.IO;

class CDDISBusiness
{
    /// <summary>Метод разбора данных из файла</summary>
    internal static List<EopParam> RefactorData(string savePath, string fileName)
    {
        Logger.Log("Debug", "Обработка файла CDDIS", "Обработка файла запущена");
        try
        {
            string data = LocalWorker.ReadData(savePath, fileName);
            Logger.Log("Debug", "Обработка файла CDDIS", $"Данные успешно считаны из файла {savePath}\\{fileName}");
            List<EopParam> EopParams = ProcessResult(data);
            return EopParams;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "Обработка файла CDDIS", $"Ошибка при обработке файла\n {e.Message}");
            throw;
        }
    }
    /// <summary>Метод тестирования</summary>
    internal static void Test(string filePath, string fileName)
    {
        Logger.Log("Debug", "Тестирование CDDIS", "Тестирование запущено");
        try
        {
            Logger.Log("Debug", "Тестирование CDDIS", "Тестирование получение данных из файла");
            string data = LocalWorker.ReadData(filePath, fileName);
            Logger.Log("Debug", "Тестирование CDDIS", $"Данные успешно считаны из файла");
            Logger.Log("Debug", "Тестирование CDDIS", "Тестирование обработки данных");
            ProcessResult(data);
            Logger.Log("Debug", "Тестирование CDDIS", "Данные успешно обработаны");
            Logger.Log("Debug", "Тестирование CDDIS", "Все тесты успешно пройдены");
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "Тестирование", $"Ошибка при тестировании \n{e.Message}");
            return;
        }
    }
    /// <summary>Метод обработки строки данных</summary>
    private static List<EopParam> ProcessResult(string data)
    {
        try
        {
            List<EopParam> result = DataProcesser.ProcessDataFromStringCDDIS(data);
            Logger.Log("Debug", "Обработка файла CDDIS", "Данные успешно обработаны");
            return result;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "Обработка файла CDDIS", $"Ошибка при обработке файла\n {e.Message}");
            throw;
        }
    }
}