﻿// <copyright file="IMegaImageInfo.cs" company="eVote">
//   Copyright © eVote
// </copyright>

using System;

namespace ProGaudi.MsgPack.Light.Tests.Generators
{
    public interface IMegaImageInfo : IImageInfo
    {
        [MsgPackMapElement("CreationDate")]
        DateTime SomeDate { get; }
    }
}