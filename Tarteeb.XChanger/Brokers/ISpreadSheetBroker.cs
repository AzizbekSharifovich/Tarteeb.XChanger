using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Brokers
{
    public interface ISpreadSheetBroker
    {
        List<ExternalApplicant> ReadExternalApplicants(MemoryStream stream);
    }
}
