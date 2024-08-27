using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;

using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;
using OzTool.SDK.Infra.Enigma.Utilities.Fakes;
using OzTool.SDK.Infra.Enigma.Extensions;

using UT.OzTool.SDK.Infra.Enigma._Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
                var nLikeCount = 100;
                var sAddress1 = $@"address1";
                var sAddress2 = $@"address2";
                var sEditLogInfoID1 = $@"A001";
                var sEditLogInfoID2 = $@"A002";
                var objAddressies = new List<string>() { sAddress1, sAddress2 };
                var objEditLogs = new ObservableCollection<EditLogInfo>() {
                    new EditLogInfo() { ID = sEditLogInfoID1},
                    new EditLogInfo() { ID = sEditLogInfoID2}
                };

                var objValueID = new XCData(sID);
                var objValueLikeCount = nLikeCount;
                var objAddressValue1 = new XCData(sAddress1);
                var objAddressValue2 = new XCData(sAddress2);
                var objValueEditLoginfo1ID = new XCData(sEditLogInfoID1);
                var objValueEditLoginfo2ID = new XCData(sEditLogInfoID2);
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
                var objResult = objDTO.Decode<Model>();

                //Assert                
                Assert.AreEqual(sID, objResult.ID);
                Assert.AreEqual(nLikeCount, objResult.LikeCount);
                CollectionAssert.AreEqual(objEditLogs, objResult.EditLogs);
                CollectionAssert.AreEquivalent(objAddressies, objResult.Addressies);
            }
        }
    }
}
