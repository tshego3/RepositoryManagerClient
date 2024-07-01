namespace repositorymanagerclient.Shared
{
    public static class RetryStrategy
    {
        public static void Do(Action action, TimeSpan retryInterval, int maxAttemptCount = Constants.MaxAttempts)
        {
            Do<object>(() => { action(); return default!; }, retryInterval, maxAttemptCount);
        }

        public static T Do<T>(Func<T> action, TimeSpan retryInterval, int maxAttemptCount = Constants.MaxAttempts)
        {
            var exceptions = new List<Exception>();

            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                try
                {
                    if (attempted > 0)
                    {
                        Thread.Sleep(retryInterval);
                    }
                    return action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            throw new AggregateException(exceptions);
        }

        public static Task DoAsync(Func<Task> action, TimeSpan retryInterval, int maxAttemptCount = Constants.MaxAttempts)
        {
            return DoAsync<object>(async () => { await action(); return default!; }, retryInterval, maxAttemptCount);
        }

        public static async Task<T> DoAsync<T>(Func<Task<T>> action, TimeSpan retryInterval, int maxAttemptCount = Constants.MaxAttempts)
        {
            var exceptions = new List<Exception>();

            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                try
                {
                    if (attempted > 0)
                    {
                        await Task.Delay(retryInterval);
                    }
                    return await action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            throw new AggregateException(exceptions);
        }
    }
}
