namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para XML.
    /// </summary>
    public class XmlHelper
    {
        ///// <summary>
        ///// Serialize object to xml.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public static string SerializeXml<T>(T item)
        //    where T : class
        //{
        //    var serializer = new XmlSerializer(typeof(T));
        //    string xml = "";

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        //        {
        //            serializer.Serialize(streamWriter, item);

        //            byte[] utf8EncodedXml = memoryStream.ToArray();
        //            xml = Encoding.UTF8.GetString(utf8EncodedXml);
        //        }
        //    }

        //    return xml;
        //}

        ///// <summary>
        ///// Deserializa um string XML para um objeto.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public static T DeserializeXml<T>(string xml)
        //     where T : class
        //{
        //    var serializer = new XmlSerializer(typeof(T));

        //    T item;

        //    using (TextReader reader = new StringReader(xml))
        //    {
        //        item = (T)serializer.Deserialize(reader);
        //    }

        //    return item;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="ident"></param>
        ///// <param name="omitXmlDeclaration"></param>
        ///// <returns></returns>
        //public static string ConvertToXML(object obj, bool ident, bool omitXmlDeclaration)
        //{
        //    string xmlDataParametro;

        //    var serializer = new XmlSerializer(obj.GetType());

        //    var settings = new XmlWriterSettings
        //    {
        //        Encoding = new UnicodeEncoding(false, false),
        //        Indent = ident,
        //        OmitXmlDeclaration = omitXmlDeclaration
        //    };

        //    using (var textWriter = new StringWriter())
        //    {
        //        using (var xmlWriter = XmlWriter.Create(textWriter, settings))
        //        {
        //            serializer.Serialize(xmlWriter, obj);
        //        }

        //        xmlDataParametro = textWriter.ToString();
        //    }

        //    return xmlDataParametro;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="xmlResponse"></param>
        ///// <param name="elementName"></param>
        ///// <returns></returns>
        //public static T DeserializeXmlElement<T>(string xmlResponse, string elementName) where T : class
        //{
        //    T obj;

        //    using (var reader = new StringReader(xmlResponse))
        //    {
        //        var document = new XmlDocument();

        //        var readerXml = XmlReader.Create(reader);

        //        document.Load(readerXml);

        //        XmlNode nodeToConvert = document.FirstChild;

        //        XmlNodeList element = document.GetElementsByTagName(elementName);

        //        if (element == null) return null;

        //        if (element.Count == 0) return null;

        //        obj = ConvertNode<T>(element[0]);
        //    }

        //    return obj;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="xmlResponse"></param>
        ///// <param name="position"></param>
        ///// <returns></returns>
        //public static T DeserializeXml<T>(string xmlResponse, int position = 1) where T : class
        //{
        //    T obj;

        //    using (var reader = new StringReader(xmlResponse))
        //    {
        //        var document = new XmlDocument();

        //        var readerXml = XmlReader.Create(reader);

        //        document.Load(readerXml);

        //        XmlNode nodeToConvert = document.FirstChild;

        //        if (position.Equals(1))
        //            nodeToConvert = document.ChildNodes[position];
        //        else
        //        {
        //            for (int i = 0; i < position; i++)
        //            {
        //                nodeToConvert = nodeToConvert.FirstChild;
        //            }
        //        }

        //        obj = ConvertNode<T>(nodeToConvert);
        //    }

        //    return obj;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="node"></param>
        ///// <returns></returns>
        //public static T ConvertNode<T>(XmlNode node) where T : class
        //{
        //    var stm = new MemoryStream();

        //    var stw = new StreamWriter(stm);

        //    stw.Write(node.OuterXml);

        //    stw.Flush();

        //    stm.Position = 0;

        //    var ser = new XmlSerializer(typeof(T));

        //    var result = (ser.Deserialize(stm) as T);

        //    return result;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="node"></param>
        ///// <param name="defaulNameSpaces"></param>
        ///// <returns></returns>
        //public static T ConvertNodeWithDefaultNamespace<T>(XmlNode node, string defaulNameSpaces = "") where T : class
        //{
        //    T result = null;
        //    using (TextReader textReader = new StringReader(node.OuterXml))
        //    {
        //        using (var reader = new XmlTextReader(textReader))
        //        {
        //            if (defaulNameSpaces == "")
        //            {
        //                reader.Namespaces = false;
        //            }

        //            var serializer = new XmlSerializer(typeof(T), defaulNameSpaces);
        //            result = (serializer.Deserialize(reader) as T);
        //        }
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="xmlResponse"></param>
        ///// <param name="position"></param>
        ///// <returns></returns>
        //public static T DeserializeXmlWithXmlTextReader<T>(string xmlResponse, int position = 1) where T : class
        //{
        //    T obj;

        //    using (var reader = new StringReader(xmlResponse))
        //    {
        //        var document = new XmlDocument();

        //        var readerXml = XmlReader.Create(reader);

        //        document.Load(readerXml);

        //        XmlNode nodeToConvert = document.ChildNodes[position];

        //        obj = ConvertNodeWithXmlTextReader<T>(nodeToConvert);
        //    }

        //    return obj;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="node"></param>
        ///// <returns></returns>
        //public static T ConvertNodeWithXmlTextReader<T>(XmlNode node) where T : class
        //{

        //    T result = null;

        //    using (TextReader textReader = new StringReader(node.OuterXml))
        //    {
        //        using (var reader = new XmlTextReader(textReader))
        //        {
        //            var serializer = new XmlSerializer(typeof(T));
        //            result = (serializer.Deserialize(reader) as T);
        //        }
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="xmlResponse"></param>
        ///// <param name="position"></param>
        ///// <returns></returns>
        //public static T DeserializeXmlWithDefaultNamespace<T>(string xmlResponse, int position = 1) where T : class
        //{
        //    T obj;

        //    using (var reader = new StringReader(xmlResponse))
        //    {
        //        var document = new XmlDocument();

        //        var readerXml = XmlReader.Create(reader);

        //        document.Load(readerXml);

        //        XmlNode nodeToConvert = document.FirstChild;

        //        if (position.Equals(1))
        //        {
        //            nodeToConvert = document.ChildNodes[position];
        //        }
        //        else
        //        {
        //            for (int i = 0; i < position; i++)
        //            {
        //                nodeToConvert = nodeToConvert.FirstChild;
        //            }
        //        }

        //        obj = ConvertNodeWithDefaultNamespace<T>(nodeToConvert);
        //    }

        //    return obj;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="ident"></param>
        ///// <param name="omitXmlDeclaration"></param>
        ///// <param name="ns"></param>
        ///// <returns></returns>
        //public static string ConvertToXMLWithPrefix(object obj, bool ident, bool omitXmlDeclaration, XmlSerializerNamespaces ns)
        //{
        //    string xmlDataParametro;

        //    var serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());

        //    var settings = new System.Xml.XmlWriterSettings
        //    {
        //        Encoding = new UnicodeEncoding(false, false),
        //        Indent = ident,
        //        OmitXmlDeclaration = omitXmlDeclaration
        //    };

        //    using (var textWriter = new System.IO.StringWriter())
        //    {
        //        using (var xmlWriter = XmlWriter.Create(textWriter, settings))
        //        {
        //            serializer.Serialize(xmlWriter, obj, ns);
        //        }

        //        xmlDataParametro = textWriter.ToString();
        //    }

        //    return xmlDataParametro;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="xmlResponse"></param>
        ///// <param name="position"></param>
        ///// <param name="defaultNS"></param>
        ///// <returns></returns>
        //public static T DeserializeXmlWithDefaultNamespaceAndOmitXmlDeclaration<T>(string xmlResponse, int position = 0, string defaultNS = "") where T : class
        //{
        //    T obj;

        //    using (var reader = new StringReader(xmlResponse))
        //    {
        //        var document = new XmlDocument();

        //        var readerXml = XmlReader.Create(reader);

        //        document.Load(readerXml);

        //        XmlNode nodeToConvert = document.FirstChild;

        //        if (nodeToConvert.NodeType == XmlNodeType.XmlDeclaration)
        //        {
        //            nodeToConvert = document.FirstChild.NextSibling;
        //        }

        //        for (int i = 0; i < position; i++)
        //        {
        //            nodeToConvert = nodeToConvert.FirstChild;
        //        }

        //        obj = ConvertNodeWithDefaultNamespace<T>(nodeToConvert, defaultNS);
        //    }

        //    return obj;
        //}
    }
}