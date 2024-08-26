using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OzTool.SDK.Infra.Enigma;
using OzTool.SDK.Infra.Enigma.Extensions;
using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;
using OzTool.SDK.Infra.Enigma.Utilities.Fakes;

using System;
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

                //Action
                var objModel = new Model() { ID = "abc"};
                var objResult = objModel.Encode();

                //Assert
                var objValue = new XCData("abc");
                var objString = new XElement(typeof(string).Name, objValue);
                var objPropertyID = new XElement("ID", objString);
                var objDTO = new XElement("Model", objPropertyID);

                Assert.IsTrue(XElement.DeepEquals(objDTO, objResult));
                
            }
        }
    }
}
