using Microsoft.VisualStudio.TestTools.UnitTesting;

using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;
using OzTool.SDK.Infra.Enigma;

using System;
using System.Xml.Linq;
using UT.OzTool.SDK.Infra.Enigma._Models;

namespace UT.OzTool.SDK.Infra.Enigma._SPECs
{
    [TestClass]
    public class XEnigma_IEnigma_Decode
    {
        [TestMethod]
        public void S01()
        {
            //Arrange
            var objParserBundle = new StubIParserBundle<XElement>();
            var objModel = new Model();

            objParserBundle.DecodeOf1XElement((obj1) => { return objModel; });

            //Action
            var objReturn = new XElement("Model");
            var objResult = XEnigma.Initial(objParserBundle).Decode<Model>(objReturn);

            //Assert
            Assert.AreEqual(objResult, objResult);

        }
    }
}
