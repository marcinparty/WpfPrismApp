using System;
using System.IO;
using System.Xml.Serialization;

namespace WpfPrismApp.PersonModule.Utils
{
    public class XmlSerializerUtil
    {
        public static void SerializeToFile<T>(T t, String fileName)
        {
            var serializer = new XmlSerializer(t.GetType());
            using (var streamWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(streamWriter, t);
            }
        }

        public static T DeserializeFromFile<T>(String fileName)
        {
            var deserializer = new XmlSerializer(typeof(T));
            using (var streamReader = new StreamReader(fileName))
            {
                return (T) deserializer.Deserialize(streamReader);
            }
        }

        public static String SerializeToString<T>(T t)
        {
            var serializer = new XmlSerializer(t.GetType());
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, t);
                return textWriter.ToString();
            }
        }
    }
}
