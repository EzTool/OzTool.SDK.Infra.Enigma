using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
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
                var objCommands = new Dictionary<int, string>()
                {
                    {1, "des1" },
                    {2, "des2" }
                };

                var objValueID = new XCData(sID);
                var objValueLikeCount = nLikeCount;
                var objAddressValue1 = new XCData(sAddress1);
                var objAddressValue2 = new XCData(sAddress2);
                var objValueEditLoginfo1ID = new XCData(sEditLogInfoID1);
                var objValueEditLoginfo2ID = new XCData(sEditLogInfoID2);

                var objCommand1Key = new XElement("Key", new XElement(typeof(int).Name, 1));
                var objCommand2Key = new XElement("Key", new XElement(typeof(int).Name, 2));
                var objStringCommand1Value = new XElement(typeof(string).Name, new XCData("des1"));
                var objStringCommand2Value = new XElement(typeof(string).Name, new XCData("des2"));
                var objCommand1Value = new XElement("Value", objStringCommand1Value);
                var objCommand2Value = new XElement("Value", objStringCommand2Value);               
                var objString = new XElement(typeof(string).Name, objValueID);
                var objInt32 = new XElement(typeof(int).Name, objValueLikeCount);
                var objStringEditLogInfo1ID = new XElement(typeof(string).Name, objValueEditLoginfo1ID);
                var objStringEditLogInfo2ID = new XElement(typeof(string).Name, objValueEditLoginfo2ID);
                var objAddress1 = new XElement(typeof(string).Name, objAddressValue1);
                var objAddress2 = new XElement(typeof(string).Name, objAddressValue2);
                var objListString = new XElement("List", objAddress1, objAddress2);
                var objEditLog1ID = new XElement("ID", objStringEditLogInfo1ID);
                var objEditLog2ID = new XElement("ID", objStringEditLogInfo2ID);
                var objCommand1 = new XElement("Package", objCommand1Key, objCommand1Value);
                var objCommand2 = new XElement("Package", objCommand2Key, objCommand2Value);
                var objEditLogInfo1 = new XElement("EditLogInfo", objEditLog1ID);
                var objEditLogInfo2 = new XElement("EditLogInfo", objEditLog2ID);
                var objDictCommands = new XElement("Dictionary", objCommand1, objCommand2);
                var objObserverCollection = new XElement("ObservableCollection", objEditLogInfo1, objEditLogInfo2);
                var objPropertyID = new XElement("ID", objString);
                var objPropertyCommands = new XElement("Commands", objDictCommands);
                var objPropertyLikeCount = new XElement("LikeCount", objInt32);
                var objPropertyAddressies = new XElement("Addressies", objListString);
                var objPropertyEditLogs = new XElement("EditLogs", objObserverCollection);
                var objDTO = new XElement("Model",
                    objPropertyID,
                    objPropertyLikeCount,
                    objPropertyCommands,
                    objPropertyAddressies,
                    objPropertyEditLogs);

                //Action
                var objResult = objDTO.Decode<Model>();

                //Assert                
                Assert.AreEqual(sID, objResult.ID);
                Assert.AreEqual(nLikeCount, objResult.LikeCount);
                CollectionAssert.AreEqual(objEditLogs, objResult.EditLogs);
                CollectionAssert.AreEquivalent(objAddressies, objResult.Addressies);
                CollectionAssert.AreEquivalent(objCommands, objResult.Commands);
            }
        }


        [TestMethod]
        public void E01_缺少參數ID時_轉出的屬性值為NULL()
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
                var objCommands = new Dictionary<int, string>()
                {
                    {1, "des1" },
                    {2, "des2" }
                };

                var objValueID = new XCData(sID);
                var objValueLikeCount = nLikeCount;
                var objAddressValue1 = new XCData(sAddress1);
                var objAddressValue2 = new XCData(sAddress2);
                var objValueEditLoginfo1ID = new XCData(sEditLogInfoID1);
                var objValueEditLoginfo2ID = new XCData(sEditLogInfoID2);

                var objCommand1Key = new XElement("Key", new XElement(typeof(int).Name, 1));
                var objCommand2Key = new XElement("Key", new XElement(typeof(int).Name, 2));
                var objStringCommand1Value = new XElement(typeof(string).Name, new XCData("des1"));
                var objStringCommand2Value = new XElement(typeof(string).Name, new XCData("des2"));
                var objCommand1Value = new XElement("Value", objStringCommand1Value);
                var objCommand2Value = new XElement("Value", objStringCommand2Value);
                var objString = new XElement(typeof(string).Name, objValueID);
                var objInt32 = new XElement(typeof(int).Name, objValueLikeCount);
                var objStringEditLogInfo1ID = new XElement(typeof(string).Name, objValueEditLoginfo1ID);
                var objStringEditLogInfo2ID = new XElement(typeof(string).Name, objValueEditLoginfo2ID);
                var objAddress1 = new XElement(typeof(string).Name, objAddressValue1);
                var objAddress2 = new XElement(typeof(string).Name, objAddressValue2);
                var objListString = new XElement("List", objAddress1, objAddress2);
                var objEditLog1ID = new XElement("ID", objStringEditLogInfo1ID);
                var objEditLog2ID = new XElement("ID", objStringEditLogInfo2ID);
                var objCommand1 = new XElement("Package", objCommand1Key, objCommand1Value);
                var objCommand2 = new XElement("Package", objCommand2Key, objCommand2Value);
                var objEditLogInfo1 = new XElement("EditLogInfo", objEditLog1ID);
                var objEditLogInfo2 = new XElement("EditLogInfo", objEditLog2ID);
                var objDictCommands = new XElement("Dictionary", objCommand1, objCommand2);
                var objObserverCollection = new XElement("ObservableCollection", objEditLogInfo1, objEditLogInfo2);
                var objPropertyID = new XElement("ID", objString);
                var objPropertyCommands = new XElement("Commands", objDictCommands);
                var objPropertyLikeCount = new XElement("LikeCount", objInt32);
                var objPropertyAddressies = new XElement("Addressies", objListString);
                var objPropertyEditLogs = new XElement("EditLogs", objObserverCollection);
                var objDTO = new XElement("Model",                    
                    objPropertyLikeCount,
                    objPropertyCommands,
                    objPropertyAddressies,
                    objPropertyEditLogs);

                //Action
                var objResult = objDTO.Decode<Model>();

                //Assert                
                Assert.IsNull(objResult.ID);
                Assert.AreEqual(nLikeCount, objResult.LikeCount);
                CollectionAssert.AreEqual(objEditLogs, objResult.EditLogs);
                CollectionAssert.AreEquivalent(objAddressies, objResult.Addressies);
                CollectionAssert.AreEquivalent(objCommands, objResult.Commands);
            }
        }
    }
}
