﻿using System;

namespace Infrastructure.Services.Binding
{
    public class DisposeAction : IDisposable
    {
        private Action _action;

        public DisposeAction(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action?.Invoke();
            _action = null;
        }
    }
}