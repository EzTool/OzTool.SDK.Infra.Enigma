using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OzTool.SDK.Infra.Enigma;
using OzTool.SDK.Infra.Enigma.Extensions;
using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;
using OzTool.SDK.Infra.Enigma.Utilities.Fakes;

using System;
using System.Collections.Generic;
using System.Xml.Linq;

using UT.OzTool.SDK.Infra.Enigma._Models;

namespace UT.OzTool.SDK.Infra.Enigma._SPECs
{
    [TestClass]
    public class XEnigma_IEnigma_Encode
    {
        [TestMethod]
        public void S01_編碼為XElement結構()
        {
            using (ShimsContext.Create())
            {
                //Arrange               
                var objValue = new XCData("abc");
                var objAddressValue1 = new XCData("address1");
                var objAddressValue2 = new XCData("address2");
                var objString = new XElement(typeof(string).Name, objValue);
                var objAddress1 = new XElement(typeof(string).Name, objAddressValue1);
                var objAddress2 = new XElement(typeof(string).Name, objAddressValue2);
                var objListString = new XElement("List", objAddress1, objAddress2);
                var objPropertyID = new XElement("ID", objString);
                var objPropertyAddressies = new XElement("Addressies", objListString);
                var objDTO = new XElement("Model",
                    objPropertyID, objPropertyAddressies);

                //Action
                var objAddressies = new List<string>() { "address1", "address2" };
                var objModel = new Model()
                {
                    ID = "abc",
                    Addressies = objAddressies
                };
                var objResult = objModel.Encode();

                //Assert
                Assert.IsTrue(XElement.DeepEquals(objDTO, objResult));

            }
        }
    }
}
