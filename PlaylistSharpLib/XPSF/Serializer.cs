using System;
using System.IO;
using System.Xml.Serialization;

namespace PlaylistSharpLib.XPSF
{
    // http://stackoverflow.com/q/2434534/1248177

    public static class Serializer
    {
        public static string SerializeToXml<T>(T toSerialize)
        {
            var serializer = new XmlSerializer(toSerialize.GetType());
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public static T DeserializeFromXml<T>(string toDeserialize)
        {
            try
            {
                var deserializer = new XmlSerializer(typeof (T));
                using (var textReader = new StringReader(toDeserialize))
                {
                    return (T) deserializer.Deserialize(textReader);
                }
            }
            catch (InvalidOperationException invalidOperationException)
            {
                throw  new Exception("PlaylistSharp cannot deserialize your xml. Maybe you want to check it first.", invalidOperationException);
            }
        }
    }
}
