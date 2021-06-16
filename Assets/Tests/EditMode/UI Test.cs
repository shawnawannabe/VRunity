using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class UITest
    {
        
        [Test]
        public void ModeUI()
        {
            GameObject modeText;
            GameObject redAlertButton;
            GameObject chillButton;
            modeText = GameObject.Find("Mode Text");
            redAlertButton = GameObject.Find("Red Alert Button");
            chillButton = GameObject.Find("Chill Mode Button");
            Assert.AreEqual(true, modeText.active);
            Assert.AreEqual(true, redAlertButton.active);
            Assert.AreEqual(true, chillButton.active);

        }
    }
}
