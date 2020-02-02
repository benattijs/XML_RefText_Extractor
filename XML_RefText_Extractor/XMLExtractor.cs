using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XML_RefText_Extractor
{
    public class XMLExtractor
    {
        public IEnumerable<XElement> ExtracAll(string xmlInput, string[] refCodeFilter)
        {
            XDocument document = XDocument.Parse(xmlInput);
            
            IEnumerable<XElement> filtered = from el in document.Element("InputDocument").Element("DeclarationList").Element("Declaration").Element("DeclarationHeader").Elements("Reference")
                            where refCodeFilter.Contains(el.Attribute("RefCode").Value)
                            select el.Element("RefText");

            return filtered;
        }
    }
}
