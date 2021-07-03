using System;
using System.IO;
using System.Xml.Serialization;

namespace LoadData.LoadLogical.XML
{
    internal sealed class LoaderXML : ILoadData
    {
#region Implementation of ILoad

        /// <summary>
        ///     Загружает XML файл
        /// </summary>
        /// <typeparam name="T">Тип модели</typeparam>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Список данных или null</returns>
        /// <exception cref="FileNotFoundException">Если файл не найден</exception>
        public ST LoadFile<ST, T>(string path)
            where T : class, new()
            where ST : class, new()
        {
            if (path is not null && File.Exists(path))
            {
                XmlAttributeOverrides overrides = new();
                XmlAttributes attributes = new();

                if (_ignoreProperty is not null)
                {
                    attributes.XmlIgnore = true;
                    foreach (string s in _ignoreProperty) overrides.Add(typeof(T), s, attributes);
                }

                XmlSerializer xmlSerializer = new(typeof(ST), overrides);

                using (FileStream fileStream = new(path, FileMode.Open))
                {
                    ST model = default;

                    try
                    {
                        model = (ST) xmlSerializer.Deserialize(fileStream);
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

        private string[] _ignoreProperty;

        /// <inheritdoc />
        public void SetIgnoreProperty(params string[] ignoreProperty) =>
            _ignoreProperty = ignoreProperty;

#endregion
    }
}