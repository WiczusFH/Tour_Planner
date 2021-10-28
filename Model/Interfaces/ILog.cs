﻿using System;

namespace Model
{
    public interface ILog
    {
        public string logTitle { get; set; }
        public string routeName { get; }
        public string dateString { get; }
        public float distance { get; }
        public string report { get; set; }
        public float duration { get; set; }
        public uint rating { get; set; }
        public float averageSpeed { get; set; }
        public float topSpeed { get; set; }
        public float calories { get; set; }
        public IDate date { get; set; }
        public ITour tour { get; set; }

    }
}
