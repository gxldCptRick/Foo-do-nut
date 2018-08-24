using System.Collections.Generic;
using WikiData;

namespace DataAccessLib.services.interfaces
{
    public interface IWikiService
    {
        IEnumerable<WikiPage> GetAllPages();
        IEnumerable<WikiPage> GetSpecificPagesBasedOnString(string query);
    }
}