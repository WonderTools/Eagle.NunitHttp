﻿using System;

namespace WonderTools.Eagle.Nunit
{
    public class TestEventListener : ITestEventListener
    {
        public void OnTestEvent(string report)
        {
            Console.WriteLine(report);
        }
    }
}