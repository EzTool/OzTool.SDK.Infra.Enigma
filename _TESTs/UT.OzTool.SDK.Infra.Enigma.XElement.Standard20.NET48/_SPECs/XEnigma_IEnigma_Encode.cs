using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OzTool.SDK.Infra.Enigma;
using OzTool.SDK.Infra.Enigma.Extensions;
using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;
using OzTool.SDK.Infra.Enigma.Utilities.Fakes;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                var objValueID = new XCData("abc");
                var objValueLikeCount = 0;
                var objAddressValue1 = new XCData("address1");
                var objAddressValue2 = new XCData("address2");
                var objValueEditLoginfo1ID = new XCData("A001");
                var objValueEditLoginfo2ID = new XCData("A002");                
                var objString = new XElement(typeof(string).Name, objValueID);
                var objInt32 = new XElement(typeof(int).Name, objValueLikeCount);
                var objStringEditLogInfo1ID = new XElement(typeof(string).Name, objValueEditLoginfo1ID);
                var objStringEditLogInfo2ID = new XElement(typeof(string).Name, objValueEditLoginfo2ID);
                var objAddress1 = new XElement(typeof(string).Name, objAddressValue1);
                var objAddress2 = new XElement(typeof(string).Name, objAddressValue2);
                var objListString = new XElement("List", objAddress1, objAddress2);
                var objEditLog1ID = new XElement("ID", objStringEditLogInfo1ID);
                var objEditLog2ID = new XElement("ID", objStringEditLogInfo2ID);
                var objEditLogInfo1 = new XElement("EditLogInfo", objEditLog1ID);
                var objEditLogInfo2 = new XElement("EditLogInfo", objEditLog2ID);
                var objObserverCollection = new XElement("ObservableCollection", objEditLogInfo1, objEditLogInfo2);
                var objPropertyID = new XElement("ID", objString);
                var objPropertyLikeCount = new XElement("LikeCount", objInt32);
                var objPropertyAddressies = new XElement("Addressies", objListString);
                var objPropertyEditLogs = new XElement("EditLogs", objObserverCollection);
                var objDTO = new XElement("Model",
                    objPropertyID,
                    objPropertyLikeCount,
                    objPropertyAddressies,
                    objPropertyEditLogs);

                //Action
                var objAddressies = new List<string>() { "address1", "address2" };
                var objEditLogs = new ObservableCollection<EditLogInfo>() {
                    new EditLogInfo() { ID = "A001"},
                    new EditLogInfo() { ID = "A002"}
                };
                var objModel = new Model()
                {
                    ID = "abc",
                    Addressies = objAddressies,
                    EditLogs = objEditLogs
                };
                var objResult = objModel.Encode();

                //Assert
                Assert.IsTrue(XElement.DeepEquals(objDTO, objResult));

            }
        }
    }
}
