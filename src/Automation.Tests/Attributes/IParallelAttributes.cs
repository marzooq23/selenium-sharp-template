[assembly: LevelOfParallelism(4)]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Automation.Tests.Attributes;

internal interface IParallelAttributes;