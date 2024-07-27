[assembly: LevelOfParallelism(4)]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SeleniumSharpTemplate.Utilities.Attributes
{
    internal interface IParallelAttributes;
}