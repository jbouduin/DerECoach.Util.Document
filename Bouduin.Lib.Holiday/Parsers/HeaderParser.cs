using System;
using System.Xml;
using Bouduin.Lib.Holiday.Locations;

namespace Bouduin.Lib.Holiday.Parsers
{
    internal interface IHeaderParser
    {
        ILevel1Location GetLocation(string fileName);
    }

    internal class HeaderParser : IHeaderParser
    {
        #region ILevel1Parser members -----------------------------------------

        public ILevel1Location GetLocation(string fileName)
        {
            try
            {


                var result = new Location(fileName);
                //var xmlNameTable = XmlNameTabl;

                var xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                var nameSpaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
                nameSpaceManager.AddNamespace("tns", "http://www.example.org/Holiday");

                // read configuration:
                var configurationNode = xmlDocument.SelectSingleNode("//tns:Configuration", nameSpaceManager);
                if (configurationNode == null || configurationNode.Attributes == null ||
                    configurationNode.Attributes.Count == 0)
                    throw new XmlException();

                // 1. read hierarchie
                result.Code = configurationNode.Attributes["hierarchy"].Value;

                result.Description = configurationNode.Attributes["description"].Value;
                // TODO translate the description

                // 2. read description
                return result;
            }
            catch (Exception)
            {
                return null;

            }
        }

        #endregion
    }
}
