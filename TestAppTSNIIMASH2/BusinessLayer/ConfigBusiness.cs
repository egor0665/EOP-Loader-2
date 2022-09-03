using System;
using System.IO;
using System.Text.RegularExpressions;

class ConfigBusiness
{
    /// <summary>Поле с конфигурациями приложения</summary>
    internal static ConfigData config { get; private set; }
    /// <summary>Метод получения параметров программы из файла config</summary>
    internal static int GetConfigsFromFile()
    {
        Logger.Log("Debug", "Выполнение", "Программа запущена");
        if (!LocalWorker.CheckConfigExistance())
        {
            throw new ConfigFileDoesNotExistException("Не удалось найти файл конфигурации");
        }
        try
        {
            config = LocalWorker.GetDataFromConfigFile();
            Logger.Log("Debug", "Считывание конфига", $"Файл config успешно считан \n-- Режим работы по умолчанию - {config.Autorun}\n"
                + $"-- скачивать данные с CDDIS - {config.AutorunCDDIS}\n"
                + $"-- скачивать данные с IERS - {config.AutorunIERS}\n"
                + $"-- Путь для сохранения CDDIS- {config.CDDISSavePath}\n"
                + $"-- Имя файла для сохранения CDDIS - {config.CDDISFileName}\n"
                + $"-- Путь для сохранения IERS- {config.IERSSavePath}\n"
                + $"-- Имя файла для сохранения IERS - {config.IERSFileName}\n"
                );
            if (config.Autorun == true)
            {
                Logger.Log("Debug", "Выполнение", "Запуск в режиме работы по умолчанию");
                return 1;
            }
            else
                return 2;
        }
        catch (Exception e)
        {
            Logger.Log("Fatal", "Считывание конфига", $"Ошибка при чтении файла config\n {e.Message}");
            return 0;
        }
    }
    public struct ConfigData
    {
        /// <summary>Параметр автозапуска программы (Интерфейс)</summary>
		public bool Autorun;
        /// <summary>При Autorun=true скачивать данные с CDDIS</summary>
        public bool AutorunCDDIS;
        /// <summary>При Autorun=true скачивать данные с IERS</summary>
        public bool AutorunIERS;
        /// <summary>Путь к файлу с данными</summary>
        public string CDDISSavePath;
        /// <summary>Имя файла с данными</summary>
        public string CDDISFileName;
        /// <summary>Путь к файлу с данными</summary>
        public string IERSSavePath;
        /// <summary>Имя файла с данными</summary>
        public string IERSFileName;
        /// <summary>Конструктор инициализации и проверки введенных значений</summary>
        public ConfigData(string _Autorun, string _AutorunCDDIS, string _AutorunIERS, string _CDDISSavePath, string _CDDISFileName, string _IERSSavePath, string _IERSFileName)
        {
            if (_Autorun == "true") Autorun = true;
            else if (_Autorun == "false") Autorun = false;
            else throw new IllegalConfigParamException("Ошибка аттрибута Autorun ");

            if (_AutorunCDDIS == "true") AutorunCDDIS = true;
            else if (_AutorunCDDIS == "false") AutorunCDDIS = false;
            else throw new IllegalConfigParamException("Ошибка аттрибута AutorunCDDIS ");

            if (_AutorunIERS == "true") AutorunIERS = true;
            else if (_AutorunIERS == "false") AutorunIERS = false;
            else throw new IllegalConfigParamException("Ошибка аттрибута AutorunIERS ");
            if (!Directory.Exists(_CDDISSavePath))
                throw new IllegalConfigParamException("Ошибка аттрибута CDDISSavePath (Не существующий путь)");
            else CDDISSavePath = _CDDISSavePath;

            if (!Directory.Exists(_IERSSavePath))
                throw new IllegalConfigParamException("Ошибка аттрибута IERSSavePath (Не существующий путь)");
            else IERSSavePath = _IERSSavePath;

            Regex regex = new Regex(@"^([a-zA-Z0-9_]+)\.(?!\.)([a-zA-Z0-9]{1,5})(?<!\.)$");
            if (!regex.Match(_CDDISFileName).Success)
            {
                throw new IllegalConfigParamException("Ошибка аттрибута CDDISFilePath (Ошибка формата)");
            }
            else CDDISFileName = _CDDISFileName;

            if (!regex.Match(_IERSFileName).Success)
            {
                throw new IllegalConfigParamException("Ошибка аттрибута IERSFilePath (Ошибка формата)");
            }
            else IERSFileName = _IERSFileName;
        }
    }
}