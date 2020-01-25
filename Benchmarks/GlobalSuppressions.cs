using System.Diagnostics.CodeAnalysis;

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: SuppressMessage("Major Bug", "S1764:Identical expressions should not be used on both sides of a binary operator", Justification = "We're benchmarking code")]
[assembly: SuppressMessage("Minor Code Smell", "S3626:Jump statements should not be redundant", Justification = "We're benchmarking code")]
[assembly: SuppressMessage("Major Bug", "S3923:All branches in a conditional structure should not have exactly the same implementation", Justification = "We're benchmarking code")]
[assembly: SuppressMessage("Redundancy", "RCS1134: Remove redundant statement", Justification = "We're benchmarking code")]
[assembly: SuppressMessage("Usage", "MA0006:use String.Equals", Justification = "We're benchmarking code.")]
[assembly: SuppressMessage("Blocker Code Smell", "S2178:Short-circuit logic should be used in boolean contexts", Justification = "We're benchmarking code.")]
[assembly: SuppressMessage("Usage", "RCS1233:Use short-circuiting operator.", Justification = "We're benchmarking code.")]
[assembly: SuppressMessage("Minor Vulnerability", "S1104:Fields should not have public accessibility", Justification = "We're benchmarking code.")]
