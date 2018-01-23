﻿using System;

namespace Core.Infrastructure
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {

        }
    }
}
