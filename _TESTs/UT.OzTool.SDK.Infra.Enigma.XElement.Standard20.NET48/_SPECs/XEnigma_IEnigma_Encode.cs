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
                var objParserBundle = new StubIParserBundle<XElement>();
                var objReturn = new XElement("Model");

                objParserBundle.EncodeOf1M0<Model>((obj1) => { return objReturn; });

                ShimParserBundle.Initial = () => { return objParserBundle; };

                //Action
                var objModel = new Model();
                var objResult = objModel.Encode();

                //Assert
                Assert.IsTrue(XElement.DeepEquals(objReturn, objResult));
                Assert.AreEqual(objReturn, objResult);
            }
        }
    }
}
