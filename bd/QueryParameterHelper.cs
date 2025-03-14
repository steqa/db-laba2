namespace bd
{
    public class QueryParameterHelper
    {
        public static Dictionary<string, object> ParseFilters(string? filters)
        {
            var filters_ = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(filters))
            {
                foreach (var filterPart in filters.Split(','))
                {
                    var keyValue = filterPart.Split('=');
                    if (keyValue.Length == 2)
                    {
                        var key = keyValue[0].Trim().ToLower();
                        var value = keyValue[1].Trim().ToLower();
                        filters_.Add(key, value);
                    }
                }
            }

            return filters_;
        }

        public static Dictionary<string, bool> ParseSort(string? sort)
        {
            var sort_ = new Dictionary<string, bool>();

            if (!string.IsNullOrEmpty(sort))
            {
                foreach (var sortPart in sort.Split(','))
                {
                    var keyValue = sortPart.Split('=');
                    if (keyValue.Length == 2)
                    {
                        var key = keyValue[0].Trim().ToLower();
                        var value = keyValue[1].Trim().ToLower();
                        if (value == "asc")
                        {
                            sort_.Add(key, false);
                        }
                        else if (value == "desc")
                        {
                            sort_.Add(key, true);
                        }
                    }
                }
            }

            return sort_;
        }
    }
}
