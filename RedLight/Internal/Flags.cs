using System.Runtime.CompilerServices;

namespace RedLight.Internal;

internal static class Flags
{
    public const MethodImplOptions HotPath = MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization;
}
