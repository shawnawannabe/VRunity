using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DirectionTest
    {

        [Test]
        public void StartPosition()
        {
            GameObject player;
            player = GameObject.Find("Player");
            Assert.AreEqual(new Vector3(-43, 1, -74), player.transform.position);
        }

     
    }
}
