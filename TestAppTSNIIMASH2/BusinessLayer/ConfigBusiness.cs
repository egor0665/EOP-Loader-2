using System;
using System.IO;
using System.Text.RegularExpressions;

class ConfigBusiness
{
    /// <summary>���� � �������������� ����������</summary>
    internal static ConfigData config { get; private set; }
    /// <summary>����� ��������� ���������� ��������� �� ����� config</summary>
    internal static int GetConfigsFromFile()
    {
        Logger.Log("Debug", "����������", "��������� ��������");
        if (!LocalWorker.CheckConfigExistance())
        {
            throw new ConfigFileDoesNotExistException("�� ������� ����� ���� ������������");
        }
        try
        {
            config = LocalWorker.GetDataFromConfigFile();
            Logger.Log("Debug", "���������� �������", $"���� config ������� ������ \n-- ����� ������ �� ��������� - {config.Autorun}\n"
                + $"-- ��������� ������ � CDDIS - {config.AutorunCDDIS}\n"
                + $"-- ��������� ������ � IERS - {config.AutorunIERS}\n"
                + $"-- ���� ��� ���������� CDDIS- {config.CDDISSavePath}\n"
                + $"-- ��� ����� ��� ���������� CDDIS - {config.CDDISFileName}\n"
                + $"-- ���� ��� ���������� IERS- {config.IERSSavePath}\n"
                + $"-- ��� ����� ��� ���������� IERS - {config.IERSFileName}\n"
                );
            if (config.Autorun == true)
            {
                Logger.Log("Debug", "����������", "������ � ������ ������ �� ���������");
                return 1;
            }
            else
                return 2;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "���������� �������", $"������ ��� ������ ����� config\n {e.Message}");
            return 0;
        }
    }
    public struct ConfigData
    {
        /// <summary>�������� ����������� ��������� (���������)</summary>
		public bool Autorun;
        /// <summary>��� Autorun=true ��������� ������ � CDDIS</summary>
        public bool AutorunCDDIS;
        /// <summary>��� Autorun=true ��������� ������ � IERS</summary>
        public bool AutorunIERS;
        /// <summary>���� � ����� � �������</summary>
        public string CDDISSavePath;
        /// <summary>��� ����� � �������</summary>
        public string CDDISFileName;
        /// <summary>���� � ����� � �������</summary>
        public string IERSSavePath;
        /// <summary>��� ����� � �������</summary>
        public string IERSFileName;
        /// <summary>����������� ������������� � �������� ��������� ��������</summary>
        public ConfigData(string _Autorun, string _AutorunCDDIS, string _AutorunIERS, string _CDDISSavePath, string _CDDISFileName, string _IERSSavePath, string _IERSFileName)
        {
            if (_Autorun == "true") Autorun = true;
            else if (_Autorun == "false") Autorun = false;
            else throw new IllegalConfigParamException("������ ��������� Autorun ");

            if (_AutorunCDDIS == "true") AutorunCDDIS = true;
            else if (_AutorunCDDIS == "false") AutorunCDDIS = false;
            else throw new IllegalConfigParamException("������ ��������� AutorunCDDIS ");

            if (_AutorunIERS == "true") AutorunIERS = true;
            else if (_AutorunIERS == "false") AutorunIERS = false;
            else throw new IllegalConfigParamException("������ ��������� AutorunIERS ");
            if (!Directory.Exists(_CDDISSavePath))
                throw new IllegalConfigParamException("������ ��������� CDDISSavePath (�� ������������ ����)");
            else CDDISSavePath = _CDDISSavePath;

            if (!Directory.Exists(_IERSSavePath))
                throw new IllegalConfigParamException("������ ��������� IERSSavePath (�� ������������ ����)");
            else IERSSavePath = _IERSSavePath;

            Regex regex = new Regex(@"^([a-zA-Z0-9_]+)\.(?!\.)([a-zA-Z0-9]{1,5})(?<!\.)$");
            if (!regex.Match(_CDDISFileName).Success)
            {
                throw new IllegalConfigParamException("������ ��������� CDDISFilePath (������ �������)");
            }
            else CDDISFileName = _CDDISFileName;

            if (!regex.Match(_IERSFileName).Success)
            {
                throw new IllegalConfigParamException("������ ��������� IERSFilePath (������ �������)");
            }
            else IERSFileName = _IERSFileName;
        }
    }
}