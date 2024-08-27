﻿using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OzTool.SDK.Infra.Enigma;
using OzTool.SDK.Infra.Enigma.Extensions;
using OzTool.SDK.Infra.Enigma.Interfaces.Fakes;
using OzTool.SDK.Infra.Enigma.Utilities.Fakes;

using System;
using System.CodeDom;
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
                var objValueLikeCount = 100;
                var objCommand1Key = new XElement("Key", new XElement(typeof(int).Name, 1));
                var objCommand2Key = new XElement("Key", new XElement(typeof(int).Name, 2));
                var objStringCommand1Value = new XElement(typeof(string).Name, new XCData("des1"));
                var objStringCommand2Value = new XElement(typeof(string).Name, new XCData("des2"));
                var objCommand1Value = new XElement("Value", objStringCommand1Value);
                var objCommand2Value = new XElement("Value", objStringCommand2Value);
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
                var objAddressies = new List<string>() { "address1", "address2" };
                var objEditLogs = new ObservableCollection<EditLogInfo>() {
                    new EditLogInfo() { ID = "A001"},
                    new EditLogInfo() { ID = "A002"}
                };
                var objCommands = new Dictionary<int, string>()
                {
                    {1, "des1" },
                    {2, "des2" }
                };
                var objModel = new Model()
                {
                    ID = "abc",
                    LikeCount = 100,
                    Commands = objCommands,
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
