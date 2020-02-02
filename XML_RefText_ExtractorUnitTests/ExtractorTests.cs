using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XML_RefText_Extractor;

namespace XML_RefText_ExtractorUnitTests
{
    [TestClass]
    public class ExtractorTests
    {
        public static string xmlInput = @"<InputDocument>
	                        <DeclarationList>
		                        <Declaration Command=""DEFAULT"" Version=""5.13"">
			                        <DeclarationHeader>
				                        <Jurisdiction>IE</Jurisdiction>
				                        <CWProcedure>IMPORT</CWProcedure>
				                        <DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>
				                        <DocumentRef>71Q0019681</DocumentRef>
				                        <SiteID>DUB</SiteID>
				                        <AccountCode>G0779837</AccountCode>
				                        <Reference RefCode=""MWB"">
					                        <RefText>586133622</RefText>
				                        </Reference>
				                        <Reference RefCode=""KEY"">
					                        <RefText>DUB16049</RefText>
				                        </Reference>
				                        <Reference RefCode=""CAR"">
					                        <RefText>71Q0019681</RefText>
				                        </Reference>
				                        <Reference RefCode=""COM"">
					                        <RefText>71Q0019681</RefText>
				                        </Reference>
				                        <Reference RefCode=""SRC"">
					                        <RefText>ECUS</RefText>
				                        </Reference>
				                        <Reference RefCode=""TRV"">
					                        <RefText>1</RefText>
				                        </Reference>
				                        <Reference RefCode=""CAS"">
					                        <RefText>586133622</RefText>
				                        </Reference>
				                        <Reference RefCode=""HWB"">
					                        <RefText>586133622</RefText>
				                        </Reference>
				                        <Reference RefCode=""UCR"">
					                        <RefText>586133622</RefText>
				                        </Reference>
				                        <Country CodeType=""NUM"" CountryType=""Destination"">IE</Country>
				                        <Country CodeType=""NUM"" CountryType=""Dispatch"">CN</Country>
			                        </DeclarationHeader>
		                        </Declaration>
	                        </DeclarationList>
                        </InputDocument>";

        [TestMethod]
        public void TestGivenExample()
        {

            string[] refCodeFilter = new[] { "MWB", "TRV", "CAR" };
            IList<string> expectedResponse = new List<string>() { "586133622", "1", "71Q0019681" };

            XMLExtractor extractor = new XMLExtractor();
            IEnumerable<XElement> result = extractor.ExtracAll(xmlInput, refCodeFilter);


            TestResponse(expectedResponse, result);


        }        
        [TestMethod]
        public void TestWithMoreTag()
        {

            string[] refCodeFilter = new[] { "MWB", "TRV", "CAR", "HWB", "KEY" };
            IList<string> expectedResponse = new List<string>() { "586133622", "1", "71Q0019681", "586133622", "DUB16049" };

            XMLExtractor extractor = new XMLExtractor();
            IEnumerable<XElement> result = extractor.ExtracAll(xmlInput, refCodeFilter);


            TestResponse(expectedResponse, result);


        }
        [TestMethod]
        public void TestWithSingleTag()
        {

            string[] refCodeFilter = new[] { "CAR" };
            IList<string> expectedResponse = new List<string>() { "71Q0019681", };

            XMLExtractor extractor = new XMLExtractor();
            IEnumerable<XElement> result = extractor.ExtracAll(xmlInput, refCodeFilter);

            TestResponse(expectedResponse, result);

        }
        
        [TestMethod]
        public void TestWithWrongTagName()
        {

            string[] refCodeFilter = new[] { "BBB" };
            IList<string> expectedResponse = new List<string>();

            XMLExtractor extractor = new XMLExtractor();
            IEnumerable<XElement> result = extractor.ExtracAll(xmlInput, refCodeFilter);

            TestResponse(expectedResponse, result);

        }
        [TestMethod]
        public void TestWithEmptyXML()
        {

            string[] refCodeFilter = new[] { "" };
            IList<string> expectedResponse = new List<string>();

            XMLExtractor extractor = new XMLExtractor();
            IEnumerable<XElement> result = extractor.ExtracAll("", refCodeFilter);

            TestResponse(expectedResponse, result);

        }

        public void TestResponse(IList<string> expectedResponse, IEnumerable<XElement> response)
        {

            int totalElementsReturned = 0;
            foreach (XElement el in response)
            {
                Assert.IsTrue(expectedResponse.Contains(el.Value));
                totalElementsReturned++;
            }

            //Check if the correct amount of elements is returned.
            Assert.AreEqual(expectedResponse.Count, totalElementsReturned);

        }
    }
}
