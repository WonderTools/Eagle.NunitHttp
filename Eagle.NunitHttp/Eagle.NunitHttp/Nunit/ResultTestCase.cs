﻿using System;
using System.Collections.Generic;

namespace WonderTools.Eagle.NUnit
{
    public class ResultTestCase
    {
        public string FullName { get; set; }

        public string Result { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public double Duration { get; set; }

        public List<string> Logs { get; set; }

    }
}