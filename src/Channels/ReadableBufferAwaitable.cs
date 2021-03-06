﻿using System;
using System.Runtime.CompilerServices;

namespace Channels
{
    /// <summary>
    /// An awaitable object that represents an asynchronous read operation
    /// </summary>
    public struct ReadableBufferAwaitable : ICriticalNotifyCompletion
    {
        private readonly IReadableBufferAwaiter _awaiter;

        public ReadableBufferAwaitable(IReadableBufferAwaiter awaiter)
        {
            _awaiter = awaiter;
        }

        public bool IsCompleted => _awaiter.IsCompleted;

        public ReadableBuffer GetResult() => _awaiter.GetBuffer();

        public ReadableBufferAwaitable GetAwaiter() => this;

        public void UnsafeOnCompleted(Action continuation) => _awaiter.OnCompleted(continuation);

        public void OnCompleted(Action continuation) => _awaiter.OnCompleted(continuation);
    }
}
