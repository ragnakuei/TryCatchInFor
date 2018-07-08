using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;

namespace TryCatchInFor
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TestRunner>();
        }
    }

    [CoreJob] // 可以針對不同的 CLR 進行測試
    [MinColumn, MaxColumn]
    [MemoryDiagnoser]
    public class TestRunner
    {
        private readonly TestClass _test = new TestClass();

        public TestRunner()
        {
        }

        [Benchmark]
        public void ForWithTryCatch() => _test.ForWithTryCatch();

        [Benchmark]
        public void ForWithoutTryCatch() => _test.ForWithoutTryCatch();
    }

    public class TestClass
    {
        private readonly int _count = 100;

        public void ForWithTryCatch()
        {
            for (int i = 0; i < _count; i++)
            {
                try
                {
                    var x = 0;
                }
                catch (Exception e)
                {
                    
                }
            }
        }

        public void ForWithoutTryCatch()
        {
            for (int i = 0; i < _count; i++)
            {
                var x = 0;
            }
        }
    }
}
