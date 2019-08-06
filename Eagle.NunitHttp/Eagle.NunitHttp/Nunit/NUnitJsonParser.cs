using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using WonderTools.Eagle.Contract;
using WonderTools.Eagle.Nunit.NUnitDiscovery;
using WonderTools.Eagle.Nunit.NUnitResult;

namespace WonderTools.Eagle.Nunit
{
    public class NUnitJsonParser
    {
        public TestSuite GetTestSuiteFromDiscoveryJson(string json)
        {
            var root = JsonConvert.DeserializeObject<NUnitDiscoveryRoot>(json);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NUnitTestSuite, TestSuite>()
                    .ForMember(o => o.Id, b => b.MapFrom(z => z.Fullname.GetIdFromFullName()));
                cfg.CreateMap<NUnitTestCase, TestCase>()
                    .ForMember(o => o.Id, b => b.MapFrom(z => z.Fullname.GetIdFromFullName()));
            });

            return config.CreateMapper().Map<TestSuite>(root.TestRun.TestSuite);
        }

        public ResultTestSuite GetTestSuiteFromResultJson(string json)
        {
            var root = JsonConvert.DeserializeObject<NUnitResultRoot>(json);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NUnitResultTestSuite, ResultTestSuite>();
                cfg.CreateMap<NUnitResultTestCase, ResultTestCase>()
                    .ForMember(x => x.Logs, b => b.MapFrom(z => GetLogs(z.Output)));
            });

            return config.CreateMapper().Map<ResultTestSuite>(root.TestRun.TestSuite);
        }

        private List<string> GetLogs(StringHolder s)
        {
            if (s == null) return new List<string>();
            if (string.IsNullOrWhiteSpace(s.Data)) return new List<string>();
            var logs = s.Data;
            return logs.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}