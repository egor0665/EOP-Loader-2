using System;
using System.Collections.Generic;
using System.IO;

class BusinessMain
{
    /// <summary>Таблица параметров вращения Земли</summary>
    public static List<EopParam> EopParams { get; set; }
    /// <summary>Обработка команд пользователя</summary>
    internal static void WorkInput(string input)
    {
        /*
        1 - Обработать данные CDDIS
        2 - Обработать данные IERS
        3 - Запустить тестирование
        */
        try
        {
            switch (input)
            {
                case "1":
                    EopParams = CDDISBusiness.RefactorData(ConfigBusiness.config.CDDISSavePath, ConfigBusiness.config.CDDISFileName);
                    TestEopParamsOutput();
                    break;
                case "2":
                    EopParams = IERSBusiness.RefactorData(ConfigBusiness.config.IERSSavePath, ConfigBusiness.config.IERSFileName);
                    TestEopParamsOutput();
                    break;
                case "3":
                    CDDISBusiness.Test(ConfigBusiness.config.CDDISSavePath, ConfigBusiness.config.CDDISFileName);
                    IERSBusiness.Test(ConfigBusiness.config.IERSSavePath, ConfigBusiness.config.IERSFileName);
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "Тестирование", $"\n {e.Message}");
            return;
        }
    }
    /// <summary>Обработка автозапуска</summary>
    internal static void RefactorDataAutorun()
    {
        if (ConfigBusiness.config.AutorunCDDIS == true)
            EopParams = CDDISBusiness.RefactorData(ConfigBusiness.config.CDDISSavePath, ConfigBusiness.config.CDDISFileName);
        else if (ConfigBusiness.config.AutorunIERS == true)
            EopParams = IERSBusiness.RefactorData(ConfigBusiness.config.IERSSavePath, ConfigBusiness.config.IERSFileName);
        TestEopParamsOutput();
    }
    /// <summary>Вывод обработанных данных</summary>
    private static void TestEopParamsOutput()
    {
        foreach (EopParam i in EopParams)
        {
            Console.WriteLine($"{i.DataNo} {i.T} {i.Xp} {i.ErrorX} {i.Yp} {i.ErrorY} {i.DeltaUt1} {i.ErrorDeltaUt1}");
        }
    }
}
