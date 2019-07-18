﻿using JT808.Protocol.Attributes;
using JT808.Protocol.Extensions.JT1078.Formatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.JT1078.MessageBody
{
    /// <summary>
    /// 云台雨刷控制
    /// </summary>
    [JT808Formatter(typeof(JT808_0x9304_Formatter))]
    public class JT808_0x9304 : JT808Bodies
    {
          /// <summary>
        /// 逻辑通道号
        /// </summary>
        public byte LogicChannelNo { get; set; }
        /// <summary>
        /// 启停标识
        /// </summary>
        public byte StartOrStop  { get; set; }
    }
}