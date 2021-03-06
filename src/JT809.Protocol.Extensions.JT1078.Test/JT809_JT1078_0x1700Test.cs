﻿using JT809.Protocol.Extensions.JT1078.Enums;
using JT809.Protocol.Extensions.JT1078.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace JT809.Protocol.Extensions.JT1078.Test
{
    public class JT809_JT1078_0x1700Test
    {
        JT809Serializer JT809Serializer;
        public JT809_JT1078_0x1700Test()
        {
            IServiceCollection serviceDescriptors1 = new ServiceCollection();
            serviceDescriptors1
                            .AddJT809Configure()
                            .AddJT1078Configure();
            var ServiceProvider1 = serviceDescriptors1.BuildServiceProvider();
            var defaultConfig = ServiceProvider1.GetRequiredService<IJT809Config>();
             JT809Serializer = defaultConfig.GetSerializer();
        }



        [Fact]
        public void Test1()
        {
           var PlateFormIds = Enumerable.Range(0, 11).Select(s => (byte)s).ToArray();
           var AuthorizeCode1s = Enumerable.Range(0, 64).Select(s => (byte)s).ToArray();
           var  AuthorizeCode2s = Enumerable.Range(0, 64).Select(s => (byte)s).ToArray();

            JT809_JT1078_0x1700 jT809_JT1078_0x1700 = new JT809_JT1078_0x1700()
            {
                    VehicleNo="粤B12345",
                    VehicleColor= Protocol.Enums.JT809VehicleColorType.黄色,
                    SubBusinessType= (ushort)JT809_JT1078_SubBusinessType.时效口令上报消息, 
                    SubBodies=  new JT809_JT1078_0x1700_0x1701() {
                        PlateFormId= PlateFormIds,
                        AuthorizeCode1= AuthorizeCode1s,
                        AuthorizeCode2= AuthorizeCode2s
                    }
            };
            var hex = JT809Serializer.Serialize(jT809_JT1078_0x1700).ToHexString();
            Assert.Equal("D4C1423132333435000000000000000000000000000217010000008B000102030405060708090A000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F202122232425262728292A2B2C2D2E2F303132333435363738393A3B3C3D3E3F000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F202122232425262728292A2B2C2D2E2F303132333435363738393A3B3C3D3E3F", hex);
        }

        [Fact]
        public void Test2()
        {
            var PlateFormIds = Enumerable.Range(0, 11).Select(s => (byte)s).ToArray();
            var AuthorizeCode1s = Enumerable.Range(0, 64).Select(s => (byte)s).ToArray();
            var AuthorizeCode2s = Enumerable.Range(0, 64).Select(s => (byte)s).ToArray();
            var jT809_JT1078_0x1700 = JT809Serializer.Deserialize<JT809_JT1078_0x1700>("D4C1423132333435000000000000000000000000000217010000008B000102030405060708090A000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F202122232425262728292A2B2C2D2E2F303132333435363738393A3B3C3D3E3F000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F202122232425262728292A2B2C2D2E2F303132333435363738393A3B3C3D3E3F".ToHexBytes());
            Assert.Equal("粤B12345", jT809_JT1078_0x1700.VehicleNo);
            Assert.Equal(Protocol.Enums.JT809VehicleColorType.黄色, jT809_JT1078_0x1700.VehicleColor);
            Assert.Equal((ushort)JT809_JT1078_SubBusinessType.时效口令上报消息, jT809_JT1078_0x1700.SubBusinessType);
            var jT809_JT1078_0x1700_0x1701 = jT809_JT1078_0x1700.SubBodies as JT809_JT1078_0x1700_0x1701;
            Assert.Equal(PlateFormIds, jT809_JT1078_0x1700_0x1701.PlateFormId);
            Assert.Equal(AuthorizeCode1s, jT809_JT1078_0x1700_0x1701.AuthorizeCode1);
            Assert.Equal(AuthorizeCode2s, jT809_JT1078_0x1700_0x1701.AuthorizeCode2);
        }

        [Fact]
        public void Test3()
        {
            JT809_JT1078_0x1700 jT809_JT1078_0x1700 = new JT809_JT1078_0x1700()
            {
                VehicleNo = "粤B12345",
                VehicleColor = Protocol.Enums.JT809VehicleColorType.黄色,
                SubBusinessType = (ushort)JT809_JT1078_SubBusinessType.时效口令请求消息,
                SubBodies = new JT809_JT1078_0x1700_0x1702()
            };
            var hex = JT809Serializer.Serialize(jT809_JT1078_0x1700).ToHexString();
            Assert.Equal("D4C14231323334350000000000000000000000000002170200000000", hex);
        }

        [Fact]
        public void Test4()
        {
            var jT809_JT1078_0x1700 = JT809Serializer.Deserialize<JT809_JT1078_0x1700>("D4C14231323334350000000000000000000000000002170200000000".ToHexBytes());
            Assert.Equal("粤B12345", jT809_JT1078_0x1700.VehicleNo);
            Assert.Equal(Protocol.Enums.JT809VehicleColorType.黄色, jT809_JT1078_0x1700.VehicleColor);
            Assert.Equal((ushort)JT809_JT1078_SubBusinessType.时效口令请求消息, jT809_JT1078_0x1700.SubBusinessType);
        }
    }
}
