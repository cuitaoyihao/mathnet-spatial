﻿namespace Spatial.Roslyn.Tests
{
    using Gu.Roslyn.Asserts;
    using NUnit.Framework;
    using SpatialAnalyzers;

    public class AngleTests
    {
        // ReSharper disable once InconsistentNaming
        private static readonly ExpectedDiagnostic CS0618 = ExpectedDiagnostic.Create("CS0618");

        [Test]
        public void ReplaceCtorWithFromDegrees()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using MathNet.Spatial.Units;

    class Foo
    {
        public Foo()
        {
            var angle = new Angle(1.2, AngleUnit.Degrees);
        }
    }
}";
            var fixedCode = @"
namespace RoslynSandbox
{
    using MathNet.Spatial.Units;

    class Foo
    {
        public Foo()
        {
            var angle = Angle.FromDegrees(1.2);
        }
    }
}";
            AnalyzerAssert.CodeFix<UpdateCodeFix>(CS0618, testCode, fixedCode);
        }

        [Test]
        public void ReplaceCtorWithFromRadians()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using MathNet.Spatial.Units;

    class Foo
    {
        public Foo()
        {
            var angle = new Angle(1.2, AngleUnit.Radians);
        }
    }
}";
            var fixedCode = @"
namespace RoslynSandbox
{
    using MathNet.Spatial.Units;

    class Foo
    {
        public Foo()
        {
            var angle = Angle.FromRadians(1.2);
        }
    }
}";
            AnalyzerAssert.CodeFix<UpdateCodeFix>(CS0618, testCode, fixedCode);
        }

        [Test]
        public void ReplaceGenericFromWithFromDegrees()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using MathNet.Spatial.Units;

    class Foo
    {
        public Foo()
        {
            var angle = Angle.From(1.2, AngleUnit.Degrees);
        }
    }
}";
            var fixedCode = @"
namespace RoslynSandbox
{
    using MathNet.Spatial.Units;

    class Foo
    {
        public Foo()
        {
            var angle = Angle.FromDegrees(1.2);
        }
    }
}";
            AnalyzerAssert.CodeFix<UpdateCodeFix>(CS0618, testCode, fixedCode);
        }

        [Test]
        public void ReplaceGenericFromWithFromRadians()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using MathNet.Spatial.Units;

    class Foo
    {
        public Foo()
        {
            var angle = Angle.From(1.2, AngleUnit.Radians);
        }
    }
}";
            var fixedCode = @"
namespace RoslynSandbox
{
    using MathNet.Spatial.Units;

    class Foo
    {
        public Foo()
        {
            var angle = Angle.FromRadians(1.2);
        }
    }
}";
            AnalyzerAssert.CodeFix<UpdateCodeFix>(CS0618, testCode, fixedCode);
        }
    }
}