using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;

using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;
using OzTool.SDK.Infra.Enigma.Utilities.Fakes;
using OzTool.SDK.Infra.Enigma.Extensions;

using UT.OzTool.SDK.Infra.Enigma._Models;
using System.Collections.Generic;

namespace UT.OzTool.SDK.Infra.Enigma._SPECs
{
    [TestClass]
    public class XEnigma_IEnigma_Decode
    {
        [TestMethod]
        public void S01_解碼為資料物件()
        {
            using (ShimsContext.Create())
            {
                //Arrange
                var sID = $@"abc";
                var sAddress1 = $@"address1";
                var sAddress2 = $@"address2";
                var objAddressies = new List<string>() { sAddress1, sAddress2 };
                var objValue = new XCData(sID);
                var objAddressValue1 = new XCData(sAddress1);
                var objAddressValue2 = new XCData(sAddress2);
                var objString = new XElement(typeof(string).Name, objValue);
                var objAddress1 = new XElement(typeof(string).Name, objAddressValue1);
                var objAddress2 = new XElement(typeof(string).Name, objAddressValue2);
                var objListString = new XElement("List", objAddress1, objAddress2);
                var objPropertyID = new XElement("ID", objString);
                var objPropertyAddressies = new XElement("Addressies", objListString);
                var objDTO = new XElement("Model",
                    objPropertyID, objPropertyAddressies);

                //Action
                var objResult = objDTO.Decode<Model>();

                //Assert                
                Assert.AreEqual(sID, objResult.ID);
                CollectionAssert.AreEquivalent(objAddressies, objResult.Addressies);
            }
        }
    }
}
