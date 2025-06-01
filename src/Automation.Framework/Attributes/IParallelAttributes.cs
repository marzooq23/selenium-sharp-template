[assembly: LevelOfParallelism(4)]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Automation.Framework.Attributes;

internal interface IParallelAttributes;