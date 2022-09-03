using System;
using System.Collections.Generic;
using System.IO;

class IERSBusiness
{
    /// <summary>����� ������� ������ �� �����</summary>
    internal static List<EopParam> RefactorData(string savePath, string fileName)
    {
        Logger.Log("Debug", "��������� ����� IERS", "��������� ����� ��������");
        try
        {
            string data = LocalWorker.ReadData(savePath, fileName);
            Logger.Log("Debug", "��������� ����� IERS", $"������ ������� ������� �� ����� {savePath}\\{fileName}");
            List<EopParam> EopParams = ProcessResult(data);
            return EopParams;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "��������� ����� IERS", $"������ ��� ��������� �����\n {e.Message}");
            throw;
        }
    }
    /// <summary>����� ������������</summary>
    internal static void Test(string filePath, string fileName)
    {
        Logger.Log("Debug", "������������ IERS", "������������ ��������");
        try
        {
            Logger.Log("Debug", "������������ IERS", "������������ ��������� ������ �� �����");
            string data = LocalWorker.ReadData(filePath, fileName);
            Logger.Log("Debug", "������������ IERS", $"������ ������� ������� �� �����");
            Logger.Log("Debug", "������������ IERS", "������������ ��������� ������");
            ProcessResult(data);
            Logger.Log("Debug", "������������ IERS", "������ ������� ����������");
            Logger.Log("Debug", "������������ IERS", "��� ����� ������� ��������");
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "������������", $"������ ��� ������������ \n{e.Message}");
            return;
        }
    }
    /// <summary>����� ��������� ������ ������</summary>
    internal static List<EopParam> ProcessResult(string data)
    {
        try
        {
            List<EopParam> result = DataProcesser.ProcessDataFromStringIERS(data);
            Logger.Log("Debug", "��������� ����� IERS", "������ ������� ����������");
            return result;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "��������� ����� IERS", $"������ ��� ��������� �����\n {e.Message}");
            throw;
        }
    }

}