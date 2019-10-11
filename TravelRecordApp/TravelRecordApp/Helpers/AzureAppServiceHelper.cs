#define OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TravelRecordApp.Helpers
{
    public class AzureAppServiceHelper
    {

        public static async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await App.MobileService.SyncContext.PushAsync();

                await App.PostsTable.PullAsync("userPosts", "");

            }
            catch (MobileServicePushFailedException msfpe)
            {
                if (msfpe.PushResult != null)
                    syncErrors = msfpe.PushResult.Errors;

            }
            catch (Exception e)
            {

            }

            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        await error.CancelAndDiscardItemAsync();
                    }
                }
            }
        }

    }
}
