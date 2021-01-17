﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Recuitment.Tests.Functions
{
    public class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();

        private NullScope() { }

        public void Dispose() { }
    }
}
