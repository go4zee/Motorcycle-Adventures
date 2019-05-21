using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorcycleAdventures.Core.TaskLibrary
{
    internal static class Operations
    {
        private static async Task<T> LongRunningOperationWithCancellationTokenAsync<T>(Task<T> task, CancellationToken cancellationToken)
        {
            // We create a TaskCompletionSource of decimal
            var taskCompletionSource = new TaskCompletionSource<T>();

            // Registering a lambda into the cancellationToken
            cancellationToken.Register(() =>
            {
                // We received a cancellation message, cancel the TaskCompletionSource.Task
                taskCompletionSource.TrySetCanceled();
            });


            // Wait for the first task to finish among the two
            var completedTask = await Task.WhenAny(task, taskCompletionSource.Task);

            // If the completed task is our long running operation we set its result.
            if (completedTask.GetType() == task.GetType())
            {
                // Extract the result, the task is finished and the await will return immediately
                var result = task;

                // Set the taskCompletionSource result
                taskCompletionSource.TrySetResult(result.Result);
            }

            // Return the result of the TaskCompletionSource.Task
            return await completedTask;
        }

    }
}
