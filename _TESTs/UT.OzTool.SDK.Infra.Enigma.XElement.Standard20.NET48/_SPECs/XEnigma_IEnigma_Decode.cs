using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;

using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;
using OzTool.SDK.Infra.Enigma.Utilities.Fakes;
using OzTool.SDK.Infra.Enigma.Extensions;

using UT.OzTool.SDK.Infra.Enigma._Models;

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

                //Action
                var objValue = new XCData(sID);
                var objString = new XElement(typeof(string).Name, objValue);
                var objPropertyID = new XElement("ID", objString);
                var objDTO = new XElement("Model", objPropertyID);
                var objResult = objDTO.Decode<Model>();

                //Assert                
                Assert.AreEqual(sID,objResult.ID);
            }
        }
    }
}
