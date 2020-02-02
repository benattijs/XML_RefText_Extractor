# EDIFACT Message Parser

## Background:
Taking the following XML document, write code to extract the RefText values for the following RefCodes:   ‘MWB’, ‘TRV’ and ‘CAR’

```
<InputDocument>
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
</InputDocument>
```


### Input:
The input expected for the main Extract method is a string containing the XML where the RefText is to be extracted and an Array with the list of RefCode to be extracted.

### Output:
The output is an Array containing the RefText elements corresponding to the RefCode extracted.

### Edge Cases and Assumptions 
1. Considered the fact that the the RefCodes to be extracted could be different on different executions.
2. Considered that the message could be received in blank.
3. Considered that the RefCode to be returned would change with different requests. Added parameter for the tags to be filtered. 
4. The original XML provided was missing the cloure of the  `<Declaration>` tag. That have been added to the XML used for tests.

## Code documentation
Project is divided and 2 projects:

### 1. XML_RefText_Extractor
This is the Main Library to be used to Extrac the RefText tags from the XML Message.

#### XML_RefText_Extractor/XMLExtractor.cs
Contains the logic that receives a XML Input extract all the RefText tags corresponding to the RefCode being filtered byt the parameter. 


### 2. XML_RefText_ExtractorUnitTests
Contains the Unit Tests created to validate the main Library. 

#### XML_RefText_ExtractorUnitTests/ExtractorTests.cs 
Contains the test cases and edge cases.
