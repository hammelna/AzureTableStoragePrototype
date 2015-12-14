using Microsoft.WindowsAzure.Storage.Table;

namespace DataAccess
{
    public static class Util
    {
        /// <summary>
        /// Returns the table result casted to its type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static T ResultOrDefault<T>(this TableResult result)
        {
            if (result != null && result.Result != null)
            {
                return (T)result.Result;
            }

            return default(T);
        }
    }
}
