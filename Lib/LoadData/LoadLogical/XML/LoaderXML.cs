using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LoadData.LoadLogical.XML
{
    internal sealed class LoaderXML : ILoad
    {
#region Implementation of ILoad

        /// <summary>
        /// Загружает XML файл
        /// </summary>
        /// <typeparam name="T">Тип модели</typeparam>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Список данных или null</returns>
        /// <exception cref="FileNotFoundException">Если файл не найден</exception>
        public IList<T> LoadFile<T>(string path)
            where T : class, new()
        {
            if (path is not null && File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    T[] model = default;

                    try
                    {
                        model = (T[]) xmlSerializer.Deserialize(fileStream);
                    }
                    catch (Exception e)
                    {
                        return null;
                    }

                    return model;
                }
            }

            throw new FileNotFoundException();
        }

#endregion
    }
}