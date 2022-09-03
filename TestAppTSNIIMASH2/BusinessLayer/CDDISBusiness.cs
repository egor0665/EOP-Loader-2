using System;
using System.Collections.Generic;
using System.IO;

class CDDISBusiness
{
    /// <summary>����� ������� ������ �� �����</summary>
    internal static List<EopParam> RefactorData(string savePath, string fileName)
    {
        Logger.Log("Debug", "��������� ����� CDDIS", "��������� ����� ��������");
        try
        {
            string data = LocalWorker.ReadData(savePath, fileName);
            Logger.Log("Debug", "��������� ����� CDDIS", $"������ ������� ������� �� ����� {savePath}\\{fileName}");
            List<EopParam> EopParams = ProcessResult(data);
            return EopParams;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "��������� ����� CDDIS", $"������ ��� ��������� �����\n {e.Message}");
            throw;
        }
    }
    /// <summary>����� ������������</summary>
    internal static void Test(string filePath, string fileName)
    {
        Logger.Log("Debug", "������������ CDDIS", "������������ ��������");
        try
        {
            Logger.Log("Debug", "������������ CDDIS", "������������ ��������� ������ �� �����");
            string data = LocalWorker.ReadData(filePath, fileName);
            Logger.Log("Debug", "������������ CDDIS", $"������ ������� ������� �� �����");
            Logger.Log("Debug", "������������ CDDIS", "������������ ��������� ������");
            ProcessResult(data);
            Logger.Log("Debug", "������������ CDDIS", "������ ������� ����������");
            Logger.Log("Debug", "������������ CDDIS", "��� ����� ������� ��������");
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "������������", $"������ ��� ������������ \n{e.Message}");
            return;
        }
    }
    /// <summary>����� ��������� ������ ������</summary>
    private static List<EopParam> ProcessResult(string data)
    {
        try
        {
            List<EopParam> result = DataProcesser.ProcessDataFromStringCDDIS(data);
            Logger.Log("Debug", "��������� ����� CDDIS", "������ ������� ����������");
            return result;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "��������� ����� CDDIS", $"������ ��� ��������� �����\n {e.Message}");
            throw;
        }
    }
}