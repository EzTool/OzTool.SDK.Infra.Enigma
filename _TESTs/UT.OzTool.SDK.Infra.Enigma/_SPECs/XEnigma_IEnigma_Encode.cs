using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OzTool.SDK.Infra.Enigma;
using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;

using System;
using System.Xml.Linq;

using UT.OzTool.SDK.Infra.Enigma._Models;

namespace UT.OzTool.SDK.Infra.Enigma._SPECs
{
    [TestClass]
    public class XEnigma_IEnigma_Encode
    {
        [TestMethod]
        public void S01()
        {
            //Arrange
            var objParserBundle = new StubIParserBundle<XElement>();
            var objReturn = new XElement("Model");

            objParserBundle.EncodeOf1M0<Model>((obj1) => { return objReturn; });

            //Action
            var objModel = new Model();
            var objResult = XEnigma.Initial(objParserBundle).Encode(objModel);

            //Assert
            Assert.AreEqual(objResult, objResult);
        }
    }
}
