using System;
using Hanssens.Net;

namespace BookStore.Models.Classes
{
    public static class Storage
    {
        private static readonly LocalStorage LocalStorage = new LocalStorage(new LocalStorageConfiguration
        {
            AutoLoad = true,
            AutoSave = true
        });

        public static LocalStorage GetLocalStorage(IServiceProvider serviceProvider) 
            => LocalStorage;
    }
}