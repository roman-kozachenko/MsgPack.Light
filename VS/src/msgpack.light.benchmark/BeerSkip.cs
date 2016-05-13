﻿using System.IO;

using BenchmarkDotNet.Attributes;

using MsgPack;
using MsgPack.Light;

namespace msgpack.light.benchmark
{
    [Config(typeof(BenchmarkConfig))]
    public class BeerSkip
    {
        private readonly MemoryStream _inputStream;

        private readonly MsgPackContext _msgPackContext;

        private readonly Unpacker _unpacker;

        public BeerSkip()
        {
            var serialize = new BeerSerializeBenchmark();
            _inputStream = PrepareMsgPack(serialize);

            _unpacker = Unpacker.Create(_inputStream);


            _msgPackContext = new MsgPackContext();
            _msgPackContext.RegisterConverter(new SkipConverter<Beer>());

        }

        private MemoryStream PrepareMsgPack(BeerSerializeBenchmark serializer)
        {
            var memoryStream = new MemoryStream();
            serializer.MsgPackSerialize(memoryStream);
            return memoryStream;
        }

        [Benchmark(Baseline = true)]
        public void MPackCli_Skip()
        {
            _inputStream.Position = 0;
            var result = _unpacker.Skip();
        }

        [Benchmark]
        public void MsgPackLight_Skip()
        {
            _inputStream.Position = 0;
            var beer = MsgPackSerializer.Deserialize<Beer>(_inputStream, _msgPackContext);
        }
    }
}