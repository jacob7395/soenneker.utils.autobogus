﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Soenneker.Utils.AutoBogus.Context;
using Soenneker.Utils.AutoBogus.Extensions;
using Soenneker.Utils.AutoBogus.Generators.Abstract;

namespace Soenneker.Utils.AutoBogus.Generators.Types.Immutables;

// ReSharper disable once InconsistentNaming
internal sealed class ImmutableArrayGenerator<TType> : IAutoFakerGenerator
{
    object IAutoFakerGenerator.Generate(AutoFakerContext context)
    {
        List<TType> items = context.GenerateMany<TType>();

        try
        {
            ImmutableArray<TType> array = [..items];
            return array;
        }
        catch (Exception)
        {
            return null!;
        }
    }
}