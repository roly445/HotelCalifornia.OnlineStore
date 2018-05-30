using System;
using System.Collections.Generic;
using ResultMonad;

namespace HotelCalifornia.OnlineStore.Infrastructure.DataProcessors
{
    public interface IPspProcessor
    {
        Result<Guid, PspError> ProcessResponse(dynamic pspResponseData);
        IDictionary<string, string> PrepData(string returnUrl);
    }
}